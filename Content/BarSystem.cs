using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

//the name of the mod is a joke
namespace BestBossBarMod.Content;

public class BarSystem : ModSystem
{

    public override void PostSetupContent()
    {
        if (ModLoader.TryGetMod("UniverseEdge", out Mod universeEdge))
        {
            universeEdge.TryFind("IcewurmHead", out ModNPC frostwurm);
            BarData.BarTexture.Add(frostwurm.Type, new Asset<Texture2D>[6]
            {
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/UniverseEdge/FrostwurmHead", (AssetRequestMode)2),
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/UniverseEdge/FrostwurmMid", (AssetRequestMode)2),
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/UniverseEdge/FrostwurmEnd", (AssetRequestMode)2),
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/UniverseEdge/FrostwurmFill", (AssetRequestMode)2),
                null,
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/UniverseEdge/FrostwurmBackground", (AssetRequestMode)2),
            });

			BarData.BarColor.Add(frostwurm.Type, Color.White);
			BarData.Midwidth.Add(frostwurm.Type, true);
			BarData.CutLength.Add(frostwurm.Type, new int[5] { 40, 25, 30, 30, 1 });
			BarData.BackgroundColor.Add(frostwurm.Type, Color.White);






            universeEdge.TryFind("AngeredVinewormJaw", out ModNPC hypermetalConstruct);
            BarData.BarTexture.Add(hypermetalConstruct.Type, new Asset<Texture2D>[6]
            {
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/UniverseEdge/HypermetalHead", (AssetRequestMode)2),
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/UniverseEdge/HypermetalMid", (AssetRequestMode)2),
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/UniverseEdge/HypermetalEnd", (AssetRequestMode)2),
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/UniverseEdge/HypermetalFill", (AssetRequestMode)2),
                null,
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/UniverseEdge/HypermetalBackground", (AssetRequestMode)2),
            });

            BarData.BarColor.Add(hypermetalConstruct.Type, Color.White);
            BarData.Midwidth.Add(hypermetalConstruct.Type, true);
            BarData.CutLength.Add(hypermetalConstruct.Type, new int[5] { 40, 25, 30, 30, 1 });
            BarData.BackgroundColor.Add(hypermetalConstruct.Type, Color.White);
        }

		//don't mind this, i'm playing through tremor on 1.4.4 and i thought it would be funny to add boss bars to it.
		if (ModLoader.TryGetMod("TremorMod", out Mod tremor))
		{
            tremor.TryFind("EvilCorn", out ModNPC evilCorn);
            BarData.BarTexture.Add(evilCorn.Type, new Asset<Texture2D>[6]
            {
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/Tremor/EvilCornHead", (AssetRequestMode)2),
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/Tremor/EvilCornMid", (AssetRequestMode)2),
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/Tremor/EvilCornEnd", (AssetRequestMode)2),
                ModContent.Request<Texture2D>("BestBossBarMod/Texture/Modded/Tremor/EvilCornFill", (AssetRequestMode)2),
                null,
                null,
            });

            BarData.BarColor.Add(evilCorn.Type, Color.White);
            BarData.CutLength.Add(evilCorn.Type, new int[5] { 40, 25, 30, 30, 1 });
        }
    }
	public override void Load()
	{
		BarData.BarTexture.Clear();
		Dictionary<int, Asset<Texture2D>[]> dictionary = new Dictionary<int, Asset<Texture2D>[]>();
        dictionary.Add(int.MaxValue - 1, new Asset<Texture2D>[6]
{
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarStart_Mas", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarMiddle_Mas", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarEnd_Mas", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarFill", (AssetRequestMode)2),
            null,
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarFill", (AssetRequestMode)2),
});
        dictionary.Add(int.MaxValue, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarStart_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarMiddle_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarEnd_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarFill", (AssetRequestMode)2),
			null,
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarFill", (AssetRequestMode)2),
        });
		dictionary.Add(int.MinValue, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarStart", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarMiddle", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarFill", (AssetRequestMode)2),
			null,
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/HealthBarFill", (AssetRequestMode)2),
        });
		dictionary.Add(50, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/KingSlimeHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/KingSlimeMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/KingSlimeEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/KingSlimeFill", (AssetRequestMode)2),
			null,
			null,
		});
		dictionary.Add(4, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/CthEyeHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/CthEyeMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/CthEyeEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/CthEyeFill", (AssetRequestMode)2),
			null,
			null,
		});
		dictionary.Add(13, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/EOCHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/EOCMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/EOCEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/EOCFill", (AssetRequestMode)2),
			TextureAssets.NpcHeadBoss[2],
			null,
		});
		dictionary.Add(266, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/BrainHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/BrainMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/BrainEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/BrainFill", (AssetRequestMode)2),
			TextureAssets.NpcHeadBoss[23],
			null,
		});
		dictionary.Add(222, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/QueenBeeHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/QueenBeeMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/QueenBeeEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/QueenBeeFill", (AssetRequestMode)2),
			null,
			null
		});
		dictionary.Add(35, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SkeletronHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SkeletronMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SkeletronEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SkeletronFill", (AssetRequestMode)2),
			null,
			null
		});
		dictionary.Add(668, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DeerclopsHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DeerclopsMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DeerclopsEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DeerclopsFill", (AssetRequestMode)2),
			null,
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DeerclopsBackground", (AssetRequestMode)2),
        });
		dictionary.Add(113, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DemonBarStart", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DemonBarMiddle", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DemonBarEnd", (AssetRequestMode)2),
			null,
			null,
			null,
		});
		dictionary.Add(657, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/QueenSlimeHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/QueenSlimeMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/QueenSlimeEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/QueenSlimeFill", (AssetRequestMode)2),
			null,
			null,
		});
		dictionary.Add(125, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarStart", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarMiddle", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarEnd", (AssetRequestMode)2),
			null,
			null,
			null,
		});
		dictionary.Add(126, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarStart", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarMiddle", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarEnd", (AssetRequestMode)2),
			null,
			null,
			null,
		});
		dictionary.Add(134, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarStart", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarMiddle", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarEnd", (AssetRequestMode)2),
			null,
			null,
			null,
		});
		dictionary.Add(127, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarStart", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarMiddle", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MechBarEnd", (AssetRequestMode)2),
			null,
			TextureAssets.NpcHeadBoss[18],
			null,
		});
		dictionary.Add(262, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/PlantBarStart", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/PlantBarMiddle", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/PlantBarEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/PlantBarFill", (AssetRequestMode)2),
			null,
			null,
		});
		dictionary.Add(245, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/GolemHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/GolemMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/GolemEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/GolemFill", (AssetRequestMode)2),
			TextureAssets.NpcHeadBoss[5],
			null,
		});
		dictionary.Add(636, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/EmpressHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/EmpressMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/EmpressEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/EmpressFill", (AssetRequestMode)2),
			null,
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/EmpressDayBackground", (AssetRequestMode)2),
        });
		dictionary.Add(370, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DukeHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DukeMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DukeEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DukeFill", (AssetRequestMode)2),
			null,
			null,
		});
		dictionary.Add(439, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/CultistHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/CultistMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/CultistEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/CultistFill", (AssetRequestMode)2),
			TextureAssets.NpcHeadBoss[24],
			null,
		});
		dictionary.Add(NPCID.MoonLordHead, new Asset<Texture2D>[6]
		{
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordSmallHead", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordSmallMid", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordSmallEnd", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordSmallFill", (AssetRequestMode)2),
            TextureAssets.NpcHeadBoss[8],
			null,
		});
		dictionary.Add(NPCID.MoonLordHand, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordSmallHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordSmallMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordSmallEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordSmallFill", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MLEye", (AssetRequestMode)2),
			null,
		});
		dictionary.Add(NPCID.MoonLordCore, new Asset<Texture2D>[6]
		{
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordHead", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordMid", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordEnd", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordFill", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MLHeart", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MoonLordBackground", (AssetRequestMode)2),
        });
		dictionary.Add(NPCID.MartianSaucerCore, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MartianHead", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MartianMid", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MartianEndEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/MartianFill", (AssetRequestMode)2),
			null,
			null,
		});
		dictionary.Add(491, new Asset<Texture2D>[6]);
		dictionary.Add(576, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarStart_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarMiddle_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarEnd_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2SmBarFill", (AssetRequestMode)2),
			null,
			null,
		});
		dictionary.Add(577, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarStart", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarMiddle", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarFill", (AssetRequestMode)2),
			null,
			null,
		});
		dictionary.Add(564, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarStart_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarMiddle_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarEnd_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2SmBarFill", (AssetRequestMode)2),
			null,
			null,
		});
		dictionary.Add(565, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarStart", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarMiddle", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarFill", (AssetRequestMode)2),
			null,
			null,
		});
		dictionary.Add(551, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarStart", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarMiddle", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarEnd", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/DD2BarFill", (AssetRequestMode)2),
			null,
			null,
		});

		dictionary.Add(NPCID.SkeletronHand, new Asset<Texture2D>[6]
		{
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarStart_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarMiddle_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarEnd_Exp", (AssetRequestMode)2),
			ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarFill", (AssetRequestMode)2),
			null,
			null,
		});
        dictionary.Add(NPCID.GolemFistLeft, new Asset<Texture2D>[6]
		{
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarStart_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarMiddle_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarEnd_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarFill", (AssetRequestMode)2),
            null,
			null,
		});
        dictionary.Add(NPCID.GolemFistRight, new Asset<Texture2D>[6]
		{
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarStart_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarMiddle_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarEnd_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarFill", (AssetRequestMode)2),
            null,
			null,
		});
        dictionary.Add(NPCID.BloodNautilus, new Asset<Texture2D>[6]
		{
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarStart_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarMiddle_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarEnd_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarFill", (AssetRequestMode)2),
            null,
			null,
		});
        dictionary.Add(NPCID.PrimeCannon, new Asset<Texture2D>[6]
		{
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarStart_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarMiddle_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarEnd_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarFill", (AssetRequestMode)2),
            null,
			null,
		});
        dictionary.Add(NPCID.PrimeSaw, new Asset<Texture2D>[6]
		{
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarStart_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarMiddle_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarEnd_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarFill", (AssetRequestMode)2),
            null,
			null,
		});
        dictionary.Add(NPCID.PrimeVice, new Asset<Texture2D>[6]
		{
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarStart_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarMiddle_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarEnd_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarFill", (AssetRequestMode)2),
            null,
			null,
		});
        dictionary.Add(NPCID.PrimeLaser, new Asset<Texture2D>[6]
		{
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarStart_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarMiddle_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarEnd_Exp", (AssetRequestMode)2),
            ModContent.Request<Texture2D>("BestBossBarMod/Texture/Vanilla/SmBarFill", (AssetRequestMode)2),
            null,
			null,
		});
        BarData.BarTexture = dictionary;
		BarData.BarColor.Clear();
		BarData.BarColor = new Dictionary<int, Color?>
		{
			{
				50,
				new Color(50, 120, 255)
			},
			{
				4,
				new Color(213, 5, 5)
			},
			{
				13,
				new Color(115, 127, 33)
			},
			{
				266,
				new Color(191, 78, 81)
			},
			{
				222,
				Color.White
			},
			{
				35,
				new Color(240, 240, 159)
			},
			{
				668,
				Color.White
			},
			{
				657,
				Color.White
			},
			{
				245,
				Color.White
			},
			{
				636,
				Color.White
			},
			{
				370,
				new Color(255, 255, 255)
			},
			{
				439,
				new Color(0, 167, 255)
			},
			{
                NPCID.MartianSaucerCore,
				Color.White
			},
			{
				576,
				Color.White
			},
			{
				577,
				Color.White
			},
			{
				564,
				Color.White
			},
			{
				565,
				Color.White
			},
			{
				551,
				Color.White
			},
            {
                NPCID.MoonLordCore,
                Color.White
            },
            {
                NPCID.MoonLordHand,
                Color.White
            },
            {
                NPCID.MoonLordHead,
                Color.White
            },
        };
        Dictionary<int, int[]> dictionary2 = new Dictionary<int, int[]>();
		BarData.CutLength.Clear();

		/*
		 INDEXES:
		1: the left side of the bar's width
		2: 
		 */
		dictionary2 = new Dictionary<int, int[]>();
		dictionary2.Add(int.MinValue, new int[5] { 96, 80, 30, 30, 1 });
		dictionary2.Add(int.MaxValue, new int[5] { 96, 80, 30, 30, 1 });
		dictionary2.Add(50, new int[5] { 48, 21, 29, 26, 1 });
		dictionary2.Add(4, new int[5] { 66, 42, 30, 26, 1 });
		dictionary2.Add(13, new int[5] { 70, 44, 32, 28, 1 });
		dictionary2.Add(266, new int[5] { 44, 22, 30, 26, 1 });
		dictionary2.Add(222, new int[5] { 80, 54, 30, 26, 1 });
		dictionary2.Add(35, new int[5] { 52, 25, 30, 30, 1 });
		dictionary2.Add(113, new int[5] { 80, 52, 28, 4, 1 });
		dictionary2.Add(657, new int[5] { 84, 57, 29, 26, 1 });
		dictionary2.Add(125, new int[5] { 58, 29, 30, 14, 1 });
		dictionary2.Add(126, new int[5] { 58, 29, 30, 14, 1 });
		dictionary2.Add(134, new int[5] { 58, 29, 30, 14, 1 });
		dictionary2.Add(127, new int[5] { 58, 29, 30, 14, 1 });
		dictionary2.Add(262, new int[5] { 50, 33, 31, 30, 1 });
		dictionary2.Add(245, new int[5] { 56, 25, 30, 24, 1 });
		dictionary2.Add(NPCID.HallowBoss, new int[5] { 84, 69, 39, 20, 1 });
        dictionary2.Add(NPCID.MoonLordCore, new int[5] { 60, 48, 39, 20, 1 });
        dictionary2.Add(370, new int[5] { 72, 45, 30, 30, 1 });
		dictionary2.Add(439, new int[5] { 70, 43, 30, 26, 1 });
		dictionary2.Add(397, new int[5] { 30, 17, 12, 0, 1 });
		dictionary2.Add(396, new int[5] { 30, 17, 12, 0, 1 });
        dictionary2.Add(NPCID.SkeletronHand, new int[5] { 30, 17, 12, 0, 1 });
        dictionary2.Add(NPCID.PrimeLaser, new int[5] { 30, 17, 12, 0, 1 });
        dictionary2.Add(NPCID.PrimeCannon, new int[5] { 30, 17, 12, 0, 1 });
        dictionary2.Add(NPCID.PrimeSaw, new int[5] { 30, 17, 12, 0, 1 });
        dictionary2.Add(NPCID.PrimeVice, new int[5] { 30, 17, 12, 0, 1 });
        dictionary2.Add(NPCID.GolemFistLeft, new int[5] { 30, 17, 12, 0, 1 });
		dictionary2.Add(NPCID.GolemFistRight, new int[5] { 30, 17, 12, 0, 1 });
        dictionary2.Add(NPCID.BloodNautilus, new int[5] { 30, 17, 12, 0, 1 });
        dictionary2.Add(NPCID.MartianSaucerCore, new int[5] { 54, 21, 29, 24, 1 });
		dictionary2.Add(491, new int[5] { 96, 80, 30, 30, 1 });
		dictionary2.Add(576, new int[5] { 30, 17, 12, 0, 8 });
		dictionary2.Add(577, new int[5] { 6, 1, 34, 46, 8 });
		dictionary2.Add(564, new int[5] { 30, 17, 12, 0, 8 });
		dictionary2.Add(565, new int[5] { 6, 1, 34, 46, 8 });
		dictionary2.Add(551, new int[5] { 6, 1, 34, 46, 8 });
        dictionary2.Add(NPCID.Deerclops, new int[5] { 64, 52, 34, 10, 1 });
        BarData.CutLength = dictionary2;
		BarData.Midwidth.Clear();
		BarData.Midwidth = new Dictionary<int, bool>
		{
			{ 668, true },
			{ 262, true },
			{ 245, true },
			{ NPCID.MartianSaucerCore, true },
        };



		BarData.BackgroundColor.Clear();
		BarData.BackgroundColor = new Dictionary<int, Color?>
		{
			{ NPCID.HallowBoss, Color.White },
            { NPCID.Deerclops, Color.White },
        };
    }
}
