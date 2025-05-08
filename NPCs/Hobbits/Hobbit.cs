using HobbitonMod.Items.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;

namespace HobbitonMod.NPCs.Hobbits
{
    [AutoloadHead]
    public class Hobbit : ModNPC
    {
        public override void SetDefaults()
        {
            //npc.maxSpawn = 1;
            NPC.GivenName = "Hobbit"; //the name displayed when hovering over the npc ingame.
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18; //the npc sprite width
            NPC.height = 33; //a hobbits height
            NPC.aiStyle = 7; //this is the npc ai style, 7 is Pasive Ai
            NPC.defense = 25;  //the npc defense
            NPC.lifeMax = 200;  // the npc life
            NPC.HitSound = SoundID.NPCHit1;  //the npc sound when is hit
            NPC.DeathSound = SoundID.NPCDeath1;  //the npc sound when he dies
            NPC.knockBackResist = 0.5f;  //the npc knockback resistance

            AnimationType = NPCID.Guide;  //this copy the guide animation
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25; //this defines how many frames the npc sprite sheet has
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 150; //this defines the npc danger detect range
            NPCID.Sets.AttackType[NPC.type] = 0; //this is the attack type,  0 (throwing), 1 (shooting), or 2 (magic). 3 (melee)
            NPCID.Sets.AttackTime[NPC.type] = 15; //this defines the npc attack speed
            NPCID.Sets.AttackAverageChance[NPC.type] = 10; //this defines the npc atack chance
            NPCID.Sets.HatOffsetY[NPC.type] = 4; //this defines the party hat position

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = .5f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = -1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
                               // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
                               // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw

            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            InitHappinessParams();
        }

        private void InitHappinessParams()
        {
            //Hobbits will love the wizard
            NPC.Happiness.
                SetNPCAffection(NPCID.Wizard, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Bee, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Bird, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Bunny, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Butterfly, AffectionLevel.Like)
                .SetNPCAffection(NPCID.OldMan, AffectionLevel.Like)
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
                .SetBiomeAffection<DungeonBiome>(AffectionLevel.Like)
                .SetBiomeAffection<CorruptionBiome>(AffectionLevel.Hate)
                .SetBiomeAffection<CrimsonBiome>(AffectionLevel.Hate)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Hate)
            ;

            //Make the wizard love hobbits!
            NPCHappiness.Get(NPCID.Wizard).SetNPCAffection(ModContent.NPCType<Hobbit>(), AffectionLevel.Love);
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            //if (npc.downedBoss0 == true) // "npc.downedBoss1 == true" means "if 1st boss is killed"
            //    {
            return true;
            //    }
            //else
            //    {
            //    return false;
            //    }
        }

        public override bool CheckConditions(int left, int right, int top, int bottom)    //Allows you to define special conditions required for this town NPC's house
        {
            return true;  //so when a house is available the npc will spawn
        }
        public override List<string> SetNPCNameList()     //Allows you to give this town NPC any name when it spawns
        {
            return new List<string>
            {
                "Bilbo",
                "Frodo",
                "Sam",
                "Merry",
                "Pippin"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)  //Allows you to set the text for the buttons that appear on this town NPC's chat window.
        {
            button = "Comprar";   //this defines the buy button name
        }

        //Allows you to make something happen whenever a button is clicked on this town NPC's chat window.
        //The firstButton parameter tells whether the first button or second button (button and button2 from SetChatButtons) was clicked. Set the shop parameter to true to open this NPC's shop.
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton) shopName = "Shop";   //so when you click on buy button opens the shop
        }

        public override void AddShops()
        {
            base.AddShops();
            new NPCShop(Type)
                .Add(ItemID.Mushroom)
                .Add(ItemID.BottledHoney)
                .Add(ItemID.Barrel)
                .Add(ItemID.Bench)
                .Add(ItemID.Fireplace)
                .Add(ItemID.BugNet)
                .Add(ItemID.Sickle)
                .Add(ItemID.PumpkinPie)
                .Add(ItemID.WoodFishingPole)
                .Add(ItemID.Ale)
                .Add(ItemID.Lemon)
                .Add(ItemID.RoastedBird)
                .Add(ItemID.RoastedDuck)
                .Add(ItemID.Grapes)
                .Register();
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            // Count how many items are already added
            int nextSlot = 0;
            foreach (Item item in items)
            {
                if (item == null) break;
                nextSlot++;
            }

            if (NPC.downedBoss1)   // Eye of Cthulhu
                items[nextSlot++] = new Item(ItemID.ApprenticeBait);
         
            if (NPC.downedBoss2)   // Eater of Worlds / Brain of Cthulhu 
                items[nextSlot++] = new Item(ItemID.ReinforcedFishingPole);
            
            if (NPC.downedBoss3)   // Skeletron 
                items[nextSlot++] = new Item(ModContent.ItemType<Sting>());
            
            if (Main.hardMode)     // Wall of Flesh
                items[nextSlot++] = new Item(ModContent.ItemType<Items.PhialOfGaladriel>());
        }

        public override string GetChat()       
        {
            CustomChats chatGenerator = new();

            if (NPC.GivenName.Equals("Bilbo"))
                return chatGenerator.chatsBilbo.ElementAt(Main.rand.Next(chatGenerator.chatsBilbo.Count));

            else if (NPC.GivenName.Equals("Frodo"))
                return chatGenerator.chatsFrodo.ElementAt(Main.rand.Next(chatGenerator.chatsFrodo.Count));

            else if (NPC.GivenName.Equals("Sam"))
                return chatGenerator.chatsSam.ElementAt(Main.rand.Next(chatGenerator.chatsSam.Count));

            else if (NPC.GivenName.Equals("Merry") || NPC.GivenName.Equals("Pippin"))
                return chatGenerator.chatsMerryPippin.ElementAt(Main.rand.Next(chatGenerator.chatsMerryPippin.Count));

            else return "Hola, ¿necesita algo?";
        }

        //  Allows you to determine the damage and knockback of this town NPC attack
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 40;  //npc damage
            knockback = 2f;   //npc knockback
        }

        //Allows you to determine the cooldown between each of this town NPC's attack. The cooldown will be a number greater than or equal to the first parameter, and less then the sum of the two parameters.
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 5;
            randExtraCooldown = 10;
        }
        //------------------------------------This is an example of how to make the npc use a sword attack-------------------------------

        //Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3).
        //Item is the Texture2D instance of the item to be drawn (use Main.itemTexture[id of item]), itemSize is the width and height of the item's hitbox
        public override void DrawTownAttackSwing(ref Texture2D item, ref Rectangle itemFrame, ref int itemSize, ref float scale, ref Vector2 offset)
        {
            // Won't affect: this NPC must have an attack type of 3 for this to make sense
            scale = .8f;
            //int itemType = ModContent.ItemType<Items.Weapons.Sting>()
            //Main.GetItemDrawFrame(ModContent.ItemType<Items.Weapons.Sting>(), out item, out itemFrame);
            scale /= 1.5f;
        }

        //Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
        {
            itemWidth = 56;
            itemHeight = 56;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.DirtBall;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
        }
    }
}