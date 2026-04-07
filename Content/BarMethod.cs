using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

//the name of the mod is a joke
namespace YuBellBossBar.Content;

public class BarMethod
{
    public static Texture2D GetHead(NPC npc)
	{
        int headSlot = npc.GetBossHeadTextureIndex();

        if (headSlot > -1)
        {
            try
            {
                return (Texture2D)TextureAssets.NpcHeadBoss[headSlot];
            }
            catch
            {
                return null;
            }
        }
		else
		{
			try
			{
				if (BarData.BarTexture.Keys.Contains(npc.type))
				{
                    Asset<Texture2D>[] NowBarArray = BarData.BarTexture[npc.type];

                    if (NowBarArray != null)
                    {
                        if (NowBarArray[4] != null)
                        {
                            return NowBarArray[4].Value;
                        }
                    }
                }
				else
				{
					return null;
				}

            }
			catch
			{
				return null;
			}

        }

		return null;
    }

    public static void DrawBar(NPC npc, int offset, int health, int maxHealth, float barOffset, int segmentsLeft)
	{
		try
		{
			int truetype = npc.type;
            Texture2D Start = null;
            Texture2D Mid = null;
            Texture2D End = null;
            Texture2D Fill = null;
            Texture2D Head = GetHead(npc);
			Texture2D BarBackground = null;
			BarMethod.GetTexture(truetype, ref Start, ref Mid, ref End, ref Fill, ref BarBackground, npc);
            Vector2 postion = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2(BarConfig.Instance.BarPostionX, 0f - (BarConfig.Instance.BarPostionY + barOffset));
			int Health = npc.life;
			int MaxHealth = npc.lifeMax;

            if (health != 0)
            {
                Health = health;
                MaxHealth = maxHealth;
            }

            float percent = (float)Health / (float)MaxHealth;
            int StartWidth = 0;
            int HeadWidth = 0;
            int HeadHeight = 0;
            int EndWidth = 0;
            int FillStart = 0;

            BarMethod.GetValues(truetype, ref StartWidth, ref HeadWidth, ref HeadHeight, ref EndWidth, ref FillStart);
            string Name = BarMethod.GetBossName(npc.type);
            string PerHP = " : [" + $"{percent * 100f:f2}" + "%]";
            string Info = Name + " : " + Health + "/" + MaxHealth + (BarConfig.Instance.ShowHealthPercentage ? PerHP : "");
            if (npc.dontTakeDamage)
            {
                Info = Info + " (Invincible)";
            }

			if (segmentsLeft != 0)
			{
				Info = Info + $" ({segmentsLeft} Segments Left)";
			}

            Color barFillColor = BarMethod.GetFillColor(truetype, Health, MaxHealth).Value;
            new Vector2(FontAssets.MouseText.Value.MeasureString(Info).X / 2f, FontAssets.MouseText.Value.MeasureString(Info).Y / 3f);
            Vector2 FillStartPosition = postion - new Vector2(BarConfig.Instance.BarLong / 2, Fill.Height / 2);
            Vector2 StartStartPosition = FillStartPosition - new Vector2(StartWidth, 0f);
            Vector2 EndStartPosition = postion + new Vector2(BarConfig.Instance.BarLong / 2 - EndWidth, -(Fill.Height / 2));
            Vector2 MidStartPosition = StartStartPosition + new Vector2(Start.Width, 0f);
            _ = EndStartPosition - new Vector2(Fill.Width - FillStart, 0f);
            float alpha = BarMethod.CheckDown(StartStartPosition, End, EndStartPosition);
            BarMethod.DrawFill(FillStartPosition, EndStartPosition, Fill, BarBackground, FillStart, barFillColor, percent, EndWidth, alpha, truetype, ref npc.GetGlobalNPC<BarNPC>().lastPositon, ref npc.GetGlobalNPC<BarNPC>().endPosition, ref npc.GetGlobalNPC<BarNPC>().LastHit);
            BarMethod.DrawBarFrame(Start, Mid, End, StartStartPosition, EndStartPosition, FillStartPosition, MidStartPosition, truetype, alpha);
            BarMethod.DrawBarInfo(Info, postion, barFillColor, alpha, npc, Name);
            BarMethod.DrawMoreInfo(npc, StartStartPosition, EndStartPosition, postion, Fill, End);


			DrawHead(Start, Mid, End, StartStartPosition, EndStartPosition, FillStartPosition, MidStartPosition, Head, HeadWidth, HeadHeight, truetype, alpha);
        }
		catch (Exception)
		{
		}
	}

