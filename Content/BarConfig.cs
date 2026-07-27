namespace YuBellBossBar.Content;

public class BarConfig : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ClientSide;

#pragma warning disable CA2211
    public static BarConfig Instance;

    public override void OnLoaded() => Instance = this;

    [Header($"PostionHeader")]

    [DefaultValue(0)]
    [Range(int.MinValue,int.MaxValue)]
    public int BarPostionX;
    [DefaultValue(0)]
    [Range(int.MinValue, int.MaxValue)]
    public int BarPostionY;

    [Header($"TextureHeader")]

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

    [Header($"CustomHeader")]

    [DefaultValue(800)]
    [Range(400, int.MaxValue)]
    public int BarLength;

    [DefaultValue(4)]
    [Range(0,int.MaxValue)]
    public int PostHealthSpeed;

    [Range(0,int.MaxValue)]
    [DefaultValue(35)]
    public int PostHealthTime;

    [Range(0, 100)]
    [DefaultValue(100)]
    public int Alpha;

    [Range(0, 100)]
    [DefaultValue(50)]
    public int MouseAlpha;

    [Range(0,255)]
    [DefaultValue(54)]
    public int ShieldColorR;
    [Range(0, 255)]
    [DefaultValue(163)]
    public int ShieldColorG;
    [Range(0, 255)]
    [DefaultValue(232)]
    public int ShieldColorB;

    [Header($"InfoHeader")]

    [DefaultValue(true)]
    public bool ShowBar;

    [DefaultValue(true)]
    public bool ShowShield;

    [DefaultValue(true)]
    public bool ShowInvincible;
    [DefaultValue(true)]
    public bool ShowName;
    [DefaultValue(true)]
    public bool ShowLife;
    [DefaultValue(true)]
    public bool ShowLifeMax;
    [DefaultValue(true)]
    public bool ShowPercent;
    [DefaultValue(true)]
    public bool ShowSegment;
    [DefaultValue(true)]
    public bool ShowDefense;
    [DefaultValue(true)]
    public bool ShowCalDR;
    [DefaultValue(true)]
    public bool ShowFarDR;
    [DefaultValue(true)]
    public bool ShowTarget;
    [DefaultValue(true)]
    public bool ShowDamage;
    [DefaultValue(true)]
    public bool ShowIcon;

    [Header($"ExperimentalHeader")]

    [DefaultValue(false)]
    public bool ImprovedLifeCalculation;

#if DEBUG
    [Header($"DebugHeader")]

    [DefaultValue(true)]
    public bool UseOldFillAllLogic;
#endif
}
