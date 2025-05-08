using Terraria.ID;
using Terraria.ModLoader;

namespace HobbitonMod.Mounts
{
    public class PonyMount : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.spawnDust = DustID.Grass; // Efecto al aparecer
            MountData.buff = ModContent.BuffType<PonyBuff>(); // Buff vinculado
            MountData.heightBoost = 10; // Ajusta la altura del jugador sobre la montura
            MountData.runSpeed = 5f; // Velocidad en tierra
            MountData.dashSpeed = 8f; // Velocidad de aceleración
            MountData.flightTimeMax = 0; // Sin vuelo
        }
    }
}
