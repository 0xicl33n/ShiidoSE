//Space Engineers proof of concept virus for ships - version .9 - Codename Shi'ido  
//by 0xicl33n  
// You should have received a copy of the GNU General Public License  
//along with this program.  If not, see <http://www.gnu.org/licenses/>.  
 
bool explodeEverything = true; //Change this if you don't want the warheads to explode automagically
int  detachDelay = 15; //Delay before the rotors detach
bool carriedByPayload = false; //Set it true if you are using a payload, then the virus won't attack until you detach
 
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
 
//lists of blocks stored here    
List<IMyTerminalBlock> fourtytwo = new List<IMyTerminalBlock>(); //Life, Universe, and Everything  
List<IMyTerminalBlock> cockpits = new List<IMyTerminalBlock>();
Random rnd = new Random(); //Needed for gyroscopes  
int cockpitCount = -1;
int detachTimer = 0;
void Main() {
  fourtytwo.Clear();
  GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(fourtytwo);
 
  bool rollDetachTimer = true;
 
  if(carriedByPayload)
  {
    cockpits.Clear();
    GridTerminalSystem.GetBlocksOfType<IMyShipController>(cockpits); //Remote control included, works with payload drones
    if(cockpitCount == -1)
    {
      cockpitCount = cockpits.Count;
    }
    if(cockpits.Count == cockpitCount)
    {
      return;
    }
  }
 
  for(int i=0; i < fourtytwo.Count; i++) //Iterate over everything
  {
    var block = fourtytwo[i]; //Make our life a little bit easier
   
    if(block is IMyRadioAntenna && messUpAntennas)
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //Turn antennas off, that's the best we can do right now
    }
   
    //Arc furnaces handled as production blocks
   
    //Artifical masses doesn't need any handling
   
    //Assemblers handled as production blocks
   
    if(block is IMyBatteryBlock && messUpBatteries)
    {
      block.GetActionWithName("OnOff_On").Apply(block);
      block.GetActionWithName("Recharge").Apply(block); //Switch recharging continuously, that's the best for keeping the power
    }
   
    if(block is IMyBeacon && messUpBeacons)
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //Turn beacons off, we don't need any help
    }
   
    if(block is IMyButtonPanel && messUpButtonPanels)
    {
      if(((IMyButtonPanel)block).AnyoneCanUse)
      {
        block.GetActionWithName("AnyoneCanUse").Apply(block); //Do everything we can
      }
    }
   
    if(block is IMyCameraBlock && messUpCameras)
    {
      block.GetActionWithName("OnOff_On").Apply(block);
      block.GetActionWithName("View").Apply(block); //I wonder what the heck will happen here
    }
   
    if(block is IMyShipController && messUpCockpits) //All cockpits and remotes - kill them all
    {
      var cockpit = block as IMyShipController;
      if(cockpit.ControlWheels)
      {
        cockpit.GetActionWithName("ControlWheels").Apply(cockpit);
      }
      if(!cockpit.ControlThrusters)
      {
        cockpit.GetActionWithName("ControlThrusters").Apply(cockpit);
      }
      if(cockpit.HandBrake)
      {
        cockpit.GetActionWithName("HandBrake").Apply(cockpit);
      }
      if(cockpit.DampenersOverride)
      {
        cockpit.GetActionWithName("DampenersOverride").Apply(cockpit);
      }
    }
   
    if(block is IMyCollector && messUpCollectors)
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //Do not accept any supplies
    }
   
    if(block is IMyShipConnector && messUpConnectors)
    {
      var connector = block as IMyShipConnector;
      connector.GetActionWithName("OnOff_On").Apply(connector);
      if(!connector.ThrowOut)
      {
        connector.GetActionWithName("ThrowOut").Apply(connector); //Throw out everything
      }
      if(!connector.CollectAll)
      {
        connector.GetActionWithName("CollectAll").Apply(connector); //From everywhere
      }
      if(connector.IsLocked)
      {
        //connector.GetActionWithName("SwitchLock").Apply(connector); //To nowhere
      }
    }
   
    //Control Panels doesn't have anything that could be handled right now
   
    if(block is IMyDoor && messUpDoors)
    {
      block.GetActionWithName("Open_Off").Apply(block); //Trap everybody
      if(!((IMyDoor)block).Open)
      {
        block.GetActionWithName("OnOff_Off").Apply(block); //Make doors unable to open as soon as they closed
      }
    }
   
    if(block is IMyShipDrill && messUpDrills)
    {
      block.GetActionWithName("OnOff_On").Apply(block); //We can never know what is in front of those blocks
    }
   
    if(block is IMyLargeTurretBase && messUpTurrets) //All turrets
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //We. Don't. Need. Defense.
    }
   
    if(block is IMyGravityGeneratorBase && messUpGravity)
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //Turn off gravity, it makes escaping the ship even more difficult
    }
   
    if(block is IMyShipGrinder && messUpGrinders)
    {
      block.GetActionWithName("OnOff_On").Apply(block); //Chainsaw lol
    }
   
    if(block is IMyGyro && messUpGyros)
    {
      var gyro = block as IMyGyro;
      gyro.GetActionWithName("OnOff_On").Apply(gyro);
      if(!gyro.GyroOverride)
      {
        gyro.GetActionWithName("Override").Apply(gyro);
      }
      gyro.GetActionWithName("IncreasePower").Apply(gyro);
      if(rnd.NextDouble() > 0.5f) //Okay, now mess them up
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
   
    if(block is IMyLightingBlock && messUpLights)
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //Turn off the lights...
    }
   
    if(block is IMyLandingGear && messUpLandingGears)
    {
      block.GetActionWithName("OnOff_On").Apply(block);
      block.GetActionWithName("Unlock").Apply(block);
    }
   
    //Cargo containers has no interface
   
    if(block is IMyReactor && messUpReactors)
    {
      block.GetActionWithName("OnOff_On").Apply(block); //Run them as long as there is enough uranium
    }
   
    if(block is IMyMedicalRoom && messUpMedicalRooms)
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //Don't respawn, that's not funny
    }
   
    if(block is IMyShipMergeBlock && messUpMergeBlocks)
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //If it was a modular ship... well, it was
    }
   
    if(block is IMyOreDetector && messUpOreDetectors)
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //Just turn them off, cuz why not? If it makes mess it's welcome...
    }
   
    if(block is IMyPistonBase && messUpPistons)
    {
      block.GetActionWithName("OnOff_On").Apply(block);
      if(((IMyPistonBase)block).Velocity<0)
      {
        block.GetActionWithName("Reverse").Apply(block); //Reverse them if they're open
      }
      block.GetActionWithName("IncreaseVelocity").Apply(block); //Faster is better
      block.GetActionWithName("IncreaseUpperLimit").Apply(block); //Break everything or at least remain closed
    }
   
    //Don't do anything with timers or programmable blocks. They can either be ours or contain antivirus software. Handle them as soon as we get a better API.
   
    if((block is IMySmallMissileLauncher || block is IMySmallMissileLauncherReload) && messUpMissileLaunchers)
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //Offense should also be turned off like defense
    }
   
    if(block is IMyMotorStator && messUpRotors)
    {
      block.GetActionWithName("OnOff_On").Apply(block);
      var rotor = block as IMyMotorStator;
      if(rotor.Velocity<0)
      {
        rotor.GetActionWithName("Reverse").Apply(rotor); //Reverse if speed is negative
      }
     
      //Speed it up
      rotor.GetActionWithName("IncreaseTorque").Apply(rotor);
      rotor.GetActionWithName("DecreaseBrakingTorque").Apply(rotor);
      rotor.GetActionWithName("IncreaseVelocity").Apply(rotor);
      rotor.GetActionWithName("IncreaseUpperLimit").Apply(rotor);
      rotor.GetActionWithName("DecreaseLowerLimit").Apply(rotor);
     
      if(rotor.Velocity>25)
      {
        if(rollDetachTimer)
        {
          detachTimer++;
          rollDetachTimer = false;
        }
        if(detachTimer>detachDelay)
        {
          rotor.GetActionWithName("Detach").Apply(rotor); //Detach as soon as it's fast enough
        }
      }
    }
   
    if(block is IMySensorBlock && messUpSensors)
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //We don't know what it does, better just turn it off
    }
   
    if(block is IMySoundBlock && messUpSoundBlocks) //Wanna play a game?
    {
      block.GetActionWithName("OnOff_On").Apply(block);
      block.GetActionWithName("IncreaseVolumeSlider").Apply(block);
      block.GetActionWithName("IncreaseRangeSlider").Apply(block);
      block.GetActionWithName("IncreaseLoopableSlider").Apply(block);
      block.GetActionWithName("PlaySound").Apply(block);
    }
   
    if(block is IMyWarhead && explodeEverything) //Incoming funny stuff
    {
      block.GetActionWithName("Safety").Apply(block); //If it turns on safety for the first try it will turn it off second and everything will explode in one sec
      block.GetActionWithName("Detonate").Apply(block);
    }
   
    if(block is IMyShipWelder && messUpWelders)
    {
      block.GetActionWithName("OnOff_Off").Apply(block); //Beware, there can be self-repairing stuff
    }
   
    if(block is IMyMotorSuspension && messUpWheels) //Turn off the wheels
    {
      var wheel = block as IMyMotorSuspension;
      wheel.GetActionWithName("OnOff_Off").Apply(wheel);
      if(wheel.Steering)
      {
        wheel.GetActionWithName("Steering").Apply(wheel);
      }
      if(wheel.Propulsion)
      {
        wheel.GetActionWithName("Propulsion").Apply(wheel);
      }
      wheel.GetActionWithName("DecreaseDamping").Apply(wheel);
      wheel.GetActionWithName("DecreaseStrength").Apply(wheel);
      wheel.GetActionWithName("DecreaseFriction").Apply(wheel);
      wheel.GetActionWithName("DecreasePower").Apply(wheel);
    }
   
    //Other things
   
    if(block is IMyProductionBlock && renameEverything) //We need EVERYTHING to use conveyor system
    {
      block.GetActionWithName("OnOff_On").Apply(block);
      if(!((IMyProductionBlock)block).UseConveyorSystem)
      {
        block.GetActionWithName("UseConveyor").Apply(block);
      }
    }
   
    if(renameEverything)
    {
      block.SetCustomName(""); //The second evilest thing I can imagine. The first is C#...
    }
   
    if(block is IMyThrust && messUpThrusters)
    {
      block.GetActionWithName("OnOff_On").Apply(block);
      block.GetActionWithName("IncreaseOverride").Apply(block);
    }
  }
}