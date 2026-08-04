namespace YuBellBossBar.DrawMethod;

internal class BarDrawsMethods
{
    public List<BarTexture2D> extraBelowFill;
    public BarTexture2D fill;
    public List<BarTexture2D> extraBetweenFillAndFrame;
    public BarTexture2D frame;
    public List<BarTexture2D> extraBetweenFrameAndHeadEnd;
    public BarTexture2D head;
    public BarTexture2D tail;
    public List<BarTexture2D> extraBetweenHeadEndAndIcon;
    public BarTexture2D icon;
    public List<BarTexture2D> extraBetweenIconAndInfo;
    public List<BarTexture2D> extraUponInfo;

    public NPC npc = new();
    public PostHealthSystem postHealthSystem = new();

    // 位置相关
    public Vector2[] CheckBox = new Vector2[2];

    public static Vector2 position
    {
        get
        { return Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2(BarConfig.Instance.BarPostionX, -BarConfig.Instance.BarPostionY - 40f); }
    }

    public Dictionary<int, float> postpercentage = new Dictionary<int, float>();

    public Dictionary<BarTexture2D, int> frameNow = new Dictionary<BarTexture2D, int>();

    public bool PreDraw(SpriteBatch spriteBatch)
    {
        return true;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {

        // 这个是当前绘制需要的血条信息
        BarInfo barInfo;

        // 获取对应血条信息，如果未获取到，则使用默认血条信息
        // 同时在此处选择使用金色或银色版本
        if (!BarData.BarInfos.TryGetValue(npc.type, out barInfo))
        {
            int index = int.MinValue;
            barInfo = BarData.BarInfos[index];
        }

        if (barInfo.ShowBar && BarConfig.Instance.ShowBar)
        {
            #region 同步不同体节血量

            if (barInfo.Segment != null && BarConfig.Instance.ImprovedLifeCalculation)
            {
                float max = barInfo.Segment.Max(npctype =>
                {
                    if (BarLifeMethods.maxlifes.ContainsKey(npctype))
                        return BarLifeMethods.maxlifes[npctype];
                    else
                        return BarLifeMethods.maxlifes[npc.type];
                });
                foreach (int npctype in barInfo.Segment)
                    BarLifeMethods.maxlifes[npctype] = max;
            }

            #endregion

            #region 声明所需局部变量
            // 血量相关
            float life = 0;
            float lifemax = 0;
            float shieldpercentage = 0;
            float shield = 0;
            float shieldmax = 0;

            BigProgressBarInfo info = default;

            if (npc.BossBar is ModBossBar bar)
            {
                bar.ValidateAndCollectNecessaryInfo(ref info);

                life = bar.Life;
                lifemax = bar.LifeMax;
                shield = bar.Shield;
                shieldmax = bar.ShieldMax;
                shieldpercentage = shield / shieldmax;
            }
            else
            {
                if (Main.BigBossProgressBar.TryGetSpecialVanillaBossBar(npc.type, out IBigProgressBar specialbar) && npc.type != NPCID.DungeonGuardian && npc.type != NPCID.Spazmatism && npc.type != NPCID.Retinazer)
                {
                    specialbar.ValidateAndCollectNecessaryInfo(ref info);
                    Type specialbarType = specialbar.GetType();
                    FieldInfo _cacheInfo = specialbarType.GetField("_cache", BindingFlags.NonPublic | BindingFlags.Instance);
                    while (_cacheInfo == null)
                    {
                        _cacheInfo = specialbarType.BaseType.GetField("_cache", BindingFlags.NonPublic | BindingFlags.Instance);
                        specialbarType = specialbarType.BaseType;
                    }
                    BigProgressBarCache _cache = (BigProgressBarCache)_cacheInfo.GetValue(specialbar);
                    life = _cache.LifeCurrent;
                    lifemax = _cache.LifeMax;
                    shield = _cache.ShieldCurrent;
                    shieldmax = _cache.ShieldMax;
                    shieldpercentage = shield / shieldmax;
                }
                else
                {
                    life = npc.life;
                    lifemax = npc.lifeMax;
                }
            }

            float percentage = life / lifemax;
            float postpercentage = postHealthSystem.GetPostHealth(npc.whoAmI, percentage);
            int lengthNow = (int)(percentage * BarConfig.Instance.BarLength);
            int lengthPost = (int)(postpercentage * BarConfig.Instance.BarLength);
            int shieldlength = (int)(BarConfig.Instance.BarLength * shieldpercentage);

            // 贴图相关
#pragma warning disable IDE0018
            #endregion

            #region 根据模组配置重新选择贴图

            extraBelowFill = barInfo.barTextures.extraTexturesBelowFill;

            barInfo.barTextures.baseTextures.TryGetValue(TextureType.Fill, out fill);

            extraBetweenFillAndFrame = barInfo.barTextures.extraTexturesBetweenFillAndFrame;
            barInfo.barTextures.baseTextures.TryGetValue(TextureType.Frame, out frame);

            extraBetweenFrameAndHeadEnd = barInfo.barTextures.extraTexturesBetweenFrameAndHeadEnd;

            barInfo.barTextures.baseTextures.TryGetValue(TextureType.Head, out head);

            barInfo.barTextures.baseTextures.TryGetValue(TextureType.Tail, out tail);

            extraBetweenHeadEndAndIcon = barInfo.barTextures.extraTexturesBetweenHeadEndAndIcon;

            if (!barInfo.barTextures.baseTextures.TryGetValue(TextureType.Icon, out icon))
            {
                if (npc.GetBossHeadTextureIndex() >= 0)
                    icon = new BarTexture2D(TextureType.Icon, TextureAssets.NpcHeadBoss[npc.GetBossHeadTextureIndex()], TextureSource.None);
                else
                    icon = new BarTexture2D(TextureType.Icon, ModContent.Request<Texture2D>("YuBellBossBar/Texture/Sweetie"), TextureSource.None);
            }

            extraBetweenIconAndInfo = barInfo.barTextures.extraTexturesBetweenIconAndInfo;

            extraUponInfo = barInfo.barTextures.extraTexturesUponInfo;


            if (BarConfig.Instance.ForceDefaulTexture)
            {
                extraBelowFill.Clear();
                extraBetweenFillAndFrame.Clear();
                extraBetweenFrameAndHeadEnd.Clear();
                extraBetweenHeadEndAndIcon.Clear();
                extraBetweenIconAndInfo.Clear();
                extraUponInfo.Clear();
            }


            if (!tail.ConfigEnabled)
            {
                tail = BarData.BarInfos[int.MinValue].barTextures.baseTextures[TextureType.Tail];
            }
            if (!head.ConfigEnabled)
            {
                head = BarData.BarInfos[int.MinValue].barTextures.baseTextures[TextureType.Head];
            }
            if (!frame.ConfigEnabled)
            {
                frame = BarData.BarInfos[int.MinValue].barTextures.baseTextures[TextureType.Frame];
            }
            if (!fill.ConfigEnabled)
            {
                fill = BarData.BarInfos[int.MinValue].barTextures.baseTextures[TextureType.Fill];
            }

            void reselectTexture(ref BarTexture2D barTexture)
            {
                if ((BarConfig.Instance.ForceGoldenStyle || Main.expertMode) && !barTexture.texture.Name.Contains("_Exp"))
                {
                    BarTexture2D outvalue;

                    string GetLastName(string path)
                    {
                        int index = path.LastIndexOf('\\');

                        return index >= 0
                            ? path[(index + 1)..]
                            : path;
                    }

                    switch (barTexture.source)
                    {
                        case TextureSource.DefaultTexture:
                            {
                                if (BuildInTextures.DefaultTexture.TryGetValue(GetLastName(barTexture.texture.Name) + "_Exp", out outvalue))
                                    barTexture = outvalue;
                                break;
                            }
                        case TextureSource.DefaultVanilla:
                            {
                                if (BuildInTextures.DefaultVanilla.TryGetValue(GetLastName(barTexture.texture.Name) + "_Exp", out outvalue))
                                    barTexture = outvalue;
                                break;
                            }
                        case TextureSource.ExtraVanilla:
                            {
                                if (BuildInTextures.ExtraVanilla.TryGetValue(GetLastName(barTexture.texture.Name) + "_Exp", out outvalue))
                                    barTexture = outvalue;
                                break;
                            }
                        case TextureSource.ExtraCalamity:
                            {
                                if (BuildInTextures.ExtraCalamity.TryGetValue(GetLastName(barTexture.texture.Name) + "_Exp", out outvalue))
                                    barTexture = outvalue;
                                break;
                            }
                        case TextureSource.ExtraAAClassic:
                            {
                                if (BuildInTextures.ExtraAAClassic.TryGetValue(GetLastName(barTexture.texture.Name) + "_Exp", out outvalue))
                                    barTexture = outvalue;
                                break;
                            }
                        case TextureSource.ExtraCustom:
                            {
                                if (BuildInTextures.ExtraCustom.TryGetValue(GetLastName(barTexture.texture.Name) + "_Exp", out outvalue))
                                    barTexture = outvalue;
                                break;
                            }
                        case TextureSource.ExtraInfo:
                            {
                                if (BuildInTextures.DefaultTexture.TryGetValue(GetLastName(barTexture.texture.Name) + "_Exp", out outvalue))
                                    barTexture = outvalue;
                                break;
                            }
                    }
                }
            }
            reselectTexture(ref head);
            reselectTexture(ref tail);
            reselectTexture(ref frame);


            frameNow.TryAdd(frame, 1);
            frameNow.TryAdd(tail, 1);
            frameNow.TryAdd(head, 1);
            frameNow.TryAdd(fill, 1);
            frameNow.TryAdd(icon, 1);

            #endregion

            #region 贴图绘制方法

            #region Alpha乘数
            bool MouseAlpha = Collision.CheckAABBvAABBCollision(Main.MouseScreen, Vector2.One, new Vector2(position.X - (BarConfig.Instance.BarLength / 2) - head.fillOffset.X, position.Y - (fill.texture.Value.Height / (2 * fill.frameCount)) - head.fillOffset.Y), new Vector2(BarConfig.Instance.BarLength + head.fillOffset.X - tail.fillOffset.X + tail.texture.Value.Width, Math.Max(head.texture.Value.Height / head.frameCount, tail.texture.Value.Height / tail.frameCount)));
            float GlobalAlpha = (MouseAlpha ? ((float)BarConfig.Instance.MouseAlpha / 100) : 1f) * ((float)BarConfig.Instance.Alpha / 100);
            #endregion

            #region 额外绘制填充之下
            if (extraBelowFill != null && !BarConfig.Instance.EnableExtraCustom)
                foreach (BarTexture2D texture in extraBelowFill)
                    texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield,shieldmax,percentage, GlobalAlpha, npc, texture.texture.Value);
            #endregion

            #region 填充相关绘制方法
            if (fill.CustomDrawEvent != null)
            {
                fill.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, fill.texture.Value);
            }
            else
            {
                StandardDrawFill(spriteBatch, position, life, lifemax, percentage, GlobalAlpha, npc, lengthPost, lengthNow, postpercentage, shieldlength);
            }

            #endregion

            #region 额外绘制填充和框架之间
            if (extraBetweenFillAndFrame != null && !BarConfig.Instance.EnableExtraCustom)
                foreach (BarTexture2D texture in extraBetweenFillAndFrame)
                    texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, texture.texture.Value);
            #endregion

