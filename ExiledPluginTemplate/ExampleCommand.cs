// Usings
using CommandSystem;
using System;

namespace ExiledPluginTemplate
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))] // This command is a Remote Admin command
    public class ExampleCommand : ICommand // Tells Exiled that class is a Command
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) // Code to execute when the command is executed
        {
            // Example Code
            response = "Example Command Response";
            return true;
        }

        public string Description { get; } = "Example Command Description"; // Example Command Description
        public string Command { get; } = "example"; // Name of the command
        public string[] Aliases { get; } = new[] {"ex"}; // Aliases, is dont necessary to add aliases, if you want to add a aliases just put = null;
    }
}