using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace HobbitonMod.Items
{
    public class PhialOfGaladriel : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Light of Eärendil");
        }

        public override void SetDefaults()
        {
            //item.Name = "Phial of Galadriel"; // The item display name in-game. Read-only.
            
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 10;
            item.useAnimation = 15;
            item.autoReuse = true; // "Torch-like"
            item.useTurn = true;

            item.consumable = false;
            item.uniqueStack = true;
            item.scale = 0.75f;
            item.width = 16;
            item.height = 16;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.buyPrice(1, 0, 0, 0); // The items value in PGSC.
            
        }

        public override void HoldItem(Player player)
        {
            float brightnessIntensity = 4f;
            Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
            Lighting.AddLight(position, 0.255f * brightnessIntensity, 0.255f * brightnessIntensity, 0.255f * brightnessIntensity);
        }

        public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick) => wetTorch = true;
    }
}