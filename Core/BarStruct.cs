namespace YuBellBossBar.Core;

internal struct VBarParams
{
    public int HashCode;

    public float life;
    public float lifemax;

    public float pastlife;

    public BossBarDrawParams drawParams;

    public VBarParams(ref BossBarDrawParams drawParams)
    {
        this.drawParams = drawParams;
        this.HashCode = drawParams.GetHashCode();
    }
}

internal ref struct VBarRefParams
{
    public BossBarDrawParams drawParams;
}
