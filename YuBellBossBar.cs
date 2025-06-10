using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ReLogic.Content;

namespace YuBellBossBar
{
    public class YuBellBossBar : Mod
    {
        public override object Call(params object[] args)
        {
            switch (args[0])
            {
                case "BellBarAddColor":
                    {
                        int? key = args[1] as int?;
                        Color? color = args[2] as Color?;
                        if (key == null || color == null)
                        {
                            return null;
                        }
                        BarData.BarColor.TryAdd((int)key, color);
                        return null;
                    }

                case "BellBarAddCotain":
                    {
                        int? key = args[1] as int?;
                        int[] cotain = args[2] as int[];
                        if (key == null || cotain == null)
                        {
                            return null;
                        }
                        BarData.BarNPCContain.TryAdd((int)key, cotain);
                        return null;
                    }

                case "BellBarAddTexture":
                    {
                        int? key = args[1] as int?;
                        Asset<Texture2D>[] texture = args[2] as Asset<Texture2D>[];
                        if (key == null || texture == null)
                        {
                            return null;
                        }
                        BarData.BarTexture.TryAdd((int)key, texture);
                        return null;
                    }

                case "BellBarAddName":
                    {
                        int? key = args[1] as int?;
                        string name = args[2] as string;
                        if (key == null || name == null)
                        {
                            return null;
                        }
                        BarData.BossName.TryAdd((int)key, name);
                        return null;
                    }

                case "BellBarAddCut":
                    {
                        int? key = args[1] as int?;
                        int[] cut = args[2] as int[];
                        if (key == null || cut == null)
                        {
                            return null;
                        }
                        BarData.CutLength.TryAdd((int)key, cut);
                        return null;
                    }

                case "BellBarAddDuplicate":
                    {
                        int? key = args[1] as int?;
                        bool? dup = args[2] as bool?;
                        if (key == null || dup == null)
                        {
                            return null;
                        }
                        BarData.Midwidth.TryAdd((int)key, (bool)dup);
                        return null;
                    }

                case "BellBarAddCan":
                    {
                        int? key = args[1] as int?;
                        bool? can = args[2] as bool?;
                        if (key == null || can == null)
                        {
                            return null;
                        }
                        BarData.CanDraw.TryAdd((int)key, (bool)can);
                        return null;
                    }

                default:
                    return null;
            }
        }
    }
}
