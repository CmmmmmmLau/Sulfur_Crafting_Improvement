using CraftingImprove.Components;
using CraftingImprove.Util;
using HarmonyLib;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Gameplay;

namespace CraftingImprove.Patcher;

[HarmonyPatch(typeof(ServiceStation), "Exit")]
public class ServiceStationPatcher {
    private static void Postfix(ServiceStation __instance) {
        PluginInstance<InventoryHelper>.Instance.SetInventoryType(InventoryType.Backpack);
    }
}

[HarmonyPatch(typeof(PlayerStash), "Enter")]
public class PlayerStashPatcher {
    private static void Postfix(PlayerStash __instance) {
        PluginInstance<InventoryHelper>.Instance.SetInventoryType(InventoryType.ServiceStation);
    }
}

[HarmonyPatch(typeof(CraftingStation), "Enter")]
public class CraftingStationPatcher {
    private static void Postfix(CraftingStation __instance) {
        PluginInstance<InventoryHelper>.Instance.SetInventoryType(InventoryType.CraftingStation);
    }
}
