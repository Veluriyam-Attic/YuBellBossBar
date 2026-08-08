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

    public static event Func<BarDrawsMethods> drawEvent;

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
            if (D_array != null)
            {
                // 只取本帧实际要画的血条数量(最多 MultipleBarAmount 根)
                int drawCount = Math.Max(0, Math.Min(D_array.Length, BarConfig.Instance.MultipleBarAmount));

                // 第一遍:先调用所有要画血条的 PreDraw,拿到各自高度
                int[] heights = new int[drawCount];
                for (int i = 0; i < drawCount; i++)
                    heights[i] = ((Func<BarDrawsMethods>)D_array[i])().PreDraw(spriteBatch);

                // 第二遍:当前血条位置用累加前的 x,间隔取当前和下一根高度的平均值,再 Draw -> PostDraw
                for (int i = 0; i < drawCount; i++)
                {
                    BarDrawsMethods current = ((Func<BarDrawsMethods>)D_array[i])();
                    int currentHeight = heights[i];
                    int nextHeight = i + 1 < drawCount ? heights[i + 1] : currentHeight;

                    Vector2 barPosition = new Vector2(BarDrawsMethods.position.X, BarDrawsMethods.position.Y - x);
                    x += (currentHeight + nextHeight) / 2;

                    current.Draw(spriteBatch, barPosition);
                    current.PostDraw(spriteBatch);
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

    public static void ClearEvent() => drawEvent = null;
}

