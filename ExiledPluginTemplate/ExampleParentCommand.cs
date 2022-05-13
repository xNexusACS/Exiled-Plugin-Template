// Usings
using System;
using CommandSystem;
using Exiled.Permissions.Extensions; // Use this if you want to add perms

namespace ExiledPluginTemplate
{
    [CommandHandler(typeof(GameConsoleCommandHandler))] // This command is a Game Console command
    public class ExampleParentCommand : ParentCommand // Tells Exiled that is a Parent Command
    {
        public ExampleParentCommand() => LoadGeneratedCommands(); // Use this to load commands for the parent command
        public override string Command { get; } = "exampleparentcommand"; // Name of the Parent command
        public override string[] Aliases { get; } = { "expc" }; // Aliases, is dont necessary to add aliases, if you want to add a aliases just put = null;
        public override string Description { get; } = "Example Parent Command Description"; // Example Parent Command Description

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response) // Code to execute when the Parent Command is executed
        {
            if (!sender.CheckPermission("test.perm")) // If the sender dont have this perm
            {
                response = "You dont have perms";
                return false;
            }
            response = "Example Parent Command Response";
            return true;
        }
        public override void LoadGeneratedCommands() // Put here your commands (the other commands dont need the [CommandHandler(typeof())]
        {
        }
    }
}