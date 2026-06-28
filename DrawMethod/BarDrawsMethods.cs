namespace YuBellBossBar.DrawMethod;

internal class BarDrawsMethods
{
    public static Vector2 position = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);

    public static bool PreDraw(SpriteBatch spriteBatch, NPC npc, BossBarDrawParams drawParams)
    {
        return true;
    }

    public static bool Draw(SpriteBatch spriteBatch, NPC npc, BossBarDrawParams drawParams)
    {
        float life = drawParams.Life;
        float lifemax = drawParams.LifeMax;

        BarInfo barInfo;

        // 获取对应血条信息，如果未获取到，则使用默认血条信息
        if (!BarData.buildincontent.TryGetValue(npc.type, out barInfo))
            barInfo = BarData.buildincontent[BarConfig.Instance.GoldenStyle? int.MaxValue:int.MinValue];

        if(barInfo.ShowBar)
        {
            spriteBatch.Draw()
        }

        spriteBatch.DrawString(FontAssets.MouseText.Value, $"Life: {life}/{lifemax}", position, Color.White);
        return true;
    }

    public static void PostDraw(SpriteBatch spriteBatch, NPC npc, BossBarDrawParams drawParams)
    {

    }
}

