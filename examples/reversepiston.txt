void Main()
{
    var piston = GridTerminalSystem.GetBlockWithName("DevPiston") as IMyPistonBase;

    var revAction = piston.GetActionWithName("Reverse");

    revAction.Apply(piston);
}