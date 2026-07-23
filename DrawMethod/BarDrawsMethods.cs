namespace YuBellBossBar.DrawMethod;

internal class BarDrawsMethods
{

    public static Vector2 position = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);

    public static Dictionary<int, float> postpercentage = new Dictionary<int, float>();

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
//---------------------------------------------------------------------------------------------------------------------------------------------------//
        #region 声明所需局部变量
        // 血量相关
        float life = drawParams.Life;
        float lifemax = drawParams.LifeMax;
        float percentage = life / lifemax;

        // 贴图相关
#pragma warning disable IDE0018
        List<BarTexture2D> extraBelowFill;
        BarTexture2D Fill;
        List<BarTexture2D> extraBetweenFillAndFrame;
        BarTexture2D frame;
        List<BarTexture2D> extraBetweenFrameAndHeadEnd;
        BarTexture2D head;
        BarTexture2D end;
        List<BarTexture2D> extraBetweenHeadEndAndIcon;
        BarTexture2D icon;
        List<BarTexture2D> extraBetweenIconAndInfo;
        BarTexture2D info;
        List<BarTexture2D> extraUponInfo;


        // 绘制信息是否被ModCall修改过
        bool modcall = YAB.ModCalls.TryGetValue(npc.type, out BarInfo modcallbarInfo);
        #endregion
        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        #region 根据模组配置重新选择贴图



        #endregion

        //---------------------------------------------------------------------------------------------------------------------------------------------------//
        #region 贴图绘制方法
        // 绘制血条填充下方的贴图

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        extraBelowFill = barInfo.barTextures.extraTexturesBelowFill;
        foreach (BarTexture2D texture in extraBelowFill)
            texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        if(barInfo.barTextures.baseTextures.TryGetValue(TextureType.Fill, out Fill))
        {
            if (Fill.CustomDrawEvent != null)
                Fill.CustomDrawEvent(spriteBatch, position, BarConfig.Instance.BarLength);
            else
            {
                Vector2 StartPosition = position - new Vector2(BarConfig.Instance.BarLength / 2, Fill.texture.Value.Height / 2);

                Rectangle FillStart = new Rectangle(0,0,Fill.fillCutLengh.Item1, Fill.texture.Value.Height);
                Rectangle FillMid = new Rectangle(Fill.fillCutLengh.Item1, 0, Fill.texture.Value.Width - Fill.fillCutLengh.Item1 - Fill.fillCutLengh.Item2, Fill.texture.Value.Height);
                Rectangle FillEnd = new Rectangle(Fill.texture.Value.Width - Fill.fillCutLengh.Item2, 0, Fill.fillCutLengh.Item2, Fill.texture.Value.Height);

            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        extraBetweenFillAndFrame = barInfo.barTextures.extraTexturesBetweenFillAndFrame;
        foreach (BarTexture2D texture in extraBetweenFillAndFrame)
            texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        barInfo.barTextures.baseTextures.TryGetValue(TextureType.Frame, out frame);

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        extraBetweenFrameAndHeadEnd = barInfo.barTextures.extraTexturesBetweenFrameAndHeadEnd;
        foreach (BarTexture2D texture in extraBetweenFrameAndHeadEnd)
            texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        barInfo.barTextures.baseTextures.TryGetValue(TextureType.Head, out head);

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        barInfo.barTextures.baseTextures.TryGetValue(TextureType.Tail, out end);

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        extraBetweenHeadEndAndIcon = barInfo.barTextures.extraTexturesBetweenHeadEndAndIcon;
        foreach (BarTexture2D texture in extraBetweenHeadEndAndIcon)
            texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        barInfo.barTextures.baseTextures.TryGetValue(TextureType.Icon, out icon);

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        extraBetweenIconAndInfo = barInfo.barTextures.extraTexturesBetweenIconAndInfo;

        //---------------------------------------------------------------------------------------------------------------------------------------------------//
        foreach (BarTexture2D texture in extraBetweenIconAndInfo)
            texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        barInfo.barTextures.baseTextures.TryGetValue(TextureType.Info, out info);

        //---------------------------------------------------------------------------------------------------------------------------------------------------//

        extraUponInfo = barInfo.barTextures.extraTexturesUponInfo;
        foreach (BarTexture2D texture in extraUponInfo)
            texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);
        #endregion
        //---------------------------------------------------------------------------------------------------------------------------------------------------//
        spriteBatch.DrawString(FontAssets.MouseText.Value, $"Life: {life}/{lifemax}", position, Color.White);

        return true;
    }

    public static void PostDraw(SpriteBatch spriteBatch, NPC npc, BossBarDrawParams drawParams)
    {

    }
}

