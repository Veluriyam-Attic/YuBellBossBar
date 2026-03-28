namespace YuBellBossBar.Content;

internal static class VBarData
{
    private const string _vpath = "YuBellBossBar/Texture/Vanilla/";

    public static Dictionary<int, BarTextures> buildiincontent = new Dictionary<int, BarTextures>();

    public static Dictionary<int, IBigProgressBar> _bossBarsByNpcNetId;

    // TODO:这个地方是用于同时绘制多Boss血条的
    // TODO:This place is used to draw multiple boss bars at the same time
    public static Dictionary<int, BarTextures> BarParams = new Dictionary<int, BarTextures>();

    public static void InstanceBuildInContent()
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