using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace TestProject
{
    [BepInPlugin("blackmoss.testproject", "Test Project", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;
        private readonly Harmony _harmony = new("blackmoss.testproject");
        public static Plugin Instance { get; private set; } = null!;
        
        public static ConfigEntry<string> commandText;

        public void Awake()
        {
            Logger = base.Logger;
            Instance = this;
            _harmony.PatchAll();
            
            CustomCommand.Initialize();
            
            commandText = Config.Bind(
                "General",
                "commandText",
                "omachili manbo!"     // 默认倒计时60秒
            );
        }
    }
}