using Terraria;
using Terraria.ModLoader;

namespace YuBellBossBar.Content
{
    public class BarSystem : ModSystem
    {
        public override void PostUpdatePlayers()
        {
            if (BarPlayer.LastHit <= 5)
            {
                BarPlayer.LastHit++;
            }
            else
            {
                BarPlayer.LastHit = 5;
            }
        }
    }
    
    public class BarPlayer : ModPlayer
    {
        public static int LastHit = 0;

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            LastHit = 0;
        }
    }
}
