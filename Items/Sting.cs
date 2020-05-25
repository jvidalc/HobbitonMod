using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HobbitonMod.Items
{
    public class Sting : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It shines when enemies are nearby!");
        }   

        public override void SetDefaults()
        {
            //item.Name = "Sting"; // The item display name in-game. Read-only.

            //Weapon attributes
            item.damage = 35;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;  // sword use
            item.knockBack = 4;
            item.autoReuse = true; // "Auto swing"

            item.useTime = 9;
            item.useAnimation = 9;
            item.width = 16;
            item.height = 16;
            item.value = 100;
            item.rare = 8;  // yellow color
            item.value = Item.buyPrice(0, 0, 0, 1); // The items value in PGSC.
            item.useAnimation = 20; // 30 = half a second (Terraria runs at 60frames/sec)



        }
/*      //No recipe
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
        }
*/
    }
}
