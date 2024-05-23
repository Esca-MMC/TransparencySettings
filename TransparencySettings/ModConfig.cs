using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace TransparencySettings
{
    /// <summary>This mod's config.json setting data.</summary>
    public class ModConfig
    {
        public ObjectSettings BuildingSettings = new ObjectSettings()
        {
            TileDistance = 3
        };
        public ObjectSettings BushSettings = new ObjectSettings();
        public ObjectSettings TreeSettings = new ObjectSettings();
        public ObjectSettings ObjectSettings = new ObjectSettings()
        {
            Enable = false,
            TileDistance = 3
        };
        public ObjectSettings CraftableSettings = new ObjectSettings()
        {
            Enable = false,
            TileDistance = 3
        };
        public KeybindSettings KeyBindings = new KeybindSettings();
    }

    /* Setting collection classes */

    public class ObjectSettings
    {
        public bool Enable = true;
        public bool BelowPlayerOnly = true;
        public int TileDistance = 5;
        public float MinimumOpacity = 0.4f;
    }

    public class KeybindSettings
    {
        private KeybindList _disableTransparency = new KeybindList();
        public KeybindList DisableTransparency
        {
            get { return _disableTransparency; }
            set { _disableTransparency = value ?? new KeybindList(); } //prevent null values
        }

        private KeybindList _fullTransparency = new KeybindList();
        public KeybindList FullTransparency
        {
            get { return _fullTransparency; }
            set { _fullTransparency = value ?? new KeybindList(); } //prevent null values
        }
    }
}
