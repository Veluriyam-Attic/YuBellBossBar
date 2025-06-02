using Humanizer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.BigProgressBar;
using Terraria.Localization;
using Terraria.ModLoader;

namespace YuBellBossBar.Content
{

    public class BarStyle : ModBossBarStyle
    {
        public override string DisplayName => Language.GetTextValue("Mods.YuBellBossBar.Name");

        public override bool PreventDraw => true;

        public override void Draw(SpriteBatch spriteBatch, IBigProgressBar currentBar, BigProgressBarInfo info)
        {
            if (currentBar == null)
            {
                return;
            }

            NPC npc = Main.npc[info.npcIndexToAimAt];
            float lifePercent = Utils.Clamp(npc.life / (float)npc.lifeMax, 0f, 1f);

            if (info.showText && BigProgressBarSystem.ShowText)
            {

                Vector2 postion = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);

                #region 边框
                #region 前端
                Vector2 postionStart = postion + new Vector2(-((BarConfig.Instance.BarLong / 2) + 90f), -30);
                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("YuBellBossBar/Texture/HealthBarStart").Value, postionStart, Color.White);
                #endregion

                #region 后端
                // 后端
                Vector2 postionEnd = postion + new Vector2(((BarConfig.Instance.BarLong / 2) - 30f), -30);
                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("YuBellBossBar/Texture/HealthBarEnd").Value, postionEnd, Color.White);
                #endregion

                #region 中段
                // 这里是中间
                for (float postionX = (postionStart.X - postion.X + 120f); postionX < (postionEnd.X - postion.X); postionX += 10)
                {
                    Main.spriteBatch.Draw(ModContent.Request<Texture2D>("YuBellBossBar/Texture/HealthBarMiddle").Value, postion + new Vector2(postionX, -30), Color.White);
                }
                #endregion
                #endregion

                #region Boss大头贴
                try
                {
                    Texture2D BossHead = TextureAssets.NpcHeadBoss[npc.GetBossHeadTextureIndex()].Value;

                    Main.spriteBatch.Draw(
                        BossHead,
                        postionStart + new Vector2(80f, 30f) - new Vector2(BossHead.Width / 2, BossHead.Height / 2),
                        Color.White);
                }
                catch (Exception)
                {
                    return;
                }
                #endregion

                #region 绘制血条


                #endregion

                #region 数据显示
                float postionDate = -40f;

                BigProgressBarHelper.DrawHealthText(spriteBatch, Rectangle.Empty, postion + new Vector2(0f, 3f), npc.life, npc.lifeMax);

                if (BarConfig.Instance.MoreDate)
                {
                    //伤害
                    string damage = Language.GetTextValue("Mods.YuBellBossBar.Damage");
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, (damage + npc.damage.ToString()), postion + new Vector2(-150f - (damage.Length / 2), postionDate), Color.White);

                    //防御
                    string defense = Language.GetTextValue("Mods.YuBellBossBar.Defense");
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, (defense + npc.defense.ToString()), postion + new Vector2(-300f - (defense.Length / 2), postionDate), Color.White);

                    //伤害减免
                    string damagereduction = Language.GetTextValue("Mods.YuBellBossBar.DamageReduction");
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, (damagereduction + npc.takenDamageMultiplier.ToString()), postion + new Vector2(150f - (damagereduction.Length / 2), postionDate), Color.White);

                    //目标
                    string target = Language.GetTextValue("Mods.YuBellBossBar.Target");
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, (target + Main.player[npc.target].name), postion + new Vector2(300f - (target.Length / 2), postionDate), Color.White);
                }

                #endregion
            }

        }
    }
}