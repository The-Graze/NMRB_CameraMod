using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Squido.NMR;
using UnhollowerRuntimeLib;

namespace NMRB_CameraMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        CameraController Camcontroller;
        Harmony harmony;
        public override void Load()
        {
            // Plugin startup logic
            ClassInjector.RegisterTypeInIl2Cpp(typeof(CameraController));
            harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        }
        [HarmonyPatch(typeof(Character), nameof(Character.Awake))]
        class Patch
        {
            static void Postfix(Character __instance)
            {
                __instance.gameObject.AddComponent<CameraController>();
            }
        }
    }
}
