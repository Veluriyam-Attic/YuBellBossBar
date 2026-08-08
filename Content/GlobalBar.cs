namespace YuBellBossBar.Content;

internal class GlobalBar : GlobalBossBar
{
    public override bool PreDraw(SpriteBatch spriteBatch, NPC npc, ref BossBarDrawParams drawParams)
    {
        // 神秘传送门(旧日军团传送门)不显示任何血条
        // Mysterious Portal (Old One's Army portal) never gets a boss bar
        if (npc.type == NPCID.DD2LanePortal)
            return false;

        return !YAB.Selected;
    }
}
