namespace YuBellBossBar.Core;

/// <summary>
/// <br/>一个血条的贴图
/// <br/>The Textures of a bar
/// </summary>
internal struct BarTextures
{
    public int npctype;

    // Fill,Frame,Head,Tail,Info是基础贴图,必有且仅有一个
    public Dictionary<TextureType, BarDraws> baseTextures = new Dictionary<TextureType, BarDraws>();

    public List<BarDraws> extraTexturesBelowFill = new List<BarDraws>();
    public List<BarDraws> extraTexturesBetweenFillAndFrame = new List<BarDraws>();
    public List<BarDraws> extraTexturesBetweenFrameAndHeadEnd = new List<BarDraws>();
    public List<BarDraws> extraTexturesBetweenHeadEndAndIcon = new List<BarDraws>();
    public List<BarDraws> extraTexturesBetweenIconAndInfo = new List<BarDraws>();
    public List<BarDraws> extraTexturesUponInfo = new List<BarDraws>();

    #region 实例构造器 Instance Constructor
    /// <summary>
    /// <br/><see langword="TextureType.Icon,TextureType.Fill, TextureType.Frame, TextureType.Head, TextureType.Tail, TextureType.Info"/>是基础贴图,必有且仅有一个
    /// <br/><see langword="TextureType.Icon,TextureType.Fill, TextureType.Frame, TextureType.Head, TextureType.Tail, TextureType.Info"/> are the basic textures, there must be one and only one of each.
    /// </summary>
    public BarTextures(int npctype,Dictionary<TextureType,BarDraws> bardraws)
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
internal struct BarDraws
{
    public Asset<Texture2D> texture;

    public int frameCount = 1;

    public BarAnimation barAnimation;

    public Vector2 certerPosition;

    public TextureType textureType;

    public BarFillStyles barFillStyles;

    public BarFrameStyles barFrameStyles;

    public BarFillColor barFillColor;

    public Color fillColor = Color.White;

    public ExtraDrawStyles extraStyles;

    public event Action<SpriteBatch, Vector2> CustomDrawEvent = null;

    #region 实例构造器 Instance Constructor
#pragma warning disable CS1573
    /// <param name="initiator">barFillStyles, barFillColor, fillColor, barFrameStyles, extraStyles</param>
    public BarDraws(TextureType type, Asset<Texture2D> texture,Action<BarFillStyles,BarFillColor,Color,BarFrameStyles,ExtraDrawStyles> initiator = null, BarAnimation animation = BarAnimation.Nope,int framecount = 1, Action<SpriteBatch, Vector2> customDraw = null)
    {
        this.textureType = type;
        this.texture = texture;
        this.CustomDrawEvent += customDraw;
        barAnimation = animation;
        this.frameCount = framecount;
        // 在默认构造器逻辑之后调用,来服务委托中潜在的修改
        // Call after the default constructor logic to serve potential modifications in the delegate
        initiator?.Invoke(barFillStyles, barFillColor, fillColor, barFrameStyles, extraStyles);
    }
    #endregion
}