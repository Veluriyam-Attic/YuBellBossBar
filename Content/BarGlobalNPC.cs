namespace YuBellBossBar.Content;

internal class BarGlobalNPC : GlobalNPC
{
    public override bool InstancePerEntity => true;

    public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
    {

        if (npc.active && npc.BossBar != null)
        {

        }

        return base.PreDraw(npc,spriteBatch,screenPos,drawColor);
    }
}

