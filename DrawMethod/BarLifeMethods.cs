namespace YuBellBossBar.DrawMethod
{
    internal class BarLifeMethods
    {
        public static void Calculation(int npcwhoami)
        {

        }
    }

    internal static class PostHealthSystem
    {
        private static readonly float[] Health = new float[NPCLoader.NPCCount];
        private static readonly float[] Last = new float[NPCLoader.NPCCount];
        private static readonly int[] Timer = new int[NPCLoader.NPCCount];

        public static float GetPostHealth(int type, float percentage)
        {
            if (Health[type] == 0f)
                Health[type] = Last[type] = percentage;

            // 回血立即同步
            if (Health[type] < percentage)
                Health[type] = percentage;

            // 继续掉血，重新计时
            if (percentage < Last[type])
                Timer[type] = 0;

            // 停止掉血，开始缩减延迟血条
            else if (++Timer[type] >= BarConfig.Instance.PostHealthTime && Health[type] > percentage)
                Health[type] = Math.Max(Health[type] - ((float)BarConfig.Instance.PostHealthSpeed / (float)BarConfig.Instance.BarLength), percentage);

            Last[type] = percentage;

            return Health[type];
        }
    }
}
