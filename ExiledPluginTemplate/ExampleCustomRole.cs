// Usings
using Exiled.CustomRoles.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using System.Collections.Generic;
using Exiled.Events.EventArgs;

// To shorten the use of the event class
using Role_PlayerHandler = Exiled.Events.Handlers.Player;

namespace ExiledPluginTemplate
{
    [CustomRole(RoleType.ClassD)] // Role to serialize
    public class ExampleCustomRole : CustomRole // Tells EXILED that is a CustomRole class
    {
        public override string Name { get; set; } = "Example"; // Name of the CustomRole
        public override string Description { get; set; } = "Example CustomRole"; // Description of the CustomRole
        public override uint Id { get; set; } = 30; // Id of the CustomRole (Recommended to put it in the Config File to avoid conflicts with other plugins)
        public override RoleType Role { get; set; } = RoleType.ClassD;
        public override int MaxHealth { get; set; } = 200; // Max Health of the CustomRole
        public override string CustomInfo { get; set; } = "Example CustomInfo"; // CustomInfo for the CustomRole

        // Spawn Properties of the CustomRole
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            Limit = 1, // Limit of this CustomRole
            // Role Spawn Point
            RoleSpawnPoints = new List<RoleSpawnPoint>
            {
                new RoleSpawnPoint
                {
                    Chance = 100, // Chance of Spawn
                    Role = RoleType.ClassD // Where the CustomRole going to be spawned
                }
            }
        };
        // Subscribe events to the CustomRole
        protected override void SubscribeEvents()
        {
            Role_PlayerHandler.TriggeringTesla += OnTriggeringTesla;
            base.SubscribeEvents();
        }

        // UnSubscribe events to the CustomRole
        protected override void UnsubscribeEvents()
        {
            Role_PlayerHandler.TriggeringTesla -= OnTriggeringTesla;
            base.UnsubscribeEvents();
        }

        private void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (Check(ev.Player)) // Checks if the Player has the CustomRole
            {
                ev.IsInIdleRange = false;
                ev.IsTriggerable = false;
            }
        }
    }
}