namespace YuBellBossBar.ModCross
{
    internal class AAClassicCross : ModType
    {
        public override void SetupContent()
        {
            if (ModLoader.TryGetMod("AAModClassic",out Mod AAClassic))
            {
                Mod yabhb = ModLoader.GetMod("YuBellBossBar");


            }
        }

        protected override void Register()
        {
            throw new NotImplementedException();
        }
    }
}
