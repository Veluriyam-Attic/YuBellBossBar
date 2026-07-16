namespace YuBellBossBar.Content;

internal static class BuildInTextures
{
    #region 默认贴图
    private const string _dtpath = "YuBellBossBar/Texture/DefaultTexture/";

    public static Dictionary<string, BarTexture2D> DefaultTexture = new Dictionary<string, BarTexture2D>()
    {
        {
            "HealthBarFill",
            new BarTexture2D(
                TextureType.Fill,
                ModContent.Request<Texture2D>(_dtpath + "HealthBarFill",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend; barFillColor = BarFillColor.Vanilla; fillCutLengh.Item2 = 8; }
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
        {
           "SmallBarFill",
           new BarTexture2D(
                TextureType.Fill,
                ModContent.Request<Texture2D>(_dtpath + "SmallBarFill", AssetRequestMode.ImmediateLoad),
               TextureSource.DefaultTexture,
               (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend; barFillColor = BarFillColor.Vanilla; fillCutLengh.Item2 = 6; }
           )
        },
        {
            "SmallBarFrame",
            new BarTexture2D(
                TextureType.Frame,
                ModContent.Request<Texture2D>(_dtpath + "SmallBarFrame", AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "SmallBarFrame_Exp",
            new BarTexture2D(
                TextureType.Frame,
                ModContent.Request<Texture2D>(_dtpath + "SmallBarFrame_Exp", AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "SmallBarHead",
            new BarTexture2D(
                TextureType.Head,
                ModContent.Request<Texture2D>(_dtpath + "SmallBarHead", AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(12,12); }
            )
        },
        {
            "SmallBarHead_Exp",
            new BarTexture2D(
                TextureType.Head,
                ModContent.Request<Texture2D>(_dtpath + "SmallBarHead_Exp", AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(12,12); }
            )
        },
        {
            "SmallBarTail",
            new BarTexture2D(
                TextureType.Tail,
                ModContent.Request<Texture2D>(_dtpath + "SmallBarTail", AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { }
            )
        },
        {
            "SmallBarTail_Exp",
            new BarTexture2D(
                TextureType.Tail,
                ModContent.Request<Texture2D>(_dtpath + "SmallBarTail_Exp", AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultTexture,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { }
            )
        },
    };
    #endregion

    #region 默认原版
    private const string _dvpath = "YuBellBossBar/Texture/DefaultVanilla/";

    public static Dictionary<string, BarTexture2D> DefaultVanilla = new Dictionary<string, BarTexture2D>()
    {
        {
            "WallofFleshFrame",
            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                (_dvpath + "WallofFleshFrame",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "WallofFleshHead",
            new BarTexture2D(
                TextureType.Head,ModContent.Request<Texture2D>
                (_dvpath + "WallofFleshHead",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(52,30);fillOffset = new Vector2(4,16); }
            )
        },
        {
            "WallofFleshTail",
            new BarTexture2D(
                TextureType.Tail,ModContent.Request<Texture2D>
                (_dvpath + "WallofFleshTail",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(4,16); }
            )
        },
        {
            "MechBossFrame",
            new BarTexture2D(
                TextureType.Frame,ModContent.Request<Texture2D>
                (_dvpath + "MechBossFrame",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "MechBossHead",
            new BarTexture2D(
                TextureType.Head,ModContent.Request<Texture2D>
                (_dvpath + "MechBossHead",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(14,16);headOffset = new Vector2(29,33); }
            )
        },
        {
            "MechBossTail",
            new BarTexture2D(
                TextureType.Tail,ModContent.Request<Texture2D>
                (_dvpath + "MechBossTail",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(14,16); }
            )
        },
        {
            "PlanteraFill",
            new BarTexture2D(
                TextureType.Frame,ModContent.Request<Texture2D>
                (_dvpath + "PlanteraFill",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend; barFillColor = BarFillColor.Vanilla; fillCutLengh.Item2 = 18; }
            )
        },
        {
            "PlanteraFrame",
            new BarTexture2D(
                TextureType.Frame,ModContent.Request<Texture2D>
                (_dvpath + "PlanteraFrame",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "PlanteraHead",
            new BarTexture2D(
                TextureType.Head,ModContent.Request<Texture2D>
                (_dvpath + "PlanteraHead",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(33,31);fillOffset = new Vector2(30,18); }
            )
        },
        {
            "PlanteraTail",
            new BarTexture2D(
                TextureType.Tail,ModContent.Request<Texture2D>
                (_dvpath + "PlanteraTail",AssetRequestMode.ImmediateLoad),
                TextureSource.DefaultVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(30,18); }
            )
        },
    };
    #endregion

    #region 额外原版
    private const string _evpath = "YuBellBossBar/Texture/ExtraVanilla/";

    public static Dictionary<string, BarTexture2D> ExtraVanilla = new Dictionary<string, BarTexture2D>()
    {
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
            "KingSlimeTail",
            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                (_evpath + "KingSlimeTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(26,16); }
            )
        },
        {
            "KingSlimeFill",
            new BarTexture2D(TextureType.Fill,ModContent.Request<Texture2D>
                (_evpath + "KingSlimeFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend;fillCutLengh.Item2 = 8;barFillColor = BarFillColor.Custom; fillColor = new Color(50, 120, 255); }
            )
        },
        {
            "EyeofCthulhuHead",
            new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                (_evpath + "EyeofCthulhuHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(40,30);fillOffset = new Vector2(66,16); }
            )
        },
        {
            "EyeofCthulhuFrame",
            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                (_evpath + "EyeofCthulhuFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "EyeofCthulhuTail",
            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                (_evpath + "EyeofCthulhuTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(26,16); }
            )
        },
        {
            "EyeofCthulhuFill",
            new BarTexture2D(TextureType.Fill,ModContent.Request<Texture2D>
                (_evpath + "EyeofCthulhuFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend;fillCutLengh.Item2 = 8; barFillColor = BarFillColor.Custom; fillColor = new Color(213, 5, 5); }
            )
        },
        {
            "EaterofWorldsHead",
            new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                (_evpath + "EaterofWorldsHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(43,30);fillOffset = new Vector2(70,16); }
            )
        },
        {
            "EaterofWorldsFrame",
            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                (_evpath + "EaterofWorldsFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "EaterofWorldsTail",
            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                (_evpath + "EaterofWorldsTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(26,16); }
            )
        },
        {
            "EaterofWorldsFill",
            new BarTexture2D(TextureType.Fill,ModContent.Request<Texture2D>
                (_evpath + "EaterofWorldsFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend; barFillColor = BarFillColor.Custom; fillCutLengh.Item2 = 8; fillColor = new Color(115, 127, 33); }
            )
        },
        {
            "BrainofCthulhuHead",
            new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                (_evpath + "BrainofCthulhuHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(41,17);fillOffset = new Vector2(62,6); }
            )
        },
        {
            "BrainofCthulhuFrame",
            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                (_evpath + "BrainofCthulhuFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "BrainofCthulhuTail",
            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                (_evpath + "BrainofCthulhuTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(16,6); }
            )
        },
        {
            "BrainofCthulhuFill",
            new BarTexture2D(TextureType.Fill,ModContent.Request<Texture2D>
                (_evpath + "BrainofCthulhuFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend; barFillColor = BarFillColor.Custom; fillColor = Color.White; fillCutLengh.Item2 = 2; }
            )
        },
        {
            "QueenBeeHead",
            new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                (_evpath + "QueenBeeHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(23,26);fillOffset = new Vector2(50,8); }
            )
        },
        {
            "QueenBeeFrame",
            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                (_evpath + "QueenBeeFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "QueenBeeTail",
            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                (_evpath + "QueenBeeTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(20,8); }
            )
        },
        {
            "QueenBeeFill",
            new BarTexture2D(TextureType.Fill,ModContent.Request<Texture2D>
                (_evpath + "QueenBeeFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend; barFillColor = BarFillColor.Custom; fillColor = Color.White; fillCutLengh.Item2 = 6; }
            )
        },
        {
            "SkeletronHead",
            new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                (_evpath + "SkeletronHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(25,29);fillOffset = new Vector2(52,16); }
            )
        },
        {
            "SkeletronFrame",
            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                (_evpath + "SkeletronFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "SkeletronTail",
            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                (_evpath + "SkeletronTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(30,16); }
            )
        },
        {
            "SkeletronFill",
            new BarTexture2D(TextureType.Fill,ModContent.Request<Texture2D>
                (_evpath + "SkeletronFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend; barFillColor = BarFillColor.Custom; fillCutLengh.Item2 = 6; fillColor = new Color(240, 240, 159); }
            )
        },
        {
            "DeerclopsHead",
            new BarTexture2D(TextureType.Head,ModContent.Request<Texture2D>
                (_evpath + "DeerclopsHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { headOffset = new Vector2(52,34);fillOffset = new Vector2(102,24); }
            )
        },
        {
            "DeerclopsFrame",
            new BarTexture2D(TextureType.Frame,ModContent.Request<Texture2D>
                (_evpath + "DeerclopsFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Dulplicate; }
            )
        },
        {
            "DeerclopsTail",
            new BarTexture2D(TextureType.Tail,ModContent.Request<Texture2D>
                (_evpath + "DeerclopsTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh,fillOffset,headOffset, barFillStyles,barFillColor,fillColor,barFrameStyles,extraDrawStyles) =>
                { fillOffset = new Vector2(10,24); }
            )
        },
        {
            "DeerclopsFill",
            new BarTexture2D(TextureType.Fill, ModContent.Request<Texture2D>
                (_evpath + "DeerclopsFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFillStyles = BarFillStyles.FillAll; barFillColor = BarFillColor.Custom; fillColor = Color.White;  }
            )
        },
        {
            "QueenSlimeHead",
            new BarTexture2D(TextureType.Head, ModContent.Request<Texture2D>
                (_evpath + "QueenSlimeHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { headOffset = new Vector2(57, 29); fillOffset = new Vector2(84, 16); }
            )
        },
        {
            "QueenSlimeFrame",
            new BarTexture2D(TextureType.Frame, ModContent.Request<Texture2D>
                (_evpath + "QueenSlimeFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "QueenSlimeTail",
            new BarTexture2D(TextureType.Tail, ModContent.Request<Texture2D>
                (_evpath + "QueenSlimeTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { fillOffset = new Vector2(26, 16); }
            )
        },
        {
            "QueenSlimeFill",
            new BarTexture2D(TextureType.Fill, ModContent.Request<Texture2D>
                (_evpath + "QueenSlimeFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend; barFillColor = BarFillColor.Custom; fillColor = Color.White;  fillCutLengh.Item2 = 10; }
            )
        },
        {
            "GolemHead",
            new BarTexture2D(TextureType.Head, ModContent.Request<Texture2D>
                (_evpath + "GolemHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { headOffset = new Vector2(26, 30); fillOffset = new Vector2(56, 20); }
            )
        },
        {
            "GolemFrame",
            new BarTexture2D(TextureType.Frame, ModContent.Request<Texture2D>
                (_evpath + "GolemFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Dulplicate; }
            )

        },
        {
            "GolemTail",
            new BarTexture2D(TextureType.Tail, ModContent.Request<Texture2D>
                (_evpath + "GolemTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { fillOffset = new Vector2(24, 20); }
            )
        },
        {
            "GolemFill",
            new BarTexture2D(TextureType.Fill, ModContent.Request<Texture2D>
                (_evpath + "GolemFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend; barFillColor = BarFillColor.Custom; fillColor = Color.White;  fillCutLengh.Item2 = 10; }
            )
        },
        {
            "MartianSaucerHead",
            new BarTexture2D(TextureType.Head, ModContent.Request<Texture2D>
                (_evpath + "MartianSaucerHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { headOffset = new Vector2(21, 29); fillOffset = new Vector2(54, 20); }
            )
        },
        {
            "MartianSaucerFrame",
            new BarTexture2D(TextureType.Frame, ModContent.Request<Texture2D>
                (_evpath + "MartianSaucerFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Dulplicate; }
            )
        },
        {
            "MartianSaucerTail",
            new BarTexture2D(TextureType.Tail, ModContent.Request<Texture2D>
                (_evpath + "MartianSaucerTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { fillOffset = new Vector2(24, 20); }
            )
        },
        {
            "MartianSaucerFill",
            new BarTexture2D(TextureType.Fill, ModContent.Request<Texture2D>
                (_evpath + "MartianSaucerFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend;  barFillColor = BarFillColor.Custom; fillColor = Color.White; fillCutLengh.Item2 = 10; }
            )
        },
        {
            "DukeFishronHead",
            new BarTexture2D(TextureType.Head, ModContent.Request<Texture2D>
                (_evpath + "DukeFishronHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { headOffset = new Vector2(37, 30); fillOffset = new Vector2(82, 16); }
            )
        },
        {
            "DukeFishronFrame",
            new BarTexture2D(TextureType.Frame, ModContent.Request<Texture2D>
                (_evpath + "DukeFishronFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "DukeFishronTail",
            new BarTexture2D (TextureType.Tail, ModContent.Request<Texture2D>
                (_evpath + "DukeFishronTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { fillOffset = new Vector2(2, 16); }
            )
        },
        {
            "DukeFishronFill",
            new BarTexture2D(TextureType.Fill, ModContent.Request<Texture2D>
                (_evpath + "DukeFishronFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend;  barFillColor = BarFillColor.Custom; fillColor = Color.White; fillCutLengh.Item2 = 2; }
            )
        },
        {
            "EmpressofLightHead",
            new BarTexture2D(TextureType.Head, ModContent.Request<Texture2D>
                (_evpath + "EmpressofLightHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { headOffset = new Vector2(69, 39); fillOffset = new Vector2(102, 26); }
            )
        },
        {
            "EmpressofLightFrame",
            new BarTexture2D(TextureType.Frame, ModContent.Request<Texture2D>
                (_evpath + "EmpressofLightFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.None; }
            )

        },
        {
            "EmpressofLightTail",
            new BarTexture2D(TextureType.Tail, ModContent.Request<Texture2D>
                (_evpath + "EmpressofLightTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { fillOffset = new Vector2(20, 26); }
            )
        },
        {
            "EmpressofLightFill",
            new BarTexture2D(TextureType.Fill, ModContent.Request<Texture2D>
                (_evpath + "EmpressofLightFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFillStyles = BarFillStyles.FillAll;  barFillColor = BarFillColor.Custom; fillColor = Color.White; }
            )
        },
        {
            "LunaticCultistHead",
            new BarTexture2D(TextureType.Head, ModContent.Request<Texture2D>
                (_evpath + "LunaticCultistHead",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { headOffset = new Vector2(20, 20); fillOffset = new Vector2(36, 6); }
            )
        },
        {
            "LunaticCultistFrame",
            new BarTexture2D(TextureType.Frame, ModContent.Request<Texture2D>
                (_evpath + "LunaticCultistFrame",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFrameStyles = BarFrameStyles.Extend; }
            )
        },
        {
            "LunaticCultistTail",
            new BarTexture2D(TextureType.Tail, ModContent.Request<Texture2D>
                (_evpath + "LunaticCultistTail",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { fillOffset = new Vector2(2, 6); }
            )
        },
        {
            "LunaticCultistFill",
            new BarTexture2D(TextureType.Fill, ModContent.Request<Texture2D>
                (_evpath + "LunaticCultistFill",
                AssetRequestMode.ImmediateLoad),
                TextureSource.ExtraVanilla,
                (fillCutLengh, fillOffset, headOffset, barFillStyles, barFillColor, fillColor, barFrameStyles, extraDrawStyles) =>
                { barFillStyles = BarFillStyles.Extend; barFillColor = BarFillColor.Custom; fillColor = Color.White;  fillCutLengh.Item2 = 2; }
            )
        },
    };
    #endregion
}