//Space Engineers proof of concept virus for ships - version .1 - Codename Shi'ido
List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock> ();
List<IMyTerminalBlock> reactors = new List<IMyTerminalBlock> ();
List<IMyTerminalBlock> cockpits = new List<IMyTerminalBlock>();

void Main() {
	reactors.Clear();
    batteries.Clear();

    GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock>(batteries);
    GridTerminalSystem.GetBlocksOfType<IMyReactor>(reactors); 
    //batteries off
    for (int i = 0; i < batteries.Count; i++) {
    	batteries[i].GetActionWithName("OnOff").Apply(batteries[i]);
    //reactors off
    for (int i = 0; i < reactors.Count; i++) {
       reactors[i].GetActionWithName("OnOff").Apply(reactors[i]);
   }
   //cockpits
    GridTerminalSystem.GetBlocksOfType<Icockpits>(cockpits);
    int CockpitCount = cockpits.Count;
    int AlarmCount = Alarms.Count;
    for(int i = 0; i < CockpitCount; i++) {
    	//turnoff dampeners on all cockpits
        ITerminalAction toggleDampeners = cockpits[i].GetActionWithName("DampenersOverride");
        toggleDampeners.Apply(cockpits[i]);
        //turnoff thruster control on all cockpits
        ITerminalAction toggleThrusters = cockpits[i].GetActionWithName("ControlThrusters");
		toggleThrusters.Apply(cockpits[i]);
    }
}