//Space Engineers proof of concept virus for ships - version 1.0 - Codename Shi'ido  
//by 0xicl33n  
// You should have received a copy of the GNU General Public License  
//along with this program.  If not, see <http://www.gnu.org/licenses/>.  
 
bool explodeEverything = true; //Change this if you don't want the warheads to explode automagically
int  detachDelay = 15; //Delay before the rotors detach
bool carriedByPayload = false; //Set it true if you are using a payload, then the virus won't attack until you detach
bool infector = true; //Preparing for infection capabilities
//Bools are here
bool messUpAntennas = true;
bool messUpBatteries = true;
bool messUpBeacons = true;
bool messUpButtonPanels = true;
bool messUpCameras = true;
bool messUpCockpits = true;
bool messUpCollectors = true;
bool messUpConnectors = true;
bool messUpDoors = true;
bool messUpDrills = true;
bool messUpTurrets = true;
bool messUpGravity = true;
bool messUpGrinders = true;
bool messUpGyros = true;
bool messUpLights = true;
bool messUpLandingGears = true;
bool messUpReactors = true;
bool messUpThrusters = true;
bool messUpMedicalRooms = true;
bool messUpMergeBlocks = true;
bool messUpOreDetectors = true;
bool messUpPistons = true;
bool messUpMissileLaunchers = true;
bool messUpRotors = true;
bool messUpSensors = true;
bool messUpSoundBlocks = true;
bool messUpWelders = true;
bool messUpWheels = true;

 
bool throwOutEverything = true;
bool renameEverything = true;
List<IMyTerminalBlock> fourtytwo = new List<IMyTerminalBlock>(); //Life, Universe, and Everything  
List<IMyTerminalBlock> prog = new List<IMyTerminalBlock>();
List<IMyTerminalBlock> cockpits = new List<IMyTerminalBlock>();
Random rnd = new Random(); //Needed for gyroscopes  
int cockpitCount = -1;
int detachTimer = 0;

//
void infect(block){
    if(block == prog && block.isRunning) break; //prevent from infecting ourselves
    //INFECTION CODE!

}
//



void Main() {
  fourtytwo.Clear();
  GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(fourtytwo);
if(carriedByPayload/* && infector*/)
  {
    cockpits.Clear();
    //prog.Clear();
    GridTerminalSystem.GetBlocksOfType<IMyShipController>(cockpits);
    //GridTerminalSystem.GetBlocksOfType<IMyProgrammableBlock>(prog);
    if(cockpitCount == -1 /*&& progcount == -1*/)
    {
      progcount = prog.Count;
      //cockpitCount = cockpits.Count;
    }
    if(/*prog.Count == progcount && */cockpits.Count == cockpitCount)
    {
      return;
    }
  }
}

//Rest of virus