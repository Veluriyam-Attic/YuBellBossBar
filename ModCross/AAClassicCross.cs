namespace YuBellBossBar.ModCross
{
    internal class AAClassicCross : ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModLoader.TryGetMod("AAModClassic",out Mod AAClassic))
            {
                Mod yabhb = ModLoader.GetMod("YuBellBossBar");


            }
        }
    }
}
