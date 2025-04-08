using BepInEx;
using BepInEx.Logging;
using CraftingImprove.Components;
using CraftingImprove.Patcher;
using HarmonyLib;
using UnityEngine;

namespace CraftingImprove;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {
    internal static new ManualLogSource Logger;
    internal static GameObject PluginGameObject;

    private void Awake() {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        this.gameObject.hideFlags = HideFlags.HideAndDontSave;
        
        var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();
    }

    private void Start() {
        var plugin = GameObject.Find("CmPlugin");
        if (plugin == null) {
            PluginGameObject = new GameObject("CmPlugin");
            Object.DontDestroyOnLoad(PluginGameObject);
        } else {
            PluginGameObject = plugin;
        }
        
        PluginGameObject.AddComponent<CraftingHelper>();
        PluginGameObject.AddComponent<InventoryHelper>();
    }
}