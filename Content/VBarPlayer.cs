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
}
