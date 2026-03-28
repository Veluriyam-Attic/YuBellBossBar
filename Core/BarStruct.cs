namespace YuBellBossBar.Core;

// TODO: 这个结构体是用来存储Boss血条的参数的,还未完成
// TODO: This struct is used to store the parameters of the boss bar, and it is not completed yet
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

    public VBarParams(NPC npc)
    {
        this.npctype = npc.type;
        this.npcwhoami = npc.whoAmI;
    }

    public VBarParams(BarTextures barTextures)
    {
        this.barTextures = barTextures;
    }
}

/// <summary>
/// <br/>一个血条的贴图
/// <br/>The Textures of a bar
/// </summary>
internal struct BarTextures
{
    public BarDraws[] baseTextures;

    public BarDraws[] extraTexturesBelowFill;
    public BarDraws[] extraTexturesBetweenFillAndFrame;
    public BarDraws[] extraTexturesBetweenFrameAndHeadEnd;
    public BarDraws[] extraTexturesBetweenHeadEndAndInfo;
    public BarDraws[] extraTexturesUponInfo;

    public BarTextures()
    {

    }
}

/// <summary>
/// <br/>一个该结构体只服务一张贴图
/// <br/>One struct serves only one texture
/// </summary>
internal struct BarDraws
{
    public Asset<Texture2D> texture;

    public Vector2 certerPosition;

    public TextureType textureType;

    public BarFillStyles barFillStyles;

    public BarFrameStyles barFrameStyles;

    public BarAnimation barAnimation;

    public BarFillColor barFillColor;

    public ExtraDrawStyles extraStyles;

    public event Action<SpriteBatch,Vector2> CustomDrawEvent;
}