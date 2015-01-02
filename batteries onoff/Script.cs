    List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock> ();

void Main() {

    batteries.Clear();

    GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock>(batteries);    

    for (int i = 0; i < batteries.Count; i++) {
       batteries[i].GetActionWithName("OnOff").Apply(batteries[i]);
    }
}