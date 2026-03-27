namespace YuBellBossBar.Content;

public class VBarPlayer : ModPlayer
{
    public static event Action RemoveIndexs;

    public override void PostUpdate()
    {
        // 当没有Boss在场时,在这里移除所有索引
        // when there's no boss in field,remove all index
        RemoveIndexs?.Invoke();
        RemoveIndexs = null;
    }

    public override void OnEnterWorld()
    {
        // 世吞太傻逼了,这样才能在是否清除索引时让世吞被判断为在场的Boss
        // The Eater of World is too stupid, this is the only way to make it be judged as a boss in the field when checking whether to remove indexs or not.
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsHead] = true;
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsBody] = true;
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsTail] = true;
    }
}
