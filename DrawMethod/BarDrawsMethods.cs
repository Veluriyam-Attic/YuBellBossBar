namespace YuBellBossBar.DrawMethod;

internal class BarDrawsMethods
{

    public static Vector2 position = Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2((float)BarConfig.Instance.BarPostionX, -(float)BarConfig.Instance.BarPostionY - 40f);

    public static Dictionary<int, float> postpercentage = new Dictionary<int, float>();

    public static Dictionary<BarTexture2D, int> frameNow = new Dictionary<BarTexture2D, int>();

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
        frameNow.TryAdd(fill,1);
        extraBetweenFillAndFrame = barInfo.barTextures.extraTexturesBetweenFillAndFrame;
        if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Frame, out frame))
            frame = barInfo.barTextures.baseTextures[TextureType.Frame];
        frameNow.TryAdd(frame, 1);
        extraBetweenFrameAndHeadEnd = barInfo.barTextures.extraTexturesBetweenFrameAndHeadEnd;
        if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Head, out head))
            head = barInfo.barTextures.baseTextures[TextureType.Head];
        frameNow.TryAdd(head, 1);
        if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Tail, out tail))
            tail = barInfo.barTextures.baseTextures[TextureType.Tail];
        frameNow.TryAdd(tail, 1);
        extraBetweenHeadEndAndIcon = barInfo.barTextures.extraTexturesBetweenHeadEndAndIcon;
        if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Icon, out icon))
            icon = new BarTexture2D(TextureType.Icon, TextureAssets.NpcHeadBoss[npc.GetBossHeadTextureIndex()], TextureSource.None);
        frameNow.TryAdd(icon, 1);
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
                int HeightPF = frame.texture.Value.Height / frame.frameCount;
                Vector2 StartPosition = position - new Vector2((BarConfig.Instance.BarLength / 2) + head.fillOffset.X - head.texture.Value.Width, HeightPF / 2);
                Vector2 EndPosition = position + new Vector2((BarConfig.Instance.BarLength / 2) - tail.fillOffset.X, - HeightPF / 2);

                switch (frame.barFrameStyles)
                {
                    case BarFrameStyles.Extend:
                        {
                            if (frameNow[frame] >= frame.frameCount * frame.TicksPerFrame)
                                frameNow[frame] = 1;

                            int NowFrame = (frameNow[frame]) / frame.TicksPerFrame;

                            Rectangle frameP = new Rectangle(
                                0,
                                HeightPF * (NowFrame),
                                frame.texture.Value.Width,
                                HeightPF
                                );

                            spriteBatch.Draw(frame.texture.Value, new Rectangle((int)StartPosition.X, (int)StartPosition.Y, (int)EndPosition.X - (int)StartPosition.X, frame.texture.Value.Height), frameP, Color.White);

                            frameNow[frame]++;
                            break;
                        }

                    case BarFrameStyles.Dulplicate:
                        {
                            if (frameNow[frame] >= frame.frameCount * frame.TicksPerFrame)
                                frameNow[frame] = 1;

                            int NowFrame = (frameNow[frame]) / frame.TicksPerFrame;

                            Rectangle frameP = new Rectangle(
                                0,
                                HeightPF * (NowFrame),
                                frame.texture.Value.Width,
                                HeightPF
                                );

                            int count = (((int)EndPosition.X - (int)StartPosition.X) / frame.texture.Value.Width) + 1;

                            for (int i = 0; i < count; i++)
                            {
                                spriteBatch.Draw(frame.texture.Value, new Rectangle((int)StartPosition.X + (i * frame.texture.Value.Width), (int)StartPosition.Y, frame.texture.Value.Width, frame.texture.Value.Height), frameP, Color.White);
                            }

                            frameNow[frame]++;
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
        {
            if (!head.ConfigEnabled)
            {
                head = BarData.buildincontent[BarConfig.Instance.GoldenStyle ? int.MaxValue : int.MinValue].barTextures.baseTextures[TextureType.Head];
            }
            if (head.CustomDrawEvent != null)
            {
                head.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength);
            }
            else
            {
                int HeightPF = head.texture.Value.Height / head.frameCount;
                Vector2 StartPosition = position - new Vector2((BarConfig.Instance.BarLength / 2) + head.fillOffset.X, HeightPF / 2);

                if (frameNow[head] >= head.frameCount * head.TicksPerFrame)
                    frameNow[head] = 1;

                int NowFrame = (frameNow[head]) / head.TicksPerFrame;

                Rectangle headP = new Rectangle(
                    0,
                    HeightPF * (NowFrame),
                    head.texture.Value.Width,
                    HeightPF
                    );

                spriteBatch.Draw(head.texture.Value, StartPosition, headP, Color.White);

                frameNow[head]++;
            }
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
                Vector2 StartPosition = position + new Vector2((BarConfig.Instance.BarLength / 2) - tail.fillOffset.X, - HeightPF / 2);

                if (frameNow[tail] >= tail.frameCount * tail.TicksPerFrame)
                    frameNow[tail] = 1;

                int NowFrame = (frameNow[tail]) / tail.TicksPerFrame;

                Rectangle tailP = new Rectangle(
                    0,
                    HeightPF * (NowFrame),
                    tail.texture.Value.Width,
                    HeightPF
                    );

                spriteBatch.Draw(tail.texture.Value, StartPosition, tailP, Color.White);

                frameNow[tail]++;
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

