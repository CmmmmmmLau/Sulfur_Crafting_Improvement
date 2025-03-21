using CraftingImprove.Components;
using HarmonyLib;
using PerfectRandom.Sulfur.Core;

namespace CraftingImprove.Patcher;

[HarmonyWrapSafe]
[HarmonyPatch(typeof(CraftingManager), "Start")]
public class CraftingManagerPatch {
    private static void Postfix(CraftingManager __instance) {
        var component = Plugin.PluginGameObject.AddComponent<CraftingHelper>();
        component.enchantRecipes = __instance.enchantmentRecipes;
        component.cookingRecipes = __instance.cookingRecipes;
        component.genericRecipes = __instance.genericRecipes;
        component.Initialize();
    }
}