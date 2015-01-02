string actionNameBase = "OnOff"; 
string actionName = "OnOff_On"; 
Random rnd = new Random(); 
List<IMyTerminalBlock> blocks = new List<IMyTerminalBlock>(); 
void Main() 
{ 
    blocks.Clear(); 
    GridTerminalSystem.GetBlocksOfType<IMyLightingBlock>(blocks); 
 
    bool allOn = true; 
    bool allOff = false; 
    for (int i =0; i < blocks.Count;++i) 
    { 
        allOff |= (blocks[i] as IMyFunctionalBlock).Enabled; 
        allOn &= (blocks[i] as IMyFunctionalBlock).Enabled; 
    } 
 
    if (!allOff) 
    { 
        actionName = actionNameBase+"_On"; 
    } 
    if (allOn) 
    { 
        actionName = actionNameBase +"_Off"; 
    } 
 
    for (int i =0; i < blocks.Count;++i) 
    {   
          test(blocks[i]);  
    }       
} 

void test(IMyTerminalBlock block)
{
        var actions = new List<ITerminalAction>();  
        block.GetActions(actions);  
  
        int value = rnd.Next(0, 10);  
        if (value < 5)  
        {  
            return;  
        }  
        for (int i =0; i < actions.Count;++i) 
        {  
            if (actions[i].Id == actionName)  
            {  
                actions[i].Apply(block);  
            }  
        }  
}
