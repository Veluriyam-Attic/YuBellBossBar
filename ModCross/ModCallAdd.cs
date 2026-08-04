namespace YuBellBossBar.ModCross
{
    internal class ModCallAdd
    {
        public static object Add(params object[] args)
        {
            switch (args[2])
            {
                default: break;

                #region 添加BarTexture2D
                case "Add BarTexture2D":
                    {
                        // index||TextureType||Asset<Texture2D>||fillCutLengh = 0||fillOffset = Vector2.Zero||headOffset = Vector2.Zero
                        // BarFillStyles = barFillStyles.None
                        // barFillColor = BarFillColor.Vanilla||fillColor = Color.White||barFrameStyles = BarFrameStyles.None
                        // framecount||TPF||customdraw = null||shieldcolor = null
                        BarTexture2D barTexture2D = new BarTexture2D(args[4] switch
                        {
                            "Icon" => TextureType.Icon,
                            "Fill" => TextureType.Fill,
                            "Frame" => TextureType.Frame,
                            "Head" => TextureType.Head,
                            "Tail" => TextureType.Tail,
                            "Info" => TextureType.Info,
                            "Shield" => TextureType.Shield,
                            "ExtraBelowFill" => TextureType.ExtraBelowFill,
                            "ExtraBetweenFillAndFrame" => TextureType.ExtraBetweenFillAndFrame,
                            "ExtraBetweenFrameAndHeadEnd" => TextureType.ExtraBetweenFrameAndHeadEnd,
                            "ExtraBetweenHeadEndAndIcon" => TextureType.ExtraBetweenHeadEndAndIcon,
                            "ExtraBetweenIconAndInfo" => TextureType.ExtraBetweenIconAndInfo,
                            "ExtraUponInfo" => TextureType.ExtraUponInfo,

                            _ => TextureType.None,
                        },
                            (Asset<Texture2D>)args[5],
                            TextureSource.ExtraCustom,
                            (ref fillCutLengh, ref fillOffset, ref headOffset, ref barFillStyles, ref barFillColor, ref fillColor, ref barFrameStyles) =>
                            {
                                fillCutLengh = (int)args[6];
                                fillOffset = (Vector2)args[7];
                                headOffset = (Vector2)args[8];
                                barFillStyles = args[9] switch
                                {
                                    "FillExtend" => BarFillStyles.FillExtend,
                                    "FillAll" => BarFillStyles.FillAll,
                                    "FillPartial" => BarFillStyles.FillPartial,
                                    "Dulplicate" => BarFillStyles.Dulplicate,

                                    _ => BarFillStyles.None
                                };
                                barFillColor = args[10] switch
                                {
                                    "Custom" => BarFillColor.Custom,
                                    _ => BarFillColor.Vanilla,
                                };
                                fillColor = (Color)args[11];
                                barFrameStyles = args[12] switch
                                {
                                    "Extend" => BarFrameStyles.Extend,
                                    "Dulplicate" => BarFrameStyles.Dulplicate,

                                    _ => BarFrameStyles.None
                                };
                            },
                            (int)args[13],
                            (int)args[14],
                            // sb, position, BarLength,life,lifemax,percentage,GlobalAlpha,npc,drawParams,bt without customdraw event,return the startposition
                            (Func<SpriteBatch, Vector2, int, int, int, float, float, NPC, BossBarDrawParams, Texture2D, Vector2>)args[15],
                            (Color?)args[16]
                        );

                        BuildInTextures.ExtraCustom.Add(
                            (string)args[3],
                            barTexture2D);
                        return barTexture2D;
                    }
                #endregion

                #region 添加BarInfo
                case "Add BarInfo":
                    {
                        Dictionary<TextureType, BarTexture2D> dict = new();

                        if (args[4] is List<object> list)
                        {
                            foreach (BarTexture2D item in list)
                            {
                                dict.TryAdd(item.textureType, item);
                            }
                        }

                        if(BarData.BarInfos.TryAdd((int)args[3], new BarInfo(new BarTextures((int)args[3], dict),
                            (Action<bool, bool, bool, bool, bool, bool, SpriteBatch, Vector2, int, float[], float, NPC, BossBarDrawParams, List<int>, float, Action<bool, bool, bool, bool, bool, bool, SpriteBatch, Vector2, int, float[], float, NPC, BossBarDrawParams, List<int>, float>>)args[5],
                            (Dictionary<string, bool>)args[6], (List<int>)args[7])))
                        {
                            return "Yet Another Mod Call: Successed!";
                        }

                        break;
                    }
                #endregion

                // index||TextureType||Asset<Texture2D>||fillCutLengh = 0||fillOffset = Vector2.Zero||headOffset = Vector2.Zero
                // BarFillStyles = barFillStyles.None
                // barFillColor = BarFillColor.Vanilla||fillColor = Color.White||barFrameStyles = BarFrameStyles.None
                // framecount||TPF||customdraw = null||shieldcolor = null
                case "Add Head":
                    {
                        if (args[7] == null)
                            return Add("YetAnotherModCall", "Add", "Add BarTexture2D", args[3], "Head", args[4], 0, args[5], args[6], "", "", Color.White, "", 1, 6, null, null);
                        else
                            return Add("YetAnotherModCall", "Add", "Add BarTexture2D", args[3], "Head", args[4], 0, args[5], args[6], "", "", Color.White, "", args[7], args[8], args[9], null);
                    }

                case "Add Tail":
                    {
                        if (args[6]==null)
                            return Add("YetAnotherModCall", "Add", "Add BarTexture2D", args[3], "Tail", args[4], 0, args[5], Vector2.Zero, "", "", Color.White, "", 1, 6, null, null);
                        else
                            return Add("YetAnotherModCall", "Add", "Add BarTexture2D", args[3], "Tail", args[4], 0, args[5], Vector2.Zero, "", "", Color.White, "", args[6], args[7], args[8], null);
                    }

                case "Add Frame":
                    {
                        if (args[6] == null)
                            return Add("YetAnotherModCall", "Add", "Add BarTexture2D", args[3], "Frame", args[4], 0, Vector2.Zero, Vector2.Zero, "", "", Color.White, args[5], 1, 6, null, null);
                        else
                            return Add("YetAnotherModCall", "Add", "Add BarTexture2D", args[3], "Frame", args[4], 0, Vector2.Zero, Vector2.Zero, "", "", Color.White, args[5], args[6], args[7], args[8], null);
                    }

                case "Add Fill":
                    {
                        if (args[9] == null)
                            return Add("YetAnotherModCall", "Add", "Add BarTexture2D", args[3], "Fill", args[4], args[5], Vector2.Zero, Vector2.Zero, args[6], args[7], args[8], "", 1, 6, null, null);
                        else
                            return Add("YetAnotherModCall", "Add", "Add BarTexture2D", args[3], "Fill", args[4], args[5], Vector2.Zero, Vector2.Zero, args[6], args[7], args[8], "", args[9], args[10], args[11], args[12]);
                    }

                case "Add Icon":
                    {
                        if (args[5] == null)
                            return Add("YetAnotherModCall", "Add", "Add BarTexture2D", args[3], "Icon", args[4], 0, Vector2.Zero, Vector2.Zero, "", "", Color.White, "", 1, 6, null, null);
                        else
                            return Add("YetAnotherModCall", "Add", "Add BarTexture2D", args[3], "Icon", args[4], 0, Vector2.Zero, Vector2.Zero, "", "", Color.White, "", args[5], args[6], args[7], null);
                    }
            }

            return "Yet Another Mod Call: Failed!";
        }
    }
}
