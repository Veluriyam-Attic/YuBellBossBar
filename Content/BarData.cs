namespace YuBellBossBar.Content;

internal static class BarData
{
    private const string _dtpath = "YuBellBossBar/Texture/DefaultTexture/";
    private const string _dvpath = "YuBellBossBar/Texture/DefaultVanilla/";
    private const string _evpath = "YuBellBossBar/Texture/ExtraVanilla/";

    public static Dictionary<int, BarInfo> buildincontent = new Dictionary<int, BarInfo>();

    /// <summary>
    /// <br/>反射拿到的原版词典
    /// <br/>The Vanilla dictionary obtained by reflection
    /// </summary>
    public static Dictionary<int, IBigProgressBar> _bossBarsByNpcNetId;

    public static void InstantiateBuildInContent()
    {
        #region 默认贴图 Default Texture
        #region 金色风格 Gloden Style
        buildincontent.Add(int.MaxValue,
            new BarInfo(
                new BarTextures(
                    int.MaxValue,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultTexture["HealthBarFrame_Exp"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["HealthBarHead_Exp"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["HealthBarTail_Exp"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 银色风格 Silver Style
        buildincontent.Add(int.MinValue,
            new BarInfo(
                new BarTextures(
                    int.MinValue,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultTexture["HealthBarFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["HealthBarHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["HealthBarTail"]
                        }
                    }
                )
            )
        );
        #endregion
        #endregion

        #region 默认原版 Default Vanilla
        #region 血肉墙 Wall of Flesh
        buildincontent.Add(NPCID.WallofFlesh,
            new BarInfo(
                new BarTextures(
                    NPCID.WallofFlesh,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["WallofFleshFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["WallofFleshHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["WallofFleshTail"]
                        },
                    }
                )
            )
        );
        #endregion
        #region 血肉墙眼 Wall of Flesh Eye
        buildincontent.Add(NPCID.WallofFleshEye,
            new BarInfo(
                new BarTextures(
                    NPCID.WallofFlesh,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["WallofFleshFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["WallofFleshHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["WallofFleshTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 激光眼 Retinazer
        buildincontent.Add(
            NPCID.Retinazer,
            new BarInfo(
                new BarTextures(
                    NPCID.Retinazer,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["MechBossTail"]
                        },
                    }
                )
            )
        );
        #endregion
        #region 魔焰眼 Spazmatism
        buildincontent.Add(
            NPCID.Spazmatism,
            new BarInfo(
                new BarTextures(
                    NPCID.Spazmatism,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["MechBossTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 毁灭者 The Destroyer
        buildincontent.Add(
            NPCID.TheDestroyer,
            new BarInfo(
                new BarTextures(
                    NPCID.TheDestroyer,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["MechBossTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 机械骷髅王 Skeletron Prime
        buildincontent.Add(
            NPCID.SkeletronPrime,
            new BarInfo(
                new BarTextures(
                    NPCID.SkeletronPrime,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["MechBossTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 世纪之花 Plantera
        buildincontent.Add(
            NPCID.Plantera,
            new BarInfo(
                new BarTextures(
                    NPCID.Plantera,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultVanilla["PlanteraFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["PlanteraFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["PlanteraHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["PlanteraTail"]
                        },
                    }
                )
            )
        );
        #endregion
        #endregion

        #region 额外原版 Extra Vanilla
        #region 史莱姆王 King Slime
        buildincontent.Add(NPCID.KingSlime,
            new BarInfo(
                new BarTextures(
                    NPCID.KingSlime,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["KingSlimeFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["KingSlimeFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["KingSlimeHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["KingSlimeTail"]
                        },
                    }
                )
            )
        );
        #endregion
        #endregion
    }
}