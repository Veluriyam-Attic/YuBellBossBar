namespace YuBellBossBar.Content;

internal class BarGlobalNPC : GlobalNPC
{
    public BarDrawsMethods DrawsMethods = new();

    public override bool InstancePerEntity => true;

    public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
    {

        if (npc.active && (npc.boss || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail || npc.type == NPCID.LunarTowerSolar || npc.type == NPCID.LunarTowerVortex || npc.type == NPCID.LunarTowerNebula || npc.type == NPCID.LunarTowerStardust))
        {
            DrawsMethods.npc = npc;

            YAB.drawEvent += DrawsMethods.Draw;
        }

        return base.PreDraw(npc,spriteBatch,screenPos,drawColor);
    }
}

