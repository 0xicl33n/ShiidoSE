 void Main()
{
    //create list to contain my cockpits
    List<IMyTerminalBlock> MyCockpit = new List<IMyTerminalBlock>();

    //get all cockpits
    GridTerminalSystem.GetBlocksOfType<IMyCockpit>(MyCockpit);

    //create list to contain sound blocks
    List<IMyTerminalBlock> Alarms = new List<IMyTerminalBlock>();

    //get all blocks named alarm
    GridTerminalSystem.SearchBlocksOfName("Alarm",Alarms);

    //number of cockpits found
    int CockpitCount = MyCockpit.Count;

    //get the number of Alarms
    int AlarmCount = Alarms.Count;

    //start with the first cockpit and go to the last, this way if ond is damaged then another picks up the slack
    for(int i = 0; i < CockpitCount; i++) {
        // check if the dampeners are on, if so do nothing 
        if (!(((IMyCockpit)MyCockpit[i]).DampenersOverride)) break;  

        //get the action to turn on/off the current block
        ITerminalAction toggleDampeners = MyCockpit[i].GetActionWithName("DampenersOverride");

        //turn on the dampeners
        toggleDampeners.Apply(MyCockpit[i]);
    }

    //start with the first Alarm and go to the last 
    for(int i = 0; i < AlarmCount; i++) { 
        //get the action to play the sound bolck
        ITerminalAction SoundAlarms = Alarms[i].GetActionWithName("PlaySound"); 

        //Sound the alarm 
        SoundAlarms.Apply(Alarms[i]); 
    }
}