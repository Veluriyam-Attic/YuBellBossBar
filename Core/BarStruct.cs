namespace YuBellBossBar.Core;

internal struct BarInfo
{
    #region 实例构造器 Instance Constructor
    public BarInfo(BarTextures bartextures, Dictionary<string, bool> fields = null,List<int> segment = null)
    {
        this.barTextures = bartextures;

        if (fields != null)
            foreach (string key in fields.Keys)
            {
                switch (key)
                {
                    default:
                        break;
                    case "ShowBar":
                        ShowBar = fields[key];
                        break;
                    case "ShowName":
                        ShowName = fields[key];
                        break;
                    case "ShowLife":
                        ShowLife = fields[key];
                        break;
                    case "ShowLifeMax":
                        ShowLifeMax = fields[key];
                        break;
                    case "ShowPercent":
                        ShowPercent = fields[key];
                        break;
                    case "ShowSegment":
                        ShowSegment = fields[key];
                        break;
                    case "ShowDefense":
                        ShowDefense = fields[key];
                        break;
                    case "ShowCalDR":
                        ShowCalDR = fields[key];
                        break;
                    case "ShowFarDR":
                        ShowFarDR = fields[key];
                        break;
                    case "ShowTarget":
                        ShowTarget = fields[key];
                        break;
                    case "ShowDamage":
                        ShowDamage = fields[key];
                        break;
                    case "ShowIcon":
                        ShowIcon = fields[key];
                        break;
                }
            }

        this.Segment = segment;
    }
    #endregion

    public int npctype => barTextures.npctype;
    public BarTextures barTextures;

    public List<int> Segment = null;

    public bool ShowBar = true;

    public bool ShowName = true;
    public bool ShowLife = true;
    public bool ShowLifeMax = true;
    public bool ShowPercent = true;
    public bool ShowSegment = true;
    public bool ShowDefense = true;
    public bool ShowCalDR = true;
    public bool ShowFarDR = true;
    public bool ShowTarget = true;
    public bool ShowDamage = true;
    public bool ShowIcon = true;
}


/// <summary>
/// <br/>一个血条的贴图
/// <br/>The Textures of a bar
/// </summary>
internal struct BarTextures
{
    public int npctype;

    // Fill,Frame,Head,Tail,Info是基础贴图,必有且仅有一个
    public Dictionary<TextureType, BarTexture2D> baseTextures = new Dictionary<TextureType, BarTexture2D>();

    public List<BarTexture2D> extraTexturesBelowFill = new List<BarTexture2D>();
    public List<BarTexture2D> extraTexturesBetweenFillAndFrame = new List<BarTexture2D>();
    public List<BarTexture2D> extraTexturesBetweenFrameAndHeadEnd = new List<BarTexture2D>();
    public List<BarTexture2D> extraTexturesBetweenHeadEndAndIcon = new List<BarTexture2D>();
    public List<BarTexture2D> extraTexturesBetweenIconAndInfo = new List<BarTexture2D>();
    public List<BarTexture2D> extraTexturesUponInfo = new List<BarTexture2D>();

    #region 实例构造器 Instance Constructor
    /// <summary>
    /// <br/><see langword="TextureType.Icon,TextureType.Fill, TextureType.Frame, TextureType.Head, TextureType.Tail, TextureType.Info"/>是基础贴图,必有且仅有一个
    /// <br/><see langword="TextureType.Icon,TextureType.Fill, TextureType.Frame, TextureType.Head, TextureType.Tail, TextureType.Info"/> are the basic textures, there must be one and only one of each.
    /// </summary>
    public BarTextures(int npctype, Dictionary<TextureType, BarTexture2D> bardraws)
    {
        this.npctype = npctype;
        foreach (TextureType type in bardraws.Keys)
        {
            switch (type)
            {
                default:
                    break;
                #region 基础贴图 Basic Textures
                case TextureType.Icon:
                    this.baseTextures.TryAdd(TextureType.Icon, bardraws[type]);
                    break;
                case TextureType.Fill:
                    this.baseTextures.TryAdd(TextureType.Fill, bardraws[type]);
                    break;
                case TextureType.Frame:
                    this.baseTextures.TryAdd(TextureType.Frame, bardraws[type]);
                    break;
                case TextureType.Head:
                    this.baseTextures.TryAdd(TextureType.Head, bardraws[type]);
                    break;
                case TextureType.Tail:
                    this.baseTextures.TryAdd(TextureType.Tail, bardraws[type]);
                    break;
                case TextureType.Info:
                    this.baseTextures.TryAdd(TextureType.Info, bardraws[type]);
                    break;
                #endregion

                #region 额外贴图 Extra Textures
                case TextureType.ExtraBelowFill:
                    this.extraTexturesBelowFill.Add(bardraws[type]);
                    break;
                case TextureType.ExtraBetweenFillAndFrame:
                    this.extraTexturesBetweenFillAndFrame.Add(bardraws[type]);
                    break;
                case TextureType.ExtraBetweenFrameAndHeadEnd:
                    this.extraTexturesBetweenFrameAndHeadEnd.Add(bardraws[type]);
                    break;
                case TextureType.ExtraBetweenHeadEndAndIcon:
                    this.extraTexturesBetweenHeadEndAndIcon.Add(bardraws[type]);
                    break;
                case TextureType.ExtraBetweenIconAndInfo:
                    this.extraTexturesBetweenIconAndInfo.Add(bardraws[type]);
                    break;
                case TextureType.ExtraUponInfo:
                    this.extraTexturesUponInfo.Add(bardraws[type]);
                    break;
                #endregion
            }
        }
    }
    #endregion
}

