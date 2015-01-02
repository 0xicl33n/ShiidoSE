void Main()
{
    var turret1 = GridTerminalSystem.GetBlockWithName("turret1") as IMyLargeInteriorTurret;

    var revAction1 = turret1.GetActionWithName("OnOff_On");

    revAction1.Apply(turret1);
    
    var turret2 = GridTerminalSystem.GetBlockWithName("turret2") as IMyLargeInteriorTurret; 
 
    var revAction2 = turret2.GetActionWithName("OnOff_On"); 
 
    revAction2.Apply(turret2);

    var turret3 = GridTerminalSystem.GetBlockWithName("turret3") as IMyLargeInteriorTurret; 
 
    var revAction3 = turret3.GetActionWithName("OnOff_On"); 
 
    revAction3.Apply(turret3);

    var door = GridTerminalSystem.GetBlockWithName("door") as IMyDoor;

    var revAction5 = door.GetActionWithName("OnOff_Off");

    revAction5.Apply(door);

    var time2 = GridTerminalSystem.GetBlockWithName("time2") as IMyTimerBlock;  
  
    var revAction4 = time2.GetActionWithName("Start");  
  
    revAction4.Apply(time2);
}