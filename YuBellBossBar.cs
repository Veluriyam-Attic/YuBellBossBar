namespace YuBellBossBar;

public class YuBellBossBar : Mod
{
    public static bool CalamityAdapt = false;

    public override void Load()
    {
        // 世吞太傻逼了,这样才能在是否清除索引时让世吞被判断为在场的Boss
        // The Eater of World is too stupid, this is the only way to make it be judged as a boss in the field when checking whether to remove indexs or not.
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsHead] = true;
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsBody] = true;
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsTail] = true;

    }

    public override void PostSetupContent()
    {
        // 加载贴图
        // Load textures
        BarData.InstantiateBuildInContent();

        Mod YuBellBossBar = ModLoader.GetMod("YuBellBossBar");

        if (ModLoader.TryGetMod("FargowiltasSouls", out Mod fargosouls))
        {
            YuBellBossBar.Call("YetAnotherModCall", "Edit", "Color", fargosouls.Find<ModNPC>("DeviBoss").Type, "Fill Color", (int)TextureType.Fill, new Color(255, 61, 223));
            YuBellBossBar.Call("YetAnotherModCall", "Edit", "Color", fargosouls.Find<ModNPC>("AbomBoss").Type, "Fill Color", (int)TextureType.Fill, Color.Orange);
            YuBellBossBar.Call("YetAnotherModCall", "Edit", "Color", fargosouls.Find<ModNPC>("MutantBoss").Type, "Fill Color", (int)TextureType.Fill, new Color(10, 255, 210));
        }

        if (ModLoader.TryGetMod("CalamityMod",out Mod calamity))
        {
            YuBellBossBar.Call("YetAnotherModCall", "Edit", "Invincible", calamity.Find<ModNPC>("SlimeGodCore").Type, false);
        }
        #region 检查灾厄是否启用了 Check if Calamity Mod is loaded
        if (CalamityAdapt && ModLoader.HasMod("CalamityMod"))
        {
            CalamityBarHealth.CalamityLoaded = true;

            {
                // 初始化各个值防止反射的过度调用
                // Initialize values to prevent excessive reflection calls
#pragma warning disable IDE0300
                CalamityBarHealth.bossHealthBarManager = ModLoader.GetMod("CalamityMod").Code.GetType("CalamityMod.UI.BossHealthBarManager");
                CalamityBarHealth.oneToMany = CalamityBarHealth.bossHealthBarManager.GetField("OneToMany");
                CalamityBarHealth.OneToMany = CalamityBarHealth.oneToMany.GetValue(CalamityBarHealth.oneToMany) as Dictionary<int, int[]>;
                CalamityBarHealth.bossHPUI = CalamityBarHealth.bossHealthBarManager.GetNestedType("BossHPUI", BindingFlags.Public);
                CalamityBarHealth.constructor = CalamityBarHealth.bossHPUI.GetConstructor(new Type[] { typeof(int), typeof(string) });
                CalamityBarHealth.updateMethod = CalamityBarHealth.bossHPUI.GetMethod("Update");
            }

            FieldInfo SpecialBarDic = typeof(BigProgressBarSystem).GetField("_bossBarsByNpcNetId", BindingFlags.NonPublic | BindingFlags.Instance);
            BarData._bossBarsByNpcNetId = SpecialBarDic.GetValue(SpecialBarDic) as Dictionary<int, IBigProgressBar>;
        }
        #endregion
    }

    public override object Call(params object[] args)
    {
        if (args[0].ToString() == "YetAnotherModCall")
        {
            switch(args[1])
            {
                default:break;

                case "Disable Yet Another Boss Health Bar Mod":
                    {
                        YAB.EnableThisMod = false;
                        return "YetAnotherModCall: Disable Target Mod Successfully!";
                    }
                case "Edit":
                    {
                        switch (args[2])
                        {
                            default: break;

                            case "Color":
                                {
                                    if (args[3] is int && args[4] is string && args[5] is int && args[6] is Color)
                                    {
                                        if (BarData.BarInfos.Keys.Contains((int)args[3]))
                                        {
                                            switch (args[4].ToString())
                                            {
                                                default: break;

                                                case "Fill Color":
                                                    {
                                                        BarInfo bridage1 = BarData.BarInfos[(int)args[3]];
                                                        BarTexture2D bridage2 = bridage1.barTextures.baseTextures[(TextureType)args[5]];
                                                        bridage2.fillColor = (Color)args[6];
                                                        bridage2.barFillColor = BarFillColor.Custom;
                                                        bridage1.barTextures.baseTextures[(TextureType)args[5]] = bridage2;
                                                        BarData.BarInfos[(int)args[3]] = bridage1;
                                                        return "YetAnotherModCall: Fill Color changed successfully!";
                                                    }

                                                case "Shield Color":
                                                    {
                                                        BarInfo bridage1 = BarData.BarInfos[(int)args[3]];
                                                        BarTexture2D bridage2 = bridage1.barTextures.baseTextures[(TextureType)args[5]];
                                                        bridage2.shieldColor = (Color)args[6];
                                                        bridage2.barFillColor = BarFillColor.Custom;
                                                        bridage1.barTextures.baseTextures[(TextureType)args[5]] = bridage2;
                                                        BarData.BarInfos[(int)args[3]] = bridage1;
                                                        return "YetAnotherModCall: Shield Color changed successfully!";
                                                    }
                                            }
                                        }
                                        else
                                        {
                                            switch (args[4].ToString())
                                            {
                                                default: break;

                                                case "Fill Color":
                                                    {
                                                        BarInfo bridage1 = new BarInfo(BarData.BarInfos[int.MaxValue]);
                                                        BarTexture2D bridage2 = bridage1.barTextures.baseTextures[(TextureType)args[5]];
                                                        bridage2.fillColor = (Color)args[6];
                                                        bridage2.barFillColor = BarFillColor.Custom;
                                                        bridage1.barTextures.baseTextures[(TextureType)args[5]] = bridage2;
                                                        BarData.BarInfos.Add((int)args[3],bridage1);
                                                        return "YetAnotherModCall: Fill Color changed successfully!";
                                                    }

                                                case "Shield Color":
                                                    {
                                                        BarInfo bridage1 = new BarInfo(BarData.BarInfos[int.MaxValue]);
                                                        BarTexture2D bridage2 = bridage1.barTextures.baseTextures[(TextureType)args[5]];
                                                        bridage2.shieldColor = (Color)args[6];
                                                        bridage2.barFillColor = BarFillColor.Custom;
                                                        bridage1.barTextures.baseTextures[(TextureType)args[5]] = bridage2;
                                                        BarData.BarInfos.Add((int)args[3], bridage1);
                                                        return "YetAnotherModCall: Shield Color changed successfully!";
                                                    }
                                            }
                                        }
                                    }
                                    break;
                                }

                            case "Invincible":
                                {
                                    if (args[3] is int && args[4] is bool)
                                    {
                                        if (BarData.BarInfos.Keys.Contains((int)args[3]))
                                        {
                                            BarInfo bridage = new BarInfo(BarData.BarInfos[(int)args[3]]);
                                            bridage.ShowInvincible = (bool)args[4];
                                            BarData.BarInfos[(int)args[3]] = bridage;
                                        }
                                        else
                                        {
                                            BarInfo bridage = new BarInfo(BarData.BarInfos[int.MaxValue]);
                                            bridage.ShowInvincible = (bool)args[4];
                                            BarData.BarInfos.Add((int)args[3],bridage);
                                        }
                                    }
                                    return "YetAnotherModCall: Invincible changed successfully!";
                                }

                        }
                        break;
                    }
            };
        }
        return "YetAnotherModCall:Failed!";
    }
}