/// <summary>
/// <br/>一个该结构体只服务一张贴图
/// <br/>One struct serves only one texture
/// </summary>
internal struct BarTexture2D
{
    // 贴图文件
    public Asset<Texture2D> texture;

    // 偏移量
    public Vector2 fillOffset = Vector2.Zero;
    public Vector2 headOffset = Vector2.Zero;
    public int fillCutLengh = 0;

    // 贴图来源
    public TextureSource source = TextureSource.None;

    // 该来源贴图是否可以被绘制
    public bool ConfigEnabled 
    {
        get {
            #pragma warning disable CS8524
            return source switch
            {
                TextureSource.DefaultTexture => true,
                TextureSource.DefaultVanilla => BarConfig.Instance.EnableDefualVanilla,
                TextureSource.ExtraVanilla => BarConfig.Instance.EnableExtraVanilla,
                TextureSource.ExtraCalamity => BarConfig.Instance.EnableExtraCalamity,
                TextureSource.ExtraInfo => BarConfig.Instance.EnableExtraInfo,
                TextureSource.ExtraCustom => BarConfig.Instance.EnableExtraCustom,
                TextureSource.None => true,
            };
        } 
    }

    // 贴图帧数
    public int frameCount = 1;

    public int TicksPerFrame = 6;

    // 贴图类型
    public TextureType textureType = TextureType.None;

    // 血条填充样式
    public BarFillStyles barFillStyles = BarFillStyles.None;

    // 血条边框样式
    public BarFrameStyles barFrameStyles = BarFrameStyles.None;

    // 血条填充颜色类型
    public BarFillColor barFillColor = BarFillColor.Custom;

    // 血条填充颜色
    public Color fillColor = Color.White;

    // 自定义绘制事件,Vector2是血条绘制正中心位置, int是血条长度
    public Func<SpriteBatch, Vector2, int,Vector2> CustomDrawEvent = null;

    public delegate void BarTexture2DInitiator(ref int fillCutLengh, ref Vector2 fillOffset, ref Vector2 headOffset, ref BarFillStyles barFillStyles, ref BarFillColor barFillColor, ref Color fillColor, ref BarFrameStyles barFrameStyles);

    #region 实例构造器 Instance Constructor
#pragma warning disable CS1573
    /// <param name="initiator">fillCutLengh,fillOffset,headOffset,barFillStyles, barFillColor, fillColor, barFrameStyles, extraStyles</param>
    public BarTexture2D(TextureType type, Asset<Texture2D> texture, TextureSource textureSource, BarTexture2DInitiator initiator = null, int framecount = 1,int TPF = 6, Func<SpriteBatch, Vector2, int, Vector2> customDraw = null)
    {
        this.textureType = type;
        this.texture = texture;
        this.CustomDrawEvent += customDraw;
        this.frameCount = framecount;
        this.source = textureSource;
        this.TicksPerFrame = TPF;

        // 在默认构造器逻辑之后调用,来服务委托中潜在的修改
        // Call after the default constructor logic to serve potential modifications in the delegate
        initiator?.Invoke(ref fillCutLengh,ref fillOffset,ref headOffset,ref barFillStyles, ref barFillColor, ref fillColor, ref barFrameStyles);
    }
    #endregion
}