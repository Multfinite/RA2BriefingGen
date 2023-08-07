### How to use

Syntax:
> BriefingGen (source map file) (target map file) (briefings file) (map namings file)
> Source map file must include [merger_trace_section] with pair %patch file name%=%patch file name%, use INIMerger with **-tron** flag.

#### Briefings file

It is INI file.

> Section is a file with a patch. Plase, visit https://github.com/Multfinite/RA2YRPatchCollection to example.
> Index parameter determines sorting order
> Name - addition to map name. Map name MUST include %MODES% placeholder. For example, you have names: NP (Index = 1), RA2 (Index = 0), it will be appliaed as RA2.NP to map name.
> 0 .. N - briefing text.

An example:

> [buff_paradrop.ini]
> Index=4
> 0=-Paradrops was extended: with GGIs for Alliance, with Tesla Trooper and Flak Trooper for Soviets, with Yuri Clone for Yuri
> 
> [buff_tesla_coil.ini]
> Index=4
> 0=-Tesla Coil CHARGED distance extended (8 -> 10)
> 
> [buff_v3.ini]
> Index=4
> 0=-V3 distance extended (18 -> 21)
> 
> [edit_ext_occupy.ini]
> Index=2
> 0=-Now GGI (MissileLauncher), Tesla Trooper, Flak Trooper (AA+Ground) can occupy buildings
> 
> [edit_fleet_patch.ini]
> Index=2
> Name=FP
> 0=-Only attackers can produce fleet and only AA and Artillery
> 
> [edit_invisible_amphibious_terror_drone.ini]
> Index=2
> 0=-Terror drone are invisible and can walk on the ground
> 
> [edit_lax_carrier.ini]
> Index=1
> 0=-Tower near LAX will call aircraft strike
> 
> [edit_outpust_allow_mcv_conopt.ini]
> Index=1
> 0=-Civilian Outpost grant access to side MCV (like repair depo)
> 
> [edit_transport_via_factory.ini]
> Index=1
> 0=-Amphibious transport can be produced via war factory
> 
> [fix_bfrt.ini]
> Index=2
> 0=-Battle Fortress nerf included
> 
> [fix_grand_cannon.ini]
> Index=2
> 0=-Grand cannon fix: now it require WHOLE alliance powerplant
> 
> [fix_siege_chopper.ini]
> Index=2
> 0=-Siege chopper distance, damage, rate of fire changes (nerf) and minimum range of 2
> 
> [mode_ra2.ini]
> Index=0
> Name=RA2
> 0=(!) RA2 Mode: RA2 units & buildings (Yuri is Soviet). 
> 1=-------------------------
> 2=All YR civilian building avaliable. YURI is soviet with Yuri Prime special.
> 3=-------------------------
> 
> [mode_ra2plus.ini]
> Index=0
> Name=RA2PLUS
> 0=(!) RA2+ Mode: RA2 units & buildings + alliance and soviet units from YR (Yuri is Soviet) + some yuri units distributed via sides.
> 1=-------------------------
> 2=All YR civilian building avaliable. YURI is soviet with Yuri Prime special.
> 3=All YR units and buildings avaliable, except: Industrial Plant.
> 4=Brute is alliance feature.
> 5=Chaos drone is soviet feature.
> 6=-------------------------
> 
> [mode_ra2plus_no_factions.ini]
> Index=0
> Name=RA2PLUS_NF
> 0=(!) RA2+ NO FACTIONS Mode: RA2 units & buildings + all new features from YR related to balance + some yuri units distributed via sides + countries have access to all special units of its own side.

#### Map namings file

Use [Briefing] section to make an map briefing which will be placed an a top of generated text.

An example:

> [Briefing]
> 0=Invasion: the attackers must defeat the defenders before timer has ended (Current: 20 minutes at 60 FPS).
> 1=-Each team must protect their control point or will lose (Parliament for attackers, Eiffel Tower for defenders). Technicians have C4.
> 5=(!) Map includes its own balance changes: buffs, nerfs and fixes. Map exists in several versions.
> 10=---------SOVIETS (DEFENCE, 5678)---------
> 11=Greetings, comrade! The liberation of workers of Europe is rapidly advancing. This circumstance compels the capitalists to act. European united forces want to strike back at us and will try to land in Normandy and counter-attack.
> 13=Comrade, the Politbureau entrusts you with the honorable task of repelling the bourgeois invasion and fulfilling your internationalist duty.
> 14=Good luck, Comrade!
> 20=------ALLIES (ATTACKERS, 1234)--------
> 21=The Soviet invasion of Europe was successful. All of Europe is occupied and the British Isles are the last bastion of the civilized world.
> 23=Commander, you and your ñolleagues must land in Normandy and after regain Paris and adjacent territories.
> 24=Note: your colleague at forefront (1) needs you.
> 25=Good luck, commander!
> 30=-------------------------------------------
