namespace YuBellBossBar.DrawMethod;

internal class BarDrawsMethods
{

    public static Vector2 position = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);

    public static Dictionary<int, float> postpercentage = new Dictionary<int, float>();

    public static Dictionary<TextureType, int> frameNow = new Dictionary<TextureType, int>
    {
        {TextureType.Head,1},
        {TextureType.Frame,1},
        {TextureType.Tail,1},
        {TextureType.Fill,1},
    };

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
        //------------------------------------------------------------------------------------------------------------------------------------//
        #region 声明所需局部变量
        // 血量相关
        float life = drawParams.Life;
        float lifemax = drawParams.LifeMax;
        float percentage = life / lifemax;

        // 贴图相关
#pragma warning disable IDE0018
        List<BarTexture2D> extraBelowFill;
        BarTexture2D fill;
        List<BarTexture2D> extraBetweenFillAndFrame;
        BarTexture2D frame;
        List<BarTexture2D> extraBetweenFrameAndHeadEnd;
        BarTexture2D head;
        BarTexture2D tail;
        List<BarTexture2D> extraBetweenHeadEndAndIcon;
        BarTexture2D icon;
        List<BarTexture2D> extraBetweenIconAndInfo;
        List<BarTexture2D> extraUponInfo;


        // 绘制信息是否被ModCall修改过
        bool modcall = YAB.ModCalls.TryGetValue(npc.type, out BarInfo modcallbarInfo);
        #endregion
        //------------------------------------------------------------------------------------------------------------------------------------//

        #region 根据模组配置重新选择贴图

        extraBelowFill = barInfo.barTextures.extraTexturesBelowFill;
        if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Fill, out fill))
            fill = barInfo.barTextures.baseTextures[TextureType.Fill];
        extraBetweenFillAndFrame = barInfo.barTextures.extraTexturesBetweenFillAndFrame;
        if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Frame, out frame))
            frame = barInfo.barTextures.baseTextures[TextureType.Frame];
        extraBetweenFrameAndHeadEnd = barInfo.barTextures.extraTexturesBetweenFrameAndHeadEnd;
        if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Head, out head))
            head = barInfo.barTextures.baseTextures[TextureType.Head];
        if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Tail, out tail))
            tail = barInfo.barTextures.baseTextures[TextureType.Tail];
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

        //------------------------------------------------------------------------------------------------------------------------------------//
        #region 贴图绘制方法
        // 绘制血条填充下方的贴图

        //------------------------------------------------------------------------------------------------------------------------------------//
        if (extraBelowFill != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraBelowFill)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //------------------------------------------------------------------------------------------------------------------------------------//

        {
            if (!fill.ConfigEnabled)
            {
                fill = BarData.buildincontent[BarConfig.Instance.GoldenStyle ? int.MaxValue : int.MinValue].barTextures.baseTextures[TextureType.Fill];
            }

            if (fill.CustomDrawEvent != null)
                fill.CustomDrawEvent(spriteBatch, position, BarConfig.Instance.BarLength);
            else
            {
                Vector2 StartPosition = position - new Vector2(BarConfig.Instance.BarLength / 2, fill.texture.Value.Height / 2);
                int filllengh = (int)(BarConfig.Instance.BarLength * percentage);

                Rectangle FillP1 = new Rectangle(0, 0, fill.fillCutLengh.Item1, fill.texture.Value.Height);
                Rectangle FillP2 = new Rectangle(fill.fillCutLengh.Item1, 0, fill.texture.Value.Width - fill.fillCutLengh.Item1 - fill.fillCutLengh.Item2, fill.texture.Value.Height);
                Rectangle FillP3 = new Rectangle(fill.texture.Value.Width - fill.fillCutLengh.Item2, 0, fill.fillCutLengh.Item2, fill.texture.Value.Height);

#pragma warning disable CS8524
                Color fillcolor = fill.barFillColor switch
                {
                    BarFillColor.Custom => fill.fillColor,
                    BarFillColor.Vanilla => BarFillColorMethods.GetVanillaBarColor(percentage)
                };

                switch (fill.barFillStyles)
                {
                    case BarFillStyles.Extend:
                        {
                            spriteBatch.Draw(fill.texture.Value, StartPosition, FillP2, fillcolor);
                            break;
                        }
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------//

        if (extraBetweenFillAndFrame != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraBetweenFillAndFrame)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //------------------------------------------------------------------------------------------------------------------------------------//
        {
            if (!frame.ConfigEnabled)
            {
                frame = BarData.buildincontent[BarConfig.Instance.GoldenStyle ? int.MaxValue : int.MinValue].barTextures.baseTextures[TextureType.Frame];
            }
            if (frame.CustomDrawEvent != null)
            {
                frame.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);
            }
            else
            {
                switch (frame.barFrameStyles)
                {
                    case BarFrameStyles.Extend:
                        {
                            int LengthPF = frame.texture.Value.Height / frame.frameCount;
                            Vector2 StartPosition = position - new Vector2(BarConfig.Instance.BarLength / 2, frame.texture.Value.Height / 2);

                            if (frameNow[TextureType.Frame] == frame.frameCount + 1)
                                frameNow[TextureType.Frame] = 1;

                            Rectangle FrameP = new Rectangle(0, LengthPF * (frameNow[TextureType.Frame] - 1), frame.texture.Value.Width, LengthPF);
                            spriteBatch.Draw(frame.texture.Value, new Rectangle((int)StartPosition.X, (int)StartPosition.Y, BarConfig.Instance.BarLength, frame.texture.Value.Height), FrameP, Color.White);

                            frameNow[TextureType.Frame]++;

                            break;
                        }
                    case BarFrameStyles.Dulplicate:
                        {
                            break;
                        }
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------//

        if (extraBetweenFrameAndHeadEnd != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraBetweenFrameAndHeadEnd)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //------------------------------------------------------------------------------------------------------------------------------------//

        if (!head.ConfigEnabled)
        { }
        else if (head.CustomDrawEvent != null)
            head.CustomDrawEvent(spriteBatch, position, BarConfig.Instance.BarLength);
        else
        {
            Vector2 StartPosition = position - new Vector2(BarConfig.Instance.BarLength / 2, head.texture.Value.Height / 2);
            spriteBatch.Draw(head.texture.Value, StartPosition - new Vector2(head.headOffset.X, 0), Color.White);
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        {
            if (!tail.ConfigEnabled)
            {
                tail = BarData.buildincontent[BarConfig.Instance.GoldenStyle ? int.MaxValue : int.MinValue].barTextures.baseTextures[TextureType.Tail];
            }
            if (tail.CustomDrawEvent != null)
            {
                tail.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);
            }
            else
            {
                int HeightPF = tail.texture.Value.Height / tail.frameCount;
                Vector2 StartPosition = position + new Vector2(BarConfig.Instance.BarLength / 2, - HeightPF / 2);

                if (frameNow[TextureType.Tail] == tail.frameCount * 4)
                    frameNow[TextureType.Tail] = 1;

                int NowFrame = (frameNow[TextureType.Tail]) / 4;

                Rectangle tailP = new Rectangle(
                    0,
                    HeightPF * (NowFrame),
                    tail.texture.Value.Width,
                    HeightPF
                    );

                spriteBatch.Draw(tail.texture.Value, StartPosition, tailP, Color.White);

                frameNow[TextureType.Tail]++;

            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------//

        if (extraBetweenHeadEndAndIcon != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraBetweenHeadEndAndIcon)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //------------------------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------------------------//
        if (extraBetweenIconAndInfo != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraBetweenIconAndInfo)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);

        //------------------------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------------------------//

        if (extraUponInfo != null && !BarConfig.Instance.EnableExtraCustom)
            foreach (BarTexture2D texture in extraUponInfo)
                texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);
        #endregion
        //------------------------------------------------------------------------------------------------------------------------------------//
        return true;
    }

    public static void PostDraw(SpriteBatch spriteBatch, NPC npc, BossBarDrawParams drawParams)
    {

    }
}

