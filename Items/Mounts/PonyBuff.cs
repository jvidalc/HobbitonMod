using Terraria;
using Terraria.ModLoader;

namespace HobbitonMod.Mounts
{
    public class PonyBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<PonyMount>(), player);
            player.buffTime[buffIndex] = 10; // Mantener la montura activa
        }
    }
}
