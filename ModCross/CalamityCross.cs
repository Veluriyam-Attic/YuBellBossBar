namespace YuBellBossBar.ModCross;

internal class CalamityCloneAdapt : ModType
{
    private static int CatastropheType = -1;
    private static int CataclysmType = -1;

    public override void SetupContent()
    {
        if (ModLoader.TryGetMod("CalamityMod", out calamity))
        {
            Mod yabhb = ModLoader.GetMod("YuBellBossBar");

            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", calamity.Find<ModNPC>("SlimeGodCore").Type, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", calamity.Find<ModNPC>("RavagerBody").Type, false);
            yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.Golem, false);
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

                #region 普灾Head
                var CalamitasCloneHead = yabhb.Call("YetAnotherModCall", "Add", "Add Head",
                    "普灾Head",
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
                    "普灾Frame",
                    ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/普灾Frame", AssetRequestMode.ImmediateLoad),
                    "Dulplicate",
                    1,
                    6,
                    DrawFrame,
                    null);
                #endregion

                #region 普灾Tail
                var CalamitasCloneTail = yabhb.Call("YetAnotherModCall", "Add", "Add Tail",
                    "普灾Tail",
                    ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/普灾Tail", AssetRequestMode.ImmediateLoad),
                    new Vector2(36, 16),
                    1,
                    6,
                    DrawTail,
                    null);
                #endregion

                #region 普灾Fill
                var CalamitasCloneFill = yabhb.Call("YetAnotherModCall", "Add", "Add Fill",
                    "普灾Fill",
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
                    "普灾Icon",
                    ModContent.Request<Texture2D>("CalamityMod/NPCs/CalClone/CalamitasClone_Head_Boss", AssetRequestMode.ImmediateLoad),
                    1,
                    6,
                    DrawIcon,
                    null);
                #endregion

                yabhb.Call("YetAnotherModCall", "Add", "Add BarInfo", calamity.Find<ModNPC>("CalamitasClone").Type, new List<object> { CalamitasCloneHead, CalamitasCloneFrame, CalamitasCloneTail, CalamitasCloneFill, CalamitasCloneIcon }, DrawText, null, new List<int> { calamity.Find<ModNPC>("SoulSeeker").Type });
            }
        }
    }

    public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");

    private static Mod calamity;

    private static Asset<Texture2D> 灾难构造体Head = ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/灾难构造体Head", AssetRequestMode.ImmediateLoad);
    private static Asset<Texture2D> 灾难构造体Frame = ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/灾难构造体Frame", AssetRequestMode.ImmediateLoad);
    private static Asset<Texture2D> 灾难构造体Tail = ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/灾难构造体Tail", AssetRequestMode.ImmediateLoad);
    private static Asset<Texture2D> 灾祸构造体Head = ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/灾祸构造体Head", AssetRequestMode.ImmediateLoad);
    private static Asset<Texture2D> 灾祸构造体Frame = ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/灾祸构造体Frame", AssetRequestMode.ImmediateLoad);
    private static Asset<Texture2D> 灾祸构造体Tail = ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/灾祸构造体Tail", AssetRequestMode.ImmediateLoad);
    private static Asset<Texture2D> 灾难Fill = ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/灾难Fill", AssetRequestMode.ImmediateLoad);
    private static Asset<Texture2D> 灾祸Fill = ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/灾祸Fill", AssetRequestMode.ImmediateLoad);

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
            if (!BrotherAlive)
            {
                Vector2 StartPosition = position - new Vector2((BarLength / 2) + 54, bt.Height / 2);
                spriteBatch.Draw(bt, StartPosition, Color.White * GlobalAlpha);
                return StartPosition;
            }
            else
            {
                Vector2 StartPosition = position - new Vector2(BarLength / 2, 灾难构造体Head.Value.Height / 2) - new Vector2(32, 0);
                Vector2 EndPosition = position + new Vector2(BarLength / 2, -(灾祸构造体Head.Value.Height / 2)) - new Vector2(16, 0);
                spriteBatch.Draw(灾难构造体Head.Value, StartPosition, Color.White * GlobalAlpha);
                spriteBatch.Draw(灾祸构造体Head.Value, EndPosition, Color.White * GlobalAlpha);
                return StartPosition;
            }
        });
    private static Func<SpriteBatch, Vector2, int, int, int, float, float, float, float, NPC, Texture2D, Vector2> DrawFrame = new(
        (spriteBatch, position, BarLength, life, lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, bt) =>
        {
            if (!BrotherAlive)
            {
                int count = (BarLength - 72) / bt.Width;
                int extra = (BarLength - 72) % bt.Width;

                for (int i = 0; i < count; i++)
                {
                    spriteBatch.Draw(bt, new Vector2(position.X - (BarLength / 2) + 36 + (i * bt.Width), position.Y - (bt.Height / 2)), Color.White * GlobalAlpha);
                }
                spriteBatch.Draw(bt, new Vector2(position.X - (BarLength / 2) + 36 + (count * bt.Width), position.Y - (bt.Height / 2)), new Rectangle(0, 0, extra, bt.Height), Color.White * GlobalAlpha);
            }
            else
            {
                int 灾难count = ((BarLength / 2) - 50) / 灾难构造体Frame.Value.Width;
                int 灾难extra = ((BarLength / 2) - 50) % 灾难构造体Frame.Value.Width;


                for (int i = 0; i < 灾难count; i++)
                {
                    spriteBatch.Draw(灾难构造体Frame.Value, new Vector2(position.X - (BarLength / 2) + 32 + (i * 灾难构造体Frame.Value.Width), position.Y - (灾难构造体Frame.Value.Height / 2)), Color.White * GlobalAlpha);
                }
                spriteBatch.Draw(灾难构造体Frame.Value, new Vector2(position.X - (BarLength / 2) + 32 + (灾难count * 灾难构造体Frame.Value.Width), position.Y - (灾难构造体Frame.Value.Height / 2)), new Rectangle(0, 0, 灾难extra, 灾难构造体Frame.Value.Height), Color.White * GlobalAlpha);

                int 灾祸count = ((BarLength / 2) - 34) / 灾祸构造体Frame.Value.Width;
                int 灾祸extra = ((BarLength / 2) - 34) % 灾祸构造体Frame.Value.Width;

                for (int i = 0; i < 灾祸count; i++)
                {
                    spriteBatch.Draw(灾祸构造体Frame.Value, new Vector2(position.X + 18 + (i * 灾祸构造体Frame.Value.Width), position.Y - (灾祸构造体Frame.Value.Height / 2)), Color.White * GlobalAlpha);
                }
                spriteBatch.Draw(灾祸构造体Frame.Value, new Vector2(position.X + 18 + (灾祸count * 灾祸构造体Frame.Value.Width), position.Y - (灾祸构造体Frame.Value.Height / 2)), new Rectangle(0, 0, 灾祸extra, 灾祸构造体Frame.Value.Height), Color.White * GlobalAlpha);
            }

            return Vector2.Zero;
        });
    private static Func<SpriteBatch, Vector2, int, int, int, float, float, float, float, NPC, Texture2D, Vector2> DrawTail = new(
        (spriteBatch, position, BarLength, life, lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, bt) =>
        {
            if (!BrotherAlive)
            {
                Vector2 StartPosition = position + new Vector2(BarLength / 2 - 36, -bt.Height / 2);
                spriteBatch.Draw(bt, StartPosition, Color.White * GlobalAlpha);
                return StartPosition;
            }
            else
            {
                Vector2 StartPosition = position - new Vector2(灾难构造体Tail.Value.Width, 灾难构造体Tail.Value.Height / 2);
                Vector2 EndPosition = position - new Vector2(0, 灾祸构造体Tail.Value.Height / 2);
                spriteBatch.Draw(灾难构造体Tail.Value, StartPosition, Color.White * GlobalAlpha);
                spriteBatch.Draw(灾祸构造体Tail.Value, EndPosition, Color.White * GlobalAlpha);
                return StartPosition;
            }
        });
    private static Func<SpriteBatch, Vector2, int, int, int, float, float, float, float, NPC, Texture2D, Vector2> DrawFill = new(
        (spriteBatch, position, BarLength, life, lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, bt) =>
        {
            if (!BrotherAlive)
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
            }
            else
            {
                int 灾难index = (int)catastropheField.GetValue(null);
                if (灾难index != -1)
                {
                    NPC 灾难 = Main.npc[灾难index];
                    float 灾难percentage = (float)灾难.life / (float)灾难.lifeMax;
                    int 灾难length = (int)(灾难percentage * ((BarLength / 2) - 10));

                    {
                        int 灾难count = 灾难length / (灾难Fill.Value.Width - 8);
                        int 灾难extra = 灾难length % (灾难Fill.Value.Width - 8);

                        spriteBatch.Draw(灾难Fill.Value, position - new Vector2(10 + 灾难extra, 灾难Fill.Value.Height / 2), new Rectangle(8, 0, 灾难extra, 灾难Fill.Value.Height), Color.White * GlobalAlpha);

                        for (int i = 0; i < 灾难count; i++)
                        {
                            spriteBatch.Draw(灾难Fill.Value, position - new Vector2(10 + 灾难extra + ((i + 1) * (灾难Fill.Value.Width - 8)), 灾难Fill.Value.Height / 2), new Rectangle(10, 0, 灾难Fill.Value.Width - 8, 灾难Fill.Value.Height), Color.White * GlobalAlpha);
                        }
                        spriteBatch.Draw(灾难Fill.Value, position - new Vector2(18 + 灾难extra + (灾难count * (灾难Fill.Value.Width - 8)), 灾难Fill.Value.Height / 2), new Rectangle(0, 0, 8, 灾难Fill.Value.Height), Color.White * GlobalAlpha);
                    }
                }
                int 灾祸index = (int)cataclysmField.GetValue(null);

                if (灾祸index != -1)
                {
                    NPC 灾祸 = Main.npc[灾祸index];
                    float 灾祸percentage = (float)灾祸.life / (float)灾祸.lifeMax;
                    int 灾祸length = (int)(灾祸percentage * ((BarLength / 2) - 10));

                    {
                        int 灾祸count = 灾祸length / (灾难Fill.Value.Width - 8);
                        int 灾祸extra = 灾祸length % (灾难Fill.Value.Width - 8);

                        spriteBatch.Draw(灾祸Fill.Value, position + new Vector2(8, -灾祸Fill.Value.Height / 2), new Rectangle(0, 0, 灾祸extra, 灾祸Fill.Value.Height), Color.White * GlobalAlpha);

                        for (int i = 0; i < 灾祸count; i++)
                        {
                            spriteBatch.Draw(灾祸Fill.Value, position + new Vector2(8 + 灾祸extra + (i * (灾祸Fill.Value.Width - 8)), -灾祸Fill.Value.Height / 2), new Rectangle(0, 0, 灾祸Fill.Value.Width - 8, 灾祸Fill.Value.Height), Color.White * GlobalAlpha);
                        }
                        spriteBatch.Draw(灾祸Fill.Value, position + new Vector2(8 + 灾祸extra + (灾祸count * (灾祸Fill.Value.Width - 8)), -灾祸Fill.Value.Height / 2), new Rectangle(灾祸Fill.Value.Width - 8, 0, 8, 灾祸Fill.Value.Height), Color.White * GlobalAlpha);
                    }
                }
            }
            return Vector2.Zero;
        });
    private static Func<SpriteBatch, Vector2, int, int, int, float, float, float, float, NPC, Texture2D, Vector2> DrawIcon = new(
        (spriteBatch, position, BarLength, life, lifemax, shield, shieldmax, percentage, GlobalAlpha, npc, bt) =>
        {
            if (!BrotherAlive)
            {
                spriteBatch.Draw(bt, position - new Vector2(28 + ((bt.Width + BarLength) / 2), bt.Height / 2), Color.White * GlobalAlpha);
            }
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
            if (!BrotherAlive)
            {
                defaultDrawText?.Invoke(bool_invincible,
                        bool_name,
                        bool_life,
                        bool_lifemax,
                        bool_percentage,
                        bool_segment,
                        spriteBatch, position, BarLength, lifefloats, GlobalAlpha, npc, SegmentTypeList, shieldpercentage);
            }
            else
            {
                int 灾难index = (int)catastropheField.GetValue(null);
                if (灾难index != -1)
                {
                    NPC 灾难 = Main.npc[灾难index];
                    float 灾难percentage = (float)灾难.life / (float)灾难.lifeMax;
                    defaultDrawText?.Invoke(bool_invincible, bool_name, bool_life, bool_lifemax, bool_percentage, bool_segment,
                    spriteBatch, new Vector2(position.X - 10 - (BarLength / 4), position.Y), BarLength, lifefloats, GlobalAlpha, 灾难, SegmentTypeList, shieldpercentage);
                }
                else
                {
                    BarDrawsMethods.DrawBorderStringWithCenter(spriteBatch, Language.GetTextValue("Mods.YuBellBossBar.Info.Defeated", Lang.GetNPCName(CatastropheType)), new Vector2(position.X - 10 - (BarLength / 4), position.Y), Color.White * GlobalAlpha);
                }

                int 灾祸index = (int)cataclysmField.GetValue(null);
                if (灾祸index != -1)
                {
                    NPC 灾祸 = Main.npc[灾祸index];
                    float 灾难percentage = (float)灾祸.life / (float)灾祸.lifeMax;
                    defaultDrawText?.Invoke(bool_invincible, bool_name, bool_life, bool_lifemax, bool_percentage, bool_segment,
                    spriteBatch, new Vector2(position.X + 10 + (BarLength / 4), position.Y), BarLength, lifefloats, GlobalAlpha, 灾祸, SegmentTypeList, shieldpercentage);
                }
                else
                {
                    BarDrawsMethods.DrawBorderStringWithCenter(spriteBatch, Language.GetTextValue("Mods.YuBellBossBar.Info.Defeated", Lang.GetNPCName(CataclysmType)), new Vector2(position.X + 10 + (BarLength / 4), position.Y), Color.White * GlobalAlpha);
                }
            }
        }
    });
}

