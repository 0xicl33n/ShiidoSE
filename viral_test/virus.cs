//Space Engineers proof of concept virus for ships - version .1 - Codename Shi'ido
//by 0xicl33n
//

//lists of blocks stored here
List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock> ();
List<IMyTerminalBlock> reactors = new List<IMyTerminalBlock> ();
List<IMyTerminalBlock> cockpits = new List<IMyTerminalBlock>();
List<IMyTerminalBlock> gravgen = new List<IMyTerminalBlock>();
List<IMyTerminalBlock> turrets = new List<IMyTerminalBlock>();

void Main() {
	//clear previous list of blocks
	reactors.Clear();
    batteries.Clear();
    cockpits.Clear();
    turrets.Clear()
    gravgen.Clear();
    //get list ofblocks were going to "play with"
	GridTerminalSystem.GetBlocksOfType<IMyLargeGatlingTurret>(turrets);
	GridTerminalSystem.GetBlocksOfType<IMyLargeMissileTurret>(turrets);
    GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock>(batteries);
    GridTerminalSystem.GetBlocksOfType<IMyReactor>(reactors);
    GridTerminalSystem.GetBlocksOfType<IMyCockpit>(cockpits);
    GridTerminalSystem.GetBlocksOfType<IMyGravityGenerator>(gravgen);
   //turrets off
   for (int i = 0; i < turrets.Count; i++){
   	turrets[i].GetActionWithName("OnOff_Off").Apply(turrets[i]);
   }
   //cockpit attack
    int CockpitCount = cockpits.Count;
    for(int i = 0; i < CockpitCount; i++) {
    	//turnoff dampeners on all cockpits
        ITerminalAction toggleDampeners = cockpits[i].GetActionWithName("DampenersOverride");
        toggleDampeners.Apply(cockpits[i]);
        //turnoff thruster control on all cockpits
        ITerminalAction toggleThrusters = cockpits[i].GetActionWithName("ControlThrusters");
		toggleThrusters.Apply(cockpits[i]);
	}
	//reverse gravity on all gravity generators ;)
	for (int i =0; i < gravgen.count; i++){
		int x = 1;
		while(x < 100){
			gravgen[i].GetActionWithName("DecreaseGravity").Apply(gravgen[i]);
			x++;
		}
	}
	//turn off gravity generators
	//for (int i=0; i < gravgen.count; i++){
	//	gravgen[i].GetActionWithName("OnOff_Off").Apply(gravgen[i]);
	//}
	//turn off power

	//batteries off
    for (int i = 0; i < batteries.Count; i++) {
    	batteries[i].GetActionWithName("OnOff_Off").Apply(batteries[i]);
    }
    //reactors off
    //for (int i = 0; i < reactors.Count; i++) {
      // reactors[i].GetActionWithName("OnOff").Apply(reactors[i]);
  // }

}