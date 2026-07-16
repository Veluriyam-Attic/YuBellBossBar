namespace YuBellBossBar.DrawMethod
{
    internal class BarLifeMethods
    {
        private static TwinsBigProgressBar _twinsBar = new TwinsBigProgressBar();

        private static EaterOfWorldsProgressBar _eaterOfWorldsBar = new EaterOfWorldsProgressBar();

        private static BrainOfCthuluBigProgressBar _brainOfCthuluBar = new BrainOfCthuluBigProgressBar();

        private static GolemHeadProgressBar _golemBar = new GolemHeadProgressBar();

        private static MoonLordProgressBar _moonlordBar = new MoonLordProgressBar();

        private static SolarFlarePillarBigProgressBar _solarPillarBar = new SolarFlarePillarBigProgressBar();

        private static VortexPillarBigProgressBar _vortexPillarBar = new VortexPillarBigProgressBar();

        private static NebulaPillarBigProgressBar _nebulaPillarBar = new NebulaPillarBigProgressBar();

        private static StardustPillarBigProgressBar _stardustPillarBar = new StardustPillarBigProgressBar();

        private static NeverValidProgressBar _neverValid = new NeverValidProgressBar();

        private static PirateShipBigProgressBar _pirateShipBar = new PirateShipBigProgressBar();

        private static MartianSaucerBigProgressBar _martianSaucerBar = new MartianSaucerBigProgressBar();

        private static DeerclopsBigProgressBar _deerclopsBar = new DeerclopsBigProgressBar();

        private Dictionary<int, IBigProgressBar> _bossBarsByNpcNetId = new Dictionary<int, IBigProgressBar>
        {
            { 125, _twinsBar },
            { 126, _twinsBar },
            { 13, _eaterOfWorldsBar },
            { 14, _eaterOfWorldsBar },
            { 15, _eaterOfWorldsBar },
            { 266, _brainOfCthuluBar },
            { 245, _golemBar },
            { 246, _golemBar },
            { 249, _neverValid },
            { 517, _solarPillarBar },
            { 422, _vortexPillarBar },
            { 507, _nebulaPillarBar },
            { 493, _stardustPillarBar },
            { 398, _moonlordBar },
            { 396, _moonlordBar },
            { 397, _moonlordBar },
            { 548, _neverValid },
            { 549, _neverValid },
            { 491, _pirateShipBar },
            { 492, _pirateShipBar },
            { 440, _neverValid },
            { 395, _martianSaucerBar },
            { 393, _martianSaucerBar },
            { 394, _martianSaucerBar },
            { 68, _neverValid },
            { 668, _deerclopsBar }
        };

        public static void Calculation(int npcwhoami)
        {

        }
    }
}
