namespace YuBellBossBar.Content;

public class VBarConfig : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ClientSide;

    public static VBarConfig Instance;

    public override void OnLoaded() => Instance = this;

    [DefaultValue(3)]
    [Range(1,10)]
    [ReloadRequired]
    public int BarCount;
}
