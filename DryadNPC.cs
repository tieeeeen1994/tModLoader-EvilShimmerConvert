using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ShimmerEvilConvert
{
    public class DryadNPC : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.Dryad;
        }

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.Dryad) return;

            RemoveItemWithChecks(items, ItemID.CorruptSeeds);
            RemoveItemWithChecks(items, ItemID.CrimsonSeeds);
        }

        private void RemoveItemWithChecks(Item[] shop, int itemID)
        {
            int? removedItemIndex = null;

            for (int i = 0; i < shop.Length; i++)
            {
                if (shop[i] != null && shop[i].type == itemID)
                {
                    removedItemIndex = i;
                    break;
                }
            }

            if (removedItemIndex == null) return;
            else
            {
                for (int i = (int)removedItemIndex; i < shop.Length - 1; i++) shop[i] = shop[i + 1];
                shop[^1] = new Item(ItemID.None);
            }
        }
    }
}
