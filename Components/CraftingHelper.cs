using System.Collections;
using System.Collections.Generic;
using CraftingImprove.Util;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.Items;
using UnityEngine;

namespace CraftingImprove.Components;

public class CraftingHelper : PluginInstance<CraftingHelper> {
    public List<CraftingRecipe> genericRecipes { private get; set; }
    public List<CraftingRecipe> cookingRecipes { private get; set; }
    public List<CraftingRecipe> enchantRecipes { private get; set; }
    
    
    private Dictionary<ItemDefinition, List<CraftingRecipe>> genericLookup = new ();
    private Dictionary<ItemDefinition, List<CraftingRecipe>> cookingLookup = new ();
    private Dictionary<ItemDefinition, List<CraftingRecipe>> enchantLookup = new ();
    
    public void Initialize() {
        this.StartCoroutine(BuildInvertedIndex(genericRecipes, genericLookup));
        this.StartCoroutine(BuildInvertedIndex(cookingRecipes, cookingLookup));
        this.StartCoroutine(BuildInvertedIndex(enchantRecipes, enchantLookup));
    }

    private IEnumerator BuildInvertedIndex(List<CraftingRecipe> recipes, Dictionary<ItemDefinition, List<CraftingRecipe>> lookup) {
        foreach (var recipe in recipes) {
            var ingredients = recipe.itemsNeeded;
            foreach (var ingredient in ingredients) {
                if (!lookup.ContainsKey(ingredient.item)) {
                    lookup[ingredient.item] = new List<CraftingRecipe>();
                }
                lookup[ingredient.item].Add(recipe);
            }
        }
        
        yield return null;
    }
}