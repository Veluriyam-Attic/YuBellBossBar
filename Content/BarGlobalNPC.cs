namespace YuBellBossBar.Content;

internal class BarGlobalNPC : GlobalNPC
{
    public BarDrawsMethods DrawsMethods = new();

    /// <summary>
    /// <br/>缓存这个NPC有效时的Boss头像。
    /// <br/>灾厄Boss在BossHeadSlot里会把索引设为-1(如阿瑞斯爆甲阶段),这时用缓存头像而不是回退到甜心。
    /// </summary>
    public Asset<Texture2D> CachedBossHead;

    /// <summary>淡出字段:最大255,每帧自减,Draw的GlobalAlpha乘以 FadeAlpha/255;减到0自动移除本NPC的事件</summary>
    public float FadeAlpha = 255f;

    /// <summary>本NPC当前注册到drawEvent上的委托(用于按whoAmI删旧加新和自移除)</summary>
    public Func<BarDrawsMethods> DrawHandler;

    /// <summary>whoAmI -> 当前注册的委托,用于"添加过这个NPC的事件就删旧加新"</summary>
    internal static readonly Dictionary<int, BarGlobalNPC> DrawnHandlers = new();

    public override bool InstancePerEntity => true;

    public override void OnKill(NPC npc)
    {
        // NPC死亡后立刻清掉该实体的缓存,防止槽位被新Boss复用后串用旧数据
        CalamityBarHealth.RemoveNPC(npc);
        CachedBossHead = null;
        DrawsMethods.ResetPostHealth();
        // Boss死后AI不再调用,血量/缓存会停留在上一帧;
        // 在死亡入口把数据源清零(保留上限),让淡出期间显示空血而不是残留血量
        DrawsMethods.MarkDead(npc);
        // 保留委托:由UpdateFades每帧自减FadeAlpha,淡出到0后才从事件订阅移除
    }


    public override void PostAI(NPC npc)
    {
        if (npc.type == NPCID.CultistBossClone || !npc.active)
            return;


        // 距离条件:仅当NPC与本地玩家(客户端视角)的距离 <= 5000 像素时才显示血条。
        // 超出范围立刻把淡出系数清零,并走下方 else 分支移除委托,血条不再显示。
        // 使用平方距离避免每帧开方;以本地玩家为参照,多人时各客户端按自己判断。
        const float MaxShowDistance = 5000f;
        bool inRange = Vector2.DistanceSquared(npc.Center, Main.LocalPlayer.Center) <= MaxShowDistance * MaxShowDistance;
        if (!inRange)
            FadeAlpha = 0;

        // 头像索引有效就刷新缓存;无效时由Draw使用缓存,缓存为空才回退默认头像
        int headIndex = npc.GetBossHeadTextureIndex();
        if (headIndex >= 0)
            CachedBossHead = TextureAssets.NpcHeadBoss[headIndex];
        else if (CachedBossHead == null && npc.type != NPCID.MoonLordCore && npc.type != NPCID.Golem)
            return;

        bool bossLike = npc.boss
            || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail
            || npc.type == NPCID.LunarTowerSolar || npc.type == NPCID.LunarTowerVortex
            || npc.type == NPCID.LunarTowerNebula || npc.type == NPCID.LunarTowerStardust;

        // 来自灾厄模组的Boss:跳过原版 BossBar 有效性检验,避免灾厄把 npc.BossBar 设为 NeverValid 时血条不注册
        bool isCalamityNpc = CalamityBarHealth.IsCalamityNpc(npc);
        // 神秘传送门(旧日军团传送门)不显示任何血条
        // Mysterious Portal (Old One's Army portal) never gets a boss bar
        bool shouldAdd = npc.active && npc.type != NPCID.DD2LanePortal
            && inRange
            && !CalamityBarHealth.IsVanillaMultiPartSideType(npc.type)
            && CalamityBarHealth.TryRegisterVanillaBarDraw(npc.type)
            && (bossLike || CalamityBarHealth.ShouldForceDrawBar(npc) || headIndex >= 0) && !CalamityBarHealth.ShouldHideBar(npc)
            && (isCalamityNpc || npc.BossBar != Main.BigBossProgressBar.NeverValid || npc.type == NPCID.DungeonGuardian);

        if (shouldAdd)
        {
            DrawsMethods.npc = npc;

            // 本帧重新添加事件,淡出重置回上限255
            FadeAlpha = 255f;

            // 同一个 whoAmI 槽位可能已被新NPC复用:先移除旧实例的委托,
            // 否则旧实例会从 DrawnHandlers 中"孤儿化",淡出永远卡住、血条残留
            if (DrawnHandlers.TryGetValue(npc.whoAmI, out BarGlobalNPC oldSlot) && oldSlot != this)
                oldSlot.RemoveDrawHandler();

            // 世吞/石巨人/月总这类多段Boss:新主实体注册时,把同组正在淡出的旧血条立即移除,
            // 避免"旧血条淡出 + 新血条显示"同时存在,出现多根血条
            if (CalamityBarHealth.IsVanillaSumPriorityType(npc.type))
                RemoveSameBossGroupHandlers(npc.type);

            // 删旧加新(按whoAmI):先从事件订阅移除自己上次添加的委托,再添加新的,防止重复
            if (DrawHandler != null)
                YAB.drawEvent -= DrawHandler;

            DrawHandler = () => DrawsMethods;
            YAB.drawEvent += DrawHandler;
            DrawnHandlers[npc.whoAmI] = this;
        }
        else
        {
            // 不再满足添加条件(还活跃):每帧自减淡出,减到0就从事件订阅移除本NPC的委托
            FadeAlpha = Math.Max(0f, FadeAlpha - 5f);
            if (FadeAlpha <= 0f)
                RemoveDrawHandler();
        }
    }

