string actionNameBase = "OnOff"; 
string actionName = "OnOff_On"; 
Random rnd = new Random(); 
List<IMyTerminalBlock> blocks = new List<IMyTerminalBlock>(); 
void Main() 
{ 
    blocks.Clear(); 
    GridTerminalSystem.GetBlocksOfType<IMyThrust>(blocks); 
 
    for(int i = 0; i < blocks.Count; i++)
    { 
          var block = blocks[i];
          if(rnd.NextDouble() > 0.5f)
          {
                block.GetActionWithName(actionNameBase).Apply(block);
          }
    }       
} 
