using Microsoft.Xna.Framework.Graphics;
using Terraria;
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
                if(BarData.CanDraw.Keys.Contains(npc.type) && !BarData.CanDraw[npc.type])
                {
                    return;
                }
                BarMethod.DrawBar(npc);
            }
        }
    }
}