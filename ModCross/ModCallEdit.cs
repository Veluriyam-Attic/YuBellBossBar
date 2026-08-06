namespace YuBellBossBar.ModCross;

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
                            // 不能用 new BarInfo():struct 无参构造不执行字段初始化器,ShowBar/ShowText 等会全是 false
                            // 复制默认银条,保留所有默认显示开关
                            BarInfo bridage = new BarInfo(BarData.BarInfos[int.MinValue]);
                            bridage.ShowInvincible = (bool)args[4];
                            BarData.BarInfos.Add(Convert.ToInt32(args[3]), bridage);
                        }
                        return "YetAnotherModCall: Invincible changed successfully!";
                    }
                }
            #endregion
        }

        return "YetAnotherModCall:Failed!";
    }
}

