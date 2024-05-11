using GenericModConfigMenu;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using System;

namespace TransparencySettings
{
    public partial class ModEntry : Mod
    {
        // <summary>A SMAPI GameLaunched event that enables GMCM support if that mod is available.</summary>
        public void EnableGMCM(object sender, GameLaunchedEventArgs e)
        {
            try
            {
                var api = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu"); //attempt to get GMCM's API instance

                if (api == null) //if the API is not available
                    return;

                api.Register(ModManifest, () => Config = new ModConfig(), () => Helper.WriteConfig(Config)); //register the mod's menu, define its reset/save actions, and allow in-game changes

                //register an option for each of this mod's config settings

                //buildings
                api.AddSectionTitle
                (
                    mod: ModManifest,
                    text: () => Helper.Translation.Get("Building.Title.Name"),
                    tooltip: () => Helper.Translation.Get("Building.Title.Desc")
                );

                api.AddBoolOption
                (
                    mod: ModManifest,
                    name: () => Helper.Translation.Get("Building.Enable.Name"),
                    tooltip: () => Helper.Translation.Get("Building.Enable.Desc"),
                    getValue: () => Config.BuildingSettings.Enable,
                    setValue: (bool val) => Config.BuildingSettings.Enable = val
                );

                api.AddBoolOption
                (
                    mod: ModManifest,
                    name: () => Helper.Translation.Get("Building.Below.Name"),
                    tooltip: () => Helper.Translation.Get("Building.Below.Desc"),
                    getValue: () => Config.BuildingSettings.BelowPlayerOnly,
                    setValue: (bool val) => Config.BuildingSettings.BelowPlayerOnly = val
                );

                api.AddNumberOption
                (
                    mod: ModManifest,
                    name: () => Helper.Translation.Get("Building.Distance.Name"),
                    tooltip: () => Helper.Translation.Get("Building.Distance.Desc"),
                    getValue: () => Config.BuildingSettings.TileDistance,
                    setValue: (int val) => Config.BuildingSettings.TileDistance = val
                );

                //bushes
                api.AddSectionTitle
                (
                    mod: ModManifest,
                    text: () => Helper.Translation.Get("Bush.Title.Name"),
                    tooltip: () => Helper.Translation.Get("Bush.Title.Desc")
                );

                api.AddBoolOption
                (
                    mod: ModManifest,
                    name: () => Helper.Translation.Get("Bush.Enable.Name"),
                    tooltip: () => Helper.Translation.Get("Bush.Enable.Desc"),
                    getValue: () => Config.BushSettings.Enable,
                    setValue: (bool val) => Config.BushSettings.Enable = val
                );

                api.AddBoolOption
                (
                    mod: ModManifest,
                    name: () => Helper.Translation.Get("Bush.Below.Name"),
                    tooltip: () => Helper.Translation.Get("Bush.Below.Desc"),
                    getValue: () => Config.BushSettings.BelowPlayerOnly,
                    setValue: (bool val) => Config.BushSettings.BelowPlayerOnly = val
                );

                api.AddNumberOption
                (
                    mod: ModManifest,
                    name: () => Helper.Translation.Get("Bush.Distance.Name"),
                    tooltip: () => Helper.Translation.Get("Bush.Distance.Desc"),
                    getValue: () => Config.BushSettings.TileDistance,
                    setValue: (int val) => Config.BushSettings.TileDistance = val
                );

                //trees
                api.AddSectionTitle
                (
                    mod: ModManifest,
                    text: () => Helper.Translation.Get("Tree.Title.Name"),
                    tooltip: () => Helper.Translation.Get("Tree.Title.Desc")
                );

                api.AddBoolOption
                (
                    mod: ModManifest,
                    name: () => Helper.Translation.Get("Tree.Enable.Name"),
                    tooltip: () => Helper.Translation.Get("Tree.Enable.Desc"),
                    getValue: () => Config.TreeSettings.Enable,
                    setValue: (bool val) => Config.TreeSettings.Enable = val
                );

                api.AddBoolOption
                (
                    mod: ModManifest,
                    name: () => Helper.Translation.Get("Tree.Below.Name"),
                    tooltip: () => Helper.Translation.Get("Tree.Below.Desc"),
                    getValue: () => Config.TreeSettings.BelowPlayerOnly,
                    setValue: (bool val) => Config.TreeSettings.BelowPlayerOnly = val
                );

                api.AddNumberOption
                (
                    mod: ModManifest,
                    name: () => Helper.Translation.Get("Tree.Distance.Name"),
                    tooltip: () => Helper.Translation.Get("Tree.Distance.Desc"),
                    getValue: () => Config.TreeSettings.TileDistance,
                    setValue: (int val) => Config.TreeSettings.TileDistance = val
                );

                //keybinds
                api.AddSectionTitle
                (
                    mod: ModManifest,
                    text: () => Helper.Translation.Get("KeyBindings.Title.Name"),
                    tooltip: () => Helper.Translation.Get("KeyBindings.Title.Desc")
                );

                api.AddKeybindList
                (
                    mod: ModManifest,
                    name: () => Helper.Translation.Get("KeyBindings.Disable.Name"),
                    tooltip: () => Helper.Translation.Get("KeyBindings.Disable.Desc"),
                    getValue: () => Config.KeyBindings.DisableTransparency,
                    setValue: (KeybindList val) => Config.KeyBindings.DisableTransparency = val
                );

                api.AddKeybindList
                (
                    mod: ModManifest,
                    name: () => Helper.Translation.Get("KeyBindings.Full.Name"),
                    tooltip: () => Helper.Translation.Get("KeyBindings.Full.Desc"),
                    getValue: () => Config.KeyBindings.FullTransparency,
                    setValue: (KeybindList val) => Config.KeyBindings.FullTransparency = val
                );
            }
            catch (Exception ex)
            {
                Monitor.Log($"An error happened while loading this mod's GMCM options menu. Its menu might be missing or fail to work. The auto-generated error message has been added to the log.", LogLevel.Warn);
                Monitor.Log($"----------", LogLevel.Trace);
                Monitor.Log($"{ex.ToString()}", LogLevel.Trace);
            }
        }
    }
}
