namespace YuBellBossBar.Content;

internal class VGlobalBar : GlobalBossBar
{
    internal Dictionary<int, float> lifemaxs = new Dictionary<int, float>();

    internal delegate void RemoveIndexHandler(ref BossBarDrawParams drawParams);
    internal static event RemoveIndexHandler RemoveIndex;

    public override bool PreDraw(SpriteBatch spriteBatch, NPC npc, ref BossBarDrawParams drawParams)
    {
        if (YAB.Selected)
        {

            // 用来防止血量上限没有当前血量大的情况
            // Used to prevent the situation where the current life is greater than the life max
            {
                if (drawParams.Life >= drawParams.LifeMax)
                    lifemaxs.TryAdd(drawParams.GetHashCode(), drawParams.Life);

                lifemaxs.TryGetValue(drawParams.GetHashCode(), out float lifemax);

                if (drawParams.Life > lifemax && lifemax != 0)
                {
                    lifemaxs[drawParams.GetHashCode()] = drawParams.Life;
                }

                lifemaxs.TryGetValue(drawParams.GetHashCode(), out drawParams.LifeMax);
            }

            {
                if (VBarData.BarParams.Keys.Contains(drawParams.GetHashCode()))
                    VBarData.BarParams[drawParams.GetHashCode()] = new VBarParams(ref drawParams);
                else
                    VBarData.BarParams.Add(drawParams.GetHashCode(), new VBarParams(ref drawParams));
            }

#if DEBUG
            YuBellBossBar.Tool(VBarData.BarParams[drawParams.GetHashCode()].drawParams.Life + "/" + VBarData.BarParams[drawParams.GetHashCode()].drawParams.LifeMax + $"\r" + VBarData.BarParams[drawParams.GetHashCode()].HashCode + "////" + VBarData.BarParams[drawParams.GetHashCode()].drawParams.GetHashCode());
#endif
            return false;
        }
        return true;
    }
}

