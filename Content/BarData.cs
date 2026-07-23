namespace YuBellBossBar.Content;

internal static class BarData
{
    private const string _dtpath = "YuBellBossBar/Texture/DefaultTexture/";
    private const string _dvpath = "YuBellBossBar/Texture/DefaultVanilla/";
    private const string _evpath = "YuBellBossBar/Texture/ExtraVanilla/";

#pragma warning disable IDE0090,IDE0028
    public static Dictionary<int, BarInfo> buildincontent = new Dictionary<int, BarInfo>();

    /// <summary>
    /// <br/>反射拿到的原版词典
    /// <br/>The Vanilla dictionary obtained by reflection
    /// </summary>
    public static Dictionary<int, IBigProgressBar> _bossBarsByNpcNetId;

    public static void InstantiateBuildInContent()
    {
        #region 默认贴图 Default Texture
        #region 金色风格 Gloden Style
        buildincontent.Add(int.MaxValue,
            new BarInfo(
                new BarTextures(
                    int.MaxValue,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultTexture["HealthBarFrame_Exp"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["HealthBarHead_Exp"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["HealthBarTail_Exp"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 银色风格 Silver Style
        buildincontent.Add(int.MinValue,
            new BarInfo(
                new BarTextures(
                    int.MinValue,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultTexture["HealthBarFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultTexture["HealthBarHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultTexture["HealthBarTail"]
                        }
                    }
                )
            )
        );
        #endregion
        #endregion

        #region 默认原版 Default Vanilla
        #region 血肉墙 Wall of Flesh
        buildincontent.Add(NPCID.WallofFlesh,
            new BarInfo(
                new BarTextures(
                    NPCID.WallofFlesh,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["WallofFleshFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["WallofFleshHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["WallofFleshTail"]
                        },
                    }
                )
            )
        );
        #endregion
        #region 血肉墙眼 Wall of Flesh Eye
        buildincontent.Add(NPCID.WallofFleshEye,
            new BarInfo(
                new BarTextures(
                    NPCID.WallofFlesh,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["WallofFleshFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["WallofFleshHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["WallofFleshTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 激光眼 Retinazer
        buildincontent.Add(
            NPCID.Retinazer,
            new BarInfo(
                new BarTextures(
                    NPCID.Retinazer,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["MechBossTail"]
                        },
                    }
                )
            )
        );
        #endregion
        #region 魔焰眼 Spazmatism
        buildincontent.Add(
            NPCID.Spazmatism,
            new BarInfo(
                new BarTextures(
                    NPCID.Spazmatism,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["MechBossTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 毁灭者 The Destroyer
        buildincontent.Add(
            NPCID.TheDestroyer,
            new BarInfo(
                new BarTextures(
                    NPCID.TheDestroyer,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["MechBossTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 机械骷髅王 Skeletron Prime
        buildincontent.Add(
            NPCID.SkeletronPrime,
            new BarInfo(
                new BarTextures(
                    NPCID.SkeletronPrime,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["MechBossFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["MechBossHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["MechBossTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.DefaultVanilla["SkeletronPrimeIcon"]
                        }
                    }
                )
            )
        );
        #endregion

        #region 世纪之花 Plantera
        buildincontent.Add(
            NPCID.Plantera,
            new BarInfo(
                new BarTextures(
                    NPCID.Plantera,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultVanilla["PlanteraFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultVanilla["PlanteraFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["PlanteraHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["PlanteraTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 月亮领主 Moon Lord
        buildincontent.Add(
            NPCID.MoonLordCore,
            new BarInfo(
                new BarTextures(
                    NPCID.MoonLordCore,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultTexture["HealthBarFrame_Exp"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["MoonLordHead_Exp"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["MoonLordTail_Exp"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.DefaultVanilla["MoonLordHeart"]
                        }
                    }
                )
            )
        );

        buildincontent.Add(
            NPCID.MoonLordHand,
            new BarInfo(
                new BarTextures(
                    NPCID.MoonLordHand,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultTexture["HealthBarFrame_Exp"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["MoonLordHead_Exp"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["MoonLordTail_Exp"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.DefaultVanilla["MoonLordEye"]
                        }
                    }
                )
            )
        );


        buildincontent.Add(
            NPCID.MoonLordHead,
            new BarInfo(
                new BarTextures(
                    NPCID.MoonLordHead,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.DefaultTexture["HealthBarFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.DefaultTexture["HealthBarFrame_Exp"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.DefaultVanilla["MoonLordHead_Exp"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.DefaultVanilla["MoonLordTail_Exp"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.DefaultVanilla["MoonLordEye"]
                        }
                    }
                )
            )
        );
        #endregion
        #endregion

        #region 额外原版 Extra Vanilla
        #region 史莱姆王 King Slime
        buildincontent.Add(NPCID.KingSlime,
            new BarInfo(
                new BarTextures(
                    NPCID.KingSlime,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["KingSlimeFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["KingSlimeFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["KingSlimeHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["KingSlimeTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 克苏鲁之眼 Eye of Cthulhu
        buildincontent.Add(NPCID.EyeofCthulhu,
            new BarInfo(
                new BarTextures(
                    NPCID.EyeofCthulhu,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["EyeofCthulhuFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["EyeofCthulhuFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["EyeofCthulhuHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["EyeofCthulhuTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 世界吞噬者 Eater of Worlds
        buildincontent.Add(NPCID.EaterofWorldsHead,
            new BarInfo(
                new BarTextures(
                    NPCID.EaterofWorldsHead,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["EaterofWorldsFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["EaterofWorldsFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["EaterofWorldsHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["EaterofWorldsTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.ExtraVanilla["EaterofWorldsIcon"]
                        }
                    }
                )
            )
        );
        buildincontent.Add(NPCID.EaterofWorldsBody,
            new BarInfo(
                new BarTextures(
                    NPCID.EaterofWorldsBody,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["EaterofWorldsFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["EaterofWorldsFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["EaterofWorldsHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["EaterofWorldsTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.ExtraVanilla["EaterofWorldsIcon"]
                        }
                    }
                )
            )
        );
        buildincontent.Add(NPCID.EaterofWorldsTail,
            new BarInfo(
                new BarTextures(
                    NPCID.EaterofWorldsTail,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["EaterofWorldsFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["EaterofWorldsFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["EaterofWorldsHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["EaterofWorldsTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.ExtraVanilla["EaterofWorldsIcon"]
                        }
                    }
                )
            )
        );
        #endregion

        #region 克苏鲁之脑 Brain of Cthulhu
        buildincontent.Add(NPCID.BrainofCthulhu,
            new BarInfo(
                new BarTextures(
                    NPCID.BrainofCthulhu,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["BrainofCthulhuFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["BrainofCthulhuFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["BrainofCthulhuHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["BrainofCthulhuTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.ExtraVanilla["BrainofCthulhuIcon"]
                        }
                    }
                )
            )
        );
        buildincontent.Add(NPCID.Creeper,
            new BarInfo(
                new BarTextures(
                    NPCID.Creeper,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["BrainofCthulhuFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["BrainofCthulhuFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["BrainofCthulhuHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["BrainofCthulhuTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.ExtraVanilla["BrainofCthulhuIcon"]
                        }
                    }
                )
            )
        );
        #endregion

        #region 蜂王 Queen Bee
        buildincontent.Add(NPCID.QueenBee,
            new BarInfo(
                new BarTextures(
                    NPCID.QueenBee,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["QueenBeeFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["QueenBeeFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["QueenBeeHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["QueenBeeTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 骷髅王 Skeletron
        buildincontent.Add(NPCID.SkeletronHead,
            new BarInfo(
                new BarTextures(
                    NPCID.SkeletronHead,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["SkeletronFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["SkeletronFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["SkeletronHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["SkeletronTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 独眼巨鹿 Deerclops
        buildincontent.Add(NPCID.Deerclops,
            new BarInfo(
                new BarTextures(
                    NPCID.Deerclops,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["DeerclopsFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["DeerclopsFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["DeerclopsHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["DeerclopsTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 史莱姆皇后 Queen Slime
        buildincontent.Add(NPCID.QueenSlimeBoss,
            new BarInfo(
                new BarTextures(
                    NPCID.QueenSlimeBoss,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["QueenSlimeFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["QueenSlimeFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["QueenSlimeHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["QueenSlimeTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 石巨人 Golem
        buildincontent.Add(NPCID.Golem,
            new BarInfo(
                new BarTextures(
                    NPCID.Golem,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["GolemFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["GolemFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["GolemHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["GolemTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.ExtraVanilla["GolemIcon"]
                        }
                    }
                )
            )
        );
        buildincontent.Add(NPCID.GolemHead,
            new BarInfo(
                new BarTextures(
                    NPCID.GolemHead,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["GolemFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["GolemFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["GolemHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["GolemTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.ExtraVanilla["GolemIcon"]
                        }
                    }
                )
            )
        );
        buildincontent.Add(NPCID.GolemFistLeft,
            new BarInfo(
                new BarTextures(
                    NPCID.GolemFistLeft,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["GolemFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["GolemFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["GolemHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["GolemTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.ExtraVanilla["GolemIcon"]
                        }
                    }
                )
            )
        );
        buildincontent.Add(NPCID.GolemFistRight,
            new BarInfo(
                new BarTextures(
                    NPCID.GolemFistLeft,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["GolemFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["GolemFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["GolemHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["GolemTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.ExtraVanilla["GolemIcon"]
                        }
                    }
                )
            )
        );
        buildincontent.Add(NPCID.GolemHeadFree,
            new BarInfo(
                new BarTextures(
                    NPCID.GolemFistLeft,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["GolemFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["GolemFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["GolemHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["GolemTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.ExtraVanilla["GolemIcon"]
                        }
                    }
                )
            )
        );
        #endregion

        #region 火星飞碟 Martian Saucer
        buildincontent.Add(NPCID.MartianSaucer,
            new BarInfo(
                new BarTextures(
                    NPCID.MartianSaucer,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["MartianSaucerFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["MartianSaucerFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["MartianSaucerHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["MartianSaucerTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 猪龙鱼公爵 Duke Fishron
        buildincontent.Add(NPCID.DukeFishron,
            new BarInfo(
                new BarTextures(
                    NPCID.DukeFishron,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["DukeFishronFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["DukeFishronFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["DukeFishronHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["DukeFishronTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 光之女皇 Empress of Light
        buildincontent.Add(NPCID.HallowBoss,
            new BarInfo(
                new BarTextures(
                    NPCID.HallowBoss,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["EmpressofLightFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["EmpressofLightFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["EmpressofLightHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["EmpressofLightTail"]
                        },
                    }
                )
            )
        );
        #endregion

        #region 拜月教邪教徒 Lunatic Cultist
        buildincontent.Add(NPCID.CultistBoss,
            new BarInfo(
                new BarTextures(
                    NPCID.CultistBoss,
                    new Dictionary<TextureType, BarTexture2D>()
                    {
                        {
                            TextureType.Fill,
                            BuildInTextures.ExtraVanilla["LunaticCultistFill"]
                        },
                        {
                            TextureType.Frame,
                            BuildInTextures.ExtraVanilla["LunaticCultistFrame"]
                        },
                        {
                            TextureType.Head,
                            BuildInTextures.ExtraVanilla["LunaticCultistHead"]
                        },
                        {
                            TextureType.Tail,
                            BuildInTextures.ExtraVanilla["LunaticCultistTail"]
                        },
                        {
                            TextureType.Icon,
                            BuildInTextures.ExtraVanilla["LunaticCultistIcon"]
                        }
                    }
                )
            )
        );
        #endregion

        #endregion
    }
}