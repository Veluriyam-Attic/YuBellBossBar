namespace YuBellBossBar.Content;

internal static class VBarData
{
    private const string _vpath = "YuBellBossBar/Texture/Vanilla/";

    public static Dictionary<int, VBarParams> buildiincontent = new Dictionary<int, VBarParams>();

    public static Dictionary<int, IBigProgressBar> _bossBarsByNpcNetId;

    // TODO:这个地方是用于同时绘制多Boss血条的
    // TODO:This place is used to draw multiple boss bars at the same time
    public static Dictionary<int, VBarParams> BarParams = new Dictionary<int, VBarParams>();

    public static void InstanceBuildInContent()
    {
        buildiincontent.Add(
            int.MaxValue,new VBarParams(new BarTextures(new Dictionary<TextureType, BarDraws>()
            {
                { 
                    TextureType.Fill, 
                    new BarDraws(TextureType.Head,ModContent.Request<Texture2D>
                    (_vpath + "HealthBarHead_Exp", AssetRequestMode.ImmediateLoad)) 
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
                    (_vpath + "HealthBarEnd_Exp", AssetRequestMode.ImmediateLoad))
                }
            }), null)
            );
    }
}