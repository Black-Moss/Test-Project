using HarmonyLib;

namespace TestProject;

public class CustomCommand
{
    public static void Initialize()
    {
        new Harmony("blackmoss.testproject.customcommandpatcher").PatchAll(typeof(CustomCommand));
    }
    
    [HarmonyPatch(typeof(ConsoleScript), "RegisterAllCommands")]
    public static class ConsoleScriptPatcher
    {
        [HarmonyPostfix]
        public static void Postfix_RegisterAllCommands()
        {
            ConsoleScript.Commands.Add(
                new Command("hachimi", "manbo!", args => 
                    { 
                        ConsoleScript.instance.LogToConsole(Configs.CommandText); 
                        Plugin.Logger.LogInfo(Configs.CommandText);
                    }, 
                    null
                )
            );
        }
    }
}