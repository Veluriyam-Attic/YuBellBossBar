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
        private static int id = -1;

        private static float Health;
        private static float Last;
        private static int Timer;


        public static float GetPostHealth(int npcId, float percentage)
        {
            // 当前显示对象改变
            if (id != npcId)
            {
                id = npcId;
                Health = Last = percentage;
                Timer = 0;
                return Health;
            }

            // 回血同步
            if (percentage > Health)
                Health = percentage;

            // 掉血
            if (percentage < Last)
            {
                Timer = 0;
            }
            else
            {
                Timer++;

                if (Timer >= BarConfig.Instance.PostHealthTime)
                {
                    Health = Math.Max(
                        Health - (float)BarConfig.Instance.PostHealthSpeed / BarConfig.Instance.BarLength,
                        percentage);
                }
            }

            Last = percentage;

            return Health;
        }
    }
}
