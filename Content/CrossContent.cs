using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace YuBellBossBar.Content
{
    public class CrossBar : ModSystem
    {
        public override void PostSetupContent()
        {
            Mod thisbar;
            ModLoader.TryGetMod("YuBellBossBar",out thisbar);
            Mod fargosouls;
            if (ModLoader.TryGetMod("FargowiltasSouls",out fargosouls))
            {
                ModLoader.TryGetMod("FargowiltasSouls", out fargosouls);
                thisbar.Call("BellBarAddColor",fargosouls.Find<ModNPC>("DeviBoss").Type , (Color?)new Color(255, 0, 147));
                thisbar.Call("BellBarAddColor", fargosouls.Find<ModNPC>("AbomBoss").Type, (Color?)Color.Orange);
                thisbar.Call("BellBarAddColor", fargosouls.Find<ModNPC>("MutantBoss").Type, (Color?)new Color(10, 255, 210));
            }

        }
    }
}
