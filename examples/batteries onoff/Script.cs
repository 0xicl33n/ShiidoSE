List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock> ();
List<IMyTerminalBlock> reactors = new List<IMyTerminalBlock> ();

void Main() {
	reactors.Clear();
    batteries.Clear();

    GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock>(batteries);
    GridTerminalSystem.GetBlocksOfType<IMyReactor>(reactors); 
    
    //for (int i = 0; i < batteries.Count; i++) {
    	//batteries[i].GetActionWithName("OnOff").Apply(batteries[i]);

    for (int i = 0; i < reactors.Count; i++) {
       batteries[i].GetActionWithName("OnOff").Apply(reactors[i]);

    }
}