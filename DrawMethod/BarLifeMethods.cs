namespace YuBellBossBar.DrawMethod;

internal class BarLifeMethods
{

#pragma warning disable IDE0090, IDE0028
    // lifemax
    public static Dictionary<int, float> lifemaxs = new Dictionary<int, float>();
    // the max value of life
    public static Dictionary<int, float> maxlifes = new Dictionary<int, float>();

    public static void Calculation(NPC npc,float Life,float LifeMax)
    {
        if (YAB.Selected)
        {
            if (BarConfig.Instance.ImprovedLifeCalculation)
            {
                #region 忘了写的什么了，应该是计算血量的最大值和当前值的，反正就是计算血量的
                bool containskey = lifemaxs.ContainsKey(npc.type) && maxlifes.ContainsKey(npc.type);

                if (!containskey)
                {
                    lifemaxs.TryAdd(npc.type, LifeMax);
                    maxlifes.TryAdd(npc.type, Life);
                }

                if (YuBellBossBar.CalamityAdapt && CalamityBarHealth.CalamityLoaded)
                {
                    if (CalamityBarHealth.OneToMany.TryGetValue(npc.type, out int[] typeArrary))
                    {
                        // 反射获取灾厄Boss血条的数值
                        // Use reflection to get the values of Calamity Mod's boss bar
                        (long?, long?, long?) values = CalamityBarHealth.DoSomeReflection(npc.whoAmI, npc.type);
                        Life = (float)values.Item1;
                        LifeMax = (float)values.Item3;

                        // 用来解决多体节在词典中数值不同步的特殊情况
                        // Used to solve the special case where multiple segments have different values in the dictionary
                        {
                            // 改为最初的血量上限
                            if (maxlifes[npc.type] < Life)
                                maxlifes[npc.type] = Life;

                            typeArrary = CalamityBarHealth.OneToMany[npc.type];

                            // 同步所有体节在词典中的数值
                            float maxValueOfLifemax = typeArrary.Where(key => lifemaxs.ContainsKey(key)).Select(key => lifemaxs[key]).DefaultIfEmpty(float.MinValue).Max();
                            float maxValueOfLife = typeArrary.Where(key => maxlifes.ContainsKey(key)).Select(key => maxlifes[key]).DefaultIfEmpty(float.MinValue).Max();

                            if (maxValueOfLifemax != float.MinValue && maxlifes.ContainsKey(npc.type))
                            {
                                foreach (int type in typeArrary)
                                {
                                    lifemaxs[type] = maxValueOfLifemax;
                                    maxlifes[type] = maxValueOfLife;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (maxlifes[npc.type] < Life)
                        maxlifes[npc.type] = Life;
                }

                LifeMax = maxlifes[npc.type];
                #endregion
            }
        }
    }
}

internal class PostHealthSystem
{
    private int id = -1;

    private float Health;
    private float Last;
    private int Timer;


    public float GetPostHealth(int npcId, float percentage)
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

