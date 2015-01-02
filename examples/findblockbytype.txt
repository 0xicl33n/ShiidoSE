    void Main() 
{
    /* We need to create a list to store all of the beacons on the grid. The "IMyTerminalBlock" in the angle brackets
    tells the script that we want to store that specific type of item, which in this case is a block accessible from the
    control panel. Here we create the list by specifying that "beaconBlocks" equals a new list. */

    List<IMyTerminalBlock> beaconBlocks = new List<IMyTerminalBlock>();

    /* Now that we have a list, we need to put things in it. Using the GetBlocksOfType method, we can specify that
    we want to find all blocks of the type "IMyBeacon" and store it in our list "beaconBlocks." You can find all the
    different block types in the Help guide. */

    GridTerminalSystem.GetBlocksOfType<IMyBeacon>(beaconBlocks);

    /* Now we use the Count method to find out how many beacons are in our list, and by extension, on the grid.
    We'll store this number in an integer "count." */

    int count = beaconBlocks.Count;

    /* Using a for loop and the "count" variable we just set, we will go through all the found beacons and give them
    a unique name. */

    	for(int i = 0; i < count; i++) {

        /* Here we tell the script that we want to set the beacon at position "i" in the list as "beacon." It is important
        that we specify what "beacon" is and make sure that the item in "beaconBlocks" is used as a block of the 
        same type. */

        IMyBeacon beacon = beaconBlocks[i] as IMyBeacon;

        /* We can use the variable "i" for more than just going through the beacons. The next line changes the name
        of the beacon we just picked from the list to "Found Beacon" plus the integer representing its location. Make
        sure that since we are setting a string that "i" is converted from an interger to a string using ".ToString()." */

        beacon.SetCustomName("Found Beacon " + i.ToString());
    }
}