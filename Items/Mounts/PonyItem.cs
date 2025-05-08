using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HobbitonMod.Mounts
{
    public class PonyItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.mountType = ModContent.MountType<PonyMount>(); // Vincular con la montura
        }
    }
}
