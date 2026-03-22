namespace YuBellBossBar;
public class YuBellBossBar : Mod
{
    internal static void Tool(string text) => Main.spriteBatch.DrawString(FontAssets.MouseText.Value, "   Jerk off is the best activity!" + text, Main.MouseScreen, Color.White);

    public override void Load()
    {        
        // 世吞太傻逼了,这样才能在是否清除索引时让世吞被判断为在场的Boss
        // The Eater of World is too stupid, this is the only way to make it be judged as a boss in the field when checking whether to remove indexs or not.
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsHead] = true;
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsBody] = true;
        NPCID.Sets.DangerThatPreventsOtherDangers[NPCID.EaterofWorldsTail] = true;

        // 初始时清除所有数
        // remove the boss bar count when load, otherwise the count will be wrong when reload the mod
        Array.Clear(YAB.BarCount,0,VBarConfig.Instance.BarCount);
    }
}
