namespace YuBellBossBar.Content;

internal class YetAnotherBossHealthBarSytle : ModBossBarStyle
{
    /// <summary>
    /// <br/>用来判断是否启用来这个Boss血条样式
    /// <br/>Use it to check whether this boss bar style is selected or not.
    /// </summary>
    /// 
    public override bool IsLoadingEnabled(Mod mod)
    {
        return EnableThisMod;
    }

    internal static bool Selected = false;

    public static bool EnableThisMod = true;

    public override string DisplayName => Language.GetTextValue("Mods.YuBellBossBar.Name");

    public override bool PreventDraw => false;

    public override void OnSelected() => Selected = true;

    public override void OnDeselected() => Selected = false;

    public static event Action<SpriteBatch, Vector2> drawEvent;

    public override void Draw(SpriteBatch spriteBatch, IBigProgressBar currentBar, BigProgressBarInfo info)
    {
        Delegate[] D_array = drawEvent?.GetInvocationList();

        int x = 0;
        if (D_array != null)
        {
            foreach (Delegate D in D_array)
            {
                D?.DynamicInvoke(spriteBatch, new Vector2(BarDrawsMethods.position.X, BarDrawsMethods.position.Y - (x * 85)));
                x++;
                if (x >= 3)
                    break;
            }
        }
        drawEvent = null;
    }
}

