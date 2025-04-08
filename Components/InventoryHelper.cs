using System;
using System.Collections;
using System.Collections.Generic;
using CraftingImprove.Util;
using HarmonyLib;
using PerfectRandom.Sulfur.Core;
using PerfectRandom.Sulfur.Core.Items;
using PerfectRandom.Sulfur.Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CraftingImprove.Components;

public class InventoryHelper : PluginInstance<InventoryHelper> {
    public ItemGrid PlayerItemGrid => StaticInstance<UIManager>.Instance.InventoryUI.PlayerBackpackGrid;
    public ItemGrid ServiceItemGrid => StaticInstance<UIManager>.Instance.InventoryUI.CurrentServiceStation.Grid;
    
    public Dictionary<string, int> PlayerInventoryItems { get; private set; } = new ();
    
    public InventoryType CurrentInventoryType { get; private set; }
    
    private void Start() {
        CurrentInventoryType = InventoryType.Backpack;
    }
    
    public void SetInventoryType(InventoryType inventoryType) {
        CurrentInventoryType = inventoryType;
        if (inventoryType == InventoryType.Backpack) {
            UpdateItemCount();
        } else if (inventoryType == InventoryType.ServiceStation) {
            UpdateItemCount(ServiceItemGrid);
        } else if (inventoryType == InventoryType.CraftingStation) {
            UpdateItemCount(ServiceItemGrid);
        }
    }

    public void UpdateItemCount(ItemGrid externalGrid = null) {
        PlayerInventoryItems.Clear();
        var list = PlayerItemGrid.AllItems();
        if (externalGrid != null) {
            list.AddRange(externalGrid.AllItems());
        }

        foreach (var inventoryItem in list)
        {
            var item = inventoryItem.itemDefinition;
            if (item.ItemType is ItemType.Weapon or ItemType.Armor)
            {
                continue;
            }
            PlayerInventoryItems.TryAdd(item.identifier, 0);
            PlayerInventoryItems[item.identifier] += 1;
        }
    }
}