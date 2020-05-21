using Terraria.ModLoader;
using HobbitonMod.NPCs.Hobbits;

namespace HobbitonMod
{
	public class HobbitonMod : Mod
	{	
		//internal static HobbitonConfig hobbitonConfig;

		public HobbitonMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
			};
		}
	}
}
