namespace YuBellBossBar.Content;

internal static class BarData
{
    private const string _dtpath = "YuBellBossBar/Texture/DefaultTexture/";
    private const string _dvpath = "YuBellBossBar/Texture/DefaultVanilla/";
    private const string _evpath = "YuBellBossBar/Texture/ExtraVanilla/";

    public static Dictionary<int, BarInfo> buildiincontent = new Dictionary<int, BarInfo>();

    /// <summary>
    /// <br/>反射拿到的原版词典
    /// <br/>The Vanilla dictionary obtained by reflection
    /// </summary>
    public static Dictionary<int, IBigProgressBar> _bossBarsByNpcNetId;

    public static void InstantiateBuildInContent()
    {
        #region 默认贴图 Default Texture
        #region 金色风格 Gloden Style
        buildiincontent.Add(int.MaxValue,
            new BarInfo(
                new BarTextures(
                    int.MaxValue,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill_Exp"]
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
        buildiincontent.Add(int.MinValue,
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
        buildiincontent.Add(NPCID.WallofFlesh,
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
                            BuildInTextures.DefaultTexture["WallofFleshFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["WallofFleshHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["WallofFleshTail"]
                        },
                    }
                )
            )
        );
        #endregion
        #region 血肉墙眼 Wall of Flesh Eye
        buildiincontent.Add(NPCID.WallofFleshEye,
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
                            BuildInTextures.DefaultTexture["WallofFleshFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["WallofFleshHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["WallofFleshTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 激光眼 Retinazer
        buildiincontent.Add(
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
                            BuildInTextures.DefaultTexture["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["MechBossTail"]
                        },
                    }
                )
            )
        );
        #endregion
        #region 魔焰眼 Spazmatism
        buildiincontent.Add(
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
                            BuildInTextures.DefaultTexture["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["MechBossTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 毁灭者 The Destroyer
        buildiincontent.Add(
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
                            BuildInTextures.DefaultTexture["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["MechBossTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 机械骷髅王 Skeletron Prime
        buildiincontent.Add(
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
                            BuildInTextures.DefaultTexture["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["MechBossTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 世纪之花 Plantera
        buildiincontent.Add(
            NPCID.Plantera,
            new BarInfo(
                new BarTextures(
                    NPCID.Plantera,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["PlanteraFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultTexture["PlanteraFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["PlanteraHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["PlanteraTail"]
                        },
                    }
                )
            )
        );
        #endregion
        #endregion

        #region 额外原版 Extra Vanilla
        #region 史莱姆王 King Slime
        buildiincontent.Add(NPCID.KingSlime,
            new BarInfo(
                new BarTextures(
                    NPCID.KingSlime,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["KingSlimeFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultTexture["KingSlimeFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["KingSlimeHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["KingSlimeTail"]
                        },
                    }
                )
            )
        );
        #endregion
        #endregion
    }
}