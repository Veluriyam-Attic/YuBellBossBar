using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace YuBellBossBar.Content
{
    public class BarMethod
    {

        public static Vector2 lastpostion = Vector2.Zero;
        public static Vector2 drawpostion = Vector2.Zero;
        public static Vector2 endpostion = Vector2.Zero;

        public static void InputInfo(Texture2D BarStart, Texture2D BarMid, Texture2D BarEnd, int StartX, int EndX, int npcType)
        {
            
        }

        public static void DrawBar
            (
            int StartX,
            int EndX,
            int HeadX,
            int HeadY,
            NPC npc
            )
        {
            Texture2D BarStart = null;
            Texture2D BarMid = null;
            Texture2D BarEnd = null;
            Texture2D Fill = null;

            try
            {
                #region GetValues
                GetBarTexture(ref BarStart, ref BarMid, ref BarEnd, ref Fill, npc);
                Vector2 postion = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);
                int HalfBarLong = BarConfig.Instance.BarLong / 2;
                int HalfHeight = BarMid.Height / 2;
                Vector2 postionStart = postion - new Vector2(HalfBarLong + StartX, HalfHeight);
                Vector2 postionEnd = postion - new Vector2(EndX - HalfBarLong, HalfHeight);
                Texture2D BossHead = GetHeadTexture(npc);
                float alpha = CheckCursorOnBar(postionStart, postionEnd + new Vector2(BarEnd.Width, HalfHeight * 2), Main.MouseWorld, BarEnd);
                #endregion
                #region Draw
                DrawBarFill(postion, postionStart, postionEnd, Fill, HalfBarLong, HalfHeight, npc, alpha);
                DrawBarFrame(postionStart, BarStart, postionEnd, BarMid, postion, HalfHeight, BarEnd, alpha);
                DrawBarBossHead(BossHead, postionStart, HeadX, HeadY, alpha);
                float NameLength = DrawBossNameAndHealth(npc, postion, alpha);
                if (NameLength == -1)
                {
                    return;
                }
                DrawBarInfo(postion, npc, NameLength);
                #endregion
            }
            catch (Exception)
            {
                Main.NewText("There's a Exception! Show it to 虞悖(Yu Bell)!");
            }
        }

        #region Draw Method
        public static void DrawBarFrame(Vector2 postionStart, Texture2D BarStart, Vector2 postionEnd, Texture2D BarMid, Vector2 postion, int HalfHeight, Texture2D BarEnd, float alpha)
        {

            for (float MidStart = postionStart.X + BarStart.Width; MidStart < postionEnd.X; MidStart += BarMid.Width)
            {
                Main.spriteBatch.Draw(BarMid, new Vector2(MidStart, postion.Y - HalfHeight), new Color(255, 255, 255) * alpha);
            }
            Main.spriteBatch.Draw(BarStart, postionStart, new Color(255, 255, 255) * alpha);
            Main.spriteBatch.Draw(BarEnd, postionEnd, new Color(255, 255, 255) * alpha);
        }

        public static void DrawBarBossHead(Texture2D BossHead, Vector2 postionStart, int HeadX, int HeadY, float alpha)
        {
            Main.spriteBatch.Draw(
                BossHead,
                postionStart + new Vector2(HeadX, HeadY) - new Vector2(BossHead.Width / 2, BossHead.Height / 2),
                new Color(255, 255, 255) * alpha);
        }

        public static void DrawBarInfo(Vector2 postion, NPC npc, float NameLength)
        {
            if (BarConfig.Instance.MoreInfo)
            {
                //int FifthBarLong = BarConfig.Instance.BarLong / 5;

                //string damage = Language.GetTextValue("Mods.YuBellBossBar.Damage");
                //Main.spriteBatch.DrawString(FontAssets.MouseText.Value, (damage + npc.damage.ToString()), postion + new Vector2(-NameLength - (damage.Length / 2) - 20f, 0), Color.Red);

                //string defense = Language.GetTextValue("Mods.YuBellBossBar.Defense");
                //Main.spriteBatch.DrawString(FontAssets.MouseText.Value, (defense + npc.defense.ToString()), postion + new Vector2(-NameLength - (damage.Length / 2) - 20f, 0), new Color(192, 192, 192));

                //string damagereduction = Language.GetTextValue("Mods.YuBellBossBar.DamageReduction");
                //Main.spriteBatch.DrawString(FontAssets.MouseText.Value, (damagereduction + string.Format("{0:f2}", (1 - npc.takenDamageMultiplier) * 100)) + "%", postion + new Vector2(FifthBarLong - (damagereduction.Length / 2), 0), Color.Pink);

                //string target = Language.GetTextValue("Mods.YuBellBossBar.Target");
                //Main.spriteBatch.DrawString(FontAssets.MouseText.Value, (target + Main.player[npc.target].name), postion + new Vector2((FifthBarLong * 2) - (target.Length / 2), 0), Color.Orange);
            }
        }

        public static float DrawBossNameAndHealth(NPC npc, Vector2 postion, float alpha)
        {
            if (npc.life < 0)
            {
                return -1;
            }
            string NameAndHealth =
                npc.FullName.ToString() + ":" +
                npc.life.ToString() + "/" + npc.lifeMax.ToString() + ":"
                + string.Format("{0:f2}", (((float)npc.life / (float)npc.lifeMax) * 100)) + "%";
            Vector2 Namepostion = new Vector2(FontAssets.MouseText.Value.MeasureString(NameAndHealth).X / 2, FontAssets.MouseText.Value.MeasureString(NameAndHealth).Y / 3);

            Main.spriteBatch.DrawString(FontAssets.MouseText.Value, NameAndHealth, postion - Namepostion, new Color(255, 255, 255));

            return FontAssets.MouseText.Value.MeasureString(NameAndHealth).X;
        }

        public static void DrawBarFill(Vector2 postion, Vector2 postionStart, Vector2 postionEnd, Texture2D Fill, int HalfBarLong, int HalfHeight, NPC npc, float alpha, Color? color = null)
        {
            Color barcolor;

            if (color == null)
            {
                barcolor = GetBarColor(npc.life, npc.lifeMax, alpha);
            }
            else
            {
                barcolor = (Color)color;
            }
            Color deepbarcolor = new Color(barcolor.R, barcolor.G, barcolor.B);

            if (BarConfig.Instance.DrawLastBar)
            {
                float fillalpha = alpha * alpha * alpha * alpha * alpha;

                for
                (
                float FillStart = (float)(postion.X - (float)HalfBarLong - Fill.Width);
                FillStart < lastpostion.X;
                FillStart++)
                {
                    Main.spriteBatch.Draw
                    (
                    Fill,
                    new Vector2((float)FillStart, (float)postion.Y - (float)HalfHeight),
                    deepbarcolor * fillalpha
                    );
                }

                float percent = ((float)npc.life / (float)npc.lifeMax);

                for
                    (
                    float FillStart = (float)(postion.X - (float)HalfBarLong - Fill.Width);
                    FillStart < (float)((postion.X - (float)HalfBarLong - Fill.Width) + ((float)HalfBarLong * 2) * percent);
                    FillStart++)
                {
                    drawpostion = new Vector2((float)FillStart, (float)postion.Y - (float)HalfHeight);

                    Main.spriteBatch.Draw
                    (
                    Fill,
                    drawpostion,
                    barcolor * fillalpha
                    );
                }

                if (BarPlayer.LastHit != 5)
                {
                    if (lastpostion.X > endpostion.X)
                    {
                        lastpostion.X -= (float)BarConfig.Instance.LastBarDecreaseSpeed;
                    }
                    if (lastpostion.X <= endpostion.X)
                    {
                        lastpostion.X = endpostion.X;
                    }
                }
                else if (BarPlayer.LastHit == 5)
                {
                    endpostion = drawpostion;
                }
            }
        }
        public static Color GetBarColor(int Health, int MaxHealth, float alpha)
        {
            float num = (float)Health / (float)MaxHealth;
            if (num > 1f)
                num = 1f;

            float num5 = 0f;
            float num6 = 0f;
            float num7 = 0f;
            float num8 = 255f;
            num -= 0.1f;
            if ((double)num > 0.5)
            {
                num6 = 255f;
                num5 = 255f * (1f - num) * 2f;
            }
            else
            {
                num6 = 255f * num * 2f;
                num5 = 255f;
            }

            float num9 = 0.95f;
            num5 = num5 * num9;
            num6 = num6 * num9;
            num8 = num8 * num9;
            if (num5 < 0f)
                num5 = 0f;

            if (num5 > 255f)
                num5 = 255f;

            if (num6 < 0f)
                num6 = 0f;

            if (num6 > 255f)
                num6 = 255f;

            if (num8 < 0f)
                num8 = 0f;

            if (num8 > 255f)
                num8 = 255f;

            return new Color((byte)num5, (byte)num6, (byte)num7, (byte)num8);
        }

        public static NPC GetNPC(NPC npc)
        {
            return npc;
        }

        public static Texture2D GetHeadTexture(NPC npc)
        {
            Texture2D BossHead;
            switch (npc.type)
            {
                case NPCID.Golem:
                    {
                        BossHead = ModContent.Request<Texture2D>($"Terraria/Images/NPC_Head_Boss_5").Value;
                        break;
                    }

                default:
                    {
                        BossHead = TextureAssets.NpcHeadBoss[npc.GetBossHeadTextureIndex()].Value;
                        break;
                    }
            }

            return BossHead;
        }

        public static void GetBarTexture(ref Texture2D BarStart, ref Texture2D BarMid, ref Texture2D BarEnd, ref Texture2D Fill, NPC npc)
        {
            if (!BarConfig.Instance.ForceUseDefaultBar)
            {
                Fill = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                if (BarConfig.Instance.UseGoldBar)
                {
                    BarStart = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarStart_Exp").Value;
                    BarMid = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarMiddle_Exp").Value;
                    BarEnd = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarEnd_Exp").Value;
                }
                else
                {
                    BarStart = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarStart").Value;
                    BarMid = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarMiddle").Value;
                    BarEnd = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarEnd").Value;
                    Fill = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                }
            }
            else
            {
                Fill = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                if (BarConfig.Instance.UseGoldBar)
                {
                    BarStart = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarStart_Exp").Value;
                    BarMid = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarMiddle_Exp").Value;
                    BarEnd = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarEnd_Exp").Value;
                }
                else
                {
                    BarStart = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarStart").Value;
                    BarMid = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarMiddle").Value;
                    BarEnd = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarEnd").Value;
                }
            }
        }

        public static float CheckCursorOnBar(Vector2 Startposition, Vector2 Endposition, Vector2 Cursorposition, Texture2D BarEnd)
        {
            bool CanDecrease = Collision.CheckAABBvAABBCollision(Main.screenPosition + Startposition, new Vector2(Endposition.X - Startposition.X + BarEnd.Width, BarEnd.Height), Main.MouseWorld, Vector2.One);
            return CanDecrease ? 0.4F : 1F;
        }
        #endregion
    }
}
