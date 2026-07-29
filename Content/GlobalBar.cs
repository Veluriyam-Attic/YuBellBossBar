namespace YuBellBossBar.Content;

internal class GlobalBar : GlobalBossBar
{
#pragma warning disable IDE0090,IDE0028
    // lifemax
    public static Dictionary<int, float> lifemaxs = new Dictionary<int, float>();
    // the max value of life
    public static Dictionary<int, float> maxlifes = new Dictionary<int, float>();

    public override bool PreDraw(SpriteBatch spriteBatch, NPC npc, ref BossBarDrawParams drawParams)
    {
        if (YAB.Selected)
        {
            if (BarConfig.Instance.ImprovedLifeCalculation)
            {
                #region 忘了写的什么了，应该是计算血量的最大值和当前值的，反正就是计算血量的
                bool containskey = lifemaxs.ContainsKey(npc.type) && maxlifes.ContainsKey(npc.type);

                if (!containskey)
                {
                    lifemaxs.TryAdd(npc.type, drawParams.LifeMax);
                    maxlifes.TryAdd(npc.type, drawParams.Life);
                }

                if (YuBellBossBar.CalamityAdapt && CalamityBarHealth.CalamityLoaded)
                {
                    if (CalamityBarHealth.OneToMany.TryGetValue(npc.type, out int[] typeArrary))
                    {
                        // 反射获取灾厄Boss血条的数值
                        // Use reflection to get the values of Calamity Mod's boss bar
                        (long?, long?, long?) values = CalamityBarHealth.DoSomeReflection(npc.whoAmI, npc.type);
                        drawParams.Life = (float)values.Item1;
                        drawParams.LifeMax = (float)values.Item3;

                        // 用来解决多体节在词典中数值不同步的特殊情况
                        // Used to solve the special case where multiple segments have different values in the dictionary
                        {
                            // 改为最初的血量上限
                            if (maxlifes[npc.type] < drawParams.Life)
                                maxlifes[npc.type] = drawParams.Life;

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
                    if (maxlifes[npc.type] < drawParams.Life)
                        maxlifes[npc.type] = drawParams.Life;
                }

                drawParams.LifeMax = maxlifes[npc.type];
                #endregion
            }

            YAB.npc = npc;
            YAB.drawParams = drawParams;

            return false;
        }
        return true;
    }
}