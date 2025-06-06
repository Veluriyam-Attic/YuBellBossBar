using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI.BigProgressBar;
using Terraria.Localization;
using Terraria.ModLoader;

namespace YuBellBossBar.Content
{
    public class BarStyle : ModBossBarStyle
    {
        public static int npcnum = 0;

        public override string DisplayName => Language.GetTextValue("Mods.YuBellBossBar.Name");

        public override bool PreventDraw => true;

        public override void Draw(SpriteBatch spriteBatch, IBigProgressBar currentBar, BigProgressBarInfo info)
        {
            if (currentBar == null)
            {
                return;
            }
            {
                NPC npc = Main.npc[info.npcIndexToAimAt];

                npc.BossBar = currentBar;

                BarMethod.DrawBar(
                    96,
                    30,
                    79,
                    31,
                    npc);
            }
        }
    }

    public class BellBar : ModBossBar
    {
        public override bool PreDraw(SpriteBatch spriteBatch, NPC npc, ref BossBarDrawParams drawParams)
        {
            return true;
        }
    }
}