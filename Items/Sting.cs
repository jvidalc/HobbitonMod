using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using System;
using log4net.Repository.Hierarchy;

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
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 9;
            item.useAnimation = 20; // 30 = half a second (Terraria runs at 60frames/sec)
            item.damage = 35;
            item.melee = true;
            item.knockBack = 2;
            item.autoReuse = true; // "Auto swing"

            item.UseSound = SoundID.Item1;
            item.width = 16;
            item.height = 16;
            item.rare = ItemRarityID.Yellow;  // yellow color
            item.value = Item.buyPrice(0, 25, 0, 0); // The items value in PGSC.

            //item.holdStyle = 1;
        }

        public override void HoldItem(Player player)
        {
            float brightnessIntensity = 3.5f;
            foreach (NPC npc in Main.npc)
                if (npc.CanBeChasedBy(player, true))
                    Lighting.AddLight(player.Center, 0.135f * brightnessIntensity, 0.217f * brightnessIntensity, 0.211f * brightnessIntensity);
        }

        public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
        {
            wetTorch = true;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.MythrilBar, 20);
            r.AddIngredient(ItemID.SoulofLight, 10);
            r.AddIngredient(ItemID.CrystalShard, 5);
            r.AddIngredient(ItemID.DirtBlock, 1);
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}