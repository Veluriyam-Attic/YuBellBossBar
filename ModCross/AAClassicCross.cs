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
        if (ModLoader.TryGetMod("AAModClassic", out Mod AAClassic))
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
            CripOfChaosInfernoType = AAClassic.Find<ModNPC>("GripOfChaosInferno").Type;

            var RGCBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-RGCBarHead", GetTexture("RGCBarHead"), new Vector2(54, 12), new Vector2(23, 26), 1, 6, null, null);
            var RGCBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-RGCBarBody", GetTexture("RGCBarBody"), "Extend", 1, 6, null, null);
            var RGCBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-RGCBarTail", GetTexture("RGCBarTail"), new Vector2(30, 10), 1, 6, null, null);
            var RGCBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-RGCBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.DarkOrange, 1, 6, null, null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", CripOfChaosInfernoType, new List<object> { RGCBarHead, RGCBarBody, RGCBarTail, RGCBarFill }, null, null, null);
            #endregion

            #region 潭渊爪
            CripOfChaosMireType = AAClassic.Find<ModNPC>("GripOfChaosMire").Type;

            var BGCBarHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "AAC-BGCBarHead", GetTexture("BGCBarHead"), new Vector2(54, 12), new Vector2(23, 26), 1, 6,
                new Func<SpriteBatch, Vector2, int, int, int, float, float, NPC, BossBarDrawParams, Texture2D, Vector2>((spriteBatch, position, BarLength, life, lifemax, percentage, GlobalAlpha, npc, drawParams, bt) =>
                {
                    BarDrawsMethods.StandardDrawHead(spriteBatch, position, life, lifemax, percentage, GlobalAlpha, npc, drawParams);

                    //if (CripOfChaosInferno != null)
                    //{
                    //    BarDrawsMethods.StandardDrawHead(spriteBatch, new Vector2(position.X, position.Y + 85), CripOfChaosInferno.life, CripOfChaosInferno.lifeMax, CripOfChaosInferno.life / CripOfChaosInferno.lifeMax, GlobalAlpha, CripOfChaosInferno, drawParams);
                    //}

                    return Vector2.Zero;
                }), null);
            var BGCBarTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "AAC-BGCBarTail", GetTexture("BGCBarTail"), new Vector2(30, 10), 1, 6,
                new Func<SpriteBatch, Vector2, int, int, int, float, float, NPC, BossBarDrawParams, Texture2D, Vector2>((spriteBatch, position, BarLength, life, lifemax, percentage, GlobalAlpha, npc, drawParams, bt) =>
                {
                    BarDrawsMethods.StandardDrawTail(spriteBatch, position, life, lifemax, percentage, GlobalAlpha, npc, drawParams);

                    //if (CripOfChaosInferno != null)
                    //{
                    //    BarDrawsMethods.StandardDrawTail(spriteBatch, new Vector2(position.X, position.Y + 85), CripOfChaosInferno.life, CripOfChaosInferno.lifeMax, CripOfChaosInferno.life / CripOfChaosInferno.lifeMax, GlobalAlpha, CripOfChaosInferno, drawParams);
                    //}

                    return Vector2.Zero;
                }), null);
            var BGCBarBody = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "AAC-BGCBarBody", GetTexture("BGCBarBody"), "Extend", 1, 6,
                new Func<SpriteBatch, Vector2, int, int, int, float, float, NPC, BossBarDrawParams, Texture2D, Vector2>((spriteBatch, position, BarLength, life, lifemax, percentage, GlobalAlpha, npc, drawParams, bt) =>
                {
                    BarDrawsMethods.StandardDrawFrame(spriteBatch, position, life, lifemax, percentage, GlobalAlpha, npc, drawParams);

                    //if (CripOfChaosInferno != null)
                    //{
                    //    BarDrawsMethods.StandardDrawFrame(spriteBatch, new Vector2(position.X, position.Y + 85), CripOfChaosInferno.life, CripOfChaosInferno.lifeMax, CripOfChaosInferno.life / CripOfChaosInferno.lifeMax, GlobalAlpha, CripOfChaosInferno, drawParams);
                    //}

                    return Vector2.Zero;
                }), null);
            var BGCBarFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "AAC-BGCBarFill", GetTexture("BarFill"), 16, "FillExtend", "Custom", Color.Indigo, 1, 6,
                new Func<SpriteBatch, Vector2, int, int, int, float, float, NPC, BossBarDrawParams, Texture2D, Vector2>((spriteBatch, position, BarLength, life, lifemax, percentage, GlobalAlpha, npc, drawParams, bt) =>
                {
                    float postpercentage = PostHealthSystem.GetPostHealth(npc.whoAmI, percentage);
                    int lengthNow = (int)(percentage * BarConfig.Instance.BarLength);
                    int lengthPost = (int)(postpercentage * BarConfig.Instance.BarLength);
                    float shieldpercentage = drawParams.Shield / drawParams.ShieldMax;
                    int shieldlength = (int)(BarConfig.Instance.BarLength * shieldpercentage);

                    BarDrawsMethods.StandardDrawFill(spriteBatch, position, life, lifemax, percentage, GlobalAlpha, npc, drawParams,
                        lengthPost, lengthNow, postpercentage, shieldlength);
                    foreach (var item in Main.npc)
                    {
                        if (item.type == CripOfChaosInfernoType)
                        {
                            //CripOfChaosInferno = item;
                            //float _percentage = item.life / item.lifeMax;
                            //float _postpercentage = PostHealthSystem.GetPostHealth(item.whoAmI, _percentage);
                            //int _lengthNow = (int)(_percentage * BarLength);
                            //int _lengthPost = (int)(postpercentage * BarLength);
                            //float _shieldpercentage = drawParams.Shield / drawParams.ShieldMax;
                            //int _shieldlength = (int)(BarLength * shieldpercentage);

                            //BarDrawsMethods.StandardDrawFill(spriteBatch, position, item.life, item.lifeMax, _percentage, GlobalAlpha, item, drawParams,
                            //    _lengthPost, _lengthNow, _postpercentage, _shieldlength);
                            //break;

                            BarDrawsMethods.Draw(spriteBatch, item, new BossBarDrawParams(null, Vector2.Zero, null, Rectangle.Empty, Color.White, item.life, item.lifeMax, null), new Vector2(position.X, position.Y + 85));
                        }
                        else
                        {
                            CripOfChaosInferno = null;
                        }
                    }
                    return Vector2.Zero;
                }), null);

            yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", CripOfChaosMireType, new List<object> { BGCBarHead, BGCBarBody, BGCBarTail, BGCBarFill }, null, null, null);
            #endregion
        }
    }

    protected override void Register() { }
}

