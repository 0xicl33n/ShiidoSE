bool infector = true;
//payload is still being tested.
string payload = "aGVsbG8gd29ybGQh"; //test string
public static string Base64Decode(string base64EncodedData) {
  var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
  return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
}
List<IMyTerminalBlock> prog = new List<IMyTerminalBlock>();
void main(){
  prog.Clear();
  GridTerminalSystem.GetBlocksOfType<IMyFunctionalBlock>(prog);
  for(int i=0; i < prog.Count; i++){
    var block = prog[i];
    if(((IMyProgrammableBlock)block).IsRunning) break; //prevent infecting ourselves
    else {
      string ourPayload = Base64Decode(payload);
    // i hope this will be possible, so much!
    //writes payload to prog block

    //block.GetActionWithName("Write"(ourPayload)).Apply(block);

    //This is possible
    block.GetActionWithName("Run").Apply(block);
    }
  }
}