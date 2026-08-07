namespace YuBellBossBar.Content;

public class BarPlayer : ModPlayer
{

    public override void PostUpdate()
    {
        // 每帧更新所有已注册血条事件的淡出:死亡/失活的NPC淡出到0后自动从事件订阅移除
        BarGlobalNPC.UpdateFades();

        // 如果没有Boss在场就移除索引
        // 一定要在这里判断,要不然就会导致死的时候场上还有Boss就永远不可能运行代码了
        // if there is no boss in the field, remove all indexs
        // You must judge here, otherwise, if there is still a boss in the field when you die, it will never allow the code to run.
        if (!Main.CurrentFrameFlags.AnyActiveBossNPC)
        {
            // 移除所有索引
            // Remove all indexs

            BarLifeMethods.lifemaxs.Clear();
            BarLifeMethods.maxlifes.Clear();
        }
    }

    public override void OnEnterWorld()
    {
        // 进入新世界清空灾厄适配的所有缓存,防止上一场战斗的InitialMaxLife等残留给同类型Boss
        CalamityBarHealth.ClearCaches();

        if (BarConfig.Instance.OnEnterWorldInfo)
        {
            Main.NewText(Language.GetTextValue("Mods.YuBellBossBar.Info.OnEnterWorld"));
        }

        // 世吞太傻逼了,这样才能在是否清除索引时让世吞被判断为在场的Boss
        // The Eater of World is too stupid, this is the only way to make it be judged as a boss in the field when checking whether to remove indexs or not.
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsHead] = true;
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsBody] = true;
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsTail] = true;
    }
}
