// Usings
using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace ExiledPluginTemplate
{
    public class EventHandlers // Events Class
    {
        // Referencing MainClass.cs
        private MainClass plugin;
        // Using the prefix created of MainClass here to create a constructor to access the config file and the MainClass methods
        public EventHandlers(MainClass plugin)
        {
            this.plugin = plugin;
        }
        public void OnRoundStarted() // RoundStarted event (Referenced on MainClass.cs/OnEnabled and OnDisabled)
        {
            // Example Code
            Log.Info("Round Started"); // Log to show in your console when the event is executed (when the round starts)
        }

        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev) // TriggeringTesla event (Referenced on MainClass.cs/OnEnabled and OnDisabled)
        {
            // Example Code
            if (ScpList.Contains(ev.Player.Role.Type)) // If the ScpList contains the Role of the Player (In this case, SCP roles)
            {
                ev.IsTriggerable = false; // The Role indicated in the list dont going to trigger the tesla
                ev.IsInIdleRange = false; // The Role indicated in the list dont going to activate the tesla
            }
        }

        public void OnPickingUpItem(PickingUpItemEventArgs ev) // PickingUpItem event (Referenced on MainClass.cs/OnEnabled and OnDisabled)
        {
            if (ev.Player.CurrentRoom.Type == RoomType.Pocket) // If the CurrentRoom of the player is PocketDimension
            {
                ev.IsAllowed = false;
            }
        }

        // List of RoleTypes used in the OnTriggeringTesla Method (Static methods can be accessed without making a constructor or referencing it)
        private static List<RoleTypeId> ScpList { get; } = new List<RoleTypeId>
        {
            RoleTypeId.Scp106,
            RoleTypeId.Scp049,
            RoleTypeId.Scp096,
            RoleTypeId.Scp173,
            RoleTypeId.Scp0492,
            RoleTypeId.Scp939
        };
    }
}