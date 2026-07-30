namespace YuBellBossBar.ModCross
{
    internal class FargoCross : ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModLoader.TryGetMod("FargowiltasSouls", out Mod fargosouls))
            {
                Mod YuBellBossBar = ModLoader.GetMod("YuBellBossBar");

                YuBellBossBar.Call("YetAnotherModCall", "Edit", "Color", fargosouls.Find<ModNPC>("DeviBoss").Type, "Fill Color", (int)TextureType.Fill, new Color(255, 61, 223));
                YuBellBossBar.Call("YetAnotherModCall", "Edit", "Color", fargosouls.Find<ModNPC>("AbomBoss").Type, "Fill Color", (int)TextureType.Fill, Color.Orange);
                YuBellBossBar.Call("YetAnotherModCall", "Edit", "Color", fargosouls.Find<ModNPC>("MutantBoss").Type, "Fill Color", (int)TextureType.Fill, new Color(10, 255, 210));
            }
        }

    }
}
