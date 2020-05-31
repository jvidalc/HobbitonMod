using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

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
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createWall = WallType<Walls.HobbitWall>();
		}
		/*
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
		*/
	}
}