            #region 框架相关绘制方法
            {
                if (frame.CustomDrawEvent != null)
                {
                    frame.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, frame.texture.Value);
                }
                else
                {
                    StandardDrawFrame(spriteBatch, position, life, lifemax, percentage, GlobalAlpha, npc);

                }
            }
            #endregion

            #region 额外绘制框架和头尾之间
            if (extraBetweenFrameAndHeadEnd != null && !BarConfig.Instance.EnableExtraCustom)
                foreach (BarTexture2D texture in extraBetweenFrameAndHeadEnd)
                    texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, texture.texture.Value);
            #endregion

            #region 头部相关绘制方法
            {
                if (head.CustomDrawEvent != null)
                {
                    CheckBox[0] = head.CustomDrawEvent.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, head.texture.Value);
                }
                else
                {
                    StandardDrawHead(spriteBatch, position, life, lifemax, percentage, GlobalAlpha, npc);
                }
            }
            #endregion

            #region 尾部相关绘制方法
            {
                if (tail.CustomDrawEvent != null)
                {
                    CheckBox[1] = tail.CustomDrawEvent.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, tail.texture.Value);
                }
                else
                {
                    StandardDrawTail(spriteBatch, position, life, lifemax, percentage, GlobalAlpha, npc);
                }
            }
            #endregion

            #region 额外绘制在头尾和大头照之间
            if (extraBetweenHeadEndAndIcon != null && !BarConfig.Instance.EnableExtraCustom)
                foreach (BarTexture2D texture in extraBetweenHeadEndAndIcon)
                    texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, texture.texture.Value);
            #endregion

            #region 大头照相关绘制方法

            if (barInfo.ShowIcon)
            {
                if (icon.CustomDrawEvent != null)
                {
                    icon.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, icon.texture.Value);
                }
                else
                {
                    StandardDrawIcon(spriteBatch, position, life, lifemax, percentage, GlobalAlpha, npc);
                }
            }

            #endregion

            #region 额外绘制大头照和信息之间
            if (extraBetweenIconAndInfo != null && !BarConfig.Instance.EnableExtraCustom)
                foreach (BarTexture2D texture in extraBetweenIconAndInfo)
                    texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, texture.texture.Value);
            #endregion

            #region 信息显示相关绘制方法

            if (barInfo.ShowText)
            {
                #region 文字部分

                if (barInfo.DrawText != null)
                {
                    barInfo.DrawText?.Invoke(
                        barInfo.ShowInvincible && BarConfig.Instance.ShowInvincible,
                        barInfo.ShowName && BarConfig.Instance.ShowName,
                        barInfo.ShowLife && BarConfig.Instance.ShowLife,
                        barInfo.ShowLifeMax && BarConfig.Instance.ShowLifeMax,
                        barInfo.ShowPercent && BarConfig.Instance.ShowPercent,
                        barInfo.ShowSegment && BarConfig.Instance.ShowSegment,
                        spriteBatch, position, BarConfig.Instance.BarLength, [life, lifemax, percentage], GlobalAlpha, npc, barInfo.Segment, shieldpercentage, DrawText);
                }
                else
                {
                    DrawText?.Invoke(barInfo.ShowInvincible && BarConfig.Instance.ShowInvincible,
                        barInfo.ShowName && BarConfig.Instance.ShowName,
                        barInfo.ShowLife && BarConfig.Instance.ShowLife,
                        barInfo.ShowLifeMax && BarConfig.Instance.ShowLifeMax,
                        barInfo.ShowPercent && BarConfig.Instance.ShowPercent,
                        barInfo.ShowSegment && BarConfig.Instance.ShowSegment,
                        spriteBatch, position, BarConfig.Instance.BarLength, [life, lifemax, percentage,shield,shieldmax], GlobalAlpha, npc, barInfo.Segment, shieldpercentage);
                }

                #endregion
            }

            #region 图片部分

            void DrawInfoWithNum(Vector2 LeftTopPosition, BarTexture2D bt, string num, int heightPF)
            {
                Vector2 p = LeftTopPosition - new Vector2(0, heightPF + 5f);

                Vector2 size = FontAssets.MouseText.Value.MeasureString(num);
                Vector2 Namepostion = new Vector2(size.X / 2, size.Y / 3);

                Rectangle btp = FrameChooser(bt, heightPF);

                spriteBatch.Draw(bt.texture.Value, LeftTopPosition, btp, Color.White * GlobalAlpha);
                Utils.DrawBorderString(spriteBatch, num, LeftTopPosition - Namepostion + new Vector2(bt.texture.Value.Width / 2, heightPF / 2), Color.White * GlobalAlpha);
            }

            if (BarConfig.Instance.ShowDefense && barInfo.ShowDefense)
            {
                BarTexture2D defense = BuildInTextures.ExtraInfo["Defense"];
                if (defense.CustomDrawEvent != null)
                {
                    defense.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, defense.texture.Value);
                }
                else
                {
                    frameNow.TryAdd(defense, 1);
                    int heightPF = defense.texture.Value.Height / defense.frameCount;
                    DrawInfoWithNum(CheckBox[0] + new Vector2(head.fillOffset.X, -heightPF - 5f), defense, ToStringWithComma(npc.defense), heightPF);
                }
            }

            if (BarConfig.Instance.ShowTarget && barInfo.ShowTarget)
            {
                BarTexture2D target = BuildInTextures.ExtraInfo["Target"];
                if (target.CustomDrawEvent != null)
                {
                    target.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, target.texture.Value);
                }
                else
                {
                    frameNow.TryAdd(target, 1);
                    int heightPF = target.texture.Value.Height / target.frameCount;
                    if (npc.target >= 0)
                    {
                        string name = Main.player[npc.target].name.ToString();
                        Vector2 size = FontAssets.MouseText.Value.MeasureString(name);

                        Vector2 LeftTopPosition = new Vector2(position.X - ((size.X + target.texture.Value.Width) / 2), CheckBox[0].Y - heightPF - 5f);

                        spriteBatch.Draw(target.texture.Value, LeftTopPosition, Color.White * GlobalAlpha);
                        Utils.DrawBorderString(spriteBatch, name, new Vector2(LeftTopPosition.X + target.texture.Value.Width, LeftTopPosition.Y + (size.Y / 5)), Color.White * GlobalAlpha);
                    }
                }
            }

            if (BarConfig.Instance.ShowDamage && barInfo.ShowDamage)
            {
                BarTexture2D damage = BuildInTextures.ExtraInfo["Damage"];
                if (damage.CustomDrawEvent != null)
                {
                    damage.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, damage.texture.Value);
                }
                else
                {
                    frameNow.TryAdd(damage, 1);
                    int heightPF = damage.texture.Value.Height / damage.frameCount;
                    DrawInfoWithNum(CheckBox[0] + new Vector2(BarConfig.Instance.BarLength + head.fillOffset.X - damage.texture.Value.Width, -heightPF - 5f), damage, ToStringWithComma(npc.damage), heightPF);
                }
            }

            #endregion

            #endregion

            #region 额外绘制信息显示之上
            if (extraUponInfo != null && !BarConfig.Instance.EnableExtraCustom)
                foreach (BarTexture2D texture in extraUponInfo)
                    texture.CustomDrawEvent?.Invoke(spriteBatch, position, BarConfig.Instance.BarLength, (int)life, (int)lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, texture.texture.Value);
            #endregion

            #endregion
        }
    }

    public void PostDraw(SpriteBatch spriteBatch)
    {
        // Fuck you Calamity so many fucking content need to adapt you
    }

    #region Fill相关绘制方法

    internal void FillExtend(SpriteBatch spriteBatch, BarTexture2D fill, Vector2 position, int length, float percentage, float postpercentage, float alpha, float GlobalAlpha)
    {
        int FillPF = fill.texture.Value.Height / fill.frameCount;

        Rectangle p1 = FrameChooser(fill, FillPF);

        Rectangle FillP1 = new Rectangle(0, p1.Y, fill.texture.Value.Width - fill.fillCutLengh - 1, FillPF);
        Rectangle FillP2 = new Rectangle(fill.texture.Value.Width - fill.fillCutLengh - 1, p1.Y, fill.fillCutLengh + 1, FillPF);

        Color color = fill.barFillColor switch
        {
            BarFillColor.Custom => fill.fillColor,
            _ => BarFillColorMethods.GetVanillaBarColor(percentage),
        };

        if (length > fill.fillCutLengh)
        {
            spriteBatch.Draw(fill.texture.Value, new Rectangle((int)position.X, (int)position.Y, length - fill.fillCutLengh, FillPF), FillP1, color * alpha * GlobalAlpha);
            spriteBatch.Draw(fill.texture.Value, new Vector2(position.X + length - fill.fillCutLengh, position.Y), FillP2, color * alpha * GlobalAlpha);
        }
        else
        {
            spriteBatch.Draw(fill.texture.Value, new Vector2(position.X + length - fill.fillCutLengh, position.Y), new Rectangle(FillP2.X, FillP2.Y, length, FillP2.Height), color * alpha * GlobalAlpha);
        }
    }
    internal void AdjustTexture(ref BarTexture2D texture, SpriteBatch spriteBatch, int dstHeight)
    {
        // 宝宝我也看不懂这些，这是AI写的
        // 但是效果是对的不就好了吗

        Texture2D source = texture.texture.Value;

        int srcWidth = source.Width;
        int srcHeight = source.Height;

        int dstWidth = Math.Max(1, BarConfig.Instance.BarLength);
        dstHeight = Math.Max(1, dstHeight);


        // 原图
        Color[] src = new Color[srcWidth * srcHeight];
        source.GetData(src);


        // 新图
        Color[] dst = new Color[dstWidth * dstHeight];


        for (int y = 0; y < dstHeight; y++)
        {
            // 目标Y对应原图Y
            float fy = dstHeight == 1
                ? 0
                : y * (srcHeight - 1f) / (dstHeight - 1f);


            int top = (int)fy;
            int bottom = Math.Min(top + 1, srcHeight - 1);

            float ty = fy - top;


            for (int x = 0; x < dstWidth; x++)
            {
                // 目标X对应原图X
                float fx = dstWidth == 1
                    ? 0
                    : x * (srcWidth - 1f) / (dstWidth - 1f);


                int left = (int)fx;
                int right = Math.Min(left + 1, srcWidth - 1);

                float tx = fx - left;


                // 四个采样点
                Color c00 = src[top * srcWidth + left];
                Color c10 = src[top * srcWidth + right];
                Color c01 = src[bottom * srcWidth + left];
                Color c11 = src[bottom * srcWidth + right];


                // X方向插值
                Color topColor = new Color(
                    (byte)(c00.R + (c10.R - c00.R) * tx),
                    (byte)(c00.G + (c10.G - c00.G) * tx),
                    (byte)(c00.B + (c10.B - c00.B) * tx),
                    (byte)(c00.A + (c10.A - c00.A) * tx)
                );

                Color bottomColor = new Color(
                    (byte)(c01.R + (c11.R - c01.R) * tx),
                    (byte)(c01.G + (c11.G - c01.G) * tx),
                    (byte)(c01.B + (c11.B - c01.B) * tx),
                    (byte)(c01.A + (c11.A - c01.A) * tx)
                );


                // Y方向插值
                dst[y * dstWidth + x] = new Color(
                    (byte)(topColor.R + (bottomColor.R - topColor.R) * ty),
                    (byte)(topColor.G + (bottomColor.G - topColor.G) * ty),
                    (byte)(topColor.B + (bottomColor.B - topColor.B) * ty),
                    (byte)(topColor.A + (bottomColor.A - topColor.A) * ty)
                );
            }
        }


        Texture2D tex = new Texture2D(
            spriteBatch.GraphicsDevice,
            dstWidth,
            dstHeight,
            false,
            SurfaceFormat.Color);


        tex.SetData(dst);

        texture.adjustedtexture = tex;
    }

    internal void FillAll(int npctype, SpriteBatch spriteBatch, BarTexture2D fill, Vector2 position, int length, float percentage, float postpercentage, float alpha, float GlobalAlpha)
    {

        Color color = fill.barFillColor switch
        {
            BarFillColor.Custom => fill.fillColor,
            _ => BarFillColorMethods.GetVanillaBarColor(percentage),
        };

        if (fill.adjustedtexture == null || fill.adjustedtexture?.Width != BarConfig.Instance.BarLength)
        {
            AdjustTexture(ref fill, spriteBatch, fill.texture.Value.Height);

            BarData.BarInfos[npctype].barTextures.baseTextures[TextureType.Fill] = fill;
        }

        int FillPF = fill.texture.Value.Height / fill.frameCount;

        Rectangle FillP = FrameChooser(fill, FillPF);

        spriteBatch.Draw(
            fill.adjustedtexture,
            position,
            new Rectangle(0, 0, length, FillPF),
            color * GlobalAlpha);
    }

    internal void FillDulplicate(SpriteBatch spriteBatch, BarTexture2D fill, Vector2 position, int length, float percentage, float postpercentage, float alpha, float GlobalAlpha)
    {
        int count = (length - fill.fillCutLengh) / (fill.texture.Value.Width - fill.fillCutLengh);
        int remainder = (length - fill.fillCutLengh) % (fill.texture.Value.Width - fill.fillCutLengh);

        Color color = fill.barFillColor switch
        {
            BarFillColor.Custom => fill.fillColor,
            _ => BarFillColorMethods.GetVanillaBarColor(percentage),
        };
        int fillPF = fill.texture.Value.Height / fill.frameCount;
        Rectangle fillp = FrameChooser(fill, fillPF);

        for (int i = 0; i < count; i++)
        {
            spriteBatch.Draw(fill.texture.Value, new Vector2(position.X + (i * (fill.texture.Value.Width - fill.fillCutLengh)), position.Y), new Rectangle(fillp.X, fillp.Y, fillp.Width - fill.fillCutLengh, fillp.Height), color * GlobalAlpha);
        }

        spriteBatch.Draw(fill.texture.Value, new Vector2(position.X + (count * (fill.texture.Value.Width - fill.fillCutLengh)), position.Y), new Rectangle(0, fillp.Y, remainder, fillPF), color * GlobalAlpha);

        spriteBatch.Draw(fill.texture.Value, new Vector2(position.X + (count * (fill.texture.Value.Width - fill.fillCutLengh)) + remainder, position.Y), new Rectangle((int)(fill.texture.Value.Width - fill.fillCutLengh), fillp.Y, fill.fillCutLengh, fillPF), color * GlobalAlpha);
    }

    #endregion

    internal Rectangle FrameChooser(BarTexture2D bartetxure, int heightPF)
    {
        if (frameNow.ContainsKey(bartetxure))
            frameNow[bartetxure]++;
        else
            frameNow.Add(bartetxure, 1);


        if (frameNow[bartetxure] >= bartetxure.frameCount * bartetxure.TicksPerFrame)
            frameNow[bartetxure] = 1;

        int NowFrame = (frameNow[bartetxure]) / bartetxure.TicksPerFrame;

        return new Rectangle(
            0,
            heightPF * (NowFrame),
            bartetxure.texture.Value.Width,
            heightPF
            );
    }

    internal Action<bool, bool, bool, bool, bool, bool, SpriteBatch, Vector2, int, float[], float, NPC, List<int>, float> DrawText = new(
                (bool_invincible, bool_name, bool_life, bool_lifemax, bool_percentage, bool_segment, spriteBatch, position, BarLength, lifefloats, GlobalAlpha, npc, SegmentTypeList, shieldpercentage) =>
            {
                string GetText(float _life, float _lifemax, float _percentage)
                {
                    string Info = string.Empty;
                    if (bool_name)
                    {
                        Info += Lang.GetNPCName(npc.type).ToString();
                    }
                    if (bool_life)
                    {
                        Info += (Info == string.Empty ? "" : " : ") + ToStringWithComma((int)_life);
                        if (bool_lifemax)
                        {
                            Info += "/";
                            Info += ToStringWithComma((int)_lifemax);
                        }
                    }
                    if (bool_lifemax && !bool_life)
                    {
                        Info += (Info == string.Empty ? "" : " : ") + ToStringWithComma((int)_lifemax);
                    }
                    if (bool_percentage)
                    {
                        Info += (Info == string.Empty ? "" : " : ") + "[" + string.Format("{0:f2}", _percentage * 100) + "%" + "]";
                    }
                    if (bool_segment && SegmentTypeList != null)
                    {
                        int amount = 0;

                        foreach (int segmentType in SegmentTypeList)
                        {
                            foreach (NPC segment in Main.npc)
                            {
                                if (segment.type == segmentType && segment.active)
                                {
                                    amount++;
                                }
                            }
                        }
                        if (amount != 0)
                        {
                            Info += (Info == string.Empty ? "" : " : ") + Language.GetTextValue("Mods.YuBellBossBar.Info.Segment", amount.ToString());
                        }
                    }
                    return Info;
                }

                string Info = string.Empty;
                if (lifefloats[3] > 0 && BarConfig.Instance.ShowShield)
                    Info = GetText(lifefloats[3], lifefloats[4], shieldpercentage);
                else
                {
                    Info = GetText(lifefloats[0], lifefloats[1], lifefloats[2]);
                    if (npc.dontTakeDamage && BarConfig.Instance.ShowInvincible && bool_invincible)
                        Info = "[" + Lang.GetNPCName(npc.type).ToString() + " : " + Language.GetTextValue("Mods.YuBellBossBar.Info.Invincible") + "]";
                }

                DrawBorderStringWithCenter(spriteBatch, Info, position, Color.White * GlobalAlpha);

            });

    internal static void DrawBorderStringWithCenter(SpriteBatch sb, string text, Vector2 center, Color color)
    {
        Vector2 size = FontAssets.MouseText.Value.MeasureString(text);
        Vector2 Namepostion = new Vector2(size.X / 2, size.Y / 3);

        Utils.DrawBorderString(sb, text, center - Namepostion, color);
    }

    internal static string ToStringWithComma(int input)
    {
        return input.ToString("N0", new NumberFormatInfo
        {
            NumberGroupSizes = new[] { Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese) ? BarConfig.Instance.ChineseCommaGap : BarConfig.Instance.CommaGap },
            NumberGroupSeparator = ","
        });
    }

    internal void StandardDrawFill(SpriteBatch spriteBatch, Vector2 position, float life, float lifemax, float percentage, float GlobalAlpha, NPC npc, int lengthPost, int lengthNow, float postpercentage, int shieldlength)
    {
        Vector2 StartPosition = position - new Vector2(BarConfig.Instance.BarLength / 2, fill.texture.Value.Height / (2 * fill.frameCount));
        int filllengh = (int)(BarConfig.Instance.BarLength * percentage);

        #region 填充部分
#pragma warning disable CS8524
        Color fillcolor = fill.barFillColor switch
        {
            BarFillColor.Custom => fill.fillColor,
            BarFillColor.Vanilla => BarFillColorMethods.GetVanillaBarColor(percentage)
        };

        switch (fill.barFillStyles)
        {
            case BarFillStyles.FillExtend:
                {
                    FillExtend(spriteBatch, fill, StartPosition, lengthPost, percentage, postpercentage, 0.7f, GlobalAlpha);
                    FillExtend(spriteBatch, fill, StartPosition, lengthNow, percentage, postpercentage, 1f, GlobalAlpha);
                    break;
                }
            case BarFillStyles.FillAll:
                {
                    FillAll(npc.type, spriteBatch, fill, StartPosition, lengthNow, percentage, postpercentage, 1f, GlobalAlpha);
                    break;
                }
            case BarFillStyles.FillPartial:
                {
                    FillExtend(spriteBatch, fill, StartPosition, lengthNow, percentage, postpercentage, 1f, GlobalAlpha);
                    break;
                }
            case BarFillStyles.Dulplicate:
                {
                    FillDulplicate(spriteBatch, fill, StartPosition, lengthNow, percentage, postpercentage, 1f, GlobalAlpha);
                    break;
                }
        }
        #endregion

        #region 盾条

        if (shieldlength > 0 && BarConfig.Instance.ShowShield)
        {
            BarTexture2D shield = BuildInTextures.ExtraInfo["Shield"];

            int heightPF = fill.texture.Value.Height / fill.frameCount;

            if (shield.adjustedtexture == null || shield.adjustedtexture?.Width != BarConfig.Instance.BarLength || shield.adjustedtexture?.Height != heightPF)
            {
                AdjustTexture(ref shield, spriteBatch, heightPF);
                BuildInTextures.ExtraInfo["Shield"] = shield;
            }

            spriteBatch.Draw(
                shield.adjustedtexture,
                StartPosition,
                new Rectangle(0, 0, shieldlength, shield.texture.Value.Height),
                shield.shieldColor * GlobalAlpha);
        }

        #endregion
    }

    internal void StandardDrawFrame(SpriteBatch spriteBatch, Vector2 position, float life, float lifemax, float percentage, float GlobalAlpha, NPC npc)
    {
        int HeightPF = frame.texture.Value.Height / frame.frameCount;
        Vector2 StartPosition = position - new Vector2((BarConfig.Instance.BarLength / 2) + head.fillOffset.X - head.texture.Value.Width, HeightPF / 2);
        Vector2 EndPosition = position + new Vector2((BarConfig.Instance.BarLength / 2) - tail.fillOffset.X, -HeightPF / 2);
        Rectangle frameP = FrameChooser(frame, HeightPF);

        switch (frame.barFrameStyles)
        {
            case BarFrameStyles.Extend:
                {
                    spriteBatch.Draw(frame.texture.Value, new Rectangle((int)StartPosition.X, (int)StartPosition.Y, (int)EndPosition.X - (int)StartPosition.X, HeightPF), frameP, Color.White * GlobalAlpha);

                    break;
                }

            case BarFrameStyles.Dulplicate:
                {
                    int count = (((int)EndPosition.X - (int)StartPosition.X) / frame.texture.Value.Width);
                    int extra = (((int)EndPosition.X - (int)StartPosition.X) % frame.texture.Value.Width);

                    for (int i = 0; i < count; i++)
                    {
                        spriteBatch.Draw(frame.texture.Value, new Rectangle((int)StartPosition.X + (i * frame.texture.Value.Width), (int)StartPosition.Y, frame.texture.Value.Width, HeightPF), frameP, Color.White * GlobalAlpha);
                    }
                    spriteBatch.Draw(frame.texture.Value, new Vector2(EndPosition.X - extra, EndPosition.Y), new Rectangle(frame.texture.Value.Width - extra, 0, extra, frameP.Height), Color.White * GlobalAlpha);

                    break;
                }
        }
    }

    internal void StandardDrawHead(SpriteBatch spriteBatch, Vector2 position, float life, float lifemax, float percentage, float GlobalAlpha, NPC npc)
    {
        int HeightPF = head.texture.Value.Height / head.frameCount;
        Vector2 StartPosition = position - new Vector2((BarConfig.Instance.BarLength / 2) + head.fillOffset.X, HeightPF / 2);

        CheckBox[0] = StartPosition;

        spriteBatch.Draw(head.texture.Value, StartPosition, FrameChooser(head, HeightPF), Color.White * GlobalAlpha);
    }

    internal void StandardDrawTail(SpriteBatch spriteBatch, Vector2 position, float life, float lifemax, float percentage, float GlobalAlpha, NPC npc)
    {
        int HeightPF = tail.texture.Value.Height / tail.frameCount;

        Vector2 StartPosition = position + new Vector2((BarConfig.Instance.BarLength / 2) - tail.fillOffset.X, -HeightPF / 2);

        CheckBox[1] = StartPosition;

        spriteBatch.Draw(tail.texture.Value, StartPosition, FrameChooser(tail, HeightPF), Color.White * GlobalAlpha);
    }

    internal void StandardDrawIcon(SpriteBatch spriteBatch, Vector2 position, float life, float lifemax, float percentage, float GlobalAlpha, NPC npc)
    {
        int HeightPF = icon.texture.Value.Height / icon.frameCount;

        spriteBatch.Draw(icon.texture.Value, CheckBox[0] + head.headOffset - new Vector2(icon.texture.Value.Width / 2, HeightPF / 2), FrameChooser(icon, HeightPF), Color.White * GlobalAlpha);

    }
}

