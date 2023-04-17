// Usings

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Exiled.API.Features;
using HarmonyLib;
using PlayerStatsSystem;
using Respawning.NamingRules;
using UnityEngine;

namespace ExiledPluginTemplate
{
    [HarmonyPatch(typeof(CheckpointKiller), nameof(CheckpointKiller.OnTriggerEnter))] // Method to Patch
    public static class ExamplePrefixPatch
    {
        [HarmonyPrefix]
        public static bool OnEnteringCheckpointKiller(CheckpointKiller __instance, Collider other)
        {
            var referenceHub = other.GetComponentInParent<ReferenceHub>();
            var player = Player.Get(referenceHub);

            if (player.IsHuman || player.IsScp)
                return false;

            player.ReferenceHub.playerStats.DealDamage(new UniversalDamageHandler(-1f, DeathTranslations.Unknown));
            return true;
        }
    }

    [HarmonyPatch(typeof(NineTailedFoxNamingRule), nameof(NineTailedFoxNamingRule.PlayEntranceAnnouncement))] // Method to Patch
    public static class ExampleTranspilerPatch
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> OnPlayingAnnouncement(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = instructions.ToList();
            var ret = generator.DefineLabel();
            int index = instructions.ToList().FindIndex(x => x.opcode == OpCodes.Call && x.operand is MethodBase method && method.Name == "SendToAuthenticated");
            newInstructions.InsertRange(index, new[]
            {
                new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(MainClass), nameof(MainClass.Instance))),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(MainClass), nameof(MainClass.Config))),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(Config), nameof(Config.EnableCassieSubtitles))),
                new CodeInstruction(OpCodes.Brfalse_S, ret)
            });
            newInstructions[index + 4].labels.Add(ret);
            foreach (var instruction in newInstructions)
            {
                yield return instruction;
            }
        }
    }
}