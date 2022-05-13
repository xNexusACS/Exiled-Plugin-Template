// Usings
using Exiled.API.Features;
using HarmonyLib;
using MapGeneration;
using Respawning.NamingRules;

namespace ExiledPluginTemplate
{
    [HarmonyPatch(typeof(UnitNamingRule), nameof(UnitNamingRule.AddCombination))] // Method to Patch
    public static class ExamplePatch
    {
        public static void Postfix(ref string regular) // Postfix, See Harmony Docs for more details: https://harmony.pardeike.net/articles/patching-postfix.html
        {
            if (PlayerManager.localPlayer == null || SeedSynchronizer.Seed == 0) return; // If the localPlayer is null and the Seed is 0 return
            Log.Info($"[ExamplePatch] unit:{regular}");
        }
    }
}