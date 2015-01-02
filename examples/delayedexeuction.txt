List<string> queue = new List<string>(); 
 
        bool firstRun = true; 
 
        void Main() 
        { 
            for (int i = 0; i < queue.Count; i++) 
            { 
                var item = queue[i]; 
                var parts = item.Split(','); 
 
                 
                if (DateTime.Now >= new DateTime(long.Parse(parts[0]))) 
                { 
                    queue.Remove(item); 
                     
                    switch(parts[1]) 
                    { 
                        case "SwitchLights": 
                            SwitchLights(); 
                            break; 
                    } 
 
                } 
            } 
 
            if (firstRun) 
            { 
                firstRun = false; 
                Delay(5, "SwitchLights"); 
            } 
 
             
        } 
 
        void SwitchLights() 
        { 
            var blocks = new List<IMyTerminalBlock>(); 
 
            GridTerminalSystem.GetBlocksOfType<IMyLightingBlock>(blocks); 
 
            for (int i = 0; i < blocks.Count; i++) 
            { 
                var light = (IMyLightingBlock)blocks[i]; 
 
                light.GetActionWithName("OnOff").Apply(light); 
            } 
 
            Delay(1, "SwitchLights"); 
        } 
 
        void Delay(int secods, string action) 
        { 
            this.queue.Add(DateTime.Now.AddSeconds(secods).Ticks.ToString() + "," + action); 
        }