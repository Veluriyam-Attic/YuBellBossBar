using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using Terraria;
using System.Collections;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace YuBellBossBar.Content
{
    public class BarMethod
    {
        public static void DrawBar
            (
            NPC npc
            )
        {
            try
            {
                int npctype = npc.type;

                Texture2D Start = null;
                Texture2D Mid = null;
                Texture2D End = null;
                Texture2D Fill = null;
                Texture2D Head = null;
                GetTexture(npc.type, out Start, ref Mid, ref End, out Fill, ref Head);

                Vector2 postion = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);

                int MaxHealth = BarData.BossMaxHealth[npc.type];
                int Health = BarData.BossNowHealth[npc.type];

                int StartWidth = 0;
                int HeadWidth = 0;
                int HeadHeight = 0;
                int EndWidth = 0;
                int FillStart = 0;
                int npckey = 0;
                BarMethod.GetMaxHealth(npc);
                GetValues(npc.type, out StartWidth, out HeadWidth, out HeadHeight, out EndWidth, out FillStart);

                string Name = GetBossName(npc.type);
                string Info = Name + ":" + Health.ToString() + "/" + MaxHealth.ToString() + ":" + string.Format("{0:f2}", (((float)Health / (float)MaxHealth) * 100)) + "%";

                Color? barFillColor = GetFillColor(npc.type, Health, MaxHealth);

                Vector2 Namepostion = new Vector2(FontAssets.MouseText.Value.MeasureString(Info).X / 2, FontAssets.MouseText.Value.MeasureString(Info).Y / 3);
                Vector2 FillStartPosition = postion - new Vector2(BarConfig.Instance.BarLong / 2, Fill.Height / 2);
                Vector2 StartStartPosition = FillStartPosition - new Vector2(StartWidth, 0);
                Vector2 EndStartPosition = postion + new Vector2(BarConfig.Instance.BarLong / 2 - EndWidth, Fill.Height / 2);
                Vector2 MidStartPosition = FillStartPosition + new Vector2(Start.Width, 0);
                Vector2 MidEndPosition = EndStartPosition - new Vector2(Fill.Width - FillStart, 0);

                DrawFill(FillStartPosition, EndStartPosition, Fill, FillStart, (Color)barFillColor);
                Main.NewText(Main.screenPosition.X.ToString() + "  " + Main.MouseScreen.X.ToString());
                Main.NewText("Loaded!");
            }
            catch (Exception)
            {
                Main.NewText("There's a Exception! Show it to 虞悖(Yu Bell)!");
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
                return -1;
            }
            catch (Exception)
            {
                Console.WriteLine("The NPC Array is NOW conforming!");
                return 0;
            }
        }

        public static void GetTexture(int npcType, out Texture2D BarStart, ref Texture2D BarMid, ref Texture2D BarEnd, out Texture2D BarFill, ref Texture2D BossHead)
        {
            try
            {
                if (BarData.BarTexture.Keys.Contains(npcType) && !(BarConfig.Instance.ForceUseDefaultBar))
                {
                    Main.NewText("True!");
                    Main.NewText("NPC Type is :" + npcType);
                    Texture2D[] NowBarArray = BarData.BarTexture[npcType];
                    Main.NewText("Height Should be : " + ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/KingSlimeFill").Value.Height);
                    Main.NewText("Height Actually be : " + NowBarArray[3].Height);
                    BarStart = NowBarArray[0];
                    BarMid = NowBarArray[1];
                    BarEnd = NowBarArray[2];
                    BarFill = NowBarArray[3];
                    BossHead = NowBarArray[4];
                    if (BarStart == null)
                    {
                        BarStart = BarData.BarTexture[BarConfig.Instance.UseGoldBar ? -1 : -2][0];
                    }
                    if (BarMid == null)
                    {
                        BarMid = BarData.BarTexture[BarConfig.Instance.UseGoldBar ? -1 : -2][1];
                    }
                    if (BarEnd == null)
                    {
                        BarEnd = BarData.BarTexture[BarConfig.Instance.UseGoldBar ? -1 : -2][2];
                    }
                    if (BarFill == null)
                    {
                        BarFill = BarData.BarTexture[BarConfig.Instance.UseGoldBar ? -1 : -2][3];
                    }
                    if (BossHead == null)
                    {
                        BossHead = TextureAssets.NpcHeadBoss[2].Value;
                    }
                }
                else
                {
                    Main.NewText("Flase!");
                    Texture2D[] DefaultTexture;
                    BarData.BarTexture.TryGetValue(BarConfig.Instance.UseGoldBar ? -1 : -2, out DefaultTexture);

                    BarStart = DefaultTexture[0];
                    BarMid = DefaultTexture[1];
                    BarEnd = DefaultTexture[2];
                    BarFill = DefaultTexture[3];
                    BossHead = DefaultTexture[4];
                    if (BossHead == null)
                    {
                        BossHead = TextureAssets.NpcHeadBoss[Main.npc[npcType].GetBossHeadTextureIndex()].Value;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The Texture Array is NOT conforming!");
                BarStart = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                BarMid = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                BarEnd = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                BarFill = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
                BossHead = ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value;
            }
        }

        public static Color? GetFillColor(int npcType,int health,int maxhealth)
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
                        return GetDefaultBarColor(health,maxhealth);
                    }
                }
                else
                {
                    return GetDefaultBarColor(health,maxhealth);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Can't Get Bar Color!");
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
                return Lang.GetNPCName(npc).Value;
            }
        }

        public static void GetValues(int npc, out int StartWidth,out int HeadWidth,out int HeadHeight,out int EndWidth,out int FillStart)
        {
            StartWidth = BarData.CutLength[npc][0];
            HeadWidth = BarData.CutLength[npc][1];
            HeadHeight = BarData.CutLength[npc][2];
            EndWidth = BarData.CutLength[npc][3];
            FillStart = BarData.CutLength[npc][4];
            //StartWidth = 48;
            //HeadWidth = 20;
            //HeadHeight = 28;
            //EndWidth = 26;
            //FillStart = 30;
        }

        public static void DrawFill(Vector2 FillStartPosition,Vector2 EndStartPosition, Texture2D Fill,int FillStart,Color barFillColor)
        {

            Vector2 postion = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);


            //Main.spriteBatch.Draw(ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value, postion, Color.Purple);


            Main.spriteBatch.Draw
                (
                ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value,
                FillStartPosition,
                new Rectangle(0, 0, FillStart, Fill
                .Height),
                barFillColor,
                0,
                Vector2.Zero,
                new Vector2(((float)EndStartPosition.X - (float)FillStartPosition.X) / (float)FillStart, 1f),
                SpriteEffects.None
                ,0
                );
        }


        public static int GetMaxHealth(NPC npc)
        {

            int sumhealth = 0;
            int nowhealth = 0;
            sumhealth = 0;
            var x = 0;
            int key = 0;
            foreach(int eachnpc in BarData.BarNPCContain.Keys)
            {
                //sumhealth = 0;
                foreach (NPC npcs in Main.npc)
                {
                    if (BarData.BarNPCContain[eachnpc].Contains(npcs.type))
                    {
                        sumhealth += npcs.lifeMax;
                        nowhealth = npc.life;
                        BarData.BossMaxHealth[eachnpc] = sumhealth;
                        x = BarData.BossMaxHealth[npc.type];
                        key = eachnpc;
                    }
                }
            }

            Main.NewText("Health:" + x + " /npc:" + npc.type.ToString()+" /return:" + x.ToString());
            return key;
        }
    }
}
