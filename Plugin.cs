using BepInEx;
using BepInEx.Logging;
using CraftingImprove.Patcher;
using HarmonyLib;
using PerfectRandom.Sulfur.Core;
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
        
        Harmony.CreateAndPatchAll(typeof(CraftingManagerPatch));
    }

    private void Start() {
        var plugin = GameObject.Find("CmPlugin");
        if (plugin == null) {
            PluginGameObject = new GameObject("CmPlugin");
            Object.DontDestroyOnLoad(PluginGameObject);
        } else {
            PluginGameObject = plugin;
        }
    }
}