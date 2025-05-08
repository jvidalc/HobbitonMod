using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HobbitonMod.Items.Weapons
{
    public class Sting : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("It shines when enemies are nearby!");
            ItemID.Sets.Torches[Type] = true;
            ItemID.Sets.WaterTorches[Type] = true;
        }

        public override void SetDefaults()
        {
            //Item.Name = "Sting"; // The item's display name in-game. Read-only.

            //Weapon attributes
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 9;
            Item.useAnimation = 20; // 30 = half a second (Terraria runs at 60frames/sec)
            Item.damage = 55;
            Item.noMelee = false;
            Item.knockBack = 2;
            Item.autoReuse = true; // "Auto swing"

            Item.UseSound = SoundID.Item1;
            Item.width = 16;
            Item.height = 16;
            Item.rare = ItemRarityID.Yellow;  // yellow color
            Item.value = Item.buyPrice(0, 25, 0, 0); // The items value in PGSC

            //Item.holdStyle = 1;
        }

        public override void HoldItem(Player player)
        {
            float brightnessIntensity = 3.5f;
            foreach (NPC npc in Main.npc)
                if (npc.CanBeChasedBy(player, true))
                    Lighting.AddLight(player.Center, 0.135f * brightnessIntensity, 0.217f * brightnessIntensity, 0.211f * brightnessIntensity);
        }

        public override void AddRecipes()
        {
            var r = Recipe.Create(ModContent.ItemType<Sting>());
            r.AddIngredient(ItemID.MythrilBar, 20);
            r.AddIngredient(ItemID.SoulofLight, 10);
            r.AddIngredient(ItemID.CrystalShard, 5);
            r.AddTile(TileID.MythrilAnvil);
            //r.Create();
            r.Register();
        }
    }
}