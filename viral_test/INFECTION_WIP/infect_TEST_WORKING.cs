bool renameEverything = true;
List<IMyTerminalBlock> fourtytwo = new List<IMyTerminalBlock>();
string payload = "aGVsbG8gd29ybGQh"; //test string - "hello world!"
public static string Base64Decode(string base64EncodedData) {
  var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
  return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
}
void Main(){
	fourtytwo.Clear();
	GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(fourtytwo);
	for(int i=0; i < fourtytwo.Count; i++){
		var block = fourtytwo[i];
		string ourPayload = Base64Decode(payload);
    	if(renameEverything)
    	{
      		block.SetCustomName(ourPayload);
  		}
	}
}