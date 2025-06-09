using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace YuBellBossBar.Content
{
    public class BarData
    {
        // 开始，中间，结束，填充，头
        public static Dictionary<int, Asset<Texture2D>[]> BarTexture = new Dictionary<int, Asset<Texture2D>[]>();

        // 绘制的颜色
        public static Dictionary<int, Color?> BarColor = new Dictionary<int, Color?>();

        // 包括的NPC
        public static Dictionary<int, int[]> BarNPCContain = new Dictionary<int, int[]>();

        public static Dictionary<int,int> BossMaxHealth = new Dictionary<int, int>();
        public static Dictionary<int, int> BossNowHealth = new Dictionary<int, int>();

        // Boss名字
        public static Dictionary<int, string> BossName = new Dictionary<int, string>();

        /* 
         框架开头的距离填充长度，距离boss头贴图的长度和高度，
         框架结尾距离血条结尾的长度，血条填充尾部的开始位置
        */
        public static Dictionary<int, int[]> CutLength = new Dictionary<int, int[]>();

        public static Dictionary<int, bool> Midwidth = new Dictionary<int, bool>();
    }
}
