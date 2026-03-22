namespace YuBellBossBar.Content;

internal class VGlobalBar : GlobalBossBar
{
    public static Dictionary<int, float> lifemaxs = new Dictionary<int, float>();

    public override bool PreDraw(SpriteBatch spriteBatch, NPC npc, ref BossBarDrawParams drawParams)
    {
        if (YAB.Selected)
        {

            // 用来防止血量上限没有当前血量大的情况
            // Used to prevent the situation where the current life is greater than the life max
            {
                // 如果血量大于血量上限
                // If the current life is greater than the life max
                if (drawParams.Life >= drawParams.LifeMax)
                    // 在词典添加血量上限,以npc.type为索引
                    // If the current life is greater than or equal to the life max, add the current life as the life max in the dictionary with npc.type as the index
                    lifemaxs.TryAdd(npc.type, drawParams.Life);
                // 否则
                // Otherwise
                else
                    // 在词典添加血量上限,以npc.type为索引
                    // add the current life max in the dictionary with npc.type as the index
                    lifemaxs.TryAdd(npc.type, drawParams.LifeMax);

                // 先试图获取一下血量上限
                // Try to get the life max from the dictionary first
                lifemaxs.TryGetValue(npc.type, out float lifemax);

                // 如果血量大于血量上限并且从词典获得到的血量上限不为0
                // 必须要写这步.不然血条会闪
                // if the current life is greater than the life max and the life max obtained from the dictionary is not 0, update the life max in the dictionary to the current life
                // This step must be written, otherwise the health bar will flash
                if (drawParams.Life > lifemax && lifemax != 0)
                    // 词典中血量上限就改为当前血量
                    // Update the life max in the dictionary to the current life
                    lifemaxs[npc.type] = drawParams.Life;

                // 对drawParams的血量上限赋值为当前记录的最大血量上限
                // Assign the life max of drawParams to the current recorded maximum life max
                lifemaxs.TryGetValue(npc.type, out drawParams.LifeMax);
            }

            {
                // 如果参数词典中已经有这个npc.type的参数了就更新一下,没有的话就添加一个
                // if the parameter dictionary already has the parameters for this npc.type, update it; if not, add a new one
                if (VBarData.BarParams.Keys.Contains(npc.type))
                    VBarData.BarParams[npc.type] = new VBarParams(ref drawParams);
                else
                    VBarData.BarParams.Add(npc.type, new VBarParams(ref drawParams));
            }

#if DEBUG
            YuBellBossBar.Tool(VBarData.BarParams[npc.type].drawParams.Life + "/" + VBarData.BarParams[npc.type].drawParams.LifeMax + "/" + npc.realLife);
            return true;
#else
            return false;
#endif
        }
        return true;
    }
}

