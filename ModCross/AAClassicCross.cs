namespace YuBellBossBar.ModCross;

internal class AAClassicCross : ModType
{
    private static Asset<Texture2D> GetTexture(string name) => ModContent.Request<Texture2D>(_path + name, AssetRequestMode.ImmediateLoad);

    private static readonly string _path = "YuBellBossBar/Texture/ExtraAAClassic/";

#pragma warning disable CS0414
    private static int CripOfChaosMireType = -1;
    private static NPC CripOfChaosMire = null;
    private static int CripOfChaosInfernoType = -1;
    private static NPC CripOfChaosInferno = null;

    public override void SetupContent()
    {
        if (ModLoader.TryGetMod("AAModClassic", out Mod AAClassic) && BarConfig.Instance.EnableExtraAAClassic)
        {
            Mod yabhb = ModLoader.GetMod("YuBellBossBar");

            // index||Asset<Texture2D>||fillCutLengh = 0||fillOffset = Vector2.Zero||headOffset = Vector2.Zero
            // BarFillStyles = barFillStyles.None
            // barFillColor = BarFillColor.Vanilla||fillColor = Color.White||barFrameStyles = BarFrameStyles.None
            // framecount||TPF||customdraw = null||shieldcolor = null

            // Head:index||Asset<Texture2D>||fillOffset = Vector2.Zero||headOffset = Vector2.Zero
            // framecount||TPF||customdraw = null||shieldcolor = null

            // Frame:index||Asset<Texture2D>||barFrameStyles = BarFrameStyles.None
            // framecount||TPF||customdraw = null||shieldcolor = null

            // Tail:index||Asset<Texture2D>||fillOffset = Vector2.Zero
            // framecount||TPF||customdraw = null||shieldcolor = null

            // Fill:index||Asset<Texture2D>||fillCutLengh||BarFillStyles = barFillStyles.None||barFillColor = BarFillColor.Vanilla||fillColor = Color.White
            // framecount||TPF||customdraw = null||shieldcolor = null

            #region 赤孢皇
            var MBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-MBarHead", GetTexture("MBarHead"), new Vector2(62, 16), new Vector2(52, 30), null);
            var MBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-MBarBody", GetTexture("MBarBody"), "Extend", null);
            var MBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-MBarTail", GetTexture("MBarTail"), new Vector2(30, 12), null);
            var MBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-MBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Firebrick, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("MushroomMonarch").Type, new List<object> { MBarHead, MBarBody, MBarTail, MBarFill }, null, null, null);
            #endregion

            #region 真菌帝
            var FBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-FBarHead", GetTexture("FBarHead"), new Vector2(50, 16), new Vector2(40, 30), null);
            var FBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-FBarBody", GetTexture("FBarBody"), "Extend", null);
            var FBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-FBarTail", GetTexture("FBarTail"), new Vector2(30, 12), null);
            var FBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-FBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.DarkCyan, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("FeudalFungus").Type, new List<object> { FBarHead, FBarBody, FBarTail, FBarFill }, null, null, null);
            #endregion

