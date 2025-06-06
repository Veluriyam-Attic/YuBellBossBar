using Microsoft.Xna.Framework;
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

                //BarMethod.DrawBar(
                //    96,
                //    30,
                //    79,
                //    31,
                //    npc);
                Texture2D Fill = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                Vector2 postion = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);
                spriteBatch.Draw(Fill, Main.screenPosition, null, Color.Purple, 0f, Vector2.Zero, new Vector2(800,60), SpriteEffects.None, 1f);
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