global using YuBellBossBar.Content;
using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace YuBellBossBar.Content
{
    public class BarConfig : ModConfig
    {
        public static BarConfig Instance;

        public override void OnLoaded()
        {
            Instance = this;
        }

        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header($"PostionHeader")]

        [DefaultValue(800)]
        [Range(400,int.MaxValue)]
        public int BarLong;

        [DefaultValue(0)]
        [Range(int.MinValue, int.MaxValue)]
        public int BarPostionY;

        [DefaultValue(0)]
        [Range(int.MinValue, int.MaxValue)]
        public int BarPostionX;

        [Header($"InfoHeader")]

        [DefaultValue(true)]
        public bool MoreInfo;

        [DefaultValue(true)]
        public bool WorldInfo;

        [Header($"StyleHeader")]

        [DefaultValue(true)]
        public bool DrawLastBar;

        [DefaultValue(5)]
        [Range(0,int.MaxValue)]
        public int LastBarDecreaseSpeed;

        [DefaultValue(true)]
        public bool UseGoldBar;

        [DefaultValue(false)]
        public bool ForceUseDefaultBar;
    }
}
