List<IMyTerminalBlock> gravgen = new List<IMyTerminalBlock>();
void main{
	GridTerminalSystem.GetBlocksOfType<IMyGravityGenerator>(gravgen);
		//reverse gravity on all gravity generators ;)
	for (int i =0; i < gravgen.count; i++){
		int x = 1;
		while(x < 100){
			gravgen[i].GetActionWithName("DecreaseGravity").Apply(gravgen[i]);
			x++;
		}
	}
}