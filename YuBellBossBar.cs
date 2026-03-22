namespace YuBellBossBar;
public class YuBellBossBar : Mod
{
    internal static void Tool(string text) => Main.spriteBatch.DrawString(FontAssets.MouseText.Value, "   Jerk off is the best activity!" + text, Main.MouseScreen, Color.White);

    public override void Load()
    {
        // 初始时清除所有数
        Array.Clear(YAB.BarCount,0,VBarConfig.Instance.BarCount);
    }
}
