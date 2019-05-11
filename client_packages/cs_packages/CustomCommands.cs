using System;
using System.Collections.Generic;
using System.Linq;

namespace robearded
{
    public class CustomCommands : RAGE.Events.Script
    {
        private HashSet<string> registeredCommands = new HashSet<string>();
		
        public CustomCommands()
        {
            RAGE.Events.OnPlayerCommand += PlayerCommand;
            RAGE.Events.Add("registerCustomCommand", RegisterCommand);
            RAGE.Events.CallRemote("playerReady");
        }

        private void PlayerCommand(string cmd, RAGE.Events.CancelEventArgs cancel)
        {
            string[] arr = cmd.Split(" ");
            if (!registeredCommands.Contains(arr[0]))
                return;
            string args = String.Join(" ", arr.Skip(1).ToArray());
            RAGE.Events.CallRemote("sendCustomCommand", arr[0], args);
            cancel.Cancel = true;
        }

        private void RegisterCommand(object[] args)
        {
            if (args.Length != 2) return;
            string cmd = (string) args[0];
            bool register = (bool)args[1];
            if (register)
            {
                if (registeredCommands.Contains(cmd)) return;
                registeredCommands.Add(cmd);
            }
            else
            {
                if (registeredCommands.Contains(cmd))
                    registeredCommands.Remove(cmd);
            }
        }
    }
}
