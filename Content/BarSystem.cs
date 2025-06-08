using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace YuBellBossBar.Content
{
    public class BarSystem : ModSystem
    {
        public override void PostUpdatePlayers()
        {
            if (BarPlayer.LastHit <= 5)
            {
                BarPlayer.LastHit++;
            }
            else
            {
                BarPlayer.LastHit = 5;
            }
        }

        public override void Load()
        {
            BarData.BarTexture.Clear();
            BarData.BarTexture = new Dictionary<int, Texture2D[]>(){
                {
                int.MaxValue,
               [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarStart_Exp").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarMiddle_Exp").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarEnd_Exp").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value,
                    null
                    ]
            },

            {
                int.MinValue,
               [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarStart").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarMiddle").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill").Value,
                    null
                    ]
            },

            {
                NPCID.KingSlime,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/KingSlimeHead").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/KingSlimeMid").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/KingSlimeEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/KingSlimeFill").Value,
                    null
                    ]
            },

            {
                NPCID.EyeofCthulhu,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CthEyeHead").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/BrainMid").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CthEyeEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CthEyeFill").Value,
                    null
                    ]
            },

            {
                NPCID.EaterofWorldsHead,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/EOCHead").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/EOCMid").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/EOCEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/EOCFill").Value,
                    null
                    ]
            },

            {
                NPCID.BrainofCthulhu ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/BrainHead").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/BrainMid").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/BrainEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/BrainFill").Value,
                    null
                    ]
            },

            {
                NPCID.QueenBee,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/QueenBeeHead").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/QueenBeeMid").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/QueenBeeEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/QueenBeeFill").Value,
                    null
                    ]
            },

            {
                NPCID.SkeletronHead ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SkeletronHead").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SkeletronMid").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SkeletronEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SkeletronFill").Value,
                    null
                    ]
            },

            {
                NPCID.Deerclops,
                [
                    null,
                    null,
                    null,
                    null,
                    null
                    ]
            },

            {
                NPCID.WallofFlesh,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DemonBarStart").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DemonBarMiddle").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DemonBarEnd").Value,
                    null,
                    null
                    ]
            },

            {
                NPCID.QueenSlimeBoss,
                [
                    null,
                    null,
                    null,
                    null,
                    null
                    ]
            },

            {
                NPCID.Retinazer,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarStart").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarMiddle").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarEnd").Value,
                    null,
                    null
                    ]
            },

            {
                NPCID.Spazmatism,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarStart").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarMiddle").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarEnd").Value,
                    null,
                    null
                    ]
            },

            {
                NPCID.TheDestroyer,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarStart").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarMiddle").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarEnd").Value,
                    null,
                    null
                    ]
            },

            {
                NPCID.SkeletronPrime ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarStart").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarMiddle").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarEnd").Value,
                    null,
                    TextureAssets.NpcHeadBoss[18].Value
                    ]
            },

            {
                NPCID.Plantera,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/PlantBarStart").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/PlantBarMiddle").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/PlantBarEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/PlantBarFill").Value,
                    null
                    ]
            },

            {
                NPCID.Golem ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/GolemHead").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/GolemMid").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/GolemEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/GolemFill").Value,
                    TextureAssets.NpcHeadBoss[5].Value
                    ]
            },

            {
                NPCID.HallowBoss,
                [
                    null,
                    null,
                    null,
                    null,
                    null
                    ]
            },

            {
                NPCID.DukeFishron,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DukeHead").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DukeMid").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DukeEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DukeFill").Value,
                    null
                    ]
            },

            {
                NPCID.CultistBoss,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CultistHead").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CultistMid").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CultistEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CultistFill").Value,
                    null
                    ]
            },

            {
                NPCID.MoonLordHead ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MoonLordBarStart_Exp").Value,
                    null,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MoonLordBarEnd_EXP").Value,
                    null,
                    TextureAssets.NpcHeadBoss[8].Value
                    ]
            },

            {
                NPCID.MartianSaucer ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MartianHead").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MartianMid").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MartianEndEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MartianFill").Value,
                    null
                    ]
            },

            {
                NPCID.PirateShip  ,
                [
                    null,
                    null,
                    null,
                    null,
                    null
                    ]
            },

            {
                NPCID.DD2OgreT2 ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarStart_Exp").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarMiddle_Exp").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarEnd_Exp").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2SmBarFill").Value,
                    null
                    ]
            },

            {
                NPCID.DD2OgreT3 ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarStart").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarMiddle").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarFill").Value,
                    null
                    ]
            },

            {
                NPCID.DD2DarkMageT1 ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarStart_Exp").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarMiddle_Exp").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarEnd_Exp").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2SmBarFill").Value,
                    null
                    ]
            },

            {
                NPCID.DD2DarkMageT3 ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarStart").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarMiddle").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarFill").Value,
                    null
                    ]
            },

            {
                NPCID.DD2Betsy ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarStart").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarMiddle").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarEnd").Value,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarFill").Value,
                    null
                    ]
            }
            };

            BarData.BarColor.Clear();
            BarData.BarColor = new Dictionary<int, Color?>()
        {
            // 史王
            { NPCID.KingSlime,
            new Color(50, 120, 255) },
            // 克眼
            { NPCID.EyeofCthulhu,
            new Color(213, 5, 5) },
            // 世吞
            { NPCID.EaterofWorldsHead ,
            new Color(115, 127, 33)},
            // 克脑
            { NPCID.BrainofCthulhu ,
            new Color(191, 78, 81) },
            // 蜂王
            { NPCID.QueenBee,
            Color.White},
            // 骷髅王
            { NPCID.SkeletronHead ,
            new Color(240, 240, 159) },
            // 独眼巨鹿
            { NPCID.Deerclops,
            null },
            // 血肉墙
            { NPCID.WallofFlesh,
            null },
            // 史莱姆皇后
            { NPCID.QueenSlimeBoss,
            null },
            // 双子魔眼
                // 激光眼
                { NPCID.Retinazer,
                null},
                // 魔焰眼
                { NPCID.Spazmatism,
                null },
            // 毁灭者
            { NPCID.TheDestroyer,
            null},
            // 机械骷髅王
            { NPCID.SkeletronPrime ,
            null},
            // 世纪之花
            { NPCID.Plantera,
            null},
            // 石巨人
            { NPCID.Golem ,
            Color.White },
            // 光女
            { NPCID.HallowBoss,
            null },
            // 猪鲨
            { NPCID.DukeFishron,
            new Color(255, 255, 255)},
            // 拜月教
            { NPCID.CultistBoss,
            new Color(0,167,255)},
            // 月总
            { NPCID.MoonLordHead ,
            null },
            // 火星人
            { NPCID.MartianSaucer ,
            Color.White },
            // 荷兰人飞盗船
            { NPCID.PirateShip ,
            Color.White },
            // 食人魔
                // T2
                { NPCID.DD2OgreT2,
                Color.White },
                // T3
                { NPCID.DD2OgreT3,
                Color.White },
            // 黑暗魔法师
                // T1
                { NPCID.DD2DarkMageT1,
                Color.White},
                // T3
                { NPCID.DD2DarkMageT3,
                Color.White },
            // 双足翼龙
            { NPCID.DD2Betsy,
            Color.White }
        };

            BarData.BarNPCContain.Clear();
            BarData.BarNPCContain = new Dictionary<int, int[]>()
        {
            // 史王
            { NPCID.KingSlime,
            [NPCID.KingSlime] },
            // 克眼
            { NPCID.EyeofCthulhu,
            [NPCID.EyeofCthulhu] },
            // 世吞
            { NPCID.EaterofWorldsHead ,
            [NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail ]},
            // 克脑
            { NPCID.BrainofCthulhu ,
            [NPCID.BrainofCthulhu, NPCID.Creeper ] },
            // 蜂王
            { NPCID.QueenBee,
            [NPCID.QueenBee] },
            // 骷髅王
            { NPCID.SkeletronHead ,
            [ NPCID.SkeletronHead, NPCID.SkeletronHand ] },
            // 独眼巨鹿
            { NPCID.Deerclops,
            [NPCID.Deerclops]},
            // 血肉墙
            { NPCID.WallofFlesh,
            [NPCID.WallofFlesh] },
            // 史莱姆皇后
            { NPCID.QueenSlimeBoss,
            [NPCID.QueenSlimeBoss] },
            // 双子魔眼
                // 激光眼
                { NPCID.Retinazer,
                [NPCID.Retinazer]},
                // 魔焰眼
                { NPCID.Spazmatism,
                [NPCID.Spazmatism] },
            // 毁灭者
            { NPCID.TheDestroyer,
            [NPCID.TheDestroyer]},
            // 机械骷髅王
            { NPCID.SkeletronPrime ,
            [  NPCID.SkeletronPrime, NPCID.PrimeSaw, NPCID.PrimeVice, NPCID.PrimeCannon, NPCID.PrimeLaser ]},
            // 世纪之花
            { NPCID.Plantera,
            [NPCID.Plantera]},
            // 石巨人
            { NPCID.Golem ,
            [NPCID.Golem, NPCID.GolemFistLeft, NPCID.GolemFistRight, NPCID.GolemHead, NPCID.GolemHeadFree ] },
            // 光女
            { NPCID.HallowBoss,
            [NPCID.HallowBoss] },
            // 猪鲨
            { NPCID.DukeFishron,
            [NPCID.DukeFishron]},
            // 拜月教
            { NPCID.CultistBoss,
            [NPCID.CultistBoss]},
            // 月总
            { NPCID.MoonLordHead ,
            [ NPCID.MoonLordHead, NPCID.MoonLordHand, NPCID.MoonLordCore ] },
            // 火星人
            { NPCID.MartianSaucer ,
            [ NPCID.MartianSaucerCore, NPCID.MartianSaucerTurret, NPCID.MartianSaucerCannon ] },
            // 荷兰人飞盗船
            { NPCID.PirateShip ,
            [ NPCID.PirateShip, NPCID.PirateShipCannon ] },
            // 食人魔
                // T2
                { NPCID.DD2OgreT2,
                [NPCID.DD2OgreT2] },
                // T3
                { NPCID.DD2OgreT3,
                [NPCID.DD2OgreT3] },
            // 黑暗魔法师
                // T1
                { NPCID.DD2DarkMageT1,
                [NPCID.DD2DarkMageT1]},
                // T3
                { NPCID.DD2DarkMageT3,
                [NPCID.DD2DarkMageT3] },
            // 双足翼龙
            { NPCID.DD2Betsy,
            [NPCID.DD2Betsy] }
                        };

            BarData.BossMaxHealth.Clear();
            BarData.BossMaxHealth = new Dictionary<int, int>()
        {
            // 史王
            { NPCID.KingSlime,
            0 },
            // 克眼
            { NPCID.EyeofCthulhu,
            0 },
            // 世吞
            { NPCID.EaterofWorldsHead ,
            0},
            // 克脑
            { NPCID.BrainofCthulhu ,
            0 },
            // 蜂王
            { NPCID.QueenBee,
            0 },
            // 骷髅王
            { NPCID.SkeletronHead ,
            0 },
            // 独眼巨鹿
            { NPCID.Deerclops,
            0},
            // 血肉墙
            { NPCID.WallofFlesh,
            0 },
            // 史莱姆皇后
            { NPCID.QueenSlimeBoss,
            0 },
            // 双子魔眼
                // 激光眼
                { NPCID.Retinazer,
                0},
                // 魔焰眼
                { NPCID.Spazmatism,
                0 },
            // 毁灭者
            { NPCID.TheDestroyer,
            0},
            // 机械骷髅王
            { NPCID.SkeletronPrime ,
            0},
            // 世纪之花
            { NPCID.Plantera,
            0},
            // 石巨人
            { NPCID.Golem ,
            0 },
            // 光女
            { NPCID.HallowBoss,
            0 },
            // 猪鲨
            { NPCID.DukeFishron,
            0},
            // 拜月教
            { NPCID.CultistBoss,
            0},
            // 月总
            { NPCID.MoonLordHead ,
            0 },
            // 火星人
            { NPCID.MartianSaucer ,
            0 },
            // 荷兰人飞盗船
            { NPCID.PirateShip ,
            0 },
            // 食人魔
                // T2
                { NPCID.DD2OgreT2,
                0 },
                // T3
                { NPCID.DD2OgreT3,
                0 },
            // 黑暗魔法师
                // T1
                { NPCID.DD2DarkMageT1,
                0},
                // T3
                { NPCID.DD2DarkMageT3,
                0 },
            // 双足翼龙
            { NPCID.DD2Betsy,
            0 }
        };

            BarData.BossNowHealth.Clear();
            BarData.BossNowHealth = new Dictionary<int, int>()
        {
            // 史王
            { NPCID.KingSlime,
            0 },
            // 克眼
            { NPCID.EyeofCthulhu,
            0 },
            // 世吞
            { NPCID.EaterofWorldsHead ,
            0},
            // 克脑
            { NPCID.BrainofCthulhu ,
            0 },
            // 蜂王
            { NPCID.QueenBee,
            0 },
            // 骷髅王
            { NPCID.SkeletronHead ,
            0 },
            // 独眼巨鹿
            { NPCID.Deerclops,
            0},
            // 血肉墙
            { NPCID.WallofFlesh,
            0 },
            // 史莱姆皇后
            { NPCID.QueenSlimeBoss,
            0 },
            // 双子魔眼
                // 激光眼
                { NPCID.Retinazer,
                0},
                // 魔焰眼
                { NPCID.Spazmatism,
                0 },
            // 毁灭者
            { NPCID.TheDestroyer,
            0},
            // 机械骷髅王
            { NPCID.SkeletronPrime ,
            0},
            // 世纪之花
            { NPCID.Plantera,
            0},
            // 石巨人
            { NPCID.Golem ,
            0 },
            // 光女
            { NPCID.HallowBoss,
            0 },
            // 猪鲨
            { NPCID.DukeFishron,
            0},
            // 拜月教
            { NPCID.CultistBoss,
            0},
            // 月总
            { NPCID.MoonLordHead ,
            0 },
            // 火星人
            { NPCID.MartianSaucer ,
            0 },
            // 荷兰人飞盗船
            { NPCID.PirateShip ,
            0 },
            // 食人魔
                // T2
                { NPCID.DD2OgreT2,
                0 },
                // T3
                { NPCID.DD2OgreT3,
                0 },
            // 黑暗魔法师
                // T1
                { NPCID.DD2DarkMageT1,
                0},
                // T3
                { NPCID.DD2DarkMageT3,
                0 },
            // 双足翼龙
            { NPCID.DD2Betsy,
            0 }
        };

            BarData.BossName.Clear();
            BarData.BossName = new Dictionary<int, string>()
        {
            // 史王
            { NPCID.KingSlime,
            Lang.GetNPCName(NPCID.KingSlime).ToString() },
            // 克眼
            { NPCID.EyeofCthulhu,
            Lang.GetNPCName(NPCID.EyeofCthulhu).ToString() },
            // 世吞
            { NPCID.EaterofWorldsHead ,
            Lang.GetNPCName(NPCID.EaterofWorldsHead).ToString()},
            // 克脑
            { NPCID.BrainofCthulhu ,
            Lang.GetNPCName(NPCID.BrainofCthulhu).ToString() },
            // 蜂王
            { NPCID.QueenBee,
            Lang.GetNPCName(NPCID.QueenBee).ToString() },
            // 骷髅王
            { NPCID.SkeletronHead ,
            Lang.GetNPCName(NPCID.SkeletronHead).ToString() },
            // 独眼巨鹿
            { NPCID.Deerclops,
            Lang.GetNPCName(NPCID.Deerclops).ToString()},
            // 血肉墙
            { NPCID.WallofFlesh,
            Lang.GetNPCName(NPCID.WallofFlesh).ToString() },
            // 史莱姆皇后
            { NPCID.QueenSlimeBoss,
            Lang.GetNPCName(NPCID.QueenSlimeBoss).ToString() },
            // 双子魔眼
                // 激光眼
                { NPCID.Retinazer,
                Lang.GetNPCName(NPCID.Retinazer).ToString()},
                // 魔焰眼
                { NPCID.Spazmatism,
                Lang.GetNPCName(NPCID.Spazmatism).ToString() },
            // 毁灭者
            { NPCID.TheDestroyer,
            Lang.GetNPCName(NPCID.TheDestroyer).ToString()},
            // 机械骷髅王
            { NPCID.SkeletronPrime ,
            Lang.GetNPCName(NPCID.SkeletronPrime).ToString()},
            // 世纪之花
            { NPCID.Plantera,
            Lang.GetNPCName(NPCID.Plantera).ToString()},
            // 石巨人
            { NPCID.Golem ,
            Lang.GetNPCName(NPCID.Golem).ToString() },
            // 光女
            { NPCID.HallowBoss,
            Lang.GetNPCName(NPCID.HallowBoss).ToString() },
            // 猪鲨
            { NPCID.DukeFishron,
            Lang.GetNPCName(NPCID.DukeFishron).ToString()},
            // 拜月教
            { NPCID.CultistBoss,
            Lang.GetNPCName(NPCID.CultistBoss).ToString()},
            // 月总
            { NPCID.MoonLordHead ,
            Lang.GetNPCName(NPCID.MoonLordHead).ToString() },
            // 火星人
            { NPCID.MartianSaucer ,
            Lang.GetNPCName(NPCID.MartianSaucer).ToString() },
            // 荷兰人飞盗船
            { NPCID.PirateShip ,
            Lang.GetNPCName(NPCID.PirateShip).ToString() },
            // 食人魔
                // T2
                { NPCID.DD2OgreT2,
                Lang.GetNPCName(NPCID.DD2OgreT2).ToString() },
                // T3
                { NPCID.DD2OgreT3,
                Lang.GetNPCName(NPCID.DD2OgreT3).ToString() },
            // 黑暗魔法师
                // T1
                { NPCID.DD2DarkMageT1,
                Lang.GetNPCName(NPCID.DD2DarkMageT1).ToString()},
                // T3
                { NPCID.DD2DarkMageT3,
                Lang.GetNPCName(NPCID.DD2DarkMageT3).ToString() },
            // 双足翼龙
            { NPCID.DD2Betsy,
            Lang.GetNPCName(NPCID.DD2Betsy).ToString() }
        };

            BarData.CutLength.Clear();
            BarData.CutLength = new Dictionary<int, int[]>()
        {
            // 史王
            { NPCID.KingSlime,
            [48,20,28,26,30]}
            //// 克眼
            //{ NPCID.EyeofCthulhu,
            //0 },
            //// 世吞
            //{ NPCID.EaterofWorldsHead ,
            //0},
            //// 克脑
            //{ NPCID.BrainofCthulhu ,
            //0 },
            //// 蜂王
            //{ NPCID.QueenBee,
            //0 },
            //// 骷髅王
            //{ NPCID.SkeletronHead ,
            //0 },
            //// 独眼巨鹿
            //{ NPCID.Deerclops,
            //0},
            //// 血肉墙
            //{ NPCID.WallofFlesh,
            //0 },
            //// 史莱姆皇后
            //{ NPCID.QueenSlimeBoss,
            //0 },
            //// 双子魔眼
            //    // 激光眼
            //    { NPCID.Retinazer,
            //    0},
            //    // 魔焰眼
            //    { NPCID.Spazmatism,
            //    0 },
            //// 毁灭者
            //{ NPCID.TheDestroyer,
            //0},
            //// 机械骷髅王
            //{ NPCID.SkeletronPrime ,
            //0},
            //// 世纪之花
            //{ NPCID.Plantera,
            //0},
            //// 石巨人
            //{ NPCID.Golem ,
            //0 },
            //// 光女
            //{ NPCID.HallowBoss,
            //0 },
            //// 猪鲨
            //{ NPCID.DukeFishron,
            //0},
            //// 拜月教
            //{ NPCID.CultistBoss,
            //0},
            //// 月总
            //{ NPCID.MoonLordHead ,
            //0 },
            //// 火星人
            //{ NPCID.MartianSaucer ,
            //0 },
            //// 荷兰人飞盗船
            //{ NPCID.PirateShip ,
            //0 },
            //// 食人魔
            //    // T2
            //    { NPCID.DD2OgreT2,
            //    0 },
            //    // T3
            //    { NPCID.DD2OgreT3,
            //    0 },
            //// 黑暗魔法师
            //    // T1
            //    { NPCID.DD2DarkMageT1,
            //    0},
            //    // T3
            //    { NPCID.DD2DarkMageT3,
            //    0 },
            //// 双足翼龙
            //{ NPCID.DD2Betsy,
            //0 }
        };

            BarData.Midwidth.Clear();
            BarData.Midwidth = new Dictionary<int, bool>()
        {
            // 史王
            { NPCID.KingSlime,
            true },
            // 克眼
            { NPCID.EyeofCthulhu,
            true },
            // 世吞
            { NPCID.EaterofWorldsHead ,
            true},
            // 克脑
            { NPCID.BrainofCthulhu ,
            true },
            // 蜂王
            { NPCID.QueenBee,
            true },
            // 骷髅王
            { NPCID.SkeletronHead ,
            true },
            // 独眼巨鹿
            { NPCID.Deerclops,
            true},
            // 血肉墙
            { NPCID.WallofFlesh,
            true },
            // 史莱姆皇后
            { NPCID.QueenSlimeBoss,
            true },
            // 双子魔眼
                // 激光眼
                { NPCID.Retinazer,
                true},
                // 魔焰眼
                { NPCID.Spazmatism,
                true },
            // 毁灭者
            { NPCID.TheDestroyer,
            true},
            // 机械骷髅王
            { NPCID.SkeletronPrime ,
            true},
            // 世纪之花
            { NPCID.Plantera,
            false},
            // 石巨人
            { NPCID.Golem ,
            true },
            // 光女
            { NPCID.HallowBoss,
            true },
            // 猪鲨
            { NPCID.DukeFishron,
            true},
            // 拜月教
            { NPCID.CultistBoss,
            true},
            // 月总
            { NPCID.MoonLordHead ,
            true},
            // 火星人
            { NPCID.MartianSaucer ,
            false },
            // 荷兰人飞盗船
            { NPCID.PirateShip ,
            true},
            // 食人魔
                // T2
                { NPCID.DD2OgreT2,
                true},
                // T3
                { NPCID.DD2OgreT3,
                true},
            // 黑暗魔法师
                // T1
                { NPCID.DD2DarkMageT1,
                true},
                // T3
                { NPCID.DD2DarkMageT3,
                true},
            // 双足翼龙
            { NPCID.DD2Betsy,
            true}
        };

        }
    }
    
    public class BarPlayer : ModPlayer
    {
        public static int LastHit = 0;

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            LastHit = 0;
        }
    }
}
