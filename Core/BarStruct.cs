namespace YuBellBossBar.Core;

// TODO: 这个结构体是用来存储Boss血条的参数的,还未完成
// TODO: This struct is used to store the parameters of the boss bar, and it is not completed yet
internal struct VBarParams
{
    public float life;
    public float lifemax;

    public float pastlife;

    public BossBarDrawParams drawParams;

    public VBarParams(ref BossBarDrawParams drawParams)
    {
        this.drawParams = drawParams;
    }
}

internal ref struct VBarRefParams
{
    public BossBarDrawParams drawParams;
}
