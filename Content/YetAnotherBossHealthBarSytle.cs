namespace YuBellBossBar.Content;

internal class YetAnotherBossHealthBarSytle : ModBossBarStyle
{
    /// <summary>
    /// <br/>用来决定绘制哪些血条
    /// <br/>Be used to check which boss's bar should be drawn
    /// </summary>
    internal static int[] BarCount = new int[VBarConfig.Instance.BarCount];

    /// <summary>
    /// <br/>用来判断是否启用来这个Boss血条样式
    /// <br/>Use it to check whether this boss bar style is selected or not.
    /// </summary>
    internal static bool Selected = false;

    public override string DisplayName => Language.GetTextValue("Mods.YuBellBossBar.Name");

    public override bool PreventDraw => true;

    public override void OnSelected() => Selected = true;

    public override void OnDeselected() => Selected = false;
}