            #region 燎狱爪
            var RGCBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-RGCBarHead", GetTexture("RGCBarHead"), new Vector2(54, 12), new Vector2(23, 26), 1, 6, null, null);
            var RGCBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-RGCBarBody", GetTexture("RGCBarBody"), "Extend", 1, 6, null, null);
            var RGCBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-RGCBarTail", GetTexture("RGCBarTail"), new Vector2(30, 10), 1, 6, null, null);
            var RGCBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-RGCBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.DarkOrange, 1, 6, null, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("GripOfChaosInferno").Type, new List<object> { RGCBarHead, RGCBarBody, RGCBarTail, RGCBarFill }, null, null, null);
            #endregion

            #region 潭渊爪
            var BGCBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-BGCBarHead", GetTexture("BGCBarHead"), new Vector2(54, 12), new Vector2(23, 26), null);
            var BGCBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-BGCBarTail", GetTexture("BGCBarTail"), new Vector2(30, 10), null);
            var BGCBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-BGCBarBody", GetTexture("BGCBarBody"), "Extend", null);
            var BGCBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-BGCBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Indigo,null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("GripOfChaosMire").Type, new List<object> { BGCBarHead, BGCBarBody, BGCBarTail, BGCBarFill }, null, null, null);
            #endregion

            #region 育母炎龙
            var BMBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-BMBarHead", GetTexture("BMBarHead"), new Vector2(64, 16), new Vector2(46, 30), null);
            var BMBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-BMBarTail", GetTexture("BMBarTail"), new Vector2(30, 10), null);
            var BMBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-BMBarBody", GetTexture("BMBarBody"), "Extend", null);
            var BMBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-BMBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.DarkOrange, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("Broodmother").Type, new List<object> { BMBarHead, BMBarBody, BMBarTail, BMBarFill }, null, null, null);
            #endregion

            #region 九头渊蛇
            var HydraBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-HydraBarHead", GetTexture("HydraBarHead"), new Vector2(56, 16), new Vector2(39, 30), null);
            var HydraBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-HydraBarTail", GetTexture("HydraBarTail"), new Vector2(30, 6), null);
            var HydraBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-HydraBarBody", GetTexture("HydraBarBody"), "Extend", null);
            var HydraBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-HydraBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Indigo, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("HydraBody").Type, new List<object> { HydraBarHead, HydraBarBody, HydraBarTail, HydraBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("HydraHead1").Type, new List<object> { HydraBarHead, HydraBarBody, HydraBarTail, HydraBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("HydraHead2").Type, new List<object> { HydraBarHead, HydraBarBody, HydraBarTail, HydraBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("HydraHead3").Type, new List<object> { HydraBarHead, HydraBarBody, HydraBarTail, HydraBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("HydraHead4").Type, new List<object> { HydraBarHead, HydraBarBody, HydraBarTail, HydraBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("HydraHead5").Type, new List<object> { HydraBarHead, HydraBarBody, HydraBarTail, HydraBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("HydraHead6").Type, new List<object> { HydraBarHead, HydraBarBody, HydraBarTail, HydraBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("HydraHead7").Type, new List<object> { HydraBarHead, HydraBarBody, HydraBarTail, HydraBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("HydraHead8").Type, new List<object> { HydraBarHead, HydraBarBody, HydraBarTail, HydraBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("HydraHead9").Type, new List<object> { HydraBarHead, HydraBarBody, HydraBarTail, HydraBarFill }, null, null, null);
            #endregion

            #region 绝零冰蛇
            var SSBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-SSBarHead", GetTexture("SSBarHead"), new Vector2(56, 14), new Vector2(28, 29), null);
            var SSBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-SSBarTail", GetTexture("SSBarTail"), new Vector2(30, 6), null);
            var SSBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-SSBarBody", GetTexture("SSBarBody"), "Extend", null);
            var SSBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-SSBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Cyan, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("SubzeroSerpentHead").Type, new List<object> { SSBarHead, SSBarBody, SSBarTail, SSBarFill }, null, null, null);
            #endregion

            #region 沙漠巨灵
            var DDBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-DDBarHead", GetTexture("DDBarHead"), new Vector2(50, 10), new Vector2(26, 24), null);
            var DDBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-DDBarTail", GetTexture("DDBarTail"), new Vector2(30, 8), null);
            var DDBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-DDBarBody", GetTexture("DDBarBody"), "Extend", null);
            var DDBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-DDBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.IndianRed, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("DesertDjinn").Type, new List<object> { DDBarHead, DDBarBody, DDBarTail, DDBarFill }, null, null, null);
            #endregion

            #region 射手座-虚空人马
            var SagBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-SagBarHead", GetTexture("SagBarHead"), new Vector2(40, 6), new Vector2(16, 20), null);
            var SagBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-SagBarTail", GetTexture("SagBarTail"), new Vector2(30, 6), null);
            var SagBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-SagBarBody", GetTexture("SagBarBody"), "Extend", null);
            var SagBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-SagBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Red, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("Sagittarius").Type, new List<object> { SagBarHead, SagBarBody, SagBarTail, SagBarFill }, null, null, null);
            #endregion

            #region 阿努比斯 史诗记述者
            var AnuBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-AnuBarHead", GetTexture("AnuBarHead"), new Vector2(44, 16), new Vector2(26, 29), null);
            var AnuBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-AnuBarTail", GetTexture("AnuBarTail"), new Vector2(20, 8), null);
            var AnuBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-AnuBarBody", GetTexture("AnuBarBody"), "Extend", null);
            var AnuBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-AnuBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Cyan, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("Anubis").Type, new List<object> { AnuBarHead, AnuBarBody, AnuBarTail, AnuBarFill }, null, null, null);
            #endregion

            #region 金食饕餮
            var GreedBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-GreedBarHead", GetTexture("GreedBarHead"), new Vector2(64, 16), new Vector2(30, 28), null);
            var GreedBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-GreedBarTail", GetTexture("GreedBarTail"), new Vector2(20, 10), null);
            var GreedBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-GreedBarBody", GetTexture("GreedBarBody"), "Dulplicate", null);
            var GreedBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-GreedBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Goldenrod, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("GreedHead").Type, new List<object> { GreedBarHead, GreedBarBody, GreedBarTail, GreedBarFill }, null, null, null);
            #endregion

            #region 巨兔王公
            var RajahBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-RajahBarHead", GetTexture("RajahBarHead"), new Vector2(94, 16), new Vector2(77, 30), null);
            var RajahBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-RajahBarTail", GetTexture("RajahBarTail"), new Vector2(30, 12), null);
            var RajahBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-RajahBarBody", GetTexture("RajahBarBody"), "Extend", null);
            var RajahBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-RajahBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Orange, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("RajahRabbit").Type, new List<object> { RajahBarHead, RajahBarBody, RajahBarTail, RajahBarFill }, null, null, null);
            #endregion

            #region 觉醒之阿努比斯 逝落的断罪师
            var FAnuBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-FAnuBarHead", GetTexture("FAnuBarHead"), new Vector2(44, 16), new Vector2(26, 29), null);
            var FAnuBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-FAnuBarTail", GetTexture("FAnuBarTail"), new Vector2(20, 8), null);
            var FAnuBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-FAnuBarBody", GetTexture("FAnuBarBody"), "Extend", null);
            var FAnuBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-FAnuBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.MediumAquamarine, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("AnubisA").Type, new List<object> { FAnuBarHead, FAnuBarBody, FAnuBarTail, FAnuBarFill }, null, null, null);
            #endregion

            #region 白昼启明虫 戴布林格
            var DBBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-DBBarHead", GetTexture("DBBarHead"), new Vector2(70, 16), new Vector2(45, 31), null);
            var DBBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-DBBarTail", GetTexture("DBBarTail"), new Vector2(32, 6), null);
            var DBBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-DBBarBody", GetTexture("DBBarBody"), "Extend", null);
            var DBBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-DBBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Cyan, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("DaybringerHead").Type, new List<object> { DBBarHead, DBBarBody, DBBarTail, DBBarFill }, null, null, null);
            #endregion

            #region 黑夜爬行虫 奈克劳尔
            var NCBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-NCBarHead", GetTexture("NCBarHead"), new Vector2(70, 16), new Vector2(45, 31), null);
            var NCBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-NCBarTail", GetTexture("NCBarTail"), new Vector2(32, 6), null);
            var NCBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-NCBarBody", GetTexture("NCBarBody"), "Extend", null);
            var NCBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-NCBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.MediumBlue, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("NightcrawlerHead").Type, new List<object> { NCBarHead, NCBarBody, NCBarTail, NCBarFill }, null, null, null);
            #endregion

            #region 潭渊妖女 八歧遥香
            var HarukaBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-HarukaBarHead", GetTexture("HarukaBarHead"), new Vector2(44, 16), new Vector2(18, 28), null);
            var HarukaBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-HarukaBarTail", GetTexture("HarukaBarTail"), new Vector2(30, 6), null);
            var HarukaBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-HarukaBarBody", GetTexture("HarukaBarBody"), "Extend", null);
            var HarukaBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-HarukaBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", new Color(122, 157, 152), null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("Haruka").Type, new List<object> { HarukaBarHead, HarukaBarBody, HarukaBarTail, HarukaBarFill }, null, null, null);
            #endregion

            #region 觉醒潭渊妖女 震惧之八歧遥香
            var HarukaBar2Head = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-HarukaBar2Head", GetTexture("HarukaBar2Head"), new Vector2(22, 6), new Vector2(9, 12), null);
            var HarukaBar2Tail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-HarukaBar2Tail", GetTexture("HarukaBar2Tail"), new Vector2(0, 6), null);
            var HarukaBar2Body = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-HarukaBar2Body", GetTexture("HarukaBar2Body"), "Extend", null);
            var HarukaBar2Fill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-HarukaBar2Fill", ModContent.Request<Texture2D>("YuBellBossBar/Texture/DefaultTexture/SmallBarFill",AssetRequestMode.ImmediateLoad), 4, "FillExtend", "Custom", new Color(122, 157, 152), null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("WrathHaruka").Type, new List<object> { HarukaBar2Head, HarukaBar2Body, HarukaBar2Tail, HarukaBar2Fill }, null, null, null);
            #endregion

            #region 燎狱魔女 邪鬼艾希
            var AsheBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-AsheBarHead", GetTexture("AsheBarHead"), new Vector2(26, 16), new Vector2(13, 30), null);
            var AsheBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-AsheBarTail", GetTexture("AsheBarTail"), new Vector2(28, 16), null);
            var AsheBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-AsheBarBody", GetTexture("AsheBarBody"), "Extend", null);
            var AsheBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-AsheBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.OrangeRed, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("Ashe").Type, new List<object> { AsheBarHead, AsheBarBody, AsheBarTail, AsheBarFill }, null, null, null);
            #endregion

            #region 觉醒燎狱魔女 凶怒之邪鬼艾希
            var AsheBar2Head = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-AsheBar2Head", GetTexture("AsheBar2Head"), new Vector2(30, 6), new Vector2(20, 12), null);
            var AsheBar2Tail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-AsheBar2Tail", GetTexture("AsheBar2Tail"), new Vector2(0, 6), null);
            var AsheBar2Body = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-AsheBar2Body", GetTexture("AsheBar2Body"), "Extend", null);
            var AsheBar2Fill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-AsheBar2Fill", ModContent.Request<Texture2D>("YuBellBossBar/Texture/DefaultTexture/SmallBarFill", AssetRequestMode.ImmediateLoad), 4, "FillExtend", "Custom", Color.OrangeRed, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("FuryAshe").Type, new List<object> { AsheBar2Head, AsheBar2Body, AsheBar2Tail, AsheBar2Fill }, null, null, null);
            #endregion

            #region 远古之八歧大蛇 惊惧梦魇
            var YamataBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-" + "Yamata" + "BarHead", GetTexture("Yamata"+"BarHead"), new Vector2(72, 16), new Vector2(55, 31), null);
            var YamataBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-"+ "Yamata" + "BarTail", GetTexture("Yamata"+"BarTail"), new Vector2(30, 6), null);
            var YamataBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-" + "Yamata" + "BarBody", GetTexture("Yamata"+"BarBody"), "Extend", null);
            var YamataBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-" + "Yamata" + "BarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Purple, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("YamataHead").Type, new List<object> { YamataBarHead, YamataBarBody, YamataBarTail, YamataBarFill }, null, null, null);
            #endregion

            #region 觉醒之八歧大蛇 八俣远吕智
            var YamataABarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-" + "YamataA" + "BarHead", GetTexture("YamataA" + "BarHead"), new Vector2(72, 16), new Vector2(55, 31), null);
            var YamataABarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-" + "YamataA" + "BarTail", GetTexture("YamataA" + "BarTail"), new Vector2(30, 6), null);
            var YamataABarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-" + "YamataA" + "BarBody", GetTexture("YamataA" + "BarBody"), "Extend", null);
            var YamataABarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-" + "YamataA" + "BarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.MediumVioletRed, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("YamataAHead").Type, new List<object> { YamataABarHead, YamataABarBody, YamataABarTail, YamataABarFill }, null, null, null);
            #endregion

            #region 远古之邪鬼巨龙 凶煞恶魔
            var AkumaBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-" + "Akuma" + "BarHead", GetTexture("Akuma" + "BarHead"), new Vector2(72, 14), new Vector2(42, 28), null);
            var AkumaBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-" + "Akuma" + "BarTail", GetTexture("Akuma" + "BarTail"), new Vector2(30, 6), null);
            var AkumaBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-" + "Akuma" + "BarBody", GetTexture("Akuma" + "BarBody"), "Extend", null);
            var AkumaBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-" + "Akuma" + "BarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Yellow, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("AkumaHead").Type, new List<object> { AkumaBarHead, AkumaBarBody, AkumaBarTail, AkumaBarFill }, null, null, null);
            #endregion

            #region 觉醒之邪鬼巨龙 狂煞魔豪鬼
            var AkumaABarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-" + "AkumaA" + "BarHead", GetTexture("AkumaA" + "BarHead"), new Vector2(72, 14), new Vector2(42, 28), null);
            var AkumaABarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-" + "AkumaA" + "BarTail", GetTexture("AkumaA" + "BarTail"), new Vector2(30, 6), null);
            var AkumaABarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-" + "AkumaA" + "BarBody", GetTexture("Akuma" + "BarBody"), "Extend", null);
            var AkumaABarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-" + "AkumaA" + "BarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.DeepSkyBlue, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("AkumaAHead").Type, new List<object> { AkumaABarHead, AkumaABarBody, AkumaABarTail, AkumaABarFill }, null, null, null);
            #endregion

            #region 零械单元 虚空之末日结构
            var ZeroBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-" + "Zero" + "BarHead", GetTexture("Zero" + "BarHead"), new Vector2(68, 14), new Vector2(45, 27), null);
            var ZeroBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-" + "Zero" + "BarTail", GetTexture("Zero" + "BarTail"), new Vector2(30, 8), null);
            var ZeroBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-" + "Zero" + "BarBody", GetTexture("Zero" + "BarBody"), "Extend", null);
            var ZeroBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-" + "Zero" + "BarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Red, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("Zero").Type, new List<object> { ZeroBarHead, ZeroBarBody, ZeroBarTail, ZeroBarFill }, null, null, null);
            #endregion

            #region 零械汇编器 零.之.始.约.协.议
            var ZeroABarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-" + "ZeroA" + "BarHead", GetTexture("ZeroA" + "BarHead"), new Vector2(68, 15), new Vector2(45, 28), null);
            var ZeroABarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-" + "ZeroA" + "BarTail", GetTexture("ZeroA" + "BarTail"), new Vector2(30, 8), null);
            var ZeroABarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-" + "ZeroA" + "BarBody", GetTexture("Zero" + "BarBody"), "Extend", null);
            var ZeroABarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-" + "ZeroA" + "BarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Red, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("ZeroA").Type, new List<object> { ZeroABarHead, ZeroABarBody, ZeroABarTail, ZeroABarFill }, null, null, null);
            #endregion

            #region 至尊巨兔王公 无辜的保护者
            var SRajahBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-" + "SRajah" + "BarHead", GetTexture("SRajah" + "BarHead"), new Vector2(30, 6), new Vector2(15, 20), null);
            var SRajahBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-" + "SRajah" + "BarTail", GetTexture("SRajah" + "BarTail"), new Vector2(30, 6), null);
            var SRajahBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-" + "SRajah" + "BarBody", GetTexture("SRajah" + "BarBody"), "Extend", null);
            var SRajahBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-" + "SRajah" + "BarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Gold, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("RajahRabbitA").Type, new List<object> { SRajahBarHead, SRajahBarBody, SRajahBarTail, SRajahBarFill }, null, null, null);
            #endregion

            #region 上神应龙 冥昧末日的预言者
            var ShenBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-" + "Shen" + "BarHead", GetTexture("Shen" + "BarHead"), new Vector2(40, 16), new Vector2(26, 36), null);
            var ShenBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-" + "Shen" + "BarTail", GetTexture("Shen" + "BarTail"), new Vector2(32, 6), null);
            var ShenBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-" + "Shen" + "BarBody", GetTexture("Shen" + "BarBody"), "Extend", null);
            var ShenBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-" + "Shen" + "BarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Purple, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("ShenDoragon").Type, new List<object> { ShenBarHead, ShenBarBody, ShenBarTail, ShenBarFill }, null, null, null);
            #endregion

            #region 觉醒之上神应龙 冥昭瞢暗的化身
            var ShenABarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-" + "ShenA" + "BarHead", GetTexture("ShenA" + "BarHead"), new Vector2(48, 22), new Vector2(26, 36), null);
            var ShenABarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-" + "ShenA" + "BarTail", GetTexture("ShenA" + "BarTail"), new Vector2(30, 6), null);
            var ShenABarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-" + "ShenA" + "BarBody", GetTexture("ShenA" + "BarBody"), "Extend", null);
            var ShenABarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-" + "ShenA" + "BarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Purple, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("ShenDoragonA").Type, new List<object> { ShenABarHead, ShenABarBody, ShenABarTail, ShenABarFill }, null, null, null);
            #endregion

            #region 上神狱怒之爪
            var BGBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-BGBarHead", GetTexture("BGBarHead"), new Vector2(54, 12), new Vector2(23, 26), 1, 6, null, null);
            var BGBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-BGBarBody", GetTexture("BGBarBody"), "Extend", 1, 6, null, null);
            var BGBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-BGBarTail", GetTexture("BGBarTail"), new Vector2(30, 10), 1, 6, null, null);
            var BGBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-BGBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.DarkOrange, 1, 6, null, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("BlazeGrip").Type, new List<object> { BGBarHead, BGBarBody, BGBarTail, BGBarFill }, null, null, null);
            #endregion

            #region 上神渊惧之爪
            var AGBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-AGBarHead", GetTexture("AGBarHead"), new Vector2(54, 12), new Vector2(23, 26), 1, 6, null, null);
            var AGBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-AGBarBody", GetTexture("AGBarBody"), "Extend", 1, 6, null, null);
            var AGBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-AGBarTail", GetTexture("AGBarTail"), new Vector2(30, 10), 1, 6, null, null);
            var AGBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-AGBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Indigo, 1, 6, null, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("AbyssGrip").Type, new List<object> { AGBarHead, AGBarBody, AGBarTail, AGBarFill }, null, null, null);
            #endregion

            #region 无限零 机械恶意
            var InfinityZeroBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-" + "InfinityZero" + "BarHead", GetTexture("InfinteZeroHead"), new Vector2(44, 20), new Vector2(25, 35), null);
            var InfinityZeroBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-" + "InfinityZero" + "BarTail", GetTexture("InfinteZero" + "Tail"), new Vector2(12, 16), null);
            var InfinityZeroBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-" + "InfinityZero" + "BarBody", GetTexture("InfinteZero" + "Body"), "Dulplicate", null);
            var InfinityZeroBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-" + "InfinityZero" + "BarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Red, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("InfinityZero").Type, new List<object> { InfinityZeroBarHead, InfinityZeroBarBody, InfinityZeroBarTail, InfinityZeroBarFill }, null, null, null);
            #endregion

            #region 克苏鲁相关
            var CthulhuBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-" + "Cthulhu" + "BarHead", GetTexture("Cthulhu" + "Head"), new Vector2(52, 23), new Vector2(31, 37), null);
            var CthulhuBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-" + "Cthulhu" + "BarTail", GetTexture("Cthulhu" + "Tail"), new Vector2(14, 20), null);
            var CthulhuBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-" + "Cthulhu" + "BarBody", GetTexture("Cthulhu" + "Body"), "Dulplicate", null);
            var CthulhuBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-" + "Cthulhu" + "BarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Cyan, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("Cthulhu").Type, new List<object> { CthulhuBarHead, CthulhuBarBody, CthulhuBarTail, CthulhuBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("SoulOfCthulhu").Type, new List<object> { CthulhuBarHead, CthulhuBarBody, CthulhuBarTail, CthulhuBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("DeityBrain").Type, new List<object> { CthulhuBarHead, CthulhuBarBody, CthulhuBarTail, CthulhuBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("DeityEater").Type, new List<object> { CthulhuBarHead, CthulhuBarBody, CthulhuBarTail, CthulhuBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("DeityEye").Type, new List<object> { CthulhuBarHead, CthulhuBarBody, CthulhuBarTail, CthulhuBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("DeityLeviathan").Type, new List<object> { CthulhuBarHead, CthulhuBarBody, CthulhuBarTail, CthulhuBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("DeityRose").Type, new List<object> { CthulhuBarHead, CthulhuBarBody, CthulhuBarTail, CthulhuBarFill }, null, null, null);
            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("DeitySkull").Type, new List<object> { CthulhuBarHead, CthulhuBarBody, CthulhuBarTail, CthulhuBarFill }, null, null, null);
            #endregion

            #region 穹武鸮姬 雅典娜
            var AthenaBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-AthenaBarHead", GetTexture("AthenaBarHead"), new Vector2(28, 28), new Vector2(14, 37), null);
            var AthenaBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-AthenaBarBody", GetTexture("AthenaBarBody"), "Dulplicate", null);
            var AthenaBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-AthenaBarTail", GetTexture("AthenaBarTail"), new Vector2(20, 16), null);
            var AthenaBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-AthenaBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Silver, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("Athena").Type, new List<object> { AthenaBarHead, AthenaBarBody, AthenaBarTail, AthenaBarFill }, null, null, null);
            #endregion

            #region 觉醒之奥林匹亚女武神 雅典娜
            var AthenaABarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-AthenaABarHead", GetTexture("AthenaABarHead"), new Vector2(28, 28), new Vector2(14, 37), null);
            var AthenaABarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-AthenaABarBody", GetTexture("AthenaABarBody"), "Dulplicate", null);
            var AthenaABarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-AthenaABarTail", GetTexture("AthenaABarTail"), new Vector2(20, 16), null);
            var AthenaABarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-AthenaABarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Silver, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("AthenaA").Type, new List<object> { AthenaABarHead, AthenaABarBody, AthenaABarTail, AthenaABarFill }, null, null, null);
            #endregion

            #region 电子化-机械松露怪
            var TechnoTruffleBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-TechnoTruffleBarHead", GetTexture("TechnoTruffleBarHead"), new Vector2(38, 12), new Vector2(27, 26), null);
            var TechnoTruffleBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-TechnoTruffleBarBody", GetTexture("TechnoTruffleBarBody"), "Dulplicate", null);
            var TechnoTruffleBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-TechnoTruffleBarTail", GetTexture("TechnoTruffleBarTail"), new Vector2(10, 6), null);
            var TechnoTruffleBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-TechnoTruffleBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.MediumPurple, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("TechnoTruffle").Type, new List<object> { TechnoTruffleBarHead, TechnoTruffleBarBody, TechnoTruffleBarTail, TechnoTruffleBarFill }, null, null, null);
            #endregion

            #region 捕猎者-电子猎犬爪
            var RetrieverBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-RetrieverBarHead", GetTexture("RetrieverBarHead"), new Vector2(64, 14), new Vector2(53, 29), null);
            var RetrieverBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-RetrieverBarBody", GetTexture("RetrieverBarBody"), "Dulplicate", null);
            var RetrieverBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-RetrieverBarTail", GetTexture("RetrieverBarTail"), new Vector2(4, 6), null);
            var RetrieverBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-RetrieverBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.MediumPurple, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("Retriever").Type, new List<object> { RetrieverBarHead, RetrieverBarBody, RetrieverBarTail, RetrieverBarFill }, null, null, null);
            #endregion

            #region 食腐者-双头狗俄耳托斯X型
            var OrthrusXBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-OrthrusXBarHead", GetTexture("OrthrusXBarHead"), new Vector2(40, 10), new Vector2(25, 23), null);
            var OrthrusXBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-OrthrusXBarBody", GetTexture("OrthrusXBarBody"), "Extend", null);
            var OrthrusXBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-OrthrusXBarTail", GetTexture("OrthrusXBarTail"), new Vector2(16, 6), null);
            var OrthrusXBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-OrthrusXBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.MediumPurple, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("OrthrusXBody").Type, new List<object> { OrthrusXBarHead, OrthrusXBarBody, OrthrusXBarTail, OrthrusXBarFill }, null, null, null);
            #endregion

            #region 侵入者-创世哺育之母
            var RaiderUltimaBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-RaiderUltimaBarHead", GetTexture("RaiderUltimaBarHead"), new Vector2(54, 8), new Vector2(41, 21), null);
            var RaiderUltimaBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-RaiderUltimaBarBody", GetTexture("RaiderUltimaBarBody"), "Extend", null);
            var RaiderUltimaBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-RaiderUltimaBarTail", GetTexture("RaiderUltimaBarTail"), new Vector2(22, 10), null);
            var RaiderUltimaBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-RaiderUltimaBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.MediumPurple, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("RaiderUltima").Type, new List<object> { RaiderUltimaBarHead, RaiderUltimaBarBody, RaiderUltimaBarTail, RaiderUltimaBarFill }, null, null, null);
            #endregion

            #region 环境原核
            var BiomiteCoreBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-BiomiteCoreBarHead", GetTexture("BiomiteCoreBarHead"), new Vector2(50, 12), new Vector2(27, 26), null);
            var BiomiteCoreBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-BiomiteCoreBarBody", GetTexture("BiomiteCoreBarBody"), "Extend", null);
            var BiomiteCoreBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-BiomiteCoreBarTail", GetTexture("BiomiteCoreBarTail"), new Vector2(22, 6), null);
            var BiomiteCoreBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-BiomiteCoreBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.LightGreen, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("BiomiteCore").Type, new List<object> { BiomiteCoreBarHead, BiomiteCoreBarBody, BiomiteCoreBarTail, BiomiteCoreBarFill }, null, null, null);
            #endregion

            #region 松露蟾蜍
            var TruffleToadBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-TruffleToadBarHead", GetTexture("TruffleToadBarHead"), new Vector2(58, 18), new Vector2(36, 32), null);
            var TruffleToadBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-TruffleToadBarBody", GetTexture("TruffleToadBarBody"), "Extend", null);
            var TruffleToadBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-TruffleToadBarTail", GetTexture("TruffleToadBarTail"), new Vector2(6, 18), null);
            var TruffleToadBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-TruffleToadBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.DarkCyan, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", AAClassic.Find<ModNPC>("TruffleToad").Type, new List<object> { TruffleToadBarHead, TruffleToadBarBody, TruffleToadBarTail, TruffleToadBarFill }, null, null, null);
            #endregion
        }
    }

    protected override void Register() { }
}

