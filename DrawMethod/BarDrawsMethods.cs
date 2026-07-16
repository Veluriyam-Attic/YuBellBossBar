namespace YuBellBossBar.DrawMethod;

internal class BarDrawsMethods
{
    public static Vector2 position = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);

    public static bool PreDraw(SpriteBatch spriteBatch, NPC npc, BossBarDrawParams drawParams)
    {
        // 获取到对应更改且不绘制时结束方法
        if (YAB.ModCalls.TryGetValue(npc.type, out BarInfo modcallbarInfo) && !modcallbarInfo.ShowBar)
            return false;

        return true;
    }

    public static bool Draw(SpriteBatch spriteBatch, NPC npc, BossBarDrawParams drawParams)
    {
        // 这个是当前绘制需要的血条信息
        BarInfo barInfo;

        // 获取对应血条信息，如果未获取到，则使用默认血条信息
        if (!BarData.buildincontent.TryGetValue(npc.type, out barInfo))
            barInfo = BarData.buildincontent[BarConfig.Instance.GoldenStyle? int.MaxValue:int.MinValue];

        #region 声明所需局部变量
        // 血量相关
        float life = drawParams.Life;
        float lifemax = drawParams.LifeMax;

        // 绘制信息是否被ModCall修改过
        bool modcall = YAB.ModCalls.TryGetValue(npc.type, out BarInfo modcallbarInfo);
        #endregion


        #region 绘制方法

        #endregion

        spriteBatch.DrawString(FontAssets.MouseText.Value, $"Life: {life}/{lifemax}", position, Color.White);

        return true;
    }

    public static void PostDraw(SpriteBatch spriteBatch, NPC npc, BossBarDrawParams drawParams)
    {

    }
}

