using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YuBellBossBar.Content
{
    public class BarData
    {
        // Start Mid End Fill
        public static Dictionary<int, Texture2D[]> BarTexture = new Dictionary<int, Texture2D[]>()
        {
            {
                -1,
               [ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarStart_Exp").Value,
                ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarMiddle_Exp").Value,
                ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarEnd_Exp").Value,
                ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarFill").Value]
            },

            {
                -2,
               [ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarStart").Value,
                ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarMiddle").Value,
                ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarEnd").Value,
                ModContent.Request<Texture2D>("YuBellBossBar/Texture/Vanilla/HealthBarFill").Value]
            }
        };

        public static Dictionary<int, Texture2D> BarHead = new Dictionary<int, Texture2D>()
        {
            // Golem
            {(int)NPCID.Golem,ModContent.Request<Texture2D>($"Terraria/Images/NPC_Head_Boss_5").Value }
            //{(int)NPCID.Golem,TextureAssets.NpcHeadBoss[Main.npc[NPCID.Golem].GetBossHeadTextureIndex()].Value }
        };

        public static Dictionary<int, Color> BarColor = new Dictionary<int, Color>()
        {

        };

        // Main NPC Should be BarNPCContain[0]
        public static Dictionary<int, int[]> BarNPCContain = new Dictionary<int, int[]>()
        {
            // Golem
            {
                (int)NPCID.Golem,[(int)NPCID.Golem, (int)NPCID.GolemFistLeft, (int)NPCID.GolemFistRight, (int)NPCID.GolemHead, (int)NPCID.GolemHeadFree]
            }
        };

        public static Dictionary<int, string> BossName = new Dictionary<int, string>()
        {
            {
                (int)NPCID.Golem,Main.npc[NPCID.Golem].FullName
            }
        };

        public static Dictionary<int, bool[]> Condition = new Dictionary<int, bool[]>();

        public static Dictionary<int, int[]> Position = new Dictionary<int, int[]>()
        {
            { NPCID.EaterofWorldsHead , new int[] { NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail }},
            { NPCID.BrainofCthulhu , new int[] { NPCID.BrainofCthulhu, NPCID.Creeper } },
            { NPCID.SkeletronHead , new int[] { NPCID.SkeletronHead, NPCID.SkeletronHand } },
            { NPCID.SkeletronPrime ,  new int[] { NPCID.SkeletronPrime, NPCID.PrimeSaw, NPCID.PrimeVice, NPCID.PrimeCannon, NPCID.PrimeLaser }},
            { NPCID.Golem , new int[] { NPCID.Golem, NPCID.GolemFistLeft, NPCID.GolemFistRight, NPCID.GolemHead, NPCID.GolemHeadFree } },
            { NPCID.MartianSaucer , new int[] { NPCID.MartianSaucerCore, NPCID.MartianSaucerTurret, NPCID.MartianSaucerCannon } },
            { NPCID.PirateShip , new int[] { NPCID.PirateShip, NPCID.PirateShipCannon } },
            { NPCID.MoonLordHead , new int[] { NPCID.MoonLordHead, NPCID.MoonLordHand, NPCID.MoonLordCore } }
        };
    }
}
