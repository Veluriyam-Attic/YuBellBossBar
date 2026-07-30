namespace YuBellBossBar.ModCross
{
    internal class CalamityCross : ModSystem
    {
        public override void PostSetupContent()
        {

            if (ModLoader.TryGetMod("CalamityMod", out Mod calamity))
            {
                Mod YuBellBossBar = ModLoader.GetMod("YuBellBossBar");

                YuBellBossBar.Call("YetAnotherModCall", "Edit", "Invincible", calamity.Find<ModNPC>("SlimeGodCore").Type, false);
                YuBellBossBar.Call("YetAnotherModCall", "Edit", "Invincible", calamity.Find<ModNPC>("RavagerBody").Type, false);
                YuBellBossBar.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.Golem, false);
                YuBellBossBar.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemHead, false);
                YuBellBossBar.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemHeadFree, false);
                YuBellBossBar.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemFistLeft, false);
                YuBellBossBar.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemFistRight, false);
            }
        }
    }
}
