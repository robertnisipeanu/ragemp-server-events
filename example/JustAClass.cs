using System;
using GTANetworkAPI;
using robearded;

namespace AnyNamespace;
{
    public class JustAClass
    {
        public JustAClass()
        {
            Events.AddCommand("cmd1", Command1);
            Events.AddCommand("cmd2", Command2);
            Events.OnPlayerConnected += PlayerConnected;
        }

        private void PlayerConnected(Client client)
        {
            Console.WriteLine($"Player {client.Name} connected!");
        }

        private void Command1(Client client, string cmd, string arg)
        {
            client.SendChatMessage("Nice try!");
        }

        private void Command2(Client client, string cmd, string arg)
        {
            client.SendChatMessage($"Oooh, you're learning new commands. You run command `{cmd}` with args `{arg}`");
        }
    }
}
