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

    /// <summary>
    /// <br/>触发所有已注册的NPC血条绘制委托。
    /// <br/>既会被本模组样式选中时的 Draw 调用,也会在"同时显示"开启且选择了其他样式时
    /// <br/>由 BarDrawSystem 挂在所有 ModBossBarStyle.Draw 上的钩子调用,
    /// <br/>确保 PreventDraw=true 的样式也能与本模组血条并存显示。
    /// </summary>
    public static void DrawRegisteredBars(SpriteBatch spriteBatch)
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

    public override void Draw(SpriteBatch spriteBatch, IBigProgressBar currentBar, BigProgressBarInfo info)
    {
        DrawRegisteredBars(spriteBatch);
    }
}

