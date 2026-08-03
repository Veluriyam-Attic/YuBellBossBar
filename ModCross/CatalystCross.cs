namespace YuBellBossBar.ModCross
{
    internal class CatalystCross : ModSystem
    {
        public override void PostSetupContent()
        {

            if (ModLoader.TryGetMod("CatalystMod", out Mod catalyst))
            {
                Mod yabhb = ModLoader.GetMod("YuBellBossBar");

                yabhb.Call("YetAnotherModCall", "Edit", "Color", catalyst.Find<ModNPC>("Astrageldon").Type, "Fill Color", (int)TextureType.Fill, Color.Purple);
            }
        }
    }
}
