using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BriefingGen
{
	internal class Program
	{
		public delegate void ArgumentHandler(List<string> args);

		static int CompareKVP(KeyValuePair<int, string> a, KeyValuePair<int, string> b) => a.Key - b.Key;

		static List<string> SortLines(List<KeyValuePair<int, string>> lines)
		{
			lines.Sort(CompareKVP);
			var ls = new List<string>();
			foreach(var line in lines)
				ls.Add(line.Value);
			return ls;
		}
		static string BuildName(string baseName, params string[] modes)
		{
			StringBuilder sb = new StringBuilder();
			for(int i = 0; i < modes.Length; i++)
			{
				if(i != 0)
					sb.Append(".");
				sb.Append(modes[i]);
			}
			return baseName.Replace("%MODES%", sb.ToString()).Replace("%MODES%", "");
		}

		static List<string> GetBriefingLines(KeyDataCollection section)
		{
			List<KeyValuePair<int, string>> lines = new List<KeyValuePair<int, string>>();
			foreach(var kmd in section)
			{
				if(int.TryParse(kmd.KeyName, out int index))
					lines.Add(new KeyValuePair<int, string>(index, kmd.Value));				
			}
			return SortLines(lines);
		}

		static string BuildBrifieng(params string[] lines)
		{
			List<string> ls = new List<string>();
			foreach(var line in lines)
				if(!string.IsNullOrWhiteSpace(line))
					ls.Add(line);

			StringBuilder sb = new StringBuilder();
			for(int i = 0; i < ls.Count; i++)
			{
				if(i != 0)
					sb.Append("@");
				sb.Append(ls[i]);
			}
			return sb.ToString();
		}

		static void Main(string[] a)
		{
			bool traceSection = false;
			bool traceOnlyName = false;

			List<string> args = new List<string>(a);
			var handlers = new Dictionary<string, ArgumentHandler>();
			/*handlers["-tr"] = (List<string> arguments) =>
			{
				traceSection = true;
				traceOnlyName = false;
			};
			handlers["-tron"] = (List<string> arguments) =>
			{
				traceSection = true;
				traceOnlyName = true;
			};*/

			int si = 0;
			foreach(var arg in args)
			{
				if(handlers.ContainsKey(arg))
				{
					handlers[arg](args);
					si++;
				}
			}

			if(args.Count < 3)
			{
				Console.WriteLine("format: BriefingGen %src file% %dest file% %brifings file% %base naming file%");
				return;
			}

			var parser = new FileIniDataParser();
			var mapData = parser.ReadFile(args[0]);
			var briefData = parser.ReadFile(args[2]);
			var namingData = parser.ReadFile(args[3]);

			var namings = new List<KeyValuePair<int, string>>();
			var briefings = new List<KeyValuePair<int, string>>();

			if(namingData.Sections.ContainsSection("Briefing"))
				briefings.Add(new KeyValuePair<int, string>(int.MaxValue, BuildBrifieng(GetBriefingLines(namingData.Sections["Briefing"]).ToArray())));

			foreach(var kvp in mapData["merger_trace_section"])
			{
				if(briefData.Sections.ContainsSection(kvp.KeyName))
				{
					int index = int.MaxValue;
					if(briefData[kvp.KeyName].ContainsKey("Index"))
						index = int.Parse(briefData[kvp.KeyName]["Index"]);
				
					briefings.Add(new KeyValuePair<int, string>(index, BuildBrifieng(GetBriefingLines(briefData.Sections[kvp.KeyName]).ToArray())));

					if(briefData[kvp.KeyName].ContainsKey("Name"))
						namings.Add(new KeyValuePair<int, string>(index, briefData[kvp.KeyName]["Name"]));
				}
			}

			IniData resultData = (IniData) mapData.Clone();
			resultData["Basic"]["Briefing"] = BuildBrifieng(SortLines(briefings).ToArray());
			resultData["Basic"]["Name"] = BuildName(mapData["Basic"]["Name"], SortLines(namings).ToArray());

			FileInfo rfi = new FileInfo(args[1]);
			string dumped = resultData.ToString();
			dumped = dumped.Replace(" = ", "=");
			//parser.WriteFile(rfi.FullName, resultData, System.Text.Encoding.UTF8);

			File.WriteAllText(rfi.FullName, dumped);
			Console.WriteLine($"Saved to {rfi.FullName}");
		}
	}
}
