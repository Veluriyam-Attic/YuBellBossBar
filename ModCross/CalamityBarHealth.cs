namespace YuBellBossBar.ModCross;

/// <summary>
/// <br/>灾厄血条适配的反射桥。
/// <br/>完全不引用 CalamityMod.dll,所有灾厄类型/成员都通过 ModLoader.GetMod("CalamityMod").Code 反射获得。
/// <br/>只有灾厄专门适配过的Boss才会返回数据,显示信息(名字/血量/上限/百分比)全部取自灾厄自己的 BossHPUI。
/// <br/>另外维护了世吞/石巨人/月总"只画一条血条"的过滤与drawEvent去重。
/// </summary>
internal class CalamityBarHealth
{
    /// <summary>反射初始化是否成功(灾厄已加载且反射成员齐全)</summary>
    public static bool CalamityLoaded = false;

    // ---- 灾厄自己的类型(Initialize时解析一次,之后复用) ----
    private static Type bossHealthBarManagerType;
    private static Type bossHPUIType;
    private static Type calamityGlobalNPCType;

    // ---- 反射目标成员 ----
    private static ConstructorInfo bossHPUIConstructor;   // BossHPUI(int, string)
    private static MethodInfo bossHPUIUpdateMethod;       // BossHPUI.Update()
    private static FieldInfo intendedNPCTypeField;        // IntendedNPCType
    private static FieldInfo initialMaxLifeField;         // InitialMaxLife
    private static FieldInfo overridingNameField;         // OverridingName
    private static PropertyInfo combinedLifeProperty;     // CombinedNPCLife
    private static PropertyInfo combinedMaxLifeProperty;  // CombinedNPCMaxLife
    private static PropertyInfo lifeRatioProperty;        // NPCLifeRatio
    private static PropertyInfo associatedNPCProperty;    // AssociatedNPC
    private static MethodInfo getCalamityGlobalNPCMethod; // NPC.GetGlobalNPC<CalamityGlobalNPC>()
    private static FieldInfo canHaveBossHealthBarField;   // CalamityGlobalNPC.CanHaveBossHealthBar
    private static Type artemisType;                      // Exo Twins 之一,灾厄自己不给它立血条
    private static Type apolloType;                       // Exo Twins 之一,灾厄给它的血条用覆盖名
    private static FieldInfo apolloExoMechdusaField;      // Apollo.exoMechdusa
    private static MethodInfo calamityGetTextValueMethod; // CalamityUtils.GetTextValue(string)
    private static Mod calamityMod;                       // CalamityMod 的 Mod 实例,用引用比较代替每帧字符串比较
    private static int slimeGodCoreType = -1;             // 史莱姆之神本体:不显示血条
    private static int ceaselessVoidType = -1;            // 无尽虚空:走ModBossBar途径,不走灾厄BossHPUI
    private static int cryogenType = -1;                  // 极地之灵:走ModBossBar途径,不走灾厄BossHPUI

    // 强制显示血条的灾厄NPC(即使不满足灾厄适配/没有头贴图):分裂后的圣卫(圣骑士分裂体)、噬魂幽花复制体
    private static readonly HashSet<int> ForceShowTypes = new();

    // ---- 灾厄自己维护的数据(反射自 BossHealthBarManager 的静态字段) ----
    public static Dictionary<int, int[]> OneToMany;
    public static List<int> BossExclusionList;
    public static List<int> MinibossHPBarList;
    private static HashSet<int> excludedSet;              // BossExclusionList 的 O(1) 查找缓存
    private static HashSet<int> minibossSet;              // MinibossHPBarList 的 O(1) 查找缓存

    // whoAmI -> BossHPUI 实例
    // 缓存实例是为了让 InitialMaxLife 等状态跨帧保持,和灾厄真实血条一致
    // (每次新建实例的话,体节死亡后 CombinedNPCMaxLife 变小,血条上限会跟着缩水)
    // NPC死亡时由 OnKill 主动清理,防止槽位被新Boss复用后串用旧InitialMaxLife
    private static readonly Dictionary<int, object> BossHPUICache = new();

