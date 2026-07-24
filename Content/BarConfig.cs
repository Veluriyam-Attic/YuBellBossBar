namespace YuBellBossBar.Content;

public class BarConfig : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ClientSide;

#pragma warning disable CA2211
    public static BarConfig Instance;

    public override void OnLoaded() => Instance = this;

    [DefaultValue(0)]
    public int BarPostionX;
    [DefaultValue(0)]
    public int BarPostionY;

    [DefaultValue(true)]
    public bool GoldenStyle;

    [DefaultValue(false)]
    public bool ForceDefaulTexture;

    [DefaultValue(true)]
    public bool EnableDefualVanilla;

    [DefaultValue(true)]
    public bool EnableExtraVanilla;

    [DefaultValue(true)]
    public bool EnableExtraCalamity;

    [DefaultValue(true)]
    public bool EnableExtraInfo;

    [DefaultValue(true)]
    public bool EnableExtraCustom;

    [DefaultValue(800)]
    [Range(400, int.MaxValue)]
    public int BarLength;

    [DefaultValue(4)]
    [Range(0,int.MaxValue)]
    public int PostHealthSpeed;

    [Range(0,int.MaxValue)]
    [DefaultValue(35)]
    public int PostHealthTime;
}
