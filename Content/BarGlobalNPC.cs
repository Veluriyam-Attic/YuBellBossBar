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
    public Func<SpriteBatch, Vector2,int> DrawHandler;

    /// <summary>whoAmI -> 当前注册的委托,用于"添加过这个NPC的事件就删旧加新"</summary>
    internal static readonly Dictionary<int, BarGlobalNPC> DrawnHandlers = new();

    public override bool InstancePerEntity => true;

    public override void OnKill(NPC npc)
    {
        // NPC死亡后立刻清掉该实体的缓存,防止槽位被新Boss复用后串用旧数据
        CalamityBarHealth.RemoveNPC(npc);
        CachedBossHead = null;
        DrawsMethods.ResetPostHealth();
        // 死亡时不直接移除委托:由UpdateFades每帧自减FadeAlpha,淡出到0后才从事件订阅移除
    }


    public override void PostAI(NPC npc)
    {
        // 头像索引有效就刷新缓存;无效时由Draw使用缓存,缓存为空才回退默认头像
        int headIndex = npc.GetBossHeadTextureIndex();
        if (headIndex >= 0)
            CachedBossHead = TextureAssets.NpcHeadBoss[headIndex];

        bool bossLike = npc.boss
            || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail
            || npc.type == NPCID.LunarTowerSolar || npc.type == NPCID.LunarTowerVortex
            || npc.type == NPCID.LunarTowerNebula || npc.type == NPCID.LunarTowerStardust;

        bool shouldAdd = npc.active && !CalamityBarHealth.IsVanillaMultiPartSideType(npc.type)
            && CalamityBarHealth.TryRegisterVanillaBarDraw(npc.type)
            && (bossLike || CalamityBarHealth.ShouldForceDrawBar(npc) || headIndex >= 0) && !CalamityBarHealth.ShouldHideBar(npc);

        if (shouldAdd)
        {
            DrawsMethods.npc = npc;

            // 本帧重新添加事件,淡出重置回上限255
            FadeAlpha = 255f;

            // 删旧加新(按whoAmI):先从事件订阅移除自己上次添加的委托,再添加新的,防止重复
            if (DrawHandler != null)
                YAB.drawEvent -= DrawHandler;

            DrawHandler = DrawsMethods.Draw;
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
}
