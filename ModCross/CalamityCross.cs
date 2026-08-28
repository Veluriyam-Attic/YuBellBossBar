namespace YuBellBossBar.ModCross;

internal class CalamityCloneAdapt : ModType
{
    private static Asset<Texture2D> GetTexture(string path) => ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/"+path,AssetRequestMode.ImmediateLoad);

    private static int CatastropheType = -1;
    private static int CataclysmType = -1;

    public override void SetupContent()
    {
        if (ModLoader.TryGetMod("CalamityMod", out calamity))
        {
            Mod yabhb = ModLoader.GetMod("YuBellBossBar");

            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", calamity.Find<ModNPC>("SlimeGodCore").Type, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", calamity.Find<ModNPC>("RavagerBody").Type, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemHead, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemHeadFree, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemFistLeft, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemFistRight, false);

            if (!ModLoader.HasMod("InfernumMode"))
            {
                CatastropheType = calamity.Find<ModNPC>("Catastrophe").Type;
                CataclysmType = calamity.Find<ModNPC>("Cataclysm").Type;


                // index||TextureType||Asset<Texture2D>||fillCutLengh = 0||fillOffset = Vector2.Zero||headOffset = Vector2.Zero
                // BarFillStyles = barFillStyles.None
                // barFillColor = BarFillColor.Vanilla||fillColor = Color.White||barFrameStyles = BarFrameStyles.None
                // framecount||TPF||customdraw = null||shieldcolor = null

                #region 普灾
                #region 普灾Head
                var CalamitasCloneHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head",
                    "CM-普灾Head",
                    ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/普灾Head", AssetRequestMode.ImmediateLoad),
                    new Vector2(54, 12),
                    new Vector2(25, 26),
                    1,
                    6,
                    DrawHead,
                    null);
                #endregion

                #region 普灾Frame
                var CalamitasCloneFrame = yabhb.Call("YetAnotherModCall", "Add", "Add Frame",
                    "CM-普灾Frame",
                    ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/普灾Frame", AssetRequestMode.ImmediateLoad),
                    "Dulplicate",
                    1,
                    6,
                    DrawFrame,
                    null);
                #endregion

                #region 普灾Tail
                var CalamitasCloneTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail",
                    "CM-普灾Tail",
                    ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/普灾Tail", AssetRequestMode.ImmediateLoad),
                    new Vector2(36, 16),
                    1,
                    6,
                    DrawTail,
                    null);
                #endregion

