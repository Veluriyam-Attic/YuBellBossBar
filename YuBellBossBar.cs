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
        // 可以从外部设定特定Boss的血条绘制情况
        if (args[0].ToString() == "ChangeBarInfo")
            YAB.ModCalls.TryAdd((int)args[1],new BarInfo(new BarTextures(), (Dictionary<string,bool>)args[2]));

        return "[Yet Another Boss Health Bar]:Mod Call has been executed.";
    }
}
