namespace YuBellBossBar.Content;

internal class GlobalBar : GlobalBossBar
{

    public override bool PreDraw(SpriteBatch spriteBatch, NPC npc, ref BossBarDrawParams drawParams)
    {
        return !YAB.Selected;
    }
}