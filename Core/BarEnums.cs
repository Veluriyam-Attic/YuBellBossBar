namespace YuBellBossBar.Core;

internal enum BarFillStyles
{
    /// <summary>
    /// <br/>最基础的自动延伸,也就是原Mod常用的
    /// <br/>The most basic auto extend, which is commonly used in the original mod.
    /// </summary>
    FillExtend = 0,
    /// <summary>
    /// <br/>自动填充整个血条,当血量减少时,会依旧绘制血量满时所绘制的部分,只不过是不再绘制依旧损失的血量部分
    /// <br/>automatically fill the entire bar, when the health decreases, it will still draw the part that is drawn when the health is full, except that it will no longer draw the part that is still lost health.
    /// </summary>
    FillAll = 1,
    /// <summary>
    /// <br/>自动填充部分血条,当血量减少时,会自动把当前血条的部分填充满
    /// <br/>automatically fill part of the bar, when the health decreases, it will automatically fill part of the current bar.
    /// </summary>
    FillPartial = 2,
    /// <summary>
    /// <br/>单纯的重复绘制血条,当血量减少时会取消绘制一部分
    /// <br/>Simply repeat the drawing of the bar, when the health decreases, it will cancel the drawing of a part.
    /// </summary>
    Dulplicate = 3,
    
    None = int.MaxValue,
}

internal enum BarFrameStyles
{
    /// <summary>
    /// <br/>延伸拉长边框,最常用
    /// <br/>Extend the stretched border, the most commonly used.
    /// </summary>
    Extend = 0,
    /// <summary>
    /// <br/>不断重复某一个特定图案
    /// <br/>Continuously repeat a specific pattern.
    /// </summary>
    Dulplicate = 1,
    
    None = int.MaxValue,
}

/// <summary>
/// <br/>增加可读性用的
/// <br/>Added for readability
/// </summary>

internal enum BarFillColor
{
    /// <summary>
    /// <br/>血条填充时绘制的颜色为原版,如果使用此颜色请使用灰度图
    /// <br/>The color drawn when the bar is filled is the vanilla version, if you use this color, please use a grayscale image.
    /// </summary>
    Vanilla = 0,
    /// <summary>
    /// <br/>血条填充时绘制颜色为自定义颜色
    /// <br/>The color drawn when the bar is filled is a custom color.
    /// </summary>
    Custom = 1,
}

internal enum TextureType
{
    Icon = -1,
    Fill = 0,
    Frame = 1,
    Head = 2,
    Tail = 3,
    Info = 4,
    ExtraBelowFill = 5,
    ExtraBetweenFillAndFrame = 6,
    ExtraBetweenFrameAndHeadEnd = 7,
    ExtraBetweenHeadEndAndIcon = 8,
    ExtraBetweenIconAndInfo = 9,
    ExtraUponInfo = 10,
    
    None = int.MaxValue,
}

internal enum TextureSource
{
    DefaultTexture = 0,
    DefaultVanilla = 1,
    ExtraVanilla = 2,
    ExtraCalamity = 3,
    ExtraInfo = 4,
    ExtraCustom = 5,
    
    None = int.MaxValue,
}