using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Linq;
using System.Security.Cryptography;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.BigProgressBar;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.UI.ModBrowser;

//the name of the mod is a joke
namespace YuBellBossBar.Content;

public class BarStyle : ModBossBarStyle
{
	public static int npcnum;

	public override string DisplayName => Language.GetTextValue("Mods.YuBellBossBar.Name");

	public override bool PreventDraw => true;

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

        return null;
    }

    int[] allowedNPCs = new int[]
    {
        NPCID.SkeletronHand,
        NPCID.PrimeCannon,
        NPCID.PrimeLaser,
        NPCID.PrimeSaw,
        NPCID.PrimeVice,
        NPCID.BloodNautilus,
        NPCID.GolemFistLeft,
        NPCID.GolemFistRight,
    };

    int[] invincibleNPCs = new int[]
    {
        NPCID.BrainofCthulhu,
        NPCID.MartianSaucer,
        NPCID.PirateShip,
    };

    public override void Draw(SpriteBatch spriteBatch, IBigProgressBar currentBar, BigProgressBarInfo info)
	{
        int bossAmount = 0;
        int[] BossesTracked = new int[ModContent.GetInstance<BarConfig>().NumberOfBossBars];
        bool gotEaterOfWorldsHead = false;
        bool gotDutchman = false;
        for (int i = 1; i < 200; i++)
        {
            NPC npc = Main.npc[i];

            if (!npc.active || npc.life <= 0 || npc.friendly)
            {
                continue;
            }

            Texture2D head = GetHead(npc);

            if (head == null && !ModContent.GetInstance<BarConfig>().ShowBossBarsWithNoHead)
            {
                continue;
            }


            if (npc.boss || (head != null) || allowedNPCs.Contains(npc.type))
            {
                if (npc.type == NPCID.LunarTowerStardust || npc.type == NPCID.LunarTowerSolar || npc.type == NPCID.LunarTowerNebula || npc.type == NPCID.LunarTowerVortex)
                {
                    if ((npc.Center - Main.LocalPlayer.Center).Length() > 5000)
                    {
                        continue;
                    }
                }

                if (npc.type == NPCID.CultistBossClone)
                {
                    continue;
                }

                if ((npc.type == NPCID.Golem && npc.dontTakeDamage) || (npc.type == NPCID.GolemHeadFree && npc.dontTakeDamage))
                {
                    continue;
                }

                if ((npc.dontTakeDamage && !ModContent.GetInstance<BarConfig>().ShowInvincibleBosses) && !invincibleNPCs.Contains(npc.type))
                {
                    continue;
                }

                if (npc.type == NPCID.EaterofWorldsHead)
                {
                    if (!gotEaterOfWorldsHead)
                    {
                        gotEaterOfWorldsHead = true;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (npc.realLife != -1 && npc.realLife != npc.whoAmI)
                {
                    continue;
                }

                if (npc.type == NPCID.PirateShip)
                {
                    if (!gotDutchman)
                    {
                        gotDutchman = true;
                    }
                    else
                    {
                        continue;
                    }
                }

                BossesTracked[bossAmount] = i;
                bossAmount++;

                if (bossAmount == BossesTracked.Length)
                {
                    break;
                }
            }
        }


        float totalOffset = 0;
        for (int i = 0; i < bossAmount + 1; i++)
        {
            if (i == ModContent.GetInstance<BarConfig>().NumberOfBossBars) { break; }
            NPC npc = Main.npc[BossesTracked[i]];

            if (!npc.active || npc.life <= 0 || npc.friendly || (npc.realLife != -1 && npc.realLife != npc.whoAmI))
            {
                continue;
            }

            if (!npc.boss)
            {
                Texture2D head = GetHead(npc);
                if (head != null || allowedNPCs.Contains(npc.type))
                {

                }
                else
                {
                    continue;
                }
            }

            if ((npc.dontTakeDamage && !ModContent.GetInstance<BarConfig>().ShowInvincibleBosses) && !invincibleNPCs.Contains(npc.type))
            {
                continue;
            }

            if (npc.type == NPCID.CultistBossClone)
            {
                continue;
            }

            int health = 0;
            int maxHealth = 0;
            int segmentsLeft = 0;

            if (npc.type == NPCID.LunarTowerStardust)
            {
                health = NPC.ShieldStrengthTowerStardust;
                maxHealth = NPC.ShieldStrengthTowerMax;

                if ((npc.Center - Main.LocalPlayer.Center).Length() > 5000)
                {
                    continue;
                }
            }

            if (npc.type == NPCID.LunarTowerSolar)
            {
                health = NPC.ShieldStrengthTowerSolar;
                maxHealth = NPC.ShieldStrengthTowerMax;

                if ((npc.Center - Main.LocalPlayer.Center).Length() > 5000)
                {
                    continue;
                }
            }

            if (npc.type == NPCID.LunarTowerNebula)
            {
                health = NPC.ShieldStrengthTowerNebula;
                maxHealth = NPC.ShieldStrengthTowerMax;

                if ((npc.Center - Main.LocalPlayer.Center).Length() > 5000)
                {
                    continue;
                }
            }

            if (npc.type == NPCID.LunarTowerVortex)
            {
                health = NPC.ShieldStrengthTowerVortex;
                maxHealth = NPC.ShieldStrengthTowerMax;

                if ((npc.Center - Main.LocalPlayer.Center).Length() > 5000)
                {
                    continue;
                }
            }

            if (npc.type == NPCID.EaterofWorldsHead)
            {
                for (int index = 1; index < 200; index++)
                {
                    NPC eaterCheck = Main.npc[index];
                    if (eaterCheck.active && eaterCheck.life > 0)
                    {
                        if (eaterCheck.type == NPCID.EaterofWorldsHead || eaterCheck.type == NPCID.EaterofWorldsBody || eaterCheck.type == NPCID.EaterofWorldsTail)
                        {
                            maxHealth += eaterCheck.lifeMax;
                            health += eaterCheck.life;
                            segmentsLeft++;
                        }
                    }
                }
            }

            if (npc.type == NPCID.PirateShip)
            {
                for (int index = 1; index < 200; index++)
                {
                    NPC pirateCheck = Main.npc[index];
                    if (pirateCheck.active && pirateCheck.life > 0)
                    {
                        if (pirateCheck.type == NPCID.PirateShipCannon)
                        {
                            maxHealth += pirateCheck.lifeMax;
                            health += pirateCheck.life;
                            segmentsLeft++;
                        }
                    }
                }
            }

            if (npc.type == NPCID.MartianSaucerCore)
            {
                for (int index = 1; index < 200; index++)
                {
                    NPC martianCheck = Main.npc[index];
                    if (martianCheck.active && martianCheck.life > 0)
                    {
                        if (martianCheck.type == NPCID.MartianSaucerCannon || martianCheck.type == NPCID.MartianSaucerTurret)
                        {
                            maxHealth += martianCheck.lifeMax;
                            health += martianCheck.life;
                            segmentsLeft++;
                        }
                    }
                }
            }

            if (npc.type == NPCID.BrainofCthulhu)
            {
                for (int index = 1; index < 200; index++)
                {
                    NPC creeperCheck = Main.npc[index];
                    if (creeperCheck.active && creeperCheck.life > 0)
                    {
                        if (creeperCheck.type == NPCID.Creeper)
                        {
                            maxHealth += creeperCheck.lifeMax;
                            health += creeperCheck.life;
                            segmentsLeft++;
                        }
                    }
                }
            }


            float midHeight = 60;
            float maxHeight = 50;
            if (ModContent.GetInstance<BarConfig>().SquishHealthBarsTogether)
            {
                maxHeight = 42;
                if (BarData.BarTexture.Keys.Contains(npc.type))
                {
                    Asset<Texture2D>[] NowBarArray = BarData.BarTexture[npc.type];
                    if (NowBarArray != null)
                    {
                        if (NowBarArray[1] != null)
                        {
                            midHeight = NowBarArray[1].Value.Height;
                        }
                    }
                }
            }


            float y = MathHelper.Clamp(midHeight, 0, maxHeight);
            totalOffset += y;


            BarMethod.DrawBar(npc, i + 1, health, maxHealth, totalOffset, segmentsLeft);

        }
    }
}