    /// <summary>
    /// <br/>每帧全局更新所有已注册事件的淡出。
    /// <br/>NPC已死亡或不再活跃时,FadeAlpha每帧自减,减到0就从事件订阅移除该实体的委托(其它事件不受影响)。
    /// </summary>
    internal static void UpdateFades()
    {
        if (DrawnHandlers.Count == 0)
            return;

        List<int> toRemove = null;
        foreach (KeyValuePair<int, BarGlobalNPC> kv in DrawnHandlers)
        {
            BarGlobalNPC barGlobal = kv.Value;
            NPC npc = barGlobal.DrawsMethods?.npc;
            if (npc == null || !npc.active)
            {
                barGlobal.FadeAlpha = Math.Max(0f, barGlobal.FadeAlpha - 5f);
                if (barGlobal.FadeAlpha <= 0f)
                {
                    toRemove ??= new List<int>();
                    toRemove.Add(kv.Key);
                }
            }
        }

        if (toRemove != null)
            foreach (int key in toRemove)
                if (DrawnHandlers.TryGetValue(key, out BarGlobalNPC barGlobal))
                    barGlobal.RemoveDrawHandler();
    }

    /// <summary>
    /// <br/>移除本NPC注册在drawEvent上的事件,其它NPC的事件不受影响。
    /// </summary>
    internal void RemoveDrawHandler()
    {
        if (DrawHandler == null)
            return;

        // 直接从事件订阅移除本NPC的委托(其它NPC的事件不受影响)
        YAB.drawEvent -= DrawHandler;

        // 清理按whoAmI记录的实例条目(指向本实例的都移除)
        List<int> stale = null;
        foreach (KeyValuePair<int, BarGlobalNPC> kv in DrawnHandlers)
        {
            if (kv.Value == this)
            {
                stale ??= new List<int>();
                stale.Add(kv.Key);
            }
        }
        if (stale != null)
            foreach (int key in stale)
                DrawnHandlers.Remove(key);

        DrawHandler = null;
    }

    /// <summary>
    /// <br/>移除指定Boss组(世吞/石巨人/月总)的所有已注册血条委托,
    /// <br/>保证该组同一时间只存在一根血条,防止多根血条同时淡出。
    /// </summary>
    private static void RemoveSameBossGroupHandlers(int npcType)
    {
        List<BarGlobalNPC> remove = null;
        foreach (KeyValuePair<int, BarGlobalNPC> kv in DrawnHandlers)
        {
            BarGlobalNPC other = kv.Value;
            NPC otherNpc = other?.DrawsMethods?.npc;
            if (otherNpc != null && otherNpc.type == npcType)
            {
                remove ??= new List<BarGlobalNPC>();
                remove.Add(other);
            }
        }

        if (remove != null)
            foreach (BarGlobalNPC other in remove)
                other.RemoveDrawHandler();
    }
}
