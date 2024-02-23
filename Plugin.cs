using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using LethalLevelLoader;
using DunGen.Graph;


namespace LethalCompanyTemplate
{
    public static class PluginInfo
    {
        public const string PLUGIN_GUID = "SleepsDchoolDungeon";
        public const string PLUGIN_NAME = "SleepsDchoolDungeon";
        public const string PLUGIN_VERSION = "0.0.1";
    }
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            AssetBundle myAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "attempt4"));
            DungeonFlow myDungeonFlow = myAssetBundle.LoadAsset<DungeonFlow>("Assets/attempt4/School.asset");
            ExtendedDungeonFlow myExtendedDungeonFlow = ScriptableObject.CreateInstance<ExtendedDungeonFlow>();
            myExtendedDungeonFlow.dungeonFlow = myDungeonFlow;
            PatchedContent.RegisterExtendedDungeonFlow(myExtendedDungeonFlow);
            myExtendedDungeonFlow.manualContentSourceNameReferenceList.Add(new StringWithRarity("Lethal Company", 99999));
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}