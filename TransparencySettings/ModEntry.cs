using HarmonyLib;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.Locations;
using StardewValley.Menus;
using System;
using xTile.Dimensions;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace TransparencySettings
{
    public partial class ModEntry : Mod
    {
        public static ModConfig Config = null;

        public override void Entry(IModHelper helper)
        {
            try
            {
                Config = helper.ReadConfig<ModConfig>(); //try to load the config.json file
            }
            catch (Exception ex)
            {
                Monitor.Log($"Encountered an error while loading the config.json file. Default settings will be used instead. Full error message:\n-----\n{ex.ToString()}", LogLevel.Error);
                Config = new ModConfig(); //use the default settings
            }

            Helper.Events.GameLoop.GameLaunched += EnableGMCM;
            CacheManager.Initialize(helper);
            InputManager.Initialize(helper, Monitor);
            ApplyHarmonyPatches();
        }

        private void ApplyHarmonyPatches()
        {
            Harmony harmony = new Harmony(ModManifest.UniqueID); //create a Harmony instance for this mod

            //apply patches
            HarmonyPatch_BuildingTransparency.ApplyPatch(harmony, Helper, Monitor);
            HarmonyPatch_BushTransparency.ApplyPatch(harmony, Helper, Monitor);
            HarmonyPatch_FruitTreeTransparency.ApplyPatch(harmony, Helper, Monitor);
            HarmonyPatch_TreeTransparency.ApplyPatch(harmony, Helper, Monitor);
        }
    }
}
