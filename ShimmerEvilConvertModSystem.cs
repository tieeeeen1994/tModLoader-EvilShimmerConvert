using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShimmerEvilConvert
{
    public class ShimmerEvilConvertModSystem : ModSystem
    {
        public static Dictionary<int, int> TransformData = new Dictionary<int, int>()
        {
            { ItemID.CrimstoneBlock, ItemID.EbonstoneBlock },
            { ItemID.CrimtaneOre, ItemID.DemoniteOre },
            { ItemID.RedSolution, ItemID.PurpleSolution },
            { ItemID.CrimsandBlock, ItemID.EbonsandBlock },
            { ItemID.CrimsonHardenedSand, ItemID.CorruptHardenedSand },
            { ItemID.CrimsonSandstone, ItemID.CorruptSandstone },
            { ItemID.RedIceBlock, ItemID.PurpleIceBlock },
            { ItemID.CrimsonSeeds, ItemID.CorruptSeeds }
        };

        public override void PostSetupContent()
        {
            foreach(var item in TransformData)
            {
                ShimmerBothWays(item.Key, item.Value);
            }
        }

        private void ShimmerBothWays(int item1, int item2)
        {
            ItemID.Sets.ShimmerTransformToItem[item1] = item2;
            ItemID.Sets.ShimmerTransformToItem[item2] = item1;
        }
    }
}
