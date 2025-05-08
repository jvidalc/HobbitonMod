using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HobbitonMod.Items
{
    public class PhialOfGaladriel : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Light of Eärendil");
            ItemID.Sets.Torches[Type] = true;
            ItemID.Sets.WaterTorches[Type] = true;
        }

        public override void SetDefaults()
        {
            //Item.Name = "Phial of Galadriel"; // The item display name in-game. Read-only.

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 10;
            Item.useAnimation = 15;
            Item.autoReuse = true; // "Torch-like"
            Item.useTurn = true;

            Item.consumable = false;
            Item.uniqueStack = true;
            Item.scale = 0.75f;
            Item.width = 16;
            Item.height = 16;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(1, 0, 0, 0); // The items value in PGSC.
        }

        public override void HoldItem(Player player)
        {
            float brightnessIntensity = 4f;
            Lighting.AddLight(player.Center, 0.255f * brightnessIntensity, 0.255f * brightnessIntensity, 0.255f * brightnessIntensity);
        }
    }
}