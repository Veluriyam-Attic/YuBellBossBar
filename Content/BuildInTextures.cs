namespace YuBellBossBar.Content;

internal static class BuildInTextures
{
    private const string _dtpath = "YuBellBossBar/Texture/DefaultTexture/";
    private const string _dvpath = "YuBellBossBar/Texture/DefaultVanilla/";
    private const string _evpath = "YuBellBossBar/Texture/ExtraVanilla/";

    public static Dictionary<string, BarTexture2D> DefaultTexture = new Dictionary<string, BarTexture2D>()
    {
        {
            "HealthBarFill",
            new BarTexture2D(
                TextureType.Fill,
                ModContent.Request<Texture2D>(_dtpath + "HealthBarFill",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                {barFillStyles = BarFillStyles.Extend; barFillColor = BarFillColor.Vanilla; fillCutLengh.Item2 = 8; }
            )
        },
        {
            "HealthBarFrame_Exp",
            new BarTexture2D(
                TextureType.Frame,
                ModContent.Request<Texture2D>(_dtpath + "HealthBarFrame_Exp", AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "HealthBarHead_Exp",
            new BarTexture2D(
                TextureType.Frame,
                ModContent.Request<Texture2D>(_dtpath + "HealthBarHead_Exp", AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(79,32);fillOffset = new Vector2(30,16); }
            )
        },
        {
            "HealthBarTail_Exp",
            new BarTexture2D(
                TextureType.Tail,
                ModContent.Request<Texture2D>(_dtpath + "HealthBarTail_Exp", AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(0,16); }
            )
        },
        {
            "HealthBarFrame",
            new BarTexture2D(
                TextureType.Frame,
                ModContent.Request<Texture2D>(_dtpath + "HealthBarFrame", AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "HealthBarHead",
            new BarTexture2D(
                TextureType.Frame,
                ModContent.Request<Texture2D>(_dtpath + "HealthBarHead", AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(79,32);fillOffset = new Vector2(30,16); }
            )
        },
        {
           "HealthBarTail",
           new BarTexture2D(
                TextureType.Tail,
                ModContent.Request<Texture2D>(_dtpath + "HealthBarTail", AssetRequestMode.ImmediateLoad),
               TextureSource.DefaultTexture,
               (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
               { fillOffset = new Vector2(0,16); }
           )
        },
    };

    public static Dictionary<string, BarTexture2D> DefaultVanilla = new Dictionary<string, BarTexture2D>()
    {
        {
            "WallofFleshFrame",
            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                (_dvpath + "WallofFleshFrame",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColot,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "WallofFleshHead",
            new BarTexture2D(
                TextureType.Head,ModContent.Request<Texture2D>
                (_dvpath + "WallofFleshHead",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColot,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(52,30);fillOffset = new Vector2(4,16); }
            )
        },
        {
            "WallofFleshTail",
            new BarTexture2D(
                TextureType.Tail,ModContent.Request<Texture2D>
                (_dvpath + "WallofFleshTail",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColot,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(4,16); }
            )
        },
        {
            "MechBossFrame",
            new BarTexture2D(
                TextureType.Frame,ModContent.Request<Texture2D>
                (_dvpath + "MechBossFrame",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColot,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "MechBossHead",
            new BarTexture2D(
                TextureType.Head,ModContent.Request<Texture2D>
                (_dvpath + "MechBossHead",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColot,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(14,16);headOffset = new Vector2(29,33); }
            )
        },
        {
            "MechBossTail",
            new BarTexture2D(
                TextureType.Tail,ModContent.Request<Texture2D>
                (_dvpath + "MechBossTail",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColot,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(14,16); }
            )
        },
        {
            "PlanteraFill",
            new BarTexture2D(
                TextureType.Frame,ModContent.Request<Texture2D>
                (_dvpath + "PlanteraFill",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColot,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend;fillCutLengh.Item2 = 18; }
            )
        },
        {
            "PlanteraFrame",
            new BarTexture2D(
                TextureType.Frame,ModContent.Request<Texture2D>
                (_dvpath + "PlanteraFrame",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColot,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "PlanteraHead",
            new BarTexture2D(
                TextureType.Head,ModContent.Request<Texture2D>
                (_dvpath + "PlanteraHead",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColot,fillColor,barFrameStyles,extraDrawStyles) =>
                {headOffset = new Vector2(33,31);fillOffset = new Vector2(30,18); }
            )
        },
        {
            "PlanteraTail",
            new BarTexture2D(
                TextureType.Tail,ModContent.Request<Texture2D>
                (_dvpath + "PlanteraTail",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColot,fillColor,barFrameStyles,extraDrawStyles) =>
                {fillOffset = new Vector2(30,18); }
            )
        },
    };

    public static Dictionary<string, BarTexture2D> ExtraVanilla = new Dictionary<string, BarTexture2D>()
    {
        {
            "KingSlimeFill",
            new BarTexture2D(TextureType.Fill,ModContent.Request<Texture2D>
                (_evpath + "KingSlimeFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend;fillCutLengh.Item2 = 8; }
            )
        },
        {
            "KingSlimeFrame",
            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                (_evpath + "KingSlimeFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "KingSlimeHead",
            new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                (_evpath + "KingSlimeHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(21,30);fillOffset = new Vector2(28,16); }
            )
        },
        {
            "KingSlimeTail",
            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                (_evpath + "KingSlimeTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(26,16); }
            )
        },
    };
}