    // 帧缓存:每帧每个NPC的灾厄判定只算一次,三个判定方法共用同一份结果
    private struct NpcFrameState
    {
        public ulong Frame;    // 记录计算时的帧号,同帧命中直接复用
        public bool Adapted;   // IsCalamityAdaptedBoss 的结果
        public bool Hide;      // ShouldHideBar 的结果
        public bool Force;     // ShouldForceDrawBar 的结果
    }
    private static readonly Dictionary<int, NpcFrameState> FrameStates = new();

    // GetInfo 的帧缓存:同帧内 Draw 覆盖和文字显示只反射计算一轮
    private struct InfoFrame
    {
        public ulong Frame;        // 记录计算时的帧号
        public CalamityBarInfo Info; // 缓存的计算结果
    }
    private static readonly Dictionary<int, InfoFrame> InfoCache = new();

    // CanHaveBossHealthBar 按 NPC 类型缓存(同一类型的所有 NPC 基本一致,避免每帧反射 Invoke)
    private static readonly Dictionary<int, bool> CanHaveCache = new();

    // 仅世吞/石巨人/月总这三个Boss的"非主实体":即使boss=true且有大头贴图,也只让主实体显示一个血条
    // (世吞体/尾、月总头/手、石巨人头/拳/自由头)。永远生效,不依赖灾厄加载。其它多体节Boss不受影响。
    private static readonly HashSet<int> VanillaMultiPartSideTypes = new()
    {
        NPCID.EaterofWorldsBody,
        NPCID.EaterofWorldsTail,
        NPCID.GolemHead,
        NPCID.GolemFistLeft,
        NPCID.GolemFistRight,
        NPCID.GolemHeadFree,
        NPCID.MoonLordHead,
        NPCID.MoonLordHand,
        NPCID.MoonLordFreeEye,
    };

    // 每帧每个多体节Boss组合只允许一个drawEvent:即使场上有多个世吞/石巨人/月总实体,也只画一条
    private static readonly HashSet<int> VanillaDrawnThisFrame = new();
    private static ulong VanillaDrawnFrame = ulong.MaxValue;

    /// <summary>
    /// <br/>反射获取灾厄 BossHealthBarManager / BossHPUI 相关的所有成员。
    /// <br/>必须在灾厄加载完成后调用(PostSetupContent)。
    /// </summary>
    internal static bool Initialize()
    {
        try
        {
            if (!ModLoader.HasMod("CalamityMod"))
                return false;

            Mod calamity = ModLoader.GetMod("CalamityMod");
            calamityMod = calamity;
            bossHealthBarManagerType = calamity?.Code?.GetType("CalamityMod.UI.BossHealthBarManager");
            if (bossHealthBarManagerType == null)
                return false;

            const BindingFlags pubStatic = BindingFlags.Public | BindingFlags.Static;
            OneToMany = bossHealthBarManagerType.GetField("OneToMany", pubStatic)?.GetValue(null) as Dictionary<int, int[]>;
            BossExclusionList = bossHealthBarManagerType.GetField("BossExclusionList", pubStatic)?.GetValue(null) as List<int>;
            MinibossHPBarList = bossHealthBarManagerType.GetField("MinibossHPBarList", pubStatic)?.GetValue(null) as List<int>;
            excludedSet = BossExclusionList == null ? null : new HashSet<int>(BossExclusionList);
            minibossSet = MinibossHPBarList == null ? null : new HashSet<int>(MinibossHPBarList);

            bossHPUIType = bossHealthBarManagerType.GetNestedType("BossHPUI", BindingFlags.Public);
            if (bossHPUIType == null)
                return false;

            const BindingFlags pubInst = BindingFlags.Public | BindingFlags.Instance;
            bossHPUIConstructor = bossHPUIType.GetConstructor(new[] { typeof(int), typeof(string) });
            bossHPUIUpdateMethod = bossHPUIType.GetMethod("Update", pubInst, null, Type.EmptyTypes, null);
            intendedNPCTypeField = bossHPUIType.GetField("IntendedNPCType", pubInst);
            initialMaxLifeField = bossHPUIType.GetField("InitialMaxLife", pubInst);
            overridingNameField = bossHPUIType.GetField("OverridingName", pubInst);
            combinedLifeProperty = bossHPUIType.GetProperty("CombinedNPCLife", pubInst);
            combinedMaxLifeProperty = bossHPUIType.GetProperty("CombinedNPCMaxLife", pubInst);
            lifeRatioProperty = bossHPUIType.GetProperty("NPCLifeRatio", pubInst);
            associatedNPCProperty = bossHPUIType.GetProperty("AssociatedNPC", pubInst);

            // 灾厄的全局NPC数据,用于复刻灾厄自己"这个实体有没有血条"的判定
            calamityGlobalNPCType = calamity.Code?.GetType("CalamityMod.NPCs.CalamityGlobalNPC");
            if (calamityGlobalNPCType != null)
            {
                canHaveBossHealthBarField = calamityGlobalNPCType.GetField("CanHaveBossHealthBar", pubInst);
                MethodInfo getGlobalNPC = typeof(NPC).GetMethod("GetGlobalNPC", Type.EmptyTypes);
                if (getGlobalNPC != null && canHaveBossHealthBarField != null)
                    getCalamityGlobalNPCMethod = getGlobalNPC.MakeGenericMethod(calamityGlobalNPCType);
            }

            // Exo Twins:灾厄的 AttemptToAddBar 隐藏 Artemis、给 Apollo 一个覆盖名(Exo Twins / Hekate)
            artemisType = calamity.Code?.GetType("CalamityMod.NPCs.ExoMechs.Artemis.Artemis");
            apolloType = calamity.Code?.GetType("CalamityMod.NPCs.ExoMechs.Apollo.Apollo");
            if (apolloType != null)
                apolloExoMechdusaField = apolloType.GetField("exoMechdusa", pubInst);
            Type calamityUtilsType = calamity.Code?.GetType("CalamityMod.CalamityUtils");
            calamityGetTextValueMethod = calamityUtilsType?.GetMethod("GetTextValue", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(string) }, null);

            // 史莱姆之神本体不显示血条;无尽虚空走ModBossBar途径(通过Find按名字找类型ID,不引用程序集)
            try { slimeGodCoreType = calamity.Find<ModNPC>("SlimeGodCore").Type; } catch { slimeGodCoreType = -1; }
            try { ceaselessVoidType = calamity.Find<ModNPC>("CeaselessVoid").Type; } catch { ceaselessVoidType = -1; }
            try { cryogenType = calamity.Find<ModNPC>("Cryogen").Type; } catch { cryogenType = -1; }

            // 分裂后的圣卫(圣骑士分裂体)与噬魂幽花复制体:强制显示血条
            ForceShowTypes.Clear();
            try { ForceShowTypes.Add(calamity.Find<ModNPC>("SplitEbonianPaladin").Type); } catch { }
            try { ForceShowTypes.Add(calamity.Find<ModNPC>("SplitCrimulanPaladin").Type); } catch { }
            try { ForceShowTypes.Add(calamity.Find<ModNPC>("PolterPhantom").Type); } catch { }

            return bossHPUIConstructor != null
                && bossHPUIUpdateMethod != null
                && combinedLifeProperty != null
                && combinedMaxLifeProperty != null
                && initialMaxLifeField != null;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// <br/>判断这个NPC是不是灾厄专门适配过(会出现在灾厄自己血条里)的Boss。
    /// <br/>未启用灾厄适配/灾厄没加载时恒为false,保证走原来的逻辑。
    /// </summary>
    internal static bool IsCalamityAdaptedBoss(NPC npc)
    {
        return GetFrameState(npc).Adapted;
    }

    /// <summary>
    /// <br/>判断这个NPC是否来自灾厄模组(按 Mod 引用比较,不依赖灾厄适配/强制显示逻辑)。
    /// <br/>灾厄未加载或未初始化时恒为false。
    /// </summary>
    internal static bool IsCalamityNpc(NPC npc)
    {
        return npc?.ModNPC != null && calamityMod != null && npc.ModNPC.Mod == calamityMod;
    }

    /// <summary>
    /// <br/>判断这个灾厄NPC是否应该完全不画血条(和灾厄自己的血条保持一致):
    /// <br/>1. Artemis:灾厄永远不给它血条(Exo Twins共用一条,由Apollo显示);
    /// <br/>2. 被灾厄排除的体节/部件(塔纳托斯体节、吞噬者体节、阿瑞斯武器等),除非挂着灾厄自己的ModBossBar(如史莱姆神核心)。
    /// </summary>
    internal static bool ShouldHideBar(NPC npc)
    {
        return GetFrameState(npc).Hide;
    }

    /// <summary>
    /// <br/>灾厄适配过的主Boss:即使 GetBossHeadTextureIndex() 返回 -1(没有有效的原版Boss大头贴图索引)也允许画血条。
    /// <br/>只对灾厄会立血条的实体生效:本体boss,或挂着灾厄自己的ModBossBar(如RavagerBody/SlimeGodCore)。
    /// <br/>不会把爪子/腿/被打飞的头等部件误画出来。
    /// </summary>
    internal static bool ShouldForceDrawBar(NPC npc)
    {
        return GetFrameState(npc).Force;
    }

    /// <summary>
    /// <br/>每帧每个NPC的判定缓存:同帧内多次查询直接返回,不重复做字符串比较/集合查找/反射。
    /// </summary>
    private static NpcFrameState GetFrameState(NPC npc)
    {
        // 快速路径:未启用/未加载/非活跃直接返回默认,不给普通NPC建缓存条目
        if (!YuBellBossBar.CalamityAdapt || !CalamityLoaded || npc == null || !npc.active)
            return default;

        // 非灾厄NPC且不在灾厄维护的原版列表里(世吞/克脑等OneToMany,南瓜王等小Boss),不需要任何灾厄判定
        if ((npc.ModNPC == null || calamityMod == null || npc.ModNPC.Mod != calamityMod)
            && (OneToMany == null || !OneToMany.ContainsKey(npc.type))
            && (minibossSet == null || !minibossSet.Contains(npc.type)))
            return default;

        ulong frame = Main.GameUpdateCount;
        if (FrameStates.TryGetValue(npc.whoAmI, out NpcFrameState state) && state.Frame == frame)
            return state;

        state = ComputeFrameState(npc, frame);
        FrameStates[npc.whoAmI] = state;

        if (FrameStates.Count > Main.maxNPCs + 32)
            PruneFrameStates(frame);
        return state;
    }

    /// <summary>
    /// <br/>实际计算一个NPC的灾厄判定结果(仅首次查询该帧时执行)。
    /// </summary>
    private static NpcFrameState ComputeFrameState(NPC npc, ulong frame)
    {
        NpcFrameState state = new NpcFrameState { Frame = frame };
        // 未启用灾厄适配/灾厄未加载/非活跃NPC:全部返回默认false
        if (!YuBellBossBar.CalamityAdapt || !CalamityLoaded || npc == null || !npc.active)
            return state;

        // 用 Mod 引用比较代替每帧字符串比较
        bool isCalamityNpc = npc.ModNPC != null && calamityMod != null && npc.ModNPC.Mod == calamityMod;
        // 灾厄自己排除的体节/部件(BossExclusionList,已转HashSet做O(1)查找)
        bool excluded = excludedSet != null && excludedSet.Contains(npc.type);
        // Artemis:灾厄永远不给它血条
        bool artemis = artemisType != null && npc.ModNPC != null && npc.ModNPC.GetType() == artemisType;
        // 强制显示:分裂后的圣卫、噬魂幽花复制体等
        bool forceShow = ForceShowTypes.Contains(npc.type);

        // IsCalamityAdaptedBoss:灾厄本体Boss / OneToMany多体节组合(含原版世吞等) / 小Boss列表 / CanHaveBossHealthBar标记
        state.Adapted = !excluded && !artemis
            && ((npc.boss && isCalamityNpc)
                || (OneToMany != null && OneToMany.ContainsKey(npc.type))
                || (minibossSet != null && minibossSet.Contains(npc.type))
                || CanHaveBossHealthBar(npc));

        // ShouldHideBar:非灾厄NPC恒不隐藏;Artemis/史莱姆之神本体隐藏;强制显示的NPC不隐藏;未适配且没挂灾厄ModBossBar的体节/部件隐藏
        state.Hide = isCalamityNpc && !forceShow && (artemis || npc.type == slimeGodCoreType || (!state.Adapted && !(npc.BossBar is ModBossBar)));

        // ShouldForceDrawBar:灾厄主Boss(本体boss/挂着灾厄ModBossBar/强制显示列表)即使没有头贴图也放行
        state.Force = isCalamityNpc && !excluded && !artemis && (npc.boss || npc.BossBar is ModBossBar || forceShow);
        return state;
    }

    /// <summary>
    /// <br/>清理帧判定缓存:删除所有非当前帧的条目(仅缓存数量超限时触发,低频)。
    /// </summary>
    private static void PruneFrameStates(ulong frame)
    {
        List<int> stale = null;
        foreach (KeyValuePair<int, NpcFrameState> pair in FrameStates)
        {
            if (pair.Value.Frame != frame)
            {
                stale ??= new List<int>();
                stale.Add(pair.Key);
            }
        }
        if (stale != null)
            foreach (int key in stale)
                FrameStates.Remove(key);
    }

    /// <summary>
    /// <br/>灾厄BossHPUI给一个NPC的显示数据快照。
    /// </summary>
    internal readonly struct CalamityBarInfo
    {
        public readonly long Life;           // CombinedNPCLife:当前合并生命
        public readonly long LifeMax;        // CombinedNPCMaxLife:当前合并上限(部件死亡后会变小)
        public readonly long InitialMaxLife; // InitialMaxLife:初始总上限(只增不减,灾厄血条用的上限)
        public readonly float Ratio;         // NPCLifeRatio:生命/初始上限
        public readonly string Name;         // OverridingName ?? FullName:显示名

        public CalamityBarInfo(long life, long lifeMax, long initialMaxLife, float ratio, string name)
        {
            Life = life;
            LifeMax = lifeMax;
            InitialMaxLife = initialMaxLife;
            Ratio = ratio;
            Name = name;
        }
    }

    /// <summary>
    /// <br/>读取灾厄 BossHPUI 给这个NPC的显示数据。
    /// <br/>名字 = OverridingName ?? FullName,血量 = CombinedNPCLife,上限 = InitialMaxLife,百分比 = NPCLifeRatio。
    /// </summary>
    internal static CalamityBarInfo GetInfo(NPC npc)
    {
        ulong frame = Main.GameUpdateCount;
        if (InfoCache.TryGetValue(npc.whoAmI, out InfoFrame cached) && cached.Frame == frame)
            return cached.Info;

        CalamityBarInfo info = ComputeInfo(npc);
        InfoCache[npc.whoAmI] = new InfoFrame { Frame = frame, Info = info };

        if (InfoCache.Count > Main.maxNPCs + 32)
            PruneInfoCache(frame);
        return info;
    }

    private static CalamityBarInfo ComputeInfo(NPC npc)
    {
        try
        {
            object ui = GetOrCreateBossHPUI(npc);

            long life = (long)combinedLifeProperty.GetValue(ui);
            long lifeMax = (long)combinedMaxLifeProperty.GetValue(ui);
            long initialMaxLife = (long)initialMaxLifeField.GetValue(ui);
            float ratio = (float)lifeRatioProperty.GetValue(ui);
            // 名字 = 灾厄BossHPUI的OverridingName ?? (Apollo等灾厄自己给定覆盖名的Boss) ?? FullName
            string name = (string)overridingNameField.GetValue(ui) ?? GetCalamityOverridingName(npc) ?? npc.FullName;

            return new CalamityBarInfo(life, lifeMax, initialMaxLife, ratio, name);
        }
        catch
        {
            // 反射失败时返回空数据,调用方会走原来的逻辑
            return default;
        }
    }

    /// <summary>
    /// <br/>清理GetInfo帧缓存:删除所有非当前帧的条目(仅缓存数量超限时触发,低频)。
    /// </summary>
    private static void PruneInfoCache(ulong frame)
    {
        List<int> stale = null;
        foreach (KeyValuePair<int, InfoFrame> pair in InfoCache)
        {
            if (pair.Value.Frame != frame)
            {
                stale ??= new List<int>();
                stale.Add(pair.Key);
            }
        }
        if (stale != null)
            foreach (int key in stale)
                InfoCache.Remove(key);
    }

    /// <summary>
    /// <br/>获取显示名:优先灾厄BossHPUI给的OverridingName(如Apollo的"Exo Twins"),没有则用NPC原名。
    /// </summary>
    internal static string GetDisplayName(NPC npc)
    {
        string name = GetInfo(npc).Name;
        return string.IsNullOrEmpty(name) ? npc.FullName : name;
    }

    /// <summary>
    /// <br/>是否原版多体节Boss的非主实体(世吞体/尾、月总头/手、石巨人头/拳等),永远不单独画血条。
    /// </summary>
    internal static bool IsVanillaMultiPartSideType(int npcType) => VanillaMultiPartSideTypes.Contains(npcType);

    /// <summary>
    /// <br/>标识世吞/石巨人/月总这三个Boss(只用于drawEvent去重,不参与血量计算)。
    /// </summary>
    internal static bool IsVanillaSumPriorityType(int npcType)
        => npcType == NPCID.EaterofWorldsHead || npcType == NPCID.Golem || npcType == NPCID.MoonLordCore;

    /// <summary>
    /// <br/>无尽虚空(灾厄):指定走ModBossBar途径,不覆盖灾厄BossHPUI。
    /// </summary>
    internal static bool IsCeaselessVoidType(int npcType) => npcType == ceaselessVoidType;

    /// <summary>
    /// <br/>极地之灵(灾厄):指定走ModBossBar途径,不覆盖灾厄BossHPUI。
    /// </summary>
    internal static bool IsCryogenType(int npcType) => npcType == cryogenType;

    /// <summary>
    /// <br/>每帧每个多体节Boss(世吞/石巨人/月总)只注册一个drawEvent,返回false表示本帧该Boss已经有血条了,跳过。
    /// </summary>
    internal static bool TryRegisterVanillaBarDraw(int npcType)
    {
        if (!IsVanillaSumPriorityType(npcType))
            return true;

        ulong frame = Main.GameUpdateCount;
        if (frame != VanillaDrawnFrame)
        {
            VanillaDrawnFrame = frame;
            VanillaDrawnThisFrame.Clear();
        }
        return VanillaDrawnThisFrame.Add(npcType);
    }

    /// <summary>
    /// <br/>NPC死亡/移除时立刻清掉这个实体的所有缓存,防止whoAmI槽位被新Boss复用后串用旧数据。
    /// </summary>
    internal static void RemoveNPC(NPC npc)
    {
        if (npc == null)
            return;
        BossHPUICache.Remove(npc.whoAmI);
        FrameStates.Remove(npc.whoAmI);
        InfoCache.Remove(npc.whoAmI);
        CanHaveCache.Remove(npc.type);
    }

    /// <summary>
    /// <br/>进入新世界时清空所有缓存,防止上一场战斗的InitialMaxLife等状态残留给同类型Boss。
    /// </summary>
    internal static void ClearCaches()
    {
        BossHPUICache.Clear();
        FrameStates.Clear();
        InfoCache.Clear();
        CanHaveCache.Clear();
        VanillaDrawnThisFrame.Clear();
        VanillaDrawnFrame = ulong.MaxValue;
    }

    /// <summary>
    /// <br/>兼容旧的调用方式:返回 (CombinedNPCLife, CombinedNPCMaxLife, InitialMaxLife)。
    /// </summary>
    internal static (long?, long?, long?) DoSomeReflection(int npcIndex, int npcType)
    {
        if (!YuBellBossBar.CalamityAdapt || !CalamityLoaded)
            return (null, null, null);
        if (npcIndex < 0 || npcIndex >= Main.npc.Length)
            return (null, null, null);

        NPC npc = Main.npc[npcIndex];
        if (npc == null || !npc.active || npc.type != npcType)
            return (null, null, null);

        CalamityBarInfo info = GetInfo(npc);
        return (info.Life, info.LifeMax, info.InitialMaxLife);
    }

    /// <summary>
    /// <br/>获取(或创建)这个NPC对应的灾厄BossHPUI实例,并调用一次Update()刷新状态。
    /// <br/>缓存实例是为了让InitialMaxLife跨帧保持;NPC死亡时由RemoveNPC清理。
    /// </summary>
    private static object GetOrCreateBossHPUI(NPC npc)
    {
        if (BossHPUICache.TryGetValue(npc.whoAmI, out object ui) && IsSameNPC(ui, npc))
        {
            bossHPUIUpdateMethod.Invoke(ui, null);
            return ui;
        }

        // 创建BossHPUI实例 -> 手动设置IntendedNPCType -> 调用Update()(和旧反射代码一致)
        ui = bossHPUIConstructor.Invoke(new object[] { npc.whoAmI, null });
        intendedNPCTypeField.SetValue(ui, npc.type);
        bossHPUIUpdateMethod.Invoke(ui, null);

        BossHPUICache[npc.whoAmI] = ui;

        // whoAmI会被复用,防止缓存无限增长
        if (BossHPUICache.Count > Main.maxNPCs + 32)
            PruneCache();

        return ui;
    }

    /// <summary>
    /// <br/>校验缓存的BossHPUI是否仍对应当前NPC(槽位相同且类型相同,防止whoAmI复用串数据)。
    /// </summary>
    private static bool IsSameNPC(object ui, NPC npc)
    {
        if (associatedNPCProperty == null)
            return false;
        NPC assoc = associatedNPCProperty.GetValue(ui) as NPC;
        return assoc != null && assoc.active && assoc.whoAmI == npc.whoAmI && assoc.type == npc.type;
    }

    /// <summary>
    /// <br/>清理BossHPUI实例缓存:删除已失效(未活跃)NPC对应的条目。
    /// </summary>
    private static void PruneCache()
    {
        List<int> dead = null;
        foreach (KeyValuePair<int, object> pair in BossHPUICache)
        {
            NPC assoc = associatedNPCProperty?.GetValue(pair.Value) as NPC;
            if (assoc == null || !assoc.active)
            {
                dead ??= new List<int>();
                dead.Add(pair.Key);
            }
        }
        if (dead != null)
            foreach (int key in dead)
                BossHPUICache.Remove(key);
    }

    /// <summary>
    /// <br/>反射读取灾厄CalamityGlobalNPC.CanHaveBossHealthBar,按NPC类型缓存结果(每类型只反射一次)。
    /// </summary>
    private static bool CanHaveBossHealthBar(NPC npc)
    {
        if (CanHaveCache.TryGetValue(npc.type, out bool cached))
            return cached;

        bool result = false;
        try
        {
            if (getCalamityGlobalNPCMethod == null || canHaveBossHealthBarField == null)
                return false;
            object global = getCalamityGlobalNPCMethod.Invoke(npc, null);
            result = global != null && (bool)canHaveBossHealthBarField.GetValue(global);
        }
        catch
        {
            result = false;
        }
        CanHaveCache[npc.type] = result;
        return result;
    }

    /// <summary>
    /// <br/>复刻灾厄 AttemptToAddBar 里给 Apollo(Exo Twins) 的覆盖名:
    /// <br/>CalamityUtils.GetTextValue("UI.ExoTwinsName" + (exoMechdusa ? "Hekate" : "Normal"))
    /// </summary>
    private static string GetCalamityOverridingName(NPC npc)
    {
        try
        {
            if (apolloType == null || npc.ModNPC == null || npc.ModNPC.GetType() != apolloType)
                return null;

            bool exoMechdusa = apolloExoMechdusaField != null && (bool)apolloExoMechdusaField.GetValue(npc.ModNPC);
            if (calamityGetTextValueMethod != null)
            {
                string localized = (string)calamityGetTextValueMethod.Invoke(null, new object[] { "UI.ExoTwinsName" + (exoMechdusa ? "Hekate" : "Normal") });
                // 汉化包或旧版本可能没有这个键,Language会原样返回键名,这时用兜底名
                if (!string.IsNullOrEmpty(localized) && !localized.Contains("ExoTwinsName"))
                    return localized;
            }

            return exoMechdusa ? "Hekate" : "Exo Twins";
        }
        catch
        {
            return null;
        }
    }
}
