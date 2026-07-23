namespace YuBellBossBar.Content;

internal class YetAnotherBossHealthBarSytle : ModBossBarStyle
{
    /// <summary>
    /// <br/>用来判断是否启用来这个Boss血条样式
    /// <br/>Use it to check whether this boss bar style is selected or not.
    /// </summary>
    internal static bool Selected = false;

#pragma warning disable IDE0090,IDE0028
    public static Dictionary<int, BarInfo> ModCalls = new Dictionary<int, BarInfo>();

    public override string DisplayName => Language.GetTextValue("Mods.YuBellBossBar.Name");

    public override bool PreventDraw => false;

    public override void OnSelected() => Selected = true;

    public override void OnDeselected() => Selected = false;

    public static NPC npc;
    public static BossBarDrawParams drawParams;

    public override void Draw(SpriteBatch spriteBatch, IBigProgressBar currentBar, BigProgressBarInfo info)
    {
        if (currentBar == null)
            return;
        if (npc == null)
            return;
        // npc和drawParams在GlobalBar.PreDraw()中被赋值
        if (BarDrawsMethods.PreDraw(spriteBatch, npc, drawParams))
            if (BarDrawsMethods.Draw(spriteBatch, npc, drawParams))
                BarDrawsMethods.PostDraw(spriteBatch, npc, drawParams);
    }
}

