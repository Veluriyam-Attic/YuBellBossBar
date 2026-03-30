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
                            new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                            (_dtpath + "HealthBarFill_Exp", AssetRequestMode.ImmediateLoad),
                            TextureSource.DefaultTexture,
                            (barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) => { barFillStyles = BarFillStyles.Extend; })
                        },
                        {
                            TextureType.Frame,
                            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                            (_dtpath + "HealthBarFrame_Exp", AssetRequestMode.ImmediateLoad),
                            TextureSource.DefaultTexture,
                            (barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) => { barFrameStyles = BarFrameStyles.Extend; })
                        },
                        {
                            TextureType.Head,
                            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                            (_dtpath + "HealthBarHead_Exp", AssetRequestMode.ImmediateLoad),
                            TextureSource.DefaultTexture)
                        },
                        {
                            TextureType.Tail,
                            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                            (_dtpath + "HealthBarTail_Exp", AssetRequestMode.ImmediateLoad),
                            TextureSource.DefaultTexture)
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
                            new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                            (_dtpath + "HealthBarFill", AssetRequestMode.ImmediateLoad),
                            TextureSource.DefaultTexture,
                            (barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) => { barFillStyles = BarFillStyles.Extend; })
                        },
                        {
                            TextureType.Frame,
                            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                            (_dtpath + "HealthBarFrame", AssetRequestMode.ImmediateLoad),
                            TextureSource.DefaultTexture,
                            (barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) => { barFrameStyles = BarFrameStyles.Extend; })
                        },
                        {
                            TextureType.Head,
                            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                            (_dtpath + "HealthBarHead", AssetRequestMode.ImmediateLoad),
                            TextureSource.DefaultTexture)
                        },
                        {
                            TextureType.Tail,
                            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                            (_dtpath + "HealthBarTail", AssetRequestMode.ImmediateLoad),
                            TextureSource.DefaultTexture)
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
                            TextureType.Frame,
                            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                                (_dvpath + "WallofFleshFrame",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla,
                                (barFillSytle,barFillColot,fillColor,barFrameStyles,extraDrawStyles) => { barFrameStyles = BarFrameStyles.Extend; }
                            )
                        },
                        {
                            TextureType.Head,
                            new BarTexture2D(
                                TextureType.Head,ModContent.Request<Texture2D>
                                (_dvpath + "WallofFleshHead",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla
                            )
                        },
                        {
                            TextureType.Tail,
                            new BarTexture2D(
                                TextureType.Tail,ModContent.Request<Texture2D>
                                (_dvpath + "WallofFleshTail",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla
                            )
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
                    NPCID.WallofFleshEye,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Frame,
                            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                                (_dvpath + "WallofFleshFrame",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla,
                                (barFillSytle,barFillColot,fillColor,barFrameStyles,extraDrawStyles) => { barFrameStyles = BarFrameStyles.Extend; }
                            )
                        },
                        {
                             TextureType.Head,
                             new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                                (_dvpath + "WallofFleshHead",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla
                             )
                        },
                        {
                             TextureType.Tail,
                             new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                                (_dvpath + "WallofFleshTail",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla
                             )
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
                            TextureType.Frame,
                            new BarTexture2D(
                                TextureType.Frame,ModContent.Request<Texture2D>
                                (_dvpath + "MechBossFrame",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla,
                                (barFillSytle,barFillColot,fillColor,barFrameStyles,extraDrawStyles) => { barFrameStyles = BarFrameStyles.Extend; }
                            )
                        },
                        {
                            TextureType.Head,
                            new BarTexture2D(
                                TextureType.Head,ModContent.Request<Texture2D>
                                (_dvpath + "MechBossHead",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla
                            )
                        },
                        {
                            TextureType.Tail,
                            new BarTexture2D(
                                TextureType.Tail,ModContent.Request<Texture2D>
                                (_dvpath + "MechBossTail",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla
                            )
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
                            TextureType.Frame,
                            new BarTexture2D(
                                TextureType.Frame,ModContent.Request<Texture2D>
                                (_dvpath + "MechBossFrame",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla,
                                (barFillSytle,barFillColot,fillColor,barFrameStyles,extraDrawStyles) => { barFrameStyles = BarFrameStyles.Extend; }
                            )
                        },
                        {
                            TextureType.Head,
                            new BarTexture2D(
                                TextureType.Head,ModContent.Request<Texture2D>
                                (_dvpath + "MechBossHead",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla
                            )
                        },
                        {
                            TextureType.Tail,
                            new BarTexture2D(
                                TextureType.Tail,ModContent.Request<Texture2D>
                                (_dvpath + "MechBossTail",AssetRequestMode.ImmediateLoad),
                                TextureSource.DefaultVanilla
                            )
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
                            new BarTexture2D(TextureType.Fill,ModContent.Request<Texture2D>
                                (_evpath + "KingSlimeFill",
                                AssetRequestMode.ImmediateLoad),
                                TextureSource.ExtraVanilla,
                                (barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) => { barFillStyles = BarFillStyles.Extend; }
                            )
                        },
                        {
                            TextureType.Frame,
                            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                                (_evpath + "KingSlimeFrame",
                                AssetRequestMode.ImmediateLoad),
                                TextureSource.ExtraVanilla,
                                (barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) => { barFrameStyles = BarFrameStyles.Extend; }
                            )
                        },
                        {
                            TextureType.Head,
                            new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                                (_evpath + "KingSlimeHead",
                                AssetRequestMode.ImmediateLoad),
                                TextureSource.ExtraVanilla
                            )
                        },
                        {
                            TextureType.Tail,
                            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                                (_evpath + "KingSlimeTail",
                                AssetRequestMode.ImmediateLoad),
                                TextureSource.ExtraVanilla
                            )
                        },
                    }
                )
            )
        );
        #endregion
        #endregion
    }
}