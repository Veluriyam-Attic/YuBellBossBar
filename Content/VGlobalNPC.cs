namespace YuBellBossBar.Content;

internal class VGlobalNPC : GlobalNPC
{
    public override bool InstancePerEntity => true;

    public override void OnSpawn(NPC npc, IEntitySource source)
    {
        // 如果不同时满足以下条件则不添加血条
        // if does not meet the following conditions, do not add the health bar
        if (!npc.boss) return;
        if (!YAB.Selected) return;

        
    }
}
