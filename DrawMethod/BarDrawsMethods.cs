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
        // 同时在此处选择使用金色或银色版本
        if (!BarData.buildincontent.TryGetValue(npc.type, out barInfo))
        {
            int index = BarConfig.Instance.GoldenStyle ? int.MaxValue : int.MinValue;
            barInfo.barTextures.baseTextures = BarData.buildincontent[index].barTextures.baseTextures;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------//
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
        List<BarTexture2D> extraUponInfo;


        // 绘制信息是否被ModCall修改过
        bool modcall = YAB.ModCalls.TryGetValue(npc.type, out BarInfo modcallbarInfo);
        #endregion
        //--------------------------------------------------------------------------------------------------------------------------------------//

        #region 根据模组配置重新选择贴图

        extraBelowFill = barInfo.barTextures.extraTexturesBelowFill;
        if(!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Fill, out Fill))
            Fill = barInfo.barTextures.baseTextures[TextureType.Fill];
        extraBetweenFillAndFrame = barInfo.barTextures.extraTexturesBetweenFillAndFrame;
        if(!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Frame, out frame))
            frame = barInfo.barTextures.baseTextures[TextureType.Frame];
        extraBetweenFrameAndHeadEnd = barInfo.barTextures.extraTexturesBetweenFrameAndHeadEnd;
        if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Head, out head))
            head = barInfo.barTextures.baseTextures[TextureType.Head];
        if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Tail, out end))
            end = barInfo.barTextures.baseTextures[TextureType.Tail];
        extraBetweenHeadEndAndIcon = barInfo.barTextures.extraTexturesBetweenHeadEndAndIcon;
        if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Icon, out icon))
            icon = new BarTexture2D(TextureType.Icon, TextureAssets.NpcHeadBoss[npc.GetBossHeadTextureIndex()], TextureSource.None);
        extraBetweenIconAndInfo = barInfo.barTextures.extraTexturesBetweenIconAndInfo;
        extraUponInfo = barInfo.barTextures.extraTexturesUponInfo;


        if (!BarConfig.Instance.ForceDefaulTexture)
        { }
        else
        {
            extraBelowFill.Clear();
            extraBetweenFillAndFrame.Clear();
            extraBetweenFrameAndHeadEnd.Clear();
            extraBetweenHeadEndAndIcon.Clear();
            extraBetweenIconAndInfo.Clear();
            extraUponInfo.Clear();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------------------------------//
        #region 贴图绘制方法
        // 绘制血条填充下方的贴图

        //--------------------------------------------------------------------------------------------------------------------------------------//
        if(extraBelowFill != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraBelowFill)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //--------------------------------------------------------------------------------------------------------------------------------------//

        {
            if (!Fill.ConfigEnabled)
            { }
            else if (Fill.CustomDrawEvent != null)
                Fill.CustomDrawEvent(spriteBatch, position, BarConfig.Instance.BarLength);
            else
            {
                Vector2 StartPosition = position - new Vector2(BarConfig.Instance.BarLength / 2, Fill.texture.Value.Height / 2);
                int filllengh = (int)(BarConfig.Instance.BarLength * percentage);

                Rectangle FillP1 = new Rectangle(0, 0, Fill.fillCutLengh.Item1, Fill.texture.Value.Height);
                Rectangle FillP2 = new Rectangle(Fill.fillCutLengh.Item1, 0, Fill.texture.Value.Width - Fill.fillCutLengh.Item1 - Fill.fillCutLengh.Item2, Fill.texture.Value.Height);
                Rectangle FillP3 = new Rectangle(Fill.texture.Value.Width - Fill.fillCutLengh.Item2, 0, Fill.fillCutLengh.Item2, Fill.texture.Value.Height);

                #pragma warning disable CS8524
                Color fillcolor = Fill.barFillColor switch
                {
                    BarFillColor.Custom => Fill.fillColor,
                    BarFillColor.Vanilla => BarFillColorMethods.GetVanillaBarColor(percentage)
                };

                switch (Fill.barFillStyles)
                {
                    case BarFillStyles.Extend:
                        {
                            spriteBatch.Draw(Fill.texture.Value,StartPosition,FillP2, fillcolor);
                            break;
                        }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------//

        if (extraBetweenFillAndFrame != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraBetweenFillAndFrame)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //--------------------------------------------------------------------------------------------------------------------------------------//

        //--------------------------------------------------------------------------------------------------------------------------------------//

        if (extraBetweenFrameAndHeadEnd != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraBetweenFrameAndHeadEnd)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //--------------------------------------------------------------------------------------------------------------------------------------//
        spriteBatch.Draw(head.texture.Value, position - new Vector2(BarConfig.Instance.BarLength / 2, head.texture.Value.Height / 2) - new Vector2(head.fillOffset.X+14,-2), Color.White);
        //--------------------------------------------------------------------------------------------------------------------------------------//

        //--------------------------------------------------------------------------------------------------------------------------------------//

        if (extraBetweenHeadEndAndIcon != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraBetweenHeadEndAndIcon)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //--------------------------------------------------------------------------------------------------------------------------------------//

        //--------------------------------------------------------------------------------------------------------------------------------------//

        //--------------------------------------------------------------------------------------------------------------------------------------//
        if (extraBetweenIconAndInfo != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraBetweenIconAndInfo)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //--------------------------------------------------------------------------------------------------------------------------------------//

        //--------------------------------------------------------------------------------------------------------------------------------------//

        if (extraUponInfo != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraUponInfo)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);
        #endregion
        //--------------------------------------------------------------------------------------------------------------------------------------//
        return true;
    }

    public static void PostDraw(SpriteBatch spriteBatch, NPC npc, BossBarDrawParams drawParams)
    {

    }
}

