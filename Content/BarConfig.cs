namespace YuBellBossBar.Content;

public class BarConfig : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ClientSide;

    public static BarConfig Instance;

    public override void OnLoaded() => Instance = this;

    [DefaultValue(3)]
    [Range(1,10)]
    [ReloadRequired]
    public int BarCount;

    [DefaultValue(0)]
    public int BarPostionX;
    [DefaultValue(0)]
    public int BarPostionY;

    [DefaultValue(true)]
    public bool GoldenStyle;

    [DefaultValue(800)]
    [Range(400,int.MaxValue)]
    public int BarLength;
}
