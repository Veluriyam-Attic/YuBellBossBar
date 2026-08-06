namespace YuBellBossBar.Content;

internal class BarGlobalNPC : GlobalNPC
{
    public BarDrawsMethods DrawsMethods = new();

    /// <summary>
    /// <br/>缓存这个NPC有效时的Boss头像。
    /// <br/>灾厄Boss在BossHeadSlot里会把索引设为-1(如阿瑞斯爆甲阶段),这时用缓存头像而不是回退到甜心。
    /// </summary>
    public Asset<Texture2D> CachedBossHead;

    public override bool InstancePerEntity => true;

    public override void OnKill(NPC npc)
    {
        // NPC死亡后立刻清掉该实体的缓存,防止槽位被新Boss复用后串用旧数据
        CalamityBarHealth.RemoveNPC(npc);
        CachedBossHead = null;
        DrawsMethods.ResetPostHealth();
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

        if (npc.active && !CalamityBarHealth.IsVanillaMultiPartSideType(npc.type)
            && CalamityBarHealth.TryRegisterVanillaBarDraw(npc.type)
            && (bossLike || CalamityBarHealth.ShouldForceDrawBar(npc) || headIndex >= 0) && !CalamityBarHealth.ShouldHideBar(npc))
        {
            DrawsMethods.npc = npc;
            YAB.drawEvent += DrawsMethods.Draw;
        }
    }
}
