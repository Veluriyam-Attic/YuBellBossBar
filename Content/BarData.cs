namespace YuBellBossBar.Content;

internal static class BarData
{
    private const string _vpath = "YuBellBossBar/Texture/Vanilla/";

    public static Dictionary<int, BarTextures> buildiincontent = new Dictionary<int, BarTextures>();

    /// <summary>
    /// <br/>反射拿到的原版词典
    /// <br/>The Vanilla dictionary obtained by reflection
    /// </summary>
    public static Dictionary<int, IBigProgressBar> _bossBarsByNpcNetId;

    public static void InstantiateBuildInContent()
    {
        #region 金色风格 Gloden Style
        buildiincontent.Add(int.MaxValue,
            new BarTextures(
                int.MaxValue,
                new Dictionary<TextureType, BarDraws>()
                {
                    {
                        TextureType.Fill,
                        new BarDraws(TextureType.Head,ModContent.Request<Texture2D>
                        (_vpath + "HealthBarFill_Exp", AssetRequestMode.ImmediateLoad))
                    },
                    {
                        TextureType.Frame,
                        new BarDraws(TextureType.Frame,ModContent.Request<Texture2D>
                        (_vpath + "HealthBarFrame_Exp", AssetRequestMode.ImmediateLoad))
                    },
                    {
                        TextureType.Head,
                        new BarDraws(TextureType.Frame,ModContent.Request<Texture2D>
                        (_vpath + "HealthBarHead_Exp", AssetRequestMode.ImmediateLoad))
                    },
                    {
                        TextureType.Tail,
                        new BarDraws(TextureType.Tail,ModContent.Request<Texture2D>
                        (_vpath + "HealthBarTail_Exp", AssetRequestMode.ImmediateLoad))
                    }
                }
            )
        );
        #endregion
    }
}