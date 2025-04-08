using CraftingImprove.Components;
using CraftingImprove.Util;
using HarmonyLib;
using PerfectRandom.Sulfur.Core.UI.Inventory;

namespace CraftingImprove.Patcher;

[HarmonyWrapSafe]
[HarmonyPatch(typeof(InventoryUI), "Start")]
public class InitPlayerItemGrid {
    private static void Postfix() {
        PluginInstance<InventoryHelper>.Instance.UpdateItemCount();
    }
}

