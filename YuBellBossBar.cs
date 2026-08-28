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

        // 加载贴图
        // Load textures
        BarData.InstantiateBuildInContent();
    }

    public override void PostSetupContent()
    {
        Mod yabhb = ModLoader.GetMod("YuBellBossBar");
        if (ModLoader.HasMod("YuBellBossBar"))
        {
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.MartianSaucer, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.MartianSaucerCannon, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.MartianSaucerCore, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.MartianSaucerTurret, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.MoonLordCore, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.BrainofCthulhu, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.Golem, false);
        }

        #region 检查灾厄是否启用了 Check if Calamity Mod is loaded
        if (ModLoader.HasMod("CalamityMod"))
        {
            // 自动启用灾厄血条适配(只对灾厄专门适配过的Boss生效)
            // Automatically enable the Calamity Mod boss bar adaptation
            CalamityAdapt = true;

            // 反射初始化灾厄Boss血条相关成员(完全不引用CalamityMod.dll)
            // Initialize reflected members of Calamity's boss health bar without referencing CalamityMod.dll at all
            CalamityBarHealth.CalamityLoaded = CalamityBarHealth.Initialize();
        }
        #endregion
    }

    public override object Call(params object[] args)
    {
        if (args[0].ToString() == "YetAnotherModCall")
        {
            switch (args[1])
            {
                default: break;

                case "Chaos":
                    {

                        break;
                    }
                case "Disable Yet Another Boss Health Bar Mod":
                    {
                        YAB.EnableThisMod = false;
                        return "YetAnotherModCall: Disable Target Mod Successfully!";
                    }
                case "Edit":
                    {
                        return ModCallEdit.Edit(args);
                    }
                case "Add":
                    {
                        return ModCallAdd.Add(args);
                    }
            }
            ;
        }
        return "YetAnotherModCall: Failed!";
    }
}
