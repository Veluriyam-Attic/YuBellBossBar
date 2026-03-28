namespace YuBellBossBar.Content;

internal class BarGlobalNPC : GlobalNPC
{
    public override bool InstancePerEntity => true;

    public override void AI(NPC npc)
    {
        if(npc.BossBar != null && YAB.Selected)
        {
        }
    }

    public override void OnKill(NPC npc)
    {

        if (npc.BossBar != null && YAB.Selected)

        BarPlayer.RemoveIndexs += () =>
        {
            // 如果没有Boss在场就移除索引
            // 一定要在这里判断,要不然就会导致死的时候场上还有Boss就永远不可能运行代码了
            // if there is no boss in the field, remove all indexs
            // You must judge here, otherwise, if there is still a boss in the field when you die, it will never allow the code to run.
            if (!Main.CurrentFrameFlags.AnyActiveBossNPC)
            {
                // 移除所有索引
                // Remove all indexs

                GlobalBar.lifemaxs.Clear();
                GlobalBar.maxlifes.Clear();
#if DEBUG
                Main.NewText("Removed All Index!" + npc.type);
#endif
            }
        };
    }
}