	public static Color GetDefaultBarColor(int Health, int MaxHealth)
	{
		float num = (float)Health / (float)MaxHealth;
		if (num > 1f)
		{
			num = 1f;
		}
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
		num5 *= num9;
		num6 *= num9;
		num8 *= num9;
		if (num5 < 0f)
		{
			num5 = 0f;
		}
		if (num5 > 255f)
		{
			num5 = 255f;
		}
		if (num6 < 0f)
		{
			num6 = 0f;
		}
		if (num6 > 255f)
		{
			num6 = 255f;
		}
		if (num8 < 0f)
		{
			num8 = 0f;
		}
		if (num8 > 255f)
		{
			num8 = 255f;
		}
		return new Color((byte)num5, (byte)num6, (byte)num7, (byte)num8);
	}

	public static void GetTexture(int npcType, ref Texture2D BarStart, ref Texture2D BarMid, ref Texture2D BarEnd, ref Texture2D BarFill, ref Texture2D BarBackground, NPC npc)
	{
		try
		{
            int index = int.MinValue;

            if (BarConfig.Instance.UseGoldBar && Main.expertMode)
            {
                index = int.MaxValue;
            }

            if (BarConfig.Instance.UseGoldBar && Main.masterMode)
            {
                index = int.MaxValue - 1;
            }

            if (BarData.BarTexture.Keys.Contains(npcType) && !BarConfig.Instance.ForceUseDefaultBar)
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
						BarStart = BarData.BarTexture[index][0].Value;
					}
					if (NowBarArray[1] != null)
					{
						BarMid = NowBarArray[1].Value;
					}
					else
					{
						BarMid = BarData.BarTexture[index][1].Value;
					}
					if (NowBarArray[2] != null)
					{
						BarEnd = NowBarArray[2].Value;
					}
					else
					{
						BarEnd = BarData.BarTexture[index][2].Value;
					}
					if (NowBarArray[3] != null)
					{
						BarFill = NowBarArray[3].Value;
					}
					else
					{
						BarFill = BarData.BarTexture[index][3].Value;
					}

                    if (NowBarArray[5] != null)
                    {
                        BarBackground = NowBarArray[5].Value;
                    }
                    else
                    {
                        BarBackground = BarFill;
                    }

                    if (npcType == NPCID.HallowBoss && !Main.dayTime)
					{
						BarFill = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/EmpressNightFill").Value;
                        BarBackground = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/EmpressNightBackground").Value;
                    }

                }
				else
				{
					BarData.BarTexture.TryGetValue(index, out var DefaultTexture);
					BarStart = DefaultTexture[0].Value;
					BarMid = DefaultTexture[1].Value;
					BarEnd = DefaultTexture[2].Value;
					BarFill = DefaultTexture[3].Value;
                    BarBackground = DefaultTexture[5].Value;
                }
			}
			else
			{
				BarData.BarTexture.TryGetValue(index, out var DefaultTexture2);
				BarStart = DefaultTexture2[0].Value;
				BarMid = DefaultTexture2[1].Value;
				BarEnd = DefaultTexture2[2].Value;
				BarFill = DefaultTexture2[3].Value;
                BarBackground = DefaultTexture2[5].Value;
            }
		}
		catch (Exception)
		{
		}
	}

	public static Color? GetFillColor(int npcType, int health, int maxhealth)
	{
		try
		{
			if (BarData.BarColor.Keys.Contains(npcType) && !BarConfig.Instance.ForceUseDefaultBar)
			{
				BarData.BarColor.TryGetValue(npcType, out var outValue);
				return outValue ?? new Color?(BarMethod.GetDefaultBarColor(health, maxhealth));
			}
			return BarMethod.GetDefaultBarColor(health, maxhealth);
		}
		catch (Exception)
		{
			return Color.White;
		}
	}

	public static string GetBossName(int npc)
	{
		return Lang.GetNPCName(npc).ToString();
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
		}
	}

	public static Color GetBackgroundColor(int npc, Color colorOfBar)
	{
        Color genericBackground = Color.Lerp(Color.Black, colorOfBar, 0.3f);
        try
        {
            if (BarData.BackgroundColor.Keys.Contains(npc) && !BarConfig.Instance.ForceUseDefaultBar)
            {
                BarData.BackgroundColor.TryGetValue(npc, out var outValue);

                return outValue ?? genericBackground;
            }
        }
        catch (Exception)
        {
            return genericBackground;
        }

        return genericBackground;
    }

	public static void DrawFill(Vector2 FillStartPosition, Vector2 EndStartPosition, Texture2D Fill, Texture2D BarBackground, int FillStart, Color barFillColor, float percent, int EndWidth, float alpha, int type, ref float lastpostion, ref float endpostion, ref int lastHit)
	{
		_ = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2(BarConfig.Instance.BarPostionX, 0f - (float)BarConfig.Instance.BarPostionY - 40f);
		float FillX = EndWidth - Fill.Width;

        if (BarConfig.Instance.DrawBarBackgrounds && BarBackground != null)
        {
			Color bgColor = GetBackgroundColor(type, barFillColor);

            float BackgroundX = EndWidth - BarBackground.Width;
            float realEnd2 = FillStartPosition.X - (float)BarBackground.Width + (EndStartPosition.X + BackgroundX - FillStartPosition.X + (float)BarBackground.Width) * 1;
            Main.spriteBatch.Draw(BarBackground, FillStartPosition, new Rectangle(0, 0, FillStart, BarBackground.Height), bgColor * alpha, 0f, Vector2.Zero, new Vector2((realEnd2 - EndWidth + FillStart + (BackgroundX) - FillStartPosition.X + (float)BarBackground.Width - (float)FillStart) / (float)FillStart, 1f), SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(BarBackground, new Vector2(realEnd2, FillStartPosition.Y), new Rectangle(FillStart, 0, BarBackground.Width - FillStart, BarBackground.Height), bgColor * alpha, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        if (BarConfig.Instance.DrawLastBar)
		{
			//draw transparency bar
            Main.spriteBatch.Draw(Fill, FillStartPosition, new Rectangle(0, 0, FillStart, Fill.Height), barFillColor * alpha * 0.7f, 0f, Vector2.Zero, new Vector2((lastpostion - EndWidth + FillStart + (FillX) - FillStartPosition.X + (float)Fill.Width - (float)FillStart) / (float)FillStart, 1f), SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(Fill, new Vector2(lastpostion, FillStartPosition.Y), new Rectangle(FillStart, 0, Fill.Width - FillStart, Fill.Height), barFillColor * alpha * 0.7f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            if (lastHit != BarConfig.Instance.TransparencyBarDecreaseTime)
			{
				if (lastpostion > endpostion)
				{
					lastpostion -= BarConfig.Instance.LastBarDecreaseSpeed;
				}
				if (lastpostion <= endpostion)
				{
					lastpostion = endpostion;
				}
			}
			else if (lastHit == BarConfig.Instance.TransparencyBarDecreaseTime)
			{
				endpostion = FillStartPosition.X - (float)Fill.Width + (EndStartPosition.X + FillX - FillStartPosition.X + (float)Fill.Width) * percent;
			}
		}


		//draw real bar
        float realEnd = FillStartPosition.X - (float)Fill.Width + (EndStartPosition.X + FillX - FillStartPosition.X + (float)Fill.Width) * percent;
        Main.spriteBatch.Draw(Fill, FillStartPosition, new Rectangle(0, 0, FillStart, Fill.Height), barFillColor * alpha, 0f, Vector2.Zero, new Vector2((realEnd - EndWidth + FillStart + (FillX) - FillStartPosition.X + (float)Fill.Width - (float)FillStart) / (float)FillStart, 1f), SpriteEffects.None, 0f);
        Main.spriteBatch.Draw(Fill, new Vector2(realEnd, FillStartPosition.Y), new Rectangle(FillStart, 0, Fill.Width - FillStart, Fill.Height), barFillColor * alpha, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
    }

	public static void DrawBarFrame(Texture2D Start, Texture2D Mid, Texture2D End, Vector2 StartStartPosition, Vector2 EndStartPosition, Vector2 FillStartPosition, Vector2 MidStartPosition, int type, float alpha)
	{
		try
		{
			BarData.Midwidth.TryGetValue(type, out var boolen);
			if (boolen && !BarConfig.Instance.ForceUseDefaultBar)
			{
				for (float i = MidStartPosition.X; i < EndStartPosition.X; i += (float)Mid.Width)
				{
					Main.spriteBatch.Draw(Mid, new Vector2(i, MidStartPosition.Y), null, Color.White * alpha, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
				}
			}
			else
			{
				Main.spriteBatch.Draw(Mid, MidStartPosition, null, Color.White * alpha, 0f, Vector2.Zero, new Vector2((EndStartPosition.X - StartStartPosition.X - (float)Start.Width) / (float)Mid.Width, 1f), SpriteEffects.None, 0f);
			}
			Main.spriteBatch.Draw(Start, StartStartPosition, Color.White * alpha);
			Main.spriteBatch.Draw(End, EndStartPosition, Color.White * alpha);
		}
		catch
		{
		}
	}

    public static void DrawHead(Texture2D Start, Texture2D Mid, Texture2D End, Vector2 StartStartPosition, Vector2 EndStartPosition, Vector2 FillStartPosition, Vector2 MidStartPosition, Texture2D Head, int HeadWidth, int HeadHeight, int type, float alpha)
    {
		try
		{
            if (Head != null)
            {
                Main.spriteBatch.Draw(Head, StartStartPosition + new Vector2(HeadWidth - Head.Width / 2, HeadHeight - Head.Height / 2), Color.White * alpha);
            }
        }
		catch
		{

		}
    }

    public static void DrawBarInfo(string Info, Vector2 postion, Color color, float alpha, NPC npc, string Name)
	{
        Vector2 Namepostion = new Vector2(FontAssets.MouseText.Value.MeasureString(Info).X / 2f, FontAssets.MouseText.Value.MeasureString(Info).Y / 3f);
        DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, Info, postion - Namepostion + new Vector2(1f, 1f), Color.Black * alpha);
        DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, Info, postion - Namepostion + new Vector2(-1f, 1f), Color.Black * alpha);
        DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, Info, postion - Namepostion + new Vector2(-1f, -1f), Color.Black * alpha);
        DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, Info, postion - Namepostion + new Vector2(1f, -1f), Color.Black * alpha);
        DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, Info, postion - Namepostion, Color.White * alpha);
    }

	public static float CheckDown(Vector2 StartStartPosition, Texture2D End, Vector2 EndStartPosition)
	{
		if (!Collision.CheckAABBvAABBCollision(Main.MouseScreen, Vector2.One, StartStartPosition, new Vector2(EndStartPosition.X + (float)End.Width - StartStartPosition.X, EndStartPosition.Y + (float)End.Height - StartStartPosition.Y)))
		{
			return 1f;
		}
		return 0.5f;
	}

	public static void DrawMoreInfo(NPC npc, Vector2 StartStartPosition, Vector2 EndStartPosition, Vector2 postion, Texture2D Fill, Texture2D End)
	{
		if (BarConfig.Instance.MoreInfo)
		{
			Texture2D Defense = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Info/Defense", (AssetRequestMode)2).Value;
			Texture2D Damage = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Info/Damage", (AssetRequestMode)2).Value;
			Texture2D Target = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Info/Target", (AssetRequestMode)2).Value;
			_ = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Info/CalDR", (AssetRequestMode)2).Value;
			_ = ModContent.Request<Texture2D>("YuBellBossBar/Texture/Info/FarDR", (AssetRequestMode)2).Value;
			Vector2 defense = new Vector2(StartStartPosition.X + (float)Defense.Width - 60, StartStartPosition.Y + 20);
			Vector2 detext = new Vector2(-5f, FontAssets.MouseText.Value.MeasureString(npc.defense.ToString()).Y / 3f);
			Main.spriteBatch.Draw(Defense, new Vector2(StartStartPosition.X - 30, StartStartPosition.Y + 20 - Defense.Height / 2), Color.White);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, npc.defense.ToString(), defense - detext + new Vector2(1f, 1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, npc.defense.ToString(), defense - detext + new Vector2(-1f, 1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, npc.defense.ToString(), defense - detext + new Vector2(-1f, -1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, npc.defense.ToString(), defense - detext + new Vector2(1f, -1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, npc.defense.ToString(), defense - detext, Color.White);
			Vector2 damage = new Vector2(EndStartPosition.X + (float)End.Width - (float)Damage.Width + 60f, EndStartPosition.Y + 20);
			Vector2 datext = new Vector2(FontAssets.MouseText.Value.MeasureString(npc.damage.ToString()).X, FontAssets.MouseText.Value.MeasureString(npc.damage.ToString()).Y / 3f);
			Main.spriteBatch.Draw(Damage, new Vector2(EndStartPosition.X + (float)End.Width - (float)Damage.Width + 40, EndStartPosition.Y + 20 - Damage.Height / 2), Color.White);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, npc.damage.ToString(), damage - datext + new Vector2(1f, 1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, npc.damage.ToString(), damage - datext + new Vector2(-1f, 1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, npc.damage.ToString(), damage - datext + new Vector2(1f, -1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, npc.damage.ToString(), damage - datext + new Vector2(-1f, -1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, npc.damage.ToString(), damage - datext, Color.White);
			/*Vector2 target = new Vector2(postion.X, postion.Y - (float)((Fill.Height + Target.Height) / 2));
			Vector2 tatext = new Vector2(FontAssets.MouseText.Value.MeasureString(Main.player[npc.target].name).X / 2f, FontAssets.MouseText.Value.MeasureString(Main.player[npc.target].name).Y / 3f);
			Main.spriteBatch.Draw(Target, target + new Vector2(-(Target.Width / 2), -Target.Width / 2), Color.White);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, Main.player[npc.target].name, target - tatext + new Vector2(1f, 1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, Main.player[npc.target].name, target - tatext + new Vector2(-1f, 1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, Main.player[npc.target].name, target - tatext + new Vector2(1f, -1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, Main.player[npc.target].name, target - tatext + new Vector2(-1f, -1f), Color.Black);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, Main.player[npc.target].name, target - tatext, Color.White);*/
		}
	}
}
