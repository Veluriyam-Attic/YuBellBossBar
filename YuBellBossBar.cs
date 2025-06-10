using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace YuBellBossBar
{
    public class YuBellBossBar : Mod
    {
        public override object Call(params object[] args)
        {
            if (args[0] == "BellBarAddColor") 
            {
                int? key = args[1] as int?;
                Color? color = args[2] as Color?;
                if (key == null || color == null)
                {
                    return null;
                }
                BarData.BarColor.TryAdd((int)key, color);
            }
            return null;
        }
    }
}
