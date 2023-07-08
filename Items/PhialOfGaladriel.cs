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

        public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick) => wetTorch = true;
    }
}