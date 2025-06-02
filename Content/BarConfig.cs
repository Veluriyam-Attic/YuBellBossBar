global using YuBellBossBar.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [DefaultValue(800f)]
        [Range(0f,1600f)]
        public int BarLong;

        [DefaultValue(0f)]
        [Range(-30f, 1200f)]
        public int BarPostionY;

        [DefaultValue(0f)]
        [Range(2000f, 2000f)]
        public int BarPostionX;

        [DefaultValue(true)]
        public bool MoreDate;
    }
}
