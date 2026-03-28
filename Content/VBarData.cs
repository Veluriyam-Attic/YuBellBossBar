namespace YuBellBossBar.Content;

internal static class VBarData
{
    public static Dictionary<int, VBarParams> buildiincontent = new Dictionary<int, VBarParams>();

    public static Dictionary<int, IBigProgressBar> _bossBarsByNpcNetId;

    // TODO:这个地方是用于同时绘制多Boss血条的
    // TODO:This place is used to draw multiple boss bars at the same time
    public static Dictionary<int, VBarParams> BarParams = new Dictionary<int, VBarParams>();

    public static void InstanceBuildInContent()
    {

    }
}