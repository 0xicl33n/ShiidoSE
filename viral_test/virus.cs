//Space Engineers proof of concept virus for ships - version .6 - Codename Shi'ido  
//by 0xicl33n  
// You should have received a copy of the GNU General Public License  
//along with this program.  If not, see <http://www.gnu.org/licenses/>.  
   
//Paste here the name of block to enable recursion  
string name="TotallyNotAVirus";  
   
//lists of blocks stored here  
List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock> ();  
List<IMyTerminalBlock> reactors = new List<IMyTerminalBlock> ();  
List<IMyTerminalBlock> cockpits = new List<IMyTerminalBlock>();  
List<IMyTerminalBlock> gravgen = new List<IMyTerminalBlock>();  
List<IMyTerminalBlock> turrets = new List<IMyTerminalBlock>();  
List<IMyTerminalBlock> pistons = new List<IMyTerminalBlock>();    
List<IMyTerminalBlock> fourtytwo = new List<IMyTerminalBlock>(); //Life, Universe, and Everything  
List<IMyTerminalBlock> gyroscopes = new List<IMyTerminalBlock>();  
List<IMyBlockGroup> groups = new List<IMyBlockGroup>();    
List<IMyTerminalBlock> thrusters = new List<IMyTerminalBlock>();    
Random rnd = new Random(); //Needed for gyroscopes  
void Main() {  
        //clear previous list of blocks(?)  
        reactors.Clear();  
    batteries.Clear();  
    turrets.Clear();  
    gravgen.Clear();  
        cockpits.Clear();  
pistons.Clear();  
fourtytwo.Clear();  
gyroscopes.Clear();      
groups.Clear();  
    //get list ofblocks were going to "play with"  
    GridTerminalSystem.GetBlocksOfType<IMyLargeGatlingTurret>(turrets);  
    GridTerminalSystem.GetBlocksOfType<IMyLargeMissileTurret>(turrets);  
    GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock>(batteries);  
    GridTerminalSystem.GetBlocksOfType<IMyReactor>(reactors);  
    GridTerminalSystem.GetBlocksOfType<IMyCockpit>(cockpits);  
    GridTerminalSystem.GetBlocksOfType<IMyGravityGenerator>(gravgen);  
    GridTerminalSystem.GetBlocksOfType<IMyPistonBase>(pistons);    
    GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(fourtytwo);    
    GridTerminalSystem.GetBlocksOfType<IMyGyro>(gyroscopes);  
    GridTerminalSystem.GetBlocksOfType<IMyThrust>(thrusters);          
    groups=GridTerminalSystem.BlockGroups;  
       
   //turrets off  
   for(int i = 0; i < turrets.Count; i++){  
        turrets[i].GetActionWithName("OnOff_Off").Apply(turrets[i]);  
   }  
   //reverse pistsons  
   for (int i = 0; i < pistons.Count; i++){  
            pistons[i].GetActionWithName("Reverse").Apply(pistons[i]);  
   }  
     
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
        /*for (int i =0; i < gravgen.Count; i++){  
            for(int j = 0; j < 20; j++){  
                                gravgen[i].GetActionWithName("DecreaseGravity").Apply(gravgen[i]);  
                    }  
        } */
        //turn off gravity generators - if you want    
   
        for (int i=0; i < gravgen.Count; i++){  
                gravgen[i].GetActionWithName("OnOff_Off").Apply(gravgen[i]);  
        }  
   
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
   
 //Delete all names  
 for(int i=0; i < fourtytwo.Count; i++) {  
    fourtytwo[i].SetCustomName("");  
 }  
   
 //Mess up the gyroscopes  
 for(int i=0; i < gyroscopes.Count; i++) {  
    var gyro = gyroscopes[i] as IMyGyro;  
    if(!gyro.GyroOverride)  
    {  
        gyro.GetActionWithName("Override").Apply(gyro);  
    }  
    gyro.GetActionWithName("IncreasePower").Apply(gyro);  
    if(rnd.NextDouble() > 0.5f)  
    {  
      gyro.GetActionWithName("IncreaseYaw").Apply(gyro);  
    }  
    else  
    {  
      gyro.GetActionWithName("DecreaseYaw").Apply(gyro);  
    }  
    if(rnd.NextDouble() > 0.5f)  
    {  
      gyro.GetActionWithName("IncreasePitch").Apply(gyro);  
    }  
    else  
    {  
      gyro.GetActionWithName("DecreasePitch").Apply(gyro);  
    }  
    if(rnd.NextDouble() > 0.5f)  
    {  
      gyro.GetActionWithName("IncreaseRoll").Apply(gyro);  
    }  
    else  
    {  
      gyro.GetActionWithName("DecreaseRoll").Apply(gyro);  
    }  
  }  
   
  //Turn on ALL thrusters, melt everything, and absolutely lose control
  for(int i=0; i< thrusters.Count; i++)
  {  
    thrusters[i].GetActionWithName("OnOff_On").Apply(thrusters[i]);
    thrusters[i].GetActionWithName("IncreaseOverride").Apply(thrusters[i]);
  }
 
  //Mess up groupping  
  for(int i=0; i < groups.Count; i++)  
  {  
    //TODO //Sorry, impossible
  }  
}