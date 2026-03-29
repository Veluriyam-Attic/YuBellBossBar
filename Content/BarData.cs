namespace YuBellBossBar.Content;

internal static class BarData
{
    private const string _dtpath = "YuBellBossBar/Texture/DefaultTexture/";
    private const string _dvpath = "YuBellBossBar/Texture/DefaultVanilla/";
    private const string _evpath = "YuBellBossBar/Texture/ExtraVanilla/";

    public static Dictionary<int, BarTextures> buildiincontent = new Dictionary<int, BarTextures>();

    /// <summary>
    /// <br/>反射拿到的原版词典
    /// <br/>The Vanilla dictionary obtained by reflection
    /// </summary>
    public static Dictionary<int, IBigProgressBar> _bossBarsByNpcNetId;

    public static void InstantiateBuildInContent()
    {
        #region Default Texture
        #region 金色风格 Gloden Style
        buildiincontent.Add(int.MaxValue,
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
        );
        #endregion

        #region 银色风格 Silver Style
        buildiincontent.Add(int.MinValue,
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
        );
        #endregion
        #endregion

        #region Default Vanilla
        #endregion

        #region Extra Vanilla
        buildiincontent.Add(NPCID.KingSlime,
            new BarTextures(
                NPCID.KingSlime,
                new Dictionary<TextureType, BarTexture2D>()
                {
                    {
                        TextureType.Fill,
                        new BarTexture2D(TextureType.Fill,ModContent.Request<Texture2D>
                        (_evpath + "KingSlimeFill",
                        AssetRequestMode.ImmediateLoad),
                        TextureSource.ExtraVanilla)
                    },
                    {
                        TextureType.Frame,
                        new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                        (_evpath + "KingSlimeFrame",
                        AssetRequestMode.ImmediateLoad),
                        TextureSource.ExtraVanilla)
                    },
                    {
                        TextureType.Head,
                        new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                        (_evpath + "KingSlimeHead",
                        AssetRequestMode.ImmediateLoad),
                        TextureSource.ExtraVanilla)
                    },
                    {
                        TextureType.Tail,
                        new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                        (_evpath + "KingSlimeTail",
                        AssetRequestMode.ImmediateLoad),
                        TextureSource.ExtraVanilla)
                    },
                    {
                        TextureType.Icon,
                        new BarTexture2D(TextureType.Icon,ModContent.Request<Texture2D>
                        (_evpath + "KingSlimeIcon",
                        AssetRequestMode.ImmediateLoad),
                        TextureSource.ExtraVanilla)
                    },
                }
            )
        );
        #endregion
    }
}