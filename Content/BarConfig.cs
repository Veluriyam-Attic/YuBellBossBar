using System.ComponentModel;
using Terraria.ModLoader.Config;

//the name of the mod is a joke
namespace BestBossBarMod.Content;

public class BarConfig : ModConfig
{
	public static BarConfig Instance;

	[Header("PostionHeader")]
	[DefaultValue(800)]
	[Range(400, int.MaxValue)]
	public int BarLong;

	[DefaultValue(0)]
	[Range(int.MinValue, int.MaxValue)]
	public int BarPostionY;

	[DefaultValue(0)]
	[Range(int.MinValue, int.MaxValue)]
	public int BarPostionX;

	[Header("InfoHeader")]
	[DefaultValue(true)]
	public bool MoreInfo;

	[DefaultValue(true)]
	public bool WorldInfo;

    [DefaultValue(true)]
    public bool ShowBossBarsWithNoHead;

    [DefaultValue(true)]
    public bool ShowInvincibleBosses;

    [DefaultValue(5)]
    [Range(1, int.MaxValue)]
    public int NumberOfBossBars;

    [DefaultValue(5)]
    [Range(1, int.MaxValue)]
    public int TransparencyBarDecreaseTime;

    [Header("StyleHeader")]
	[DefaultValue(true)]
	public bool DrawLastBar;

	[DefaultValue(5)]
    [Range(1, int.MaxValue)]
    public int LastBarDecreaseSpeed;

	[DefaultValue(true)]
	public bool UseGoldBar;

	[DefaultValue(false)]
	public bool ForceUseDefaultBar;

	[DefaultValue(true)]
	public bool ShowHealthPercentage;

    [DefaultValue(true)]
    public bool SquishHealthBarsTogether;

    [DefaultValue(true)]
    public bool DrawBarBackgrounds;

    public override ConfigScope Mode => ConfigScope.ClientSide;

	public override void OnLoaded()
	{
		BarConfig.Instance = this;
	}
}
