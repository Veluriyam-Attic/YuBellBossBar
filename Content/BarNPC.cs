using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

//the name of the mod is a joke
namespace BestBossBarMod.Content;

public class BarNPC : GlobalNPC
{
    public override bool InstancePerEntity => true;
	public float endPosition;
	public float lastPositon;
    public int LastHit = BarConfig.Instance.TransparencyBarDecreaseTime;
    public override void OnKill(NPC npc)
	{

	}

    public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
    {
        LastHit = 0;
    }

    public override void AI(NPC npc)
    {
        if (LastHit <= BarConfig.Instance.TransparencyBarDecreaseTime)
        {
            LastHit++;
        }
        else
        {
            LastHit = BarConfig.Instance.TransparencyBarDecreaseTime;
        }
    }
}
