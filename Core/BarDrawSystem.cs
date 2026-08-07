namespace YuBellBossBar.Core;

/// <summary>
/// <br/>给所有已加载的 ModBossBarStyle 的 Draw 方法挂上 On 钩子。
/// <br/>引擎始终会调用"当前选中样式"的 Draw(即使 PreventDraw=true 也会调用),
/// <br/>所以在钩子内先执行原样式自身的绘制、再按需补绘本模组血条,
/// <br/>即可让本模组血条与任意样式(包括 PreventDraw=true 的样式)同时显示。
/// </summary>
internal class BarDrawSystem : ModSystem
{
    // Draw 是实例方法,MonoMod 的 Hook 要求 orig 委托和钩子委托都带 this 参数(样式实例)
    private delegate void Orig_Draw(ModBossBarStyle style, SpriteBatch spriteBatch, IBigProgressBar currentBar, BigProgressBarInfo info);

    private static readonly HashSet<MethodBase> hookedDrawMethods = new();
    private static bool drawInProgress;

    public override void PostSetupContent()
    {
        // 兜底:基础 ModBossBarStyle.Draw 覆盖默认 Vanilla 样式及所有未重写 Draw 的样式
        hookedDrawMethods.Add(typeof(ModBossBarStyle).GetMethod(nameof(ModBossBarStyle.Draw), BindingFlags.Instance | BindingFlags.Public));

        // 所有 Mod 加载完成后,所有 ModBossBarStyle 都已注册,此时枚举并逐个挂钩子
        foreach (ModBossBarStyle style in ModContent.GetContent<ModBossBarStyle>())
        {
            // GetMethod 返回该样式实际生效(最派生)的 Draw 方法
            MethodBase draw = style.GetType().GetMethod(nameof(ModBossBarStyle.Draw), BindingFlags.Instance | BindingFlags.Public);
            if (draw != null && hookedDrawMethods.Add(draw))
                MonoModHooks.Add(draw, new Action<Orig_Draw, ModBossBarStyle, SpriteBatch, IBigProgressBar, BigProgressBarInfo>(Draw_Detour));
        }
    }

    private static void Draw_Detour(Orig_Draw orig, ModBossBarStyle style, SpriteBatch spriteBatch, IBigProgressBar currentBar, BigProgressBarInfo info)
    {
        // 先执行该样式原本的绘制
        orig(style, spriteBatch, currentBar, info);

        // 同时显示开启、且当前选中的不是本模组样式时补绘(本模组样式被选中时其 Draw 已绘制,避免重复)
        // drawInProgress 防止某样式在 Draw 里调用 base.Draw() 造成重复绘制
        if (BarConfig.Instance.EnableSimultaneously && !YAB.Selected && !drawInProgress)
        {
            drawInProgress = true;
            try
            {
                YAB.DrawRegisteredBars(spriteBatch);
            }
            finally
            {
                drawInProgress = false;
            }
        }
    }
}