                #region 普灾Fill
                var CalamitasCloneFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill",
                    "CM-普灾Fill",
                    ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/普灾Fill", AssetRequestMode.ImmediateLoad),
                    0,
                    "Dulplicate",
                    "Custom",
                    Color.White,
                    1,
                    6,
                    DrawFill,
                    null);
                #endregion

                #region 普灾Icon
                var CalamitasCloneIcon = yabhb.Call("YetAnotherModCall", "Add", "Add Icon",
                    "CM-普灾Icon",
                    ModContent.Request<Texture2D>("CalamityMod/NPCs/CalClone/CalamitasClone_Head_Boss", AssetRequestMode.ImmediateLoad),
                    1,
                    6,
                    DrawIcon,
                    null);
                #endregion

                yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", calamity.Find<ModNPC>("CalamitasClone").Type, new List<object> { CalamitasCloneHead, CalamitasCloneFrame, CalamitasCloneTail, CalamitasCloneFill, CalamitasCloneIcon }, DrawText, null, new List<int> { calamity.Find<ModNPC>("SoulSeeker").Type });
                #endregion

                #region 灾难构造体
                var 灾难构造体Head = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "CM-灾难构造体Head", GetTexture("普灾/灾难构造体Head"), new Vector2(32, 16), new Vector2(20, 28), null);
                var 灾难构造体Body = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "CM-灾难构造体Frame", GetTexture("普灾/灾难构造体Frame"), "Dulplicate", null);
                var 灾难构造体Tail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "CM-灾难构造体Tail", GetTexture("普灾/灾难构造体Tail"), new Vector2(8, 10), null);
                var 灾难构造体Fill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "CM-灾难构造体Fill", GetTexture("普灾/灾难灾祸Fill"), 8, "FillExtend", "Custom",Color.White, null);

                yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", calamity.Find<ModNPC>("Catastrophe").Type, new List<object> { 灾难构造体Head, 灾难构造体Body, 灾难构造体Tail, 灾难构造体Fill }, null, null, null);
                #endregion

                #region 灾祸构造体
                var 灾祸构造体Head = yabhb.Call("YetAnotherModCall", "Add", "Add Head", "CM-灾祸构造体Head", GetTexture("普灾/灾祸构造体Head"), new Vector2(46, 11), new Vector2(23, 24), null);
                var 灾祸构造体Body = yabhb.Call("YetAnotherModCall", "Add", "Add Frame", "CM-灾祸构造体Frame", GetTexture("普灾/灾祸构造体Frame"), "Dulplicate", null);
                var 灾祸构造体Tail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail", "CM-灾祸构造体Tail", GetTexture("普灾/灾祸构造体Tail"), new Vector2(8, 10), null);
                var 灾祸构造体Fill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill", "CM-灾祸构造体Fill", GetTexture("普灾/灾难灾祸Fill"), 8, "FillExtend", "Custom", Color.White, null);

                yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", calamity.Find<ModNPC>("Cataclysm").Type, new List<object> { 灾祸构造体Head, 灾祸构造体Body, 灾祸构造体Tail, 灾祸构造体Fill }, null, null, null);
                #endregion
            }
        }
    }

    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");

    private static Mod calamity;

    private static FieldInfo catastropheField;
    private static FieldInfo cataclysmField;
    private static Type calamityGlobalNPCType;
    private static MethodInfo aiMethod;

    private static bool BrotherAlive = false;
    private static float CalCloneAI3 = 0;
    private static float CalCloneAI2 = 0;

    public override void Load()
    {
        IL_GetBrotherAlive();
        IL_GetNewAI_23();
    }

    #region IL Modifies
    private static void IL_GetBrotherAlive()
    {
        if (!ModLoader.TryGetMod("CalamityMod", out Mod calamity))
            return;

        Type calamitasCloneType = calamity.Code.GetType("CalamityMod.NPCs.CalClone.CalamitasClone");
        calamityGlobalNPCType = calamity.Code.GetType("CalamityMod.NPCs.CalamityGlobalNPC");

        if (calamitasCloneType == null || calamityGlobalNPCType == null)
            return;

        aiMethod = calamitasCloneType.GetMethod("AI", BindingFlags.Public | BindingFlags.Instance);
        catastropheField = calamityGlobalNPCType.GetField("catastrophe");
        cataclysmField = calamityGlobalNPCType.GetField("cataclysm");
        FieldInfo mainNpcField = typeof(Main).GetField("npc");
        FieldInfo npcActiveField = typeof(NPC).GetField("active");

        if (aiMethod == null || catastropheField == null || mainNpcField == null || npcActiveField == null)
            return;

        MonoModHooks.Modify(aiMethod, il =>
        {
            ILCursor cursor = new ILCursor(il);
            int brotherAliveIndex = -1;

            if (cursor.TryGotoNext(MoveType.After,
                i => i.MatchLdsfld(catastropheField),
                i => i.MatchLdcI4(-1),
                i => i.MatchBeq(out _),
                i => i.MatchLdsfld(mainNpcField),
                i => i.MatchLdsfld(catastropheField),
                i => i.MatchLdelemRef(),
                i => i.MatchLdfld(npcActiveField),
                i => i.MatchBrfalse(out _),
                i => i.MatchLdcI4(1),
                i => i.MatchStloc(out brotherAliveIndex)
            ))
            {
                cursor.Index++;

                cursor.Emit(OpCodes.Dup);
                cursor.EmitDelegate<Action<bool>>(brotherAlive =>
                {
                    BrotherAlive = brotherAlive;
                });
            }

        });
    }

    private static void IL_GetNewAI_23()
    {
        MonoModHooks.Modify(aiMethod, il =>
        {
            ILCursor cursor = new(il);

            FieldInfo newAIField = calamityGlobalNPCType.GetField("newAI");

            if (cursor.TryGotoNext(
                MoveType.After,
                i => i.MatchLdloc(0),
                i => i.MatchLdfld(newAIField),
                i => i.MatchLdcI4(2),
                i => i.MatchLdelemR4()
            ))
            {
                cursor.Emit(OpCodes.Dup);

                cursor.EmitDelegate<Action<float>>(value =>
                {
                    CalCloneAI2 = value;
                });
            }


            if (cursor.TryGotoNext(
                MoveType.After,
                i => i.MatchLdloc(0),
                i => i.MatchLdfld(newAIField),
                i => i.MatchLdcI4(3),
                i => i.MatchLdelema<float>(),
                i => i.MatchDup(),
                i => i.MatchLdindR4()
            ))
            {
                cursor.Emit(OpCodes.Dup);

                cursor.EmitDelegate<Action<float>>(value =>
                {
                    CalCloneAI3 = value;
                });
            }
        });
    }
    #endregion

    protected override void Register() { }

    private static Func<SpriteBatch, Vector2, int, int, int, float, float, float, float, NPC, Texture2D, Vector2> DrawHead = new(
        (spriteBatch, position, BarLength, life, lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, bt) =>
        {
            Vector2 StartPosition = position - new Vector2((BarLength / 2) + 54, bt.Height / 2);
            spriteBatch.Draw(bt, StartPosition, Color.White * GlobalAlpha);
            return StartPosition;

        });
    private static Func<SpriteBatch, Vector2, int, int, int, float, float, float, float, NPC, Texture2D, Vector2> DrawFrame = new(
        (spriteBatch, position, BarLength, life, lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, bt) =>
        {
            int count = (BarLength - 72) / bt.Width;
            int extra = (BarLength - 72) % bt.Width;

            for (int i = 0; i < count; i++)
            {
                spriteBatch.Draw(bt, new Vector2(position.X - (BarLength / 2) + 36 + (i * bt.Width), position.Y - (bt.Height / 2)), Color.White * GlobalAlpha);
            }
            spriteBatch.Draw(bt, new Vector2(position.X - (BarLength / 2) + 36 + (count * bt.Width), position.Y - (bt.Height / 2)), new Rectangle(0, 0, extra, bt.Height), Color.White * GlobalAlpha);

            return Vector2.Zero;
        });
    private static Func<SpriteBatch, Vector2, int, int, int, float, float, float, float, NPC, Texture2D, Vector2> DrawTail = new(
        (spriteBatch, position, BarLength, life, lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, bt) =>
        {
            Vector2 StartPosition = position + new Vector2(BarLength / 2 - 36, -bt.Height / 2);
            spriteBatch.Draw(bt, StartPosition, Color.White * GlobalAlpha);
            return StartPosition;

        });
    private static Func<SpriteBatch, Vector2, int, int, int, float, float, float, float, NPC, Texture2D, Vector2> DrawFill = new(
        (spriteBatch, position, BarLength, life, lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, bt) =>
        {
            void DrawByPercent(float percentage, float GA)
            {
                Vector2 StartPostion = position - new Vector2(BarLength / 2, bt.Height / 2);
                int length = (int)(percentage * BarLength);
                if (length > 8)
                {
                    spriteBatch.Draw(bt, StartPostion, new Rectangle(0, 0, 8, bt.Height), Color.White * GlobalAlpha * GA);

                    int count = length / (bt.Width - 8);
                    int extra = length % (bt.Width - 8);

                    for (int i = 0; i < count; i++)
                    {
                        spriteBatch.Draw(bt, StartPostion + new Vector2(8 + i * (bt.Width - 8), 0), new Rectangle(8, 0, bt.Width - 8, bt.Height), Color.White * GlobalAlpha * GA);
                    }
                    spriteBatch.Draw(bt, StartPostion + new Vector2(8 + count * (bt.Width - 8), 0), new Rectangle(8, 0, extra, bt.Height), Color.White * GlobalAlpha * GA);
                }
                else
                {
                    spriteBatch.Draw(bt, StartPostion, new Rectangle(0, 0, length, bt.Height), Color.White * GlobalAlpha * GA);
                }
            }

            if (CalCloneAI3 > 0 && CalCloneAI2 > 0)
            {
                DrawByPercent((900f - CalCloneAI3) / 900f, 1f);
            }
            else
            {
                float postpercentage = npc.GetGlobalNPC<BarGlobalNPC>().DrawsMethods.postHealthSystem.GetPostHealth(npc.whoAmI, percentage);

                DrawByPercent(postpercentage, 0.7f);
                DrawByPercent(percentage, 1f);
            }

            return Vector2.Zero;
        });
    private static Func<SpriteBatch, Vector2, int, int, int, float, float, float, float, NPC, Texture2D, Vector2> DrawIcon = new(
        (spriteBatch, position, BarLength, life, lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, bt) =>
        {
            spriteBatch.Draw(bt, position - new Vector2(28 + ((bt.Width + BarLength) / 2), bt.Height / 2), Color.White * GlobalAlpha);

            return Vector2.Zero;
        });

    private static Action<bool, bool, bool, bool, bool, bool, SpriteBatch, Vector2, int, float[], float, NPC, List<int>, float, Action<bool, bool, bool, bool, bool, bool, SpriteBatch, Vector2, int, float[], float, NPC, List<int>, float>> DrawText = new((bool_invincible, bool_name, bool_life, bool_lifemax, bool_percentage, bool_segment, spriteBatch, position, BarLength, lifefloats, GlobalAlpha, npc, SegmentTypeList, shieldpercentage, defaultDrawText) =>
    {
        if (CalCloneAI3 > 0 && CalCloneAI2 > 0)
        {

            string text = Language.GetTextValue("Mods.YuBellBossBar.Info.BulletHell", string.Format("{0:f2}", (900f - CalCloneAI3) / 60));

            BarDrawsMethods.DrawBorderStringWithCenter(spriteBatch, text, position, Color.White * GlobalAlpha);
        }
        else
        {
            defaultDrawText?.Invoke(bool_invincible,
                    bool_name,
                    bool_life,
                    bool_lifemax,
                    bool_percentage,
                    bool_segment,
                    spriteBatch, position, BarLength, lifefloats, GlobalAlpha, npc, SegmentTypeList, shieldpercentage);
        }
    });
}

