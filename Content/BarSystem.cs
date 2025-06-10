using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
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
            BarData.BarTexture = new Dictionary<int, Asset<Texture2D>[]>(){
                {
                int.MaxValue,
               [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarStart_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarMiddle_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarEnd_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill"),
                    null
                    ]
            },

            {
                int.MinValue,
               [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarStart"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarMiddle"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/HealthBarFill"),
                    null
                    ]
            },

            {
                NPCID.KingSlime,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/KingSlimeHead"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/KingSlimeMid"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/KingSlimeEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/KingSlimeFill"),
                    null
                    ]
            },

            {
                NPCID.EyeofCthulhu,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CthEyeHead"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CthEyeMid"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CthEyeEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CthEyeFill"),
                    null
                    ]
            },

            {
                NPCID.EaterofWorldsHead,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/EOCHead"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/EOCMid"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/EOCEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/EOCFill"),
                    TextureAssets.NpcHeadBoss[2]
                    ]
            },

            {
                NPCID.BrainofCthulhu ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/BrainHead"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/BrainMid"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/BrainEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/BrainFill"),
                    TextureAssets.NpcHeadBoss[23]
                    ]
            },

            {
                NPCID.QueenBee,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/QueenBeeHead"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/QueenBeeMid"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/QueenBeeEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/QueenBeeFill"),
                    null
                    ]
            },

            {
                NPCID.SkeletronHead ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SkeletronHead"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SkeletronMid"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SkeletronEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SkeletronFill"),
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
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DemonBarStart"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DemonBarMiddle"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DemonBarEnd"),
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
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarStart"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarMiddle"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarEnd"),
                    null,
                    null
                    ]
            },

            {
                NPCID.Spazmatism,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarStart"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarMiddle"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarEnd"),
                    null,
                    null
                    ]
            },

            {
                NPCID.TheDestroyer,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarStart"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarMiddle"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarEnd"),
                    null,
                    null
                    ]
            },

            {
                NPCID.SkeletronPrime ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarStart"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarMiddle"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MechBarEnd"),
                    null,
                    TextureAssets.NpcHeadBoss[18]
                    ]
            },

            {
                NPCID.Plantera,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/PlantBarStart"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/PlantBarMiddle"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/PlantBarEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/PlantBarFill"),
                    null
                    ]
            },

            {
                NPCID.Golem ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/GolemHead"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/GolemMid"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/GolemEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/GolemFill"),
                    TextureAssets.NpcHeadBoss[5]
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
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DukeHead"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DukeMid"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DukeEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DukeFill"),
                    null
                    ]
            },

            {
                NPCID.CultistBoss,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CultistHead"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CultistMid"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CultistEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/CultistFill"),
                    TextureAssets.NpcHeadBoss[24]
                    ]
            },

            {
                NPCID.MoonLordHead ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MoonLordBarStart_Exp"),
                    null,
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MoonLordBarEnd_EXP"),
                    null,
                    TextureAssets.NpcHeadBoss[8]
                    ]
            },


            {
                NPCID.MoonLordHand,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarStart_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarMiddle_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarEnd_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarFill"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MLEye")
                    ]
            },

            {
                NPCID.MoonLordCore,
               [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarStart_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarMiddle_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarEnd_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarFill"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MLHeart")]
            },

            {
                NPCID.MartianSaucer ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MartianHead"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MartianMid"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MartianEndEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/MartianFill"),
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
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarStart_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarMiddle_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarEnd_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2SmBarFill"),
                    null
                    ]
            },

            {
                NPCID.DD2OgreT3 ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarStart"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarMiddle"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarFill"),
                    null
                    ]
            },

            {
                NPCID.DD2DarkMageT1 ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarStart_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarMiddle_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/SmBarEnd_Exp"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2SmBarFill"),
                    null
                    ]
            },

            {
                NPCID.DD2DarkMageT3 ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarStart"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarMiddle"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarFill"),
                    null
                    ]
            },

            {
                NPCID.DD2Betsy ,
                [
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarStart"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarMiddle"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarEnd"),
                    ModContent.Request<Texture2D>($"YuBellBossBar/Texture/Vanilla/DD2BarFill"),
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
            new Color(0,167,255)
            //LuiColor()
                },
            // 月总
            { NPCID.MoonLordHead ,
            null },
                {NPCID.MoonLordHand,
                null
                },
                {NPCID.MoonLordCore,
                null
                },
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
            [ NPCID.SkeletronHead ] },
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
            [  NPCID.SkeletronPrime ]},
            // 世纪之花
            { NPCID.Plantera,
            [NPCID.Plantera]},
            // 石巨人
            { NPCID.Golem ,
            [NPCID.Golem, NPCID.GolemHead ] },
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
            [ NPCID.MoonLordHead, NPCID.MoonLordCore] },
                {NPCID.MoonLordHand,
                [NPCID.MoonLordHand]
                },
                {NPCID.MoonLordCore,
                [NPCID.MoonLordCore]
                },
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
            {int.MinValue,
            [96,80,30,30,1] },
            {int.MaxValue,
            [96,80,30,30,1]},
            // 史王
            { NPCID.KingSlime,
            [48,21,29,26,1]},
            // 克眼
            { NPCID.EyeofCthulhu,
            [66,42,30,26,1] },
            // 世吞
            { NPCID.EaterofWorldsHead ,
            [70,44,32,28,1]},
            // 克脑
            { NPCID.BrainofCthulhu ,
            [44,22,30,26,1] },
            // 蜂王
            { NPCID.QueenBee,
            [80,54,30,26,1] },
            // 骷髅王
            { NPCID.SkeletronHead ,
            [52,25,30,30,1] },
            // 独眼巨鹿
            { NPCID.Deerclops,
            [96,80,30,30,1]},
            // 血肉墙
            { NPCID.WallofFlesh,
            [80,52,28,4,1] },
            // 史莱姆皇后
            { NPCID.QueenSlimeBoss,
            [96,80,30,30,1] },
            // 双子魔眼
                // 激光眼
                { NPCID.Retinazer,
                [58,29,30,14,1]},
                // 魔焰眼
                { NPCID.Spazmatism,
                [58,29,30,14,1] },
            // 毁灭者
            { NPCID.TheDestroyer,
            [58,29,30,14,1]},
            // 机械骷髅王
            { NPCID.SkeletronPrime ,
            [58,29,30,14,1]},
            // 世纪之花
            { NPCID.Plantera,
            [50,33,31,30,1]},
            // 石巨人
            { NPCID.Golem ,
            [56,25,30,24,1] },
            // 光女
            { NPCID.HallowBoss,
            [96,80,30,30,1] },
            // 猪鲨
            { NPCID.DukeFishron,
            [72,45,30,30,1]},
            // 拜月教
            { NPCID.CultistBoss,
            [70,43,30,26,1]},
            // 月总
            { NPCID.MoonLordHead ,
            [96,79,30,30,1] },

                {NPCID.MoonLordHand,
                [30,17,12,0,1]
                },
                {NPCID.MoonLordCore,
                [30,17,12,0,1]
                },
            // 火星人
            { NPCID.MartianSaucer ,
            [54,21,29,24,1] },
            // 荷兰人飞盗船
            { NPCID.PirateShip ,
            [96,80,30,30,1] },
            // 食人魔
                // T2
                { NPCID.DD2OgreT2,
                [30,17,12,0,8] },
                // T3
                { NPCID.DD2OgreT3,
                [6,1,34,38,8] },
            // 黑暗魔法师
                // T1
                { NPCID.DD2DarkMageT1,
                [30,17,12,0,8]},
                // T3
                { NPCID.DD2DarkMageT3,
                [6,1,34,38,8] },
            // 双足翼龙
            { NPCID.DD2Betsy,
            [6,1,34,38,8] }
        };

            BarData.Midwidth.Clear();
            BarData.Midwidth = new Dictionary<int, bool>()
        {
            // 史王
            { NPCID.KingSlime,
            false },
            // 克眼
            { NPCID.EyeofCthulhu,
            false },
            // 世吞
            { NPCID.EaterofWorldsHead ,
            false},
            // 克脑
            { NPCID.BrainofCthulhu ,
            false },
            // 蜂王
            { NPCID.QueenBee,
            false },
            // 骷髅王
            { NPCID.SkeletronHead ,
            false },
            // 独眼巨鹿
            { NPCID.Deerclops,
            false},
            // 血肉墙
            { NPCID.WallofFlesh,
            false },
            // 史莱姆皇后
            { NPCID.QueenSlimeBoss,
            false },
            // 双子魔眼
                // 激光眼
                { NPCID.Retinazer,
                false},
                // 魔焰眼
                { NPCID.Spazmatism,
                false },
            // 毁灭者
            { NPCID.TheDestroyer,
            false},
            // 机械骷髅王
            { NPCID.SkeletronPrime ,
            false},
            // 世纪之花
            { NPCID.Plantera,
            true},
            // 石巨人
            { NPCID.Golem ,
            true },
            // 光女
            { NPCID.HallowBoss,
            false },
            // 猪鲨
            { NPCID.DukeFishron,
            false},
            // 拜月教
            { NPCID.CultistBoss,
            false},
            // 月总
            { NPCID.MoonLordHead ,
            false},
            // 火星人
            { NPCID.MartianSaucer ,
            true },
            // 荷兰人飞盗船
            { NPCID.PirateShip ,
            false},
            // 食人魔
                // T2
                { NPCID.DD2OgreT2,
                false},
                // T3
                { NPCID.DD2OgreT3,
                false},
            // 黑暗魔法师
                // T1
                { NPCID.DD2DarkMageT1,
                false},
                // T3
                { NPCID.DD2DarkMageT3,
                false},
            // 双足翼龙
            { NPCID.DD2Betsy,
            false}
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

        public override void OnEnterWorld()
        {
            Main.NewText(Language.GetTextValue($"Mods.YuBellBossBar.WorldText"));
        }
    }

    public class BarNPC : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            foreach(var npcs in Main.npc)
            {
                if (npcs.boss)
                {
                    return;
                }
            }
            BarData.BossMaxHealth.Clear();
            BarData.BossNowHealth.Clear();
        }

        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            if(npc.type == NPCID.MoonLordHead)
            {
                npc.life -= 1;
            }
        }
    }
}
