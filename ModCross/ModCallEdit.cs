using static YuBellBossBar.Core.BarTexture2D;

namespace YuBellBossBar.ModCross
{
    internal class ModCallEdit
    {
        public static object Edit(params object[] args)
        {
            switch (args[2])
            {
                default: break;

                #region 修改颜色
                case "Color":
                    {
                        //if (args[3] is int && args[4] is string && args[5] is int && args[6] is Color)
                        {

                            {
                                switch (args[4].ToString())
                                {
                                    default: break;

                                    case "Fill Color":
                                        {
                                            if (BarData.BarInfos.Keys.Contains(Convert.ToInt32(args[3])))
                                            {
                                                BarInfo bridage1 = BarData.BarInfos[Convert.ToInt32(args[3])];
                                                BarTexture2D bridage2 = bridage1.barTextures.baseTextures[(TextureType)args[5]];
                                                bridage2.fillColor = (Color)args[6];
                                                bridage2.barFillColor = BarFillColor.Custom;
                                                bridage1.barTextures.baseTextures[(TextureType)args[5]] = bridage2;
                                                BarData.BarInfos[Convert.ToInt32(args[3])] = bridage1;
                                                return "YetAnotherModCall: Fill Color changed successfully!";
                                            }
                                            else
                                            {
                                                BarInfo bridage1 = new BarInfo(BarData.BarInfos[int.MinValue]);
                                                BarTexture2D bridage2 = bridage1.barTextures.baseTextures[(TextureType)args[5]];
                                                bridage2.fillColor = (Color)args[6];
                                                bridage2.barFillColor = BarFillColor.Custom;
                                                bridage1.barTextures.baseTextures[(TextureType)args[5]] = bridage2;
                                                BarData.BarInfos.Add(Convert.ToInt32(args[3]), bridage1);
                                                return "YetAnotherModCall: Fill Color changed successfully!";
                                            }
                                        }

                                    case "Shield Color":
                                        {
                                            if (BarData.BarInfos.Keys.Contains(Convert.ToInt32(args[3])))
                                            {
                                                BarInfo bridage1 = BarData.BarInfos[Convert.ToInt32(args[3])];
                                                BarTexture2D bridage2 = bridage1.barTextures.baseTextures[(TextureType)args[5]];
                                                bridage2.shieldColor = (Color)args[6];
                                                bridage2.barFillColor = BarFillColor.Custom;
                                                bridage1.barTextures.baseTextures[(TextureType)args[5]] = bridage2;
                                                BarData.BarInfos[Convert.ToInt32(args[3])] = bridage1;
                                                return "YetAnotherModCall: Shield Color changed successfully!";
                                            }


                                            else
                                            {
                                                BarInfo bridage1 = new BarInfo(BarData.BarInfos[int.MinValue]);
                                                BarTexture2D bridage2 = bridage1.barTextures.baseTextures[(TextureType)args[5]];
                                                bridage2.shieldColor = (Color)args[6];
                                                bridage2.barFillColor = BarFillColor.Custom;
                                                bridage1.barTextures.baseTextures[(TextureType)args[5]] = bridage2;
                                                BarData.BarInfos.Add(Convert.ToInt32(args[3]), bridage1);
                                                return "YetAnotherModCall: Shield Color changed successfully!";
                                            }
                                        }
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region 修改是否显示无敌状态
                case "Invincible":
                    {
                        //if (args[3] is int && args[4] is bool)
                        {
                            if (BarData.BarInfos.Keys.Contains(Convert.ToInt32(args[3])))
                            {
                                BarInfo bridage = new BarInfo(BarData.BarInfos[Convert.ToInt32(args[3])]);
                                bridage.ShowInvincible = (bool)args[4];
                                BarData.BarInfos[Convert.ToInt32(args[3])] = bridage;
                            }
                            else
                            {
                                BarInfo bridage = new BarInfo();
                                bridage.ShowInvincible = (bool)args[4];
                                BarData.BarInfos.Add(Convert.ToInt32(args[3]), bridage);
                            }
                            return "YetAnotherModCall: Invincible changed successfully!";
                        }
                    }
                #endregion

                case "AddBarTexture2D":
                    {
                        // index,TextureType,Asset<Texture2D>,fillCutLengh = 0,fillOdffset = Vector2.Zero,headOffset = Vector2.Zero
                        // BarFillStyles = (int.MaxValue)barFillStyles.None
                        // barFillColor = (0)BarFillColor.Vanilla ,fillColor = Color.White, barFrameStyles = (int.MaxValue)BarFrameStyles.None
                        // framecount,TPF,customdraw = null,shieldcolor = null
                        BuildInTextures.ExtraCustom.Add(
                            (string)args[3],
                            new BarTexture2D((TextureType)args[4],
                            (Asset<Texture2D>)args[5],
                            TextureSource.ExtraCustom,
                            (ref fillCutLengh, ref fillOffset, ref headOffset, ref barFillStyles, ref barFillColor, ref fillColor, ref barFrameStyles) =>
                        {
                            fillCutLengh = (int)args[6];
                            fillOffset = (Vector2)args[7];
                            headOffset = (Vector2)args[8];
                            barFillStyles = (BarFillStyles)args[9];
                            barFillColor = (BarFillColor)args[10];
                            fillColor = (Color)args[11];
                            barFrameStyles = (BarFrameStyles)args[12];
                        },
                            (int)args[13],
                            (int)args[14],
                            // sb, position, BarLength,life,lifemax,percentage,GlobalAlpha,npc,drawParams,bt without customdraw event,return the startposition
                            (Func<SpriteBatch, Vector2, int, int, int, float, float, NPC, BossBarDrawParams, BarTexture2D, Vector2>)args[15],
                            (Color?)args[16]
                        ));
                        break;
                    }
            }

            return "YetAnotherModCall:Failed!";
        }
    }
}
