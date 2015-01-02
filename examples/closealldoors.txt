void Main() 
{ 
    List<IMyTerminalBlock> doorBlocks = new List<IMyTerminalBlock>(); 
    GridTerminalSystem.GetBlocksOfType<IMyDoor>(doorBlocks); 
   
    int doorCount = doorBlocks.Count; 
 
    for(int i = 0; i < doorCount; i++) { 
        ITerminalAction closeDoors = doorBlocks[i].GetActionWithName("Open_Off"); 
        closeDoors.Apply(doorBlocks[i]); 
    } 
}