using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HobbitonMod.Items.Placeable
{
    public class PlaceableHobbitWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Pared de prueba");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.consumable = true;
            Item.createWall = WallType<Walls.HobbitWall>();
        }

    }
}