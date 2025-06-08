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
            if (args[0] is Texture2D && args[1] is Texture2D && args[2] is Texture2D && args[3] is int && args[4] is int && args[5] is int)
            {
                if (args[0] == null || args[1] == null || args[2] == null || args[3] == null || args[4] == null || args[5] == null)
                {
                    return "Value Can't be NULL";
                }

                try
                {
                    Texture2D BarStart = args[0] as Texture2D;
                    Texture2D BarMid = args[1] as Texture2D;
                    Texture2D BarEnd = args[2] as Texture2D;
                    int? StartX = args[3] as int?;
                    int? StartY = args[4] as int?;
                    int? npcType = args[5] as int?;

                    //BarMethod.InputInfo(BarStart, BarMid, BarEnd, (int)StartX, (int)StartY, (int)npcType);
                    return null;
                }
                catch (Exception)
                {
                    return "There's a Exception!";
                }
            }
            else
            {
                return "Value Error!";
            }
        }
    }
}
