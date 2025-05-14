using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;

[BepInPlugin("com.yourname.dicewood.russifier", "Dicewood Russifier", "1.0.0")]
public class RussifierPlugin : BaseUnityPlugin
{
    private static Dictionary<string, string> translations = new Dictionary<string, string>
    {
        {"Start Game", "Начать игру"},
        {"Options", "Настройки"},
    };
    
    private void Awake()
    {
        var harmony = new Harmony("com.yourname.dicewood.russifier");
        harmony.PatchAll();
        
        Logger.LogInfo("Русификатор загружен!");
    }
    
    [HarmonyPatch(typeof(TextManager), "SetText")]
    class TextPatch
    {
        static void Prefix(ref string text)
        {
            if (translations.TryGetValue(text, out string translated))
                text = translated;
        }
    }
}