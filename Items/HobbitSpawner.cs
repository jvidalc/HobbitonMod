using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HobbitonMod.Items
{
    public class HobbitSpawner : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Spawn a hobbit!");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.value = 100;
            item.rare = 8;  // yellow color
            // Set other item.X values here

            item.useStyle = 4;  // for use like life crystal
            item.consumable = false; //won't be consumed after use
            item.useAnimation = 30; // Half a second (Terraria runs at 60frames/sec)


        }

        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Wood, 1);
            r.AddTile(TileID.WorkBenches);
            r.SetResult(this);
            r.AddRecipe();
        }

        public override void OnConsumeItem (Player player)
        {
            ModNPC npc = Terraria.ModLoader.NPCLoader.GetNPC(1);
            npc.SpawnNPC((int)(((float)Main.mouseX + Main.screenPosition.X) / 16f) , (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f));
        }
    }
}