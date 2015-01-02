//Space Engineers proof of concept virus for ships - version .5 - Codename Shi'ido
//by 0xicl33n
// You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

//lists of blocks stored here
List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock> ();
List<IMyTerminalBlock> reactors = new List<IMyTerminalBlock> ();
List<IMyTerminalBlock> cockpits = new List<IMyTerminalBlock>();
List<IMyTerminalBlock> gravgen = new List<IMyTerminalBlock>();
List<IMyTerminalBlock> turrets = new List<IMyTerminalBlock>();
//List<IMyTerminalBlock> pistons = new List<IMyTerminalBlock>(); Not working
void Main() {
	//clear previous list of blocks(?)
	reactors.Clear();
    batteries.Clear();
    turrets.Clear();
    gravgen.Clear();
	cockpits.Clear();
    //get list ofblocks were going to "play with"
    GridTerminalSystem.GetBlocksOfType<IMyLargeGatlingTurret>(turrets);
    GridTerminalSystem.GetBlocksOfType<IMyLargeMissileTurret>(turrets);
    GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock>(batteries);
    GridTerminalSystem.GetBlocksOfType<IMyReactor>(reactors);
    GridTerminalSystem.GetBlocksOfType<IMyCockpit>(cockpits);
    GridTerminalSystem.GetBlocksOfType<IMyGravityGenerator>(gravgen);
    // pistons not working
    //GridTerminalSystem.GetBlockWithName<IMyPistonBase>(pistons);
    
   //turrets off
   for(int i = 0; i < turrets.Count; i++){
   	turrets[i].GetActionWithName("OnOff_Off").Apply(turrets[i]);
   }
   //reverse pistsons - not working
   //for (int i = 0; i < pistons.count; i++){
   	//pistons[i].GetActionWithName("Reverse").Apply(pistons[i]);
   //}
  
   //one run test shit
   /*
   public static bool cockpitRayp;
   if cockpitRayp < 1 {
   	for(..)
	}
	else{
		break
	} 
	*/
   //cockpit attack
   int CockpitCount = cockpits.Count;
   for(int i = 0; i < CockpitCount; i++) {
        //turnoff thruster control on all cockpits
		if (!((IMyCockpit)cockpits[i]).ControlThrusters) break;
        ITerminalAction toggleThrusters = cockpits[i].GetActionWithName("ControlThrusters");
        toggleThrusters.Apply(cockpits[i]);
		//turnoff dampeners on all cockpits
		if (!((IMyCockpit)cockpits[i]).DampenersOverride) break;
		ITerminalAction toggleDampeners = cockpits[i].GetActionWithName("DampenersOverride");
		toggleDampeners.Apply(cockpits[i]);
        //cockpitRayp = 1;
    }
	//reverse gravity on all gravity generators ;)
	for (int i =0; i < gravgen.Count; i++){
		gravgen[i].GetActionWithName("DecreaseGravity").Apply(gravgen[i]);
		/*int x = 1;
		while(x < 1000){
			gravgen[i].GetActionWithName("DecreaseGravity").Apply(gravgen[i]);
			x++;
		}*/
	}
	//turn off gravity generators - if you want 
	/*
	for (int i=0; i < gravgen.count; i++){
		gravgen[i].GetActionWithName("OnOff_Off").Apply(gravgen[i]);
	}
*/
	//turn off power

	//batteries off
    for (int i = 0; i < batteries.Count; i++) {
    	batteries[i].GetActionWithName("OnOff_Off").Apply(batteries[i]);
    }
    //reactors off - if you want ;)
    /*
    for (int i = 0; i < reactors.Count; i++) {
    	reactors[i].GetActionWithName("OnOff").Apply(reactors[i]);
  }
*/

}