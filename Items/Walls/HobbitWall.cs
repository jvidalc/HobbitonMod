using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HobbitonMod.Items.Walls
{
    public class HobbitWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //dustType = DustType<Sparkle>();
            //ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = ItemType<Placeable.PlaceableHobbitWall>();
            AddMapEntry(new Color(150, 150, 150));
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.4f;
            g = 0.4f;
            b = 0.4f;
        }
    }
}