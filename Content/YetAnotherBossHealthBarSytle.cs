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

    public static event Func<SpriteBatch, Vector2,int> drawEvent;

    public override void Draw(SpriteBatch spriteBatch, IBigProgressBar currentBar, BigProgressBarInfo info)
    {
        try
        {
            Delegate[] D_array = drawEvent?.GetInvocationList();

            int x = 0;
            int count = 0;
            if (D_array != null)
            {
                foreach (Delegate D in D_array)
                {
                    // 直接强转调用,避免 DynamicInvoke 的反射装箱开销
                    x += ((Func<SpriteBatch, Vector2, int>)D).Invoke(spriteBatch, new Vector2(BarDrawsMethods.position.X, BarDrawsMethods.position.Y - x));
                    count++;
                    if (count >= BarConfig.Instance.MultipleBarAmount)
                        break;
                }
            }
        }
        catch (Exception e)
        {
            // 打印异常,避免被静默吞掉后血条不显示且排查不到原因
            Main.NewText("[Yet Another Mod Log] 血条绘制异常: " + e, Color.Red);
        }
        // 注意:drawEvent不再每帧清空,改为跨帧保留;
        // 由BarGlobalNPC按whoAmI删旧加新防止重复,由FadeAlpha淡出到0自动移除
    }
}

