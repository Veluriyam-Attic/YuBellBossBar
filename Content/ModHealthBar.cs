using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.UI.BigProgressBar;
using Terraria.ID;
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
            if (currentBar is CommonBossBigProgressBar)
            {
                NPC npc = Main.npc[info.npcIndexToAimAt];

                Main.spriteBatch.Draw(ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value, Main.MouseScreen, null, Color.Purple, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                BarMethod.DrawBar(npc);
            }
        }
    }
}