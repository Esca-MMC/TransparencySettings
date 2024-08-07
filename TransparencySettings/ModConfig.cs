﻿using StardewModdingAPI.Utilities;

namespace TransparencySettings
{
    /// <summary>This mod's config.json setting data.</summary>
    public class ModConfig
    {
        public ObjectSettings BuildingSettings = new ObjectSettings();
        public ObjectSettings BushSettings = new ObjectSettings()
        {
            TileDistance = 5 //helps with object size
        };
        public ObjectSettings TreeSettings = new ObjectSettings()
        {
            TileDistance = 5 //helps with object size
        };
        public ObjectSettings GrassSettings = new ObjectSettings()
        {
            BelowPlayerOnly = false, //looks a bit weird otherwise
            MinimumOpacity = 0.3f //helps with overlapping textures
        };
        public ObjectSettings CropSettings = new ObjectSettings()
        {
            Enable = false,
            BelowPlayerOnly = false //looks a bit weird otherwise
        };
        public ObjectSettings ObjectSettings = new ObjectSettings()
        {
            Enable = false
        };
        public ObjectSettings CraftableSettings = new ObjectSettings()
        {
            Enable = false
        };
        public KeybindSettings KeyBindings = new KeybindSettings();
    }

    /* Setting collection classes */

    public class ObjectSettings
    {
        public bool Enable = true;
        public bool BelowPlayerOnly = true;
        public int TileDistance = 3;
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
