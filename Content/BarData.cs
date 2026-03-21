using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

//the name of the mod is a joke
namespace BestBossBarMod.Content;

public class BarData
{
	public static Dictionary<int, Asset<Texture2D>[]> BarTexture = new Dictionary<int, Asset<Texture2D>[]>();

	public static Dictionary<int, Color?> BarColor = new Dictionary<int, Color?>();

	public static Dictionary<int, int[]> CutLength = new Dictionary<int, int[]>();

	public static Dictionary<int, bool> Midwidth = new Dictionary<int, bool>();



	public static Dictionary<int, Color?> BackgroundColor = new Dictionary<int, Color?>();

    public static Dictionary<int, int[]> BackgroundCutLength = new Dictionary<int, int[]>();
}
