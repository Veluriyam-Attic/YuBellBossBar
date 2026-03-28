namespace YuBellBossBar.Core;
internal struct VBarParams
{
    public int npctype;
    public int npcwhoami;

    public float life;

    /// <summary>
    /// <br/>血量上限
    /// <br/>this npc's life's max value
    /// </summary>
    public float lifemax;

    /// <summary>
    /// <br/>出现过的最高血量
    /// <br/>the max value of life since this npc be spawned
    /// </summary>
    public float maxlife;

    public float pastlife;

    public BossBarDrawParams drawParams;

    /// <summary>
    /// <br/>贴图和如何绘制贴图都在这里了
    /// <br/>The textures and how to draw them are all here
    /// </summary>
    public BarTextures barTextures;

    /// <param name="initiator">npctype, npcwhoami, life, lifemax, maxlife, pastlife, drawParams</param>
    public VBarParams(BarTextures barTextures,Action<int,int,float,float,float,float,BossBarDrawParams> initiator)
    {
        this.barTextures = barTextures;
        initiator?.Invoke(npctype, npcwhoami, life, lifemax, maxlife, pastlife, drawParams);
    }
}

/// <summary>
/// <br/>一个血条的贴图
/// <br/>The Textures of a bar
/// </summary>
internal struct BarTextures
{
    // Fill,Frame,Head,Tail,Info是基础贴图,必有且仅有一个
    public Dictionary<TextureType, BarDraws> baseTextures = new Dictionary<TextureType, BarDraws>();

    public List<BarDraws> extraTexturesBelowFill = new List<BarDraws>();
    public List<BarDraws> extraTexturesBetweenFillAndFrame = new List<BarDraws>();
    public List<BarDraws> extraTexturesBetweenFrameAndHeadEnd = new List<BarDraws>();
    public List<BarDraws> extraTexturesBetweenHeadEndAndInfo = new List<BarDraws>();
    public List<BarDraws> extraTexturesUponInfo = new List<BarDraws>();

    #region 实例构造器 Instance Constructor
    public BarTextures(Dictionary<TextureType,BarDraws> bardraws)
    {
        foreach (TextureType type in bardraws.Keys)
        {
            switch (type)
            {
                default:
                    break;
                case TextureType.ExtraBelowFill:
                    this.extraTexturesBelowFill.Add(bardraws[type]);
                    break;
                case TextureType.ExtraBetweenFillAndFrame:
                    this.extraTexturesBetweenFillAndFrame.Add(bardraws[type]);
                    break;
                case TextureType.ExtraBetweenFrameAndHeadEnd:
                    this.extraTexturesBetweenFrameAndHeadEnd.Add(bardraws[type]);
                    break;
                case TextureType.ExtraBetweenHeadEndAndInfo:
                    this.extraTexturesBetweenHeadEndAndInfo.Add(bardraws[type]);
                    break;
                case TextureType.ExtraUponInfo:
                    this.extraTexturesUponInfo.Add(bardraws[type]);
                    break;
                case TextureType.Fill:
                    this.baseTextures.Add(TextureType.Fill, bardraws[type]);
                    break;
                case TextureType.Frame:
                    this.baseTextures.Add(TextureType.Frame, bardraws[type]);
                    break;
                case TextureType.Head:
                    this.baseTextures.Add(TextureType.Head, bardraws[type]);
                    break;
                case TextureType.Tail:
                    this.baseTextures.Add(TextureType.Tail, bardraws[type]);
                    break;
                case TextureType.Info:
                    this.baseTextures.Add(TextureType.Info, bardraws[type]);
                    break;
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