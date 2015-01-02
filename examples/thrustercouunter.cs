//By MRH
void Main() 
{ 
    for (int i = 0; i < GridTerminalSystem.Blocks.Count; i++) 
    {     
        if(GridTerminalSystem.Blocks[i] is IMyThrust) 
        {     
                GridTerminalSystem.Blocks[i].SetCustomName("Thruster: "+i);
        } 
    } 
}