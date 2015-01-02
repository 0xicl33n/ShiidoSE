void Main()
{
    var ant = GridTerminalSystem.GetBlockWithName("Antenna") as IMyRadioAntenna;

    ant.SetCustomName("Hello World!");
}