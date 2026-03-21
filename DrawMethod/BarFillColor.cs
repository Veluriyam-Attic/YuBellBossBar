namespace YuBellBossBar.DrawMethod;

internal class BarFillColor
{
    /// <summary>
    /// <br/>这是原版血条颜色的方法
    /// <br/>This is the vanilla method to get bar fill color.
    /// </summary>
    /// <param name="Health"></param>
    /// <param name="MaxHealth"></param>
    /// <returns></returns>
    internal static Color GetVanillaBarColor(int Health, int MaxHealth)
    {
        float num = (float)Health / (float)MaxHealth;
        if (num > 1f)
            num = 1f;

        float num5 = 0f;
        float num6 = 0f;
        float num7 = 0f;
        float num8 = 255f;
        num -= 0.1f;
        if ((double)num > 0.5)
        {
            num6 = 255f;
            num5 = 255f * (1f - num) * 2f;
        }
        else
        {
            num6 = 255f * num * 2f;
            num5 = 255f;
        }

        float num9 = 0.95f;
        num5 = num5 * num9;
        num6 = num6 * num9;
        num8 = num8 * num9;
        if (num5 < 0f)
            num5 = 0f;

        if (num5 > 255f)
            num5 = 255f;

        if (num6 < 0f)
            num6 = 0f;

        if (num6 > 255f)
            num6 = 255f;

        if (num8 < 0f)
            num8 = 0f;

        if (num8 > 255f)
            num8 = 255f;

        return new Color((byte)num5, (byte)num6, (byte)num7, (byte)num8);
    }
}

