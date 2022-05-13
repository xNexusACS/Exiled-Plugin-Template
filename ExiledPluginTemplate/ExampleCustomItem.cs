// Usings
using Exiled.CustomItems.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using System.Collections.Generic;
using Exiled.CustomItems.API;
using Exiled.Events.EventArgs;

// To shorten the use of the event class
using Item_PlayerHandler = Exiled.Events.Handlers.Player;

namespace ExiledPluginTemplate
{
    [CustomItem(ItemType.Medkit)] // Item to serialize
    public class ExampleCustomItem : CustomItem // Tells EXILED that is a CustomItem class
    {
        public override string Name { get; set; } = "Example"; // Name of the CustomItem
        public override string Description { get; set; } = "Example CustomItem"; // Description of the CustomItem
        public override uint Id { get; set; } = 30; // Id of the CustomItem (Recommended to put it in the Config File to avoid conflicts with other plugins)
        public override float Weight { get; set; } = 1f; // Weight of the CustomItem

        // Spawn Properties of the CustomItem
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            Limit = 1, // Limit of this CustomItem
            // Dynamic Spawn Point
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint
                {
                    Location = SpawnLocation.Inside914, // Where the CustomItem going to be spawned
                    Chance = 100 // Chance of Spawn
                }
            }
        };

        // Subscribe events to the CustomItem
        protected override void SubscribeEvents()
        {
            Item_PlayerHandler.UsingItem += OnUsingItem;
            base.SubscribeEvents();
        }

        // UnSubscribe events to the CustomItem
        protected override void UnsubscribeEvents()
        {
            Item_PlayerHandler.UsingItem -= OnUsingItem;
            base.UnsubscribeEvents();
        }

        // Example Event (Referenced on ExampleCustomItem.cs [SubscribeEvents() and UnsubscribeEvents()])
        private void OnUsingItem(UsingItemEventArgs ev)
        {
            if (Check(ev.Item)) // Checks if the Item to use is the CustomItem
            {
                ev.Player.Heal(100f, true); // When using the item it heal the player 100 and it override the maxhealth
            }
        }
    }
}