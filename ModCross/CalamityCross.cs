namespace YuBellBossBar.ModCross
{
    internal class CalamityCross : ModSystem
    {
        public override void PostSetupContent()
        {

            if (ModLoader.TryGetMod("CalamityMod", out Mod calamity))
            {
                Mod yabhb = ModLoader.GetMod("YuBellBossBar");

                yabhb.Call("YetAnotherModCall", "Edit", "Invincible", calamity.Find<ModNPC>("SlimeGodCore").Type, false);
                yabhb.Call("YetAnotherModCall", "Edit", "Invincible", calamity.Find<ModNPC>("RavagerBody").Type, false);
                yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.Golem, false);
                yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemHead, false);
                yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemHeadFree, false);
                yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemFistLeft, false);
                yabhb.Call("YetAnotherModCall", "Edit", "Invincible", NPCID.GolemFistRight, false);

                yabhb.Call("YetAnotherModCall", "Edit", "AddBarTexture2D",
                    "普灾Head", 2,
                    ModContent.Request<Texture2D>("YuBellBossBar/Texture/ExtraCalamity/普灾/普灾Head", AssetRequestMode.ImmediateLoad),
                    0,
                    new Vector2(54, 12),
                    new Vector2(25, 26),
                    int.MaxValue,
                    0,
                    Color.White,
                    int.MaxValue,
                    1,
                    1,
                     new Func<SpriteBatch, Vector2, int, int, int, float, float, NPC, BossBarDrawParams, BarTexture2D, Vector2>((spriteBatch, position, BarLength, life, lifemax, percentage, GlobalAlpha, npc, drawParams, bt) =>
                     {
                         Vector2 StartPosition = position - new Vector2(BarLength / 2, bt.texture.Value.Height / 2) - bt.fillOffset;
                         if (!CalamityCloneAdapt.BrotherAlive)
                         {
                             spriteBatch.Draw(bt.texture.Value, StartPosition, Color.White);
                         }
                         else
                         {
                             spriteBatch.Draw(CalamityCloneAdapt.灾难构造体Head.Value,)
                         }

                         return StartPosition;
                     }),
                    null);
            }
        }
    }

    internal class CalamityCloneAdapt
    {
        public static Asset<Texture2D> 灾难构造体Head = ModContent.Request<Texture2D>("YuBellBossBar.Texture.ExtraCalamity.普灾.灾难构造体Head",AssetRequestMode.ImmediateLoad);
        public static Asset<Texture2D> 灾难构造体Frame = ModContent.Request<Texture2D>("YuBellBossBar.Texture.ExtraCalamity.普灾.灾难构造体Frame", AssetRequestMode.ImmediateLoad);
        public static Asset<Texture2D> 灾难构造体Tail = ModContent.Request<Texture2D>("YuBellBossBar.Texture.ExtraCalamity.普灾.灾难构造体Tail", AssetRequestMode.ImmediateLoad);
        public static Asset<Texture2D> 灾祸构造体Head = ModContent.Request<Texture2D>("YuBellBossBar.Texture.ExtraCalamity.普灾.灾祸构造体Head", AssetRequestMode.ImmediateLoad);
        public static Asset<Texture2D> 灾祸构造体Frame = ModContent.Request<Texture2D>("YuBellBossBar.Texture.ExtraCalamity.普灾.灾祸构造体Frame", AssetRequestMode.ImmediateLoad);
        public static Asset<Texture2D> 灾祸构造体Tail = ModContent.Request<Texture2D>("YuBellBossBar.Texture.ExtraCalamity.普灾.灾祸构造体Tail", AssetRequestMode.ImmediateLoad);

        public static bool BrotherAlive = false;

        public static void IL_GetBrotherAlive()
        {
            if (!ModLoader.TryGetMod("CalamityMod", out Mod calamity))
                return;

            Type calamitasCloneType = calamity.Code.GetType("CalamityMod.NPCs.CalClone.CalamitasClone");
            Type calamityGlobalNPCType = calamity.Code.GetType("CalamityMod.NPCs.CalamityGlobalNPC");

            if (calamitasCloneType == null || calamityGlobalNPCType == null)
                return;

            MethodInfo aiMethod = calamitasCloneType.GetMethod("AI", BindingFlags.Public | BindingFlags.Instance);
            FieldInfo catastropheField = calamityGlobalNPCType.GetField("catastrophe");
            FieldInfo cataclysmField = calamityGlobalNPCType.GetField("cataclysm");
            FieldInfo mainNpcField = typeof(Main).GetField("npc");
            FieldInfo npcActiveField = typeof(NPC).GetField("active");

            if (aiMethod == null || catastropheField == null || mainNpcField == null || npcActiveField == null)
                return;

            MonoModHooks.Modify(aiMethod, il =>
            {
                ILCursor cursor = new ILCursor(il);
                int brotherAliveIndex = -1;

                bool found = cursor.TryGotoNext(MoveType.After,
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
                );

                if (!found && cataclysmField != null)
                {
                    cursor = new ILCursor(il);
                    found = cursor.TryGotoNext(MoveType.After,
                        i => i.MatchLdsfld(cataclysmField),
                        i => i.MatchLdcI4(-1),
                        i => i.MatchBeq(out _),
                        i => i.MatchLdsfld(mainNpcField),
                        i => i.MatchLdsfld(cataclysmField),
                        i => i.MatchLdelemRef(),
                        i => i.MatchLdfld(npcActiveField),
                        i => i.MatchBrfalse(out _),
                        i => i.MatchLdcI4(1),
                        i => i.MatchStloc(out brotherAliveIndex)
                    );
                }

                if (!found)
                    return;

                found = cursor.TryGotoNext(MoveType.Before,
                    i => i.MatchLdloc(brotherAliveIndex),
                    i => i.MatchBrfalse(out _)
                );

                if (!found)
                    return;

                cursor.Index++;

                cursor.Emit(OpCodes.Dup);
                cursor.EmitDelegate<Action<bool>>(brotherAlive =>
                {
                    CalamityCloneAdapt.BrotherAlive = brotherAlive;
                });
            });
        }
    }
}
