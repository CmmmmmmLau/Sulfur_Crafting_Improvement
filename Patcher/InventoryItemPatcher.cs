using CraftingImprove.Components;
using HarmonyLib;
using PerfectRandom.Sulfur.Core.Items;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace CraftingImprove.Patcher;

[HarmonyWrapSafe]
[HarmonyPatch(typeof(InventoryItem), "ModifyArtwork")]
public class InventoryItemPatcher {
    private static void Postfix(InventoryItem __instance) {
        var container = __instance.transform.Find("Container");
        var outline = new GameObject("Outline");
        outline.transform.SetParent(container.transform);
        outline.AddComponent<ImageOutlineController>();
    }
}