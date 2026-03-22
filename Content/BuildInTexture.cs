namespace YuBellBossBar.Content;

/// <summary>
/// <br/>一些贴图文件存储打表的地方
/// <br/>Signed all texture here
/// </summary>
public static class BuildInTexture
{
    private const string _cpath = "YuBellBossBar/Texture/Info/";
    /// <summary>
    /// <br/>在这里注册所有信息贴图
    /// <br/>Signed all info texture here
    /// </summary>
    public static Dictionary<string,Asset<Texture2D>> InfoTextures = new Dictionary<string, Asset<Texture2D>>()
    {
        {
            "Damage",
           ModContent.Request<Texture2D>(_cpath + "Damage", AssetRequestMode.ImmediateLoad)
        },
        {
            "Defense",
           ModContent.Request<Texture2D>(_cpath + "Defense", AssetRequestMode.ImmediateLoad)
        },
        {
            "Target",
           ModContent.Request<Texture2D>(_cpath + "Target", AssetRequestMode.ImmediateLoad)
        },
        {
            "CalamityDamageReduction",
           ModContent.Request<Texture2D>(_cpath + "CalDR", AssetRequestMode.ImmediateLoad)
        },
        {
            "FargoDamageReduction",
           ModContent.Request<Texture2D>(_cpath + "FarDR", AssetRequestMode.ImmediateLoad)
        },
    };

    private const string _vpath = "YuBellBossBar/Texture/Vanilla/";
    /// <summary>
    /// <br/>在这里注册所有原版血条贴图
    /// <br/>Signed all Vanilla health bar texture here
    /// </summary>
    public static Dictionary<int, Asset<Texture2D>[]> VanillaTextures = new Dictionary<int, Asset<Texture2D>[]>()
    {
        {
            int.MaxValue,
            [
                 ModContent.Request<Texture2D>(_vpath + "HealthBarStart_Exp", AssetRequestMode.ImmediateLoad),
                 ModContent.Request<Texture2D>(_vpath + "HealthBarMiddle_Exp", AssetRequestMode.ImmediateLoad),
                 ModContent.Request<Texture2D>(_vpath + "HealthBarEnd_Exp", AssetRequestMode.ImmediateLoad),
                 ModContent.Request<Texture2D>(_vpath + "HealthBarFill", AssetRequestMode.ImmediateLoad),
                 null
            ]
        }, 

        {
            int.MinValue,
            [
                ModContent.Request<Texture2D>(_vpath + "HealthBarStart", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "HealthBarMiddle", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "HealthBarEnd", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "HealthBarFill", AssetRequestMode.ImmediateLoad),
                null
            ]
        },

        {
            NPCID.KingSlime,
            [
                ModContent.Request<Texture2D>(_vpath + "KingSlimeHead", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "KingSlimeMid", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "KingSlimeEnd", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "KingSlimeFill", AssetRequestMode.ImmediateLoad),
                null
            ]
        },

        {
            NPCID.EyeofCthulhu,
            [
                ModContent.Request<Texture2D>(_vpath + "CthEyeHead", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "CthEyeMid", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "CthEyeEnd", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "CthEyeFill", AssetRequestMode.ImmediateLoad),
                null
            ]
        },

        {
            NPCID.EaterofWorldsHead,
            [
                ModContent.Request<Texture2D>(_vpath + "EOCHead", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "EOCMid", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "EOCEnd", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "EOCFill", AssetRequestMode.ImmediateLoad),
                TextureAssets.NpcHeadBoss[2]
            ]
        },

        {
            NPCID.BrainofCthulhu ,
            [
                ModContent.Request<Texture2D>(_vpath + "BrainHead", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "BrainMid", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "BrainEnd", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "BrainFill", AssetRequestMode.ImmediateLoad),
                TextureAssets.NpcHeadBoss[23]
            ]
        },

        {
            NPCID.QueenBee,
            [
                ModContent.Request<Texture2D>(_vpath + "QueenBeeHead", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "QueenBeeMid", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "QueenBeeEnd", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "QueenBeeFill", AssetRequestMode.ImmediateLoad),
                null
            ]
        },

        {
            NPCID.SkeletronHead ,
            [
                ModContent.Request<Texture2D>(_vpath + "SkeletronHead", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "SkeletronMid", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "SkeletronEnd", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "SkeletronFill", AssetRequestMode.ImmediateLoad),
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
                null,
            ]
        },

        {
            NPCID.WallofFlesh,
            [
                ModContent.Request<Texture2D>(_vpath + "DemonBarStart", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "DemonBarMiddle", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "DemonBarEnd", AssetRequestMode.ImmediateLoad),
                null,
                null
            ]
        },

        {
            NPCID.QueenSlimeBoss,
            [
                ModContent.Request<Texture2D>(_vpath + "QueenSlimeStart", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "QueenSlimeMid", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "QueenSlimeEnd", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "QueenSlimeFill", AssetRequestMode.ImmediateLoad),
                null
            ]
        },

        {
            NPCID.Retinazer,
            [
                ModContent.Request<Texture2D>(_vpath + "MechBarStart", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "MechBarMiddle", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "MechBarEnd", AssetRequestMode.ImmediateLoad),
                null,
                null
            ]
        },

        {
            NPCID.Spazmatism,
            [
                ModContent.Request<Texture2D>(_vpath + "MechBarStart", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "MechBarMiddle", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "MechBarEnd", AssetRequestMode.ImmediateLoad),
                null,
                null
            ]
        },

        {
            NPCID.TheDestroyer,
            [
                ModContent.Request<Texture2D>(_vpath + "MechBarStart", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "MechBarMiddle", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "MechBarEnd", AssetRequestMode.ImmediateLoad),
                null,
                null
            ]
        },

        {
            NPCID.SkeletronPrime ,
            [
                ModContent.Request<Texture2D>(_vpath + "MechBarStart", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "MechBarMiddle", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "MechBarEnd", AssetRequestMode.ImmediateLoad),
                null,
                TextureAssets.NpcHeadBoss[18]
            ]
        },

        {
            NPCID.Plantera,
            [
                ModContent.Request<Texture2D>(_vpath + "PlantBarStart", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "PlantBarMiddle", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "PlantBarEnd", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "PlantBarFill", AssetRequestMode.ImmediateLoad),
                null
            ]
        },

        {
            NPCID.Golem ,
            [
                ModContent.Request<Texture2D>(_vpath + "GolemHead", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "GolemMid", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "GolemEnd", AssetRequestMode.ImmediateLoad),
                ModContent.Request<Texture2D>(_vpath + "GolemFill", AssetRequestMode.ImmediateLoad),
                TextureAssets.NpcHeadBoss[5]
            ]
        },

        {
            NPCID.HallowBoss,
            [
               ModContent.Request<Texture2D>(_vpath + "ELStart", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "ELMid", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "ELEnd", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "ELFill", AssetRequestMode.ImmediateLoad),
               null
            ]
        },

        {
            NPCID.DukeFishron,
            [
               ModContent.Request<Texture2D>(_vpath + "DukeHead", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DukeMid", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DukeEnd", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DukeFill", AssetRequestMode.ImmediateLoad),
               null
            ]
        },

        {
            NPCID.CultistBoss,
            [
               ModContent.Request<Texture2D>(_vpath + "CultistHead", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "CultistMid", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "CultistEnd", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "CultistFill", AssetRequestMode.ImmediateLoad),
               TextureAssets.NpcHeadBoss[24]
            ]
        },

        {
            NPCID.MoonLordHead ,
            [
               ModContent.Request<Texture2D>(_vpath + "MoonLordBarStart_Exp", AssetRequestMode.ImmediateLoad),
               null,
               ModContent.Request<Texture2D>(_vpath + "MoonLordBarEnd_EXP", AssetRequestMode.ImmediateLoad),
               null,
               TextureAssets.NpcHeadBoss[8]
            ]
        },


        {
            NPCID.MoonLordHand,
            [
               ModContent.Request<Texture2D>(_vpath + "SmBarStart_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "SmBarMiddle_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "SmBarEnd_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "SmBarFill", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "MLEye", AssetRequestMode.ImmediateLoad)
            ]
        },

        {
            NPCID.MoonLordCore,
            [
               ModContent.Request<Texture2D>(_vpath + "SmBarStart_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "SmBarMiddle_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "SmBarEnd_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "SmBarFill", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "MLHeart", AssetRequestMode.ImmediateLoad)
            ]
        },

        {
            NPCID.MartianSaucer ,
            [
               ModContent.Request<Texture2D>(_vpath + "MartianHead", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "MartianMid", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "MartianEndEnd", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "MartianFill", AssetRequestMode.ImmediateLoad),
               null
            ]
        },

        {
            NPCID.PirateShip,
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
               ModContent.Request<Texture2D>(_vpath + "SmBarStart_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "SmBarMiddle_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "SmBarEnd_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DD2SmBarFill", AssetRequestMode.ImmediateLoad),
               null
            ]
        },

        {
            NPCID.DD2OgreT3 ,
            [
               ModContent.Request<Texture2D>(_vpath + "DD2BarStart", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DD2BarMiddle", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DD2BarEnd", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DD2BarFill", AssetRequestMode.ImmediateLoad),
               null
            ]
        },

        {
            NPCID.DD2DarkMageT1 ,
            [
               ModContent.Request<Texture2D>(_vpath + "SmBarStart_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "SmBarMiddle_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "SmBarEnd_Exp", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DD2SmBarFill", AssetRequestMode.ImmediateLoad),
               null
            ]
        },

        {
            NPCID.DD2DarkMageT3 ,
            [
               ModContent.Request<Texture2D>(_vpath + "DD2BarStart", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DD2BarMiddle", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DD2BarEnd", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DD2BarFill", AssetRequestMode.ImmediateLoad),
               null
            ]
        },

        {
            NPCID.DD2Betsy ,
            [
               ModContent.Request<Texture2D>(_vpath + "DD2BarStart", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DD2BarMiddle", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DD2BarEnd", AssetRequestMode.ImmediateLoad),
               ModContent.Request<Texture2D>(_vpath + "DD2BarFill", AssetRequestMode.ImmediateLoad),
               null
            ]
        }
    };

    /// <summary>
    /// <br/>在这里注册所有灾厄血条贴图,请在<see langword="Mod.Load"/>后修改该词典中文件
    /// <br/>Signed all Calamity health bar texture here,please modify it after it be signed in <see langword="Mod.Load"/>
    /// </summary>
    public static Dictionary<int, Asset<Texture2D>[]> CalamityTextures = new Dictionary<int, Asset<Texture2D>[]>();
}

