// Usings
using Exiled.API.Features;
using System;
using Exiled.CustomItems.API;
using Exiled.CustomRoles.API;
using HarmonyLib;

// To shorten the use of the event class
using ServerHandler = Exiled.Events.Handlers.Server;
using PlayerHandler = Exiled.Events.Handlers.Player;

namespace ExiledPluginTemplate
{
    // Main Class
    public class MainClass : Plugin<Config> // Referencing the Config File to the MainClass
    {
        public override string Author { get; } = "xNexus-ACS"; // Author of the plugin (Author to show when Exiled load it)
        public override string Name { get; } = "ExiledPluginTemplate"; // Name of the plugin (Name to show when Exiled load it)
        public override string Prefix { get; } = "exiled_plugin_template"; // Name to show on your config file (EXILED/Configs/yourport-config.yml)
        public override Version Version { get; } = new Version(0, 1, 0); // Version of the plugin (Version to show when Exiled load it)
        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 1); // Version of Exiled required to load the plugin

        private static ExampleCustomItem exCI; // Referencing the ExampleCustomItem and creating a prefix for it
        private static ExampleCustomRole exCR; // Referencing the ExampleCustomRole and creating a prefix for it
        
        private Harmony h { get; set; } // Referencing HarmonyLib, Used to Patch (See ExamplePatch.cs)

        private EventHandlers ev; // Referencing the EventHandlers class and creating a prefix to access the class
        
        public override void OnEnabled() // Code to execute when the plugin is enabled (Can be events, methods etc)
        {
            ev = new EventHandlers(this); // Small Constructor (See EventHandlers.cs)
            h.PatchAll(); // Patch all patches created on this plugin
            
            ServerHandler.RoundStarted += ev.OnRoundStarted; // Subscribing the event RoundStarted
            PlayerHandler.TriggeringTesla += ev.OnTriggeringTesla; // Subscribing the event TriggeringTesla
            
            base.OnEnabled();
            CustomItemRegister(); // Register All CustomItems in this plugin
            CustomRoleRegister(); // Register All CustomRoles in this plugin
        }

        public override void OnDisabled() 
        {
            ServerHandler.RoundStarted -= ev.OnRoundStarted; // Unsubscribing the event RoundStarted
            PlayerHandler.TriggeringTesla -= ev.OnTriggeringTesla; // Unsubscribing the event TriggeringTesla

            ev = null;
            h.UnpatchAll(); // Unpatch all patches created on this plugin
            base.OnDisabled();
        }

        private static void CustomItemRegister()
        {
            exCI = new ExampleCustomItem {Type = ItemType.Medkit};
            exCI.Register(); // Register the Example Custom Item
        }

        private static void CustomRoleRegister()
        {
            exCR = new ExampleCustomRole {Role = RoleType.ClassD};
            exCR.Register(); // Register the Example Custom Role
        }
    }
}