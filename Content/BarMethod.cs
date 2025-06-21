using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using System.Linq;
using ReLogic.Content;
using System;
using Terraria.ID;
using Terraria.Localization;

namespace YuBellBossBar.Content
{
    public class BarMethod
    {
        public static void DrawBar(NPC npc)
        {
            try
            {
                int npctype = npc.type;

                int truetype = GetNPC(npctype);

                Texture2D Start = null;
                Texture2D Mid = null;
                Texture2D End = null;
                Texture2D Fill = null;
                Texture2D Head = null;
                GetTexture(truetype, ref Start, ref Mid, ref End, ref Fill, ref Head, npc);

                Vector2 postion = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);

                GetMaxHealth(truetype);
                int MaxHealth;
                BarData.BossMaxHealth.TryGetValue(truetype, out MaxHealth);
                int Health;
                BarData.BossNowHealth.TryGetValue(truetype, out Health);
                float percent = (float)Health / (float)MaxHealth;


                int StartWidth = 0;
                int HeadWidth = 0;
                int HeadHeight = 0;
                int EndWidth = 0;
                int FillStart = 0;
                int npckey = 0;
                GetValues(truetype, ref StartWidth, ref HeadWidth, ref HeadHeight, ref EndWidth, ref FillStart);

                string Name = GetBossName(npc.type);
                string Info = Name + " : " + Health.ToString() + "/" + MaxHealth.ToString() + " : [" + string.Format("{0:f2}", (percent * 100)) + "%]";

                Color barFillColor = (Color)GetFillColor(truetype, Health, MaxHealth);

                Vector2 Namepostion = new Vector2(FontAssets.MouseText.Value.MeasureString(Info).X / 2, FontAssets.MouseText.Value.MeasureString(Info).Y / 3);
                Vector2 FillStartPosition = postion - new Vector2(BarConfig.Instance.BarLong / 2, Fill.Height / 2);
                Vector2 StartStartPosition = FillStartPosition - new Vector2(StartWidth, 0);
                Vector2 EndStartPosition = postion + new Vector2(BarConfig.Instance.BarLong / 2 - EndWidth, -(Fill.Height / 2));
                Vector2 MidStartPosition = StartStartPosition + new Vector2(Start.Width, 0);
                Vector2 MidEndPosition = EndStartPosition - new Vector2(Fill.Width - FillStart, 0);
                float alpha = CheckDown(StartStartPosition, End, EndStartPosition);

                DrawFill(FillStartPosition, EndStartPosition, Fill, FillStart, (Color)barFillColor, percent, EndWidth, alpha, truetype);
                DrawBarFrame(Start, Mid, End, StartStartPosition, EndStartPosition, FillStartPosition, MidStartPosition, Head, HeadWidth, HeadHeight, truetype, alpha);
                DrawBarInfo(Info, postion, barFillColor, alpha,npc,Name);
                DrawMoreInfo(npc,StartStartPosition,EndStartPosition,postion,Fill,End);
            }
            catch (Exception)
            {
                return;
            }
        }

        public static Color GetDefaultBarColor(int Health, int MaxHealth)
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

        public static int GetNPC(int npcType)
        {
            try
            {
                foreach (var npcs in BarData.BarNPCContain.Keys)
                {
                    int[] npc;
                    BarData.BarNPCContain.TryGetValue(npcs, out npc);
                    if (npc.Contains(npcType))
                    {
                        return npcs;
                    }
                }
                return npcType;
            }
            catch (Exception)
            {
                return npcType;
            }
        }

        public static void GetTexture(int npcType, ref Texture2D BarStart, ref Texture2D BarMid, ref Texture2D BarEnd, ref Texture2D BarFill, ref Texture2D BossHead, NPC npc)
        {
            try
            {
                if (BarData.BarTexture.Keys.Contains(npcType) && !(BarConfig.Instance.ForceUseDefaultBar))
                {
                    Asset<Texture2D>[] NowBarArray = BarData.BarTexture[npcType];

                    if (NowBarArray != null)
                    {
                        if (NowBarArray[0] != null) 
                        {
                            BarStart = NowBarArray[0].Value;
                        }
                        else
                        {
                            BarStart = BarData.BarTexture[BarConfig.Instance.UseGoldBar ? int.MaxValue : int.MinValue][0].Value;
                        }
                        if (NowBarArray[1] != null)
                        {
                            BarMid = NowBarArray[1].Value;
                        }
                        else
                        {
                            BarMid = BarData.BarTexture[BarConfig.Instance.UseGoldBar ? int.MaxValue : int.MinValue][1].Value;
                        }
                        if (NowBarArray[2] != null)
                        {
                            BarEnd = NowBarArray[2].Value;
                        }
                        else
                        {
                            BarEnd = BarData.BarTexture[BarConfig.Instance.UseGoldBar ? int.MaxValue : int.MinValue][2].Value;
                        }
                        if (NowBarArray[3] != null)
                        {
                            BarFill = NowBarArray[3].Value;
                        }
                        else
                        {
                            BarFill = BarData.BarTexture[BarConfig.Instance.UseGoldBar ? int.MaxValue : int.MinValue][3].Value;
                        }
                        if (NowBarArray[4] != null)
                        {
                            BossHead = NowBarArray[4].Value;
                        }
                        else
                        {
                            BossHead = TextureAssets.NpcHeadBoss[npc.GetBossHeadTextureIndex()].Value;
                        }
                    }
                    else
                    {
                        Asset<Texture2D>[] DefaultTexture;
                        BarData.BarTexture.TryGetValue(BarConfig.Instance.UseGoldBar ? int.MaxValue : int.MinValue, out DefaultTexture);

                        BarStart = DefaultTexture[0].Value;
                        BarMid = DefaultTexture[1].Value;
                        BarEnd = DefaultTexture[2].Value;
                        BarFill = DefaultTexture[3].Value;
                        BossHead = TextureAssets.NpcHeadBoss[Main.npc[npcType].GetBossHeadTextureIndex()].Value;

                        return;
                    }

                }
                else
                {
                    Asset<Texture2D>[] DefaultTexture;
                    BarData.BarTexture.TryGetValue(BarConfig.Instance.UseGoldBar ? int.MaxValue : int.MinValue, out DefaultTexture);


                    BarStart = DefaultTexture[0].Value;
                    BarMid = DefaultTexture[1].Value;
                    BarEnd = DefaultTexture[2].Value;
                    BarFill = DefaultTexture[3].Value;
                    BossHead = TextureAssets.NpcHeadBoss[npc.GetBossHeadTextureIndex()].Value;

                    return;
                }
            }
            catch (Exception)
            {
                return;
                BarStart = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                BarMid = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                BarEnd = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                BarFill = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                BossHead = TextureAssets.NpcHeadBoss[npc.GetBossHeadTextureIndex()].Value;
            }
        }

        public static Color? GetFillColor(int npcType, int health, int maxhealth)
        {
            try
            {
                Color? outValue;
                if (BarData.BarColor.Keys.Contains(npcType))
                {
                    BarData.BarColor.TryGetValue(npcType, out outValue);
                    if (outValue != null)
                    {
                        return outValue;
                    }
                    else
                    {
                        return GetDefaultBarColor(health, maxhealth);
                    }
                }
                else
                {
                    return GetDefaultBarColor(health, maxhealth);
                }
            }
            catch (Exception)
            {
                return Color.White;
            }
        }

        public static string GetBossName(int npc)
        {
            if (BarData.BossName.Keys.Contains(npc))
            {
                return BarData.BossName[npc];
            }
            else
            {
                return Lang.GetNPCName(npc).ToString();
            }
        }

        public static void GetValues(int npc, ref int StartWidth, ref int HeadWidth, ref int HeadHeight, ref int EndWidth, ref int FillStart)
        {
            try
            {
                if (BarData.CutLength.Keys.Contains(npc) && !BarConfig.Instance.ForceUseDefaultBar)
                {
                    StartWidth = BarData.CutLength[npc][0];
                    HeadWidth = BarData.CutLength[npc][1];
                    HeadHeight = BarData.CutLength[npc][2];
                    EndWidth = BarData.CutLength[npc][3];
                    FillStart = BarData.CutLength[npc][4];
                }
                else
                {
                    StartWidth = BarData.CutLength[int.MinValue][0];
                    HeadWidth = BarData.CutLength[int.MinValue][1];
                    HeadHeight = BarData.CutLength[int.MinValue][2];
                    EndWidth = BarData.CutLength[int.MinValue][3];
                    FillStart = BarData.CutLength[int.MinValue][4];
                }
            }
            catch
            {
                return;
            }
        }

        public static float lastpostion = 0;
        public static float endpostion = 0;

        public static void DrawFill(Vector2 FillStartPosition, Vector2 EndStartPosition, Texture2D Fill, int FillStart, Color barFillColor, float percent, int EndWidth, float alpha, int type)
        {
            Vector2 postion = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);

            float FillX = EndWidth - Fill.Width;

            if (BarConfig.Instance.DrawLastBar)
            {

                bool a = (type == NPCID.DD2OgreT2 || type == NPCID.DD2OgreT3 || type == NPCID.DD2DarkMageT1 || type == NPCID.DD2DarkMageT3 || type == NPCID.DD2Betsy);
                if (!a)
                {
                    Main.spriteBatch.Draw
                    (
                    Fill,
                    FillStartPosition,
                    new Rectangle(0, 0, FillStart, Fill.Height),
                    barFillColor * alpha * 0.7f,
                    0,
                    Vector2.Zero,
                    new Vector2((lastpostion - FillStartPosition.X) / FillStart, 1f),
                    SpriteEffects.None
                    , 0
                    );
                    Main.spriteBatch.Draw
                    (
                    Fill,
                    new Vector2(lastpostion, FillStartPosition.Y),
                    null,
                    barFillColor * alpha * 0.7f,
                    0,
                    Vector2.Zero,
                    1f,
                    SpriteEffects.None
                    , 0
                    );
                }
                else
                {

                    Main.spriteBatch.Draw
                    (
                    Fill,
                    FillStartPosition,
                    new Rectangle(0, 0, FillStart, Fill.Height),
                    barFillColor * alpha * 0.7f,
                    0,
                    Vector2.Zero,
                    new Vector2((lastpostion - FillStartPosition.X + Fill.Width - FillStart) / FillStart, 1f),
                    SpriteEffects.None
                    , 0
                    );
                    Main.spriteBatch.Draw
                    (
                    Fill,
                    new Vector2(lastpostion, FillStartPosition.Y),
                    new Rectangle(FillStart, 0, Fill.Width - FillStart, Fill.Height),
                    barFillColor * alpha * 0.7f,
                    0,
                    Vector2.Zero,
                    1f,
                    SpriteEffects.None
                    , 0
                    );
                }
                if (BarPlayer.LastHit != 5)
                {
                    if (lastpostion > endpostion)
                    {
                        lastpostion -= (float)BarConfig.Instance.LastBarDecreaseSpeed;
                    }
                    if (lastpostion <= endpostion)
                    {
                        lastpostion = endpostion;
                    }
                }
                else if (BarPlayer.LastHit == 5)
                {
                    endpostion = FillStartPosition.X - Fill.Width + ((EndStartPosition.X + (float)FillX - FillStartPosition.X + Fill.Width) * percent);
                }
            }

            

            bool condition = (type == NPCID.DD2OgreT2 || type == NPCID.DD2OgreT3 || type == NPCID.DD2DarkMageT1 || type == NPCID.DD2DarkMageT3 || type == NPCID.DD2Betsy);
            if (!condition)
            {
                Main.spriteBatch.Draw
                (
                Fill,
                FillStartPosition - new Vector2(Fill.Width, 0),
                new Rectangle(0, 0, FillStart, Fill.Height),
                barFillColor * alpha,
                0,
                Vector2.Zero,
                new Vector2((EndStartPosition.X + (float)FillX - FillStartPosition.X + Fill.Width) * percent / FillStart, 1f),
                SpriteEffects.None
                , 0
                );

                Main.spriteBatch.Draw
                (
                Fill,
                new Vector2(FillStartPosition.X - Fill.Width + ((EndStartPosition.X + (float)FillX - FillStartPosition.X + Fill.Width) * percent), FillStartPosition.Y),
                null,
                barFillColor * alpha,
                0,
                Vector2.Zero,
                1f,
                SpriteEffects.None
                , 0
                );
            }
            else
            {
                Main.spriteBatch.Draw
                (
                Fill,
                FillStartPosition,
                new Rectangle(0, 0, FillStart, Fill.Height),
                barFillColor * alpha,
                0,
                Vector2.Zero,
                new Vector2((EndStartPosition.X + (float)FillX - FillStartPosition.X + Fill.Width) * percent / FillStart, 1f),
                SpriteEffects.None
                , 0
                );

                Main.spriteBatch.Draw
                (
                Fill,
                new Vector2(FillStartPosition.X - Fill.Width + FillStart + ((EndStartPosition.X + (float)FillX - FillStartPosition.X + Fill.Width) * percent), FillStartPosition.Y),
                new Rectangle(FillStart,0,Fill.Width -FillStart,Fill.Height),
                barFillColor * alpha,
                0,
                Vector2.Zero,
                1f,
                SpriteEffects.None
                , 0
                );
            }

        }


        public static void GetMaxHealth(int type)
        {

            int sumhealth = 0;
            int nowhealth = 0;
            sumhealth = 0;
            //foreach (int eachnpc in BarData.BarNPCContain.Keys)
            try
            {
                //sumhealth = 0;
                foreach (NPC npcs in Main.npc)
                {
                    if (BarData.BarNPCContain.Keys.Contains(type))
                    {
                        if (BarData.BarNPCContain[type].Contains(npcs.type) && npcs.type != NPCID.MoonLordHead && npcs.type != NPCID.MoonLordHand)
                        {
                            sumhealth += npcs.lifeMax;
                            if (npcs.life >= 0)
                            {
                                nowhealth += npcs.life;
                            }
                            if (BarData.BossMaxHealth[type] <= sumhealth)
                            {
                                BarData.BossMaxHealth[type] = sumhealth;
                            }
                            BarData.BossNowHealth[type] = nowhealth;
                        }
                        else if(BarData.BarNPCContain[type].Contains(npcs.type) && ( npcs.type == NPCID.MoonLordHand || npcs.type == NPCID.MoonLordHead) && npcs.life < npcs.lifeMax)
                        {
                            sumhealth += npcs.lifeMax;
                            if (npcs.life >= 0)
                            {
                                nowhealth += npcs.life;
                            }
                            if (BarData.BossMaxHealth[type] <= sumhealth)
                            {
                                BarData.BossMaxHealth[type] = sumhealth;
                            }
                            BarData.BossNowHealth[type] = nowhealth;
                        }

                        else
                        {

                            BarData.BossMaxHealth.TryAdd(type, npcs.lifeMax);
                            BarData.BossNowHealth.TryAdd(type, npcs.life);

                        }
                    }
                    else
                    {
                        BarData.BarNPCContain.Add(type, [type]);
                        BarData.BossMaxHealth.TryAdd(type, npcs.lifeMax);
                        BarData.BossNowHealth.TryAdd(type, npcs.life);
                    }
                }
                //Main.NewText(nowhealth);
            }
            catch
            {
                //Main.NewText("Yeah!");
                return;
            }

            //Main.NewText("Health:" + x + " / Health now;" + BarData.BossNowHealth[type] + " /npc:" + type.ToString() + " /return:" + x.ToString());
            return;
        }

        public static void DrawBarFrame(Texture2D Start, Texture2D Mid, Texture2D End, Vector2 StartStartPosition, Vector2 EndStartPosition, Vector2 FillStartPosition, Vector2 MidStartPosition, Texture2D Head, int HeadWidth, int HeadHeight, int type, float alpha)
        {
            bool boolen;
            try
            {
                BarData.Midwidth.TryGetValue(type, out boolen);
                if (boolen)
                {
                    for (float i = MidStartPosition.X; i < EndStartPosition.X; i += Mid.Width)
                    {
                        Main.spriteBatch.Draw(
                            Mid,
                            new Vector2(i, MidStartPosition.Y),
                            sourceRectangle: null,
                            Color.White * alpha,
                             0,
                            Vector2.Zero,
                             1f,
                            SpriteEffects.None,
                            0
                            );
                    }
                }
                else
                {
                    Main.spriteBatch.Draw(
                    Mid,
                    MidStartPosition,
                    null,
                    Color.White * alpha,
                    0,
                    Vector2.Zero,
                     new Vector2((EndStartPosition.X - StartStartPosition.X - (float)Start.Width) / (float)Mid.Width, 1f),
                    SpriteEffects.None, 0
                    );
                }

                Main.spriteBatch.Draw(Start, StartStartPosition, Color.White * alpha);
                Main.spriteBatch.Draw(End, EndStartPosition, Color.White * alpha);

                if(Head != null)
                {
                    Main.spriteBatch.Draw(
                    Head,
                    StartStartPosition + new Vector2(HeadWidth - (Head.Width / 2), HeadHeight - (Head.Height / 2)),
                    Color.White * alpha
                    );
                }

                
            }
            catch
            {
                return;
            }

        }

        public static void DrawBarInfo(string Info, Vector2 postion, Color color, float alpha,NPC npc,string Name)
        {
            if (!npc.dontTakeDamage)
            {
                Vector2 Namepostion = new Vector2(FontAssets.MouseText.Value.MeasureString(Info).X / 2, FontAssets.MouseText.Value.MeasureString(Info).Y / 3);
                Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Info, postion - Namepostion + new Vector2(1, 1), Color.Black * alpha);
                Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Info, postion - Namepostion + new Vector2(-1, 1), Color.Black * alpha);
                Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Info, postion - Namepostion + new Vector2(-1, -1), Color.Black * alpha);
                Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Info, postion - Namepostion + new Vector2(1, -1), Color.Black * alpha);
                Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Info, postion - Namepostion, Color.White * alpha);
            }
            else
            {
                string Invincible = "["+Name + " : " + Language.GetTextValue($"Mods.YuBellBossBar.Invincible") + "]";
                Vector2 Namepostion = new Vector2(FontAssets.MouseText.Value.MeasureString(Invincible).X / 2, FontAssets.MouseText.Value.MeasureString(Invincible).Y / 3);
                Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Invincible, postion - Namepostion + new Vector2(1, 1), Color.Black * alpha);
                Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Invincible, postion - Namepostion + new Vector2(-1, 1), Color.Black * alpha);
                Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Invincible, postion - Namepostion + new Vector2(-1, -1), Color.Black * alpha);
                Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Invincible, postion - Namepostion + new Vector2(1, -1), Color.Black * alpha);
                Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Invincible, postion - Namepostion, Color.White * alpha);
            }

        }

        public static float CheckDown(Vector2 StartStartPosition, Texture2D End, Vector2 EndStartPosition)
        {

            if (!(Collision.CheckAABBvAABBCollision(Main.MouseScreen, Vector2.One, StartStartPosition, new Vector2(EndStartPosition.X + End.Width - StartStartPosition.X, EndStartPosition.Y + End.Height - StartStartPosition.Y))))
            {
                return 1f;
            }
            else
            {
                return 0.5f;
            }
        }

        public static void DrawMoreInfo(NPC npc,Vector2 StartStartPosition,Vector2 EndStartPosition,Vector2 postion,Texture2D Fill,Texture2D End)
        {
            if (BarConfig.Instance.MoreInfo)
            {
                Texture2D Defense = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Info/Defense").Value;
                Texture2D Damage = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Info/Damage").Value;
                Texture2D Target = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Info/Target").Value;
                Texture2D CalDR = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Info/CalDR").Value;
                Texture2D FarDR = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Info/FarDR").Value;

                {
                    Vector2 defense = new Vector2(StartStartPosition.X + Defense.Width, StartStartPosition.Y - (Defense.Height / 2));
                    Vector2 detext = new Vector2( -5f , FontAssets.MouseText.Value.MeasureString(npc.defense.ToString()).Y / 3);

                    Main.spriteBatch.Draw(Defense, new Vector2(StartStartPosition.X, StartStartPosition.Y - Defense.Height), Color.White);
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, npc.defense.ToString(), defense - detext + new Vector2(1,1), Color.Black);
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, npc.defense.ToString(), defense - detext + new Vector2(-1,1), Color.Black);
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, npc.defense.ToString(), defense - detext + new Vector2(-1, -1), Color.
                        Black);
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, npc.defense.ToString(), defense - detext + new Vector2(1,-1), Color.Black);

                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, npc.defense.ToString(), defense - detext, Color.White);
                }

                {
                    Vector2 damage = new Vector2(EndStartPosition.X + End.Width - Damage.Width - 10f,EndStartPosition.Y - (Damage.Height / 2));
                    Vector2 datext = new Vector2(FontAssets.MouseText.Value.MeasureString(npc.damage.ToString()).X, FontAssets.MouseText.Value.MeasureString(npc.damage.ToString()).Y / 3);
                    Main.spriteBatch.Draw(Damage,new Vector2(EndStartPosition.X + End.Width - Damage.Width,EndStartPosition.Y - Damage.Height ),Color.White);

                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, npc.damage.ToString(), damage - datext + new Vector2(1, 1), Color.Black);
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, npc.damage.ToString(), damage - datext + new Vector2(-1, 1), Color.Black);
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, npc.damage.ToString(), damage - datext + new Vector2(1, -1), Color.Black);
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, npc.damage.ToString(), damage - datext + new Vector2(-1, -1), Color.Black);

                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, npc.damage.ToString(),damage - datext, Color.White);
                }

                {
                    Vector2 target = new Vector2(postion.X, postion.Y-((Fill.Height + Target.Height) / 2));
                    Vector2 tatext = new Vector2(FontAssets.MouseText.Value.MeasureString(Main.player[npc.target].name).X / 2, FontAssets.MouseText.Value.MeasureString(Main.player[npc.target].name).Y / 3);

                    Main.spriteBatch.Draw(Target, target + new Vector2(-(Target.Width / 2), -Target.Width / 2), Color.White);
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Main.player[npc.target].name, target - tatext + new Vector2(1, 1), Color.Black);
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Main.player[npc.target].name, target - tatext + new Vector2(-1, 1), Color.Black);
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Main.player[npc.target].name, target - tatext + new Vector2(1, -1), Color.Black);
                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Main.player[npc.target].name, target - tatext + new Vector2(-1, -1), Color.Black);

                    Main.spriteBatch.DrawString(FontAssets.MouseText.Value, Main.player[npc.target].name, target - tatext, Color.White);
                }
            }
        }
    }
}
