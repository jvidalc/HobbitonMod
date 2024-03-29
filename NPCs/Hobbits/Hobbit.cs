using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
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

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
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
        public override void OnChatButtonClicked(bool firstButton, ref bool openShop)
        {
            if (firstButton)
            {
                openShop = true;   //so when you click on buy button opens the shop
            }
        }

        //Allows you to add items to this town NPC's shop. Add an item by setting the defaults of shop.item[nextSlot] then incrementing nextSlot.
        public override void SetupShop(Chest shop, ref int nextSlot)
        {

            shop.item[nextSlot].SetDefaults(ItemID.Mushroom);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 15);
            shop.item[nextSlot].shopCustomPrice = 15;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.BottledHoney);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5, 50);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Barrel);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 3, 20);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Bench);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5, 0);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Fireplace);
            shop.item[nextSlot].shopCustomPrice = 75;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.BugNet);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 7, 75);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Sickle);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 15, 0);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.PumpkinPie);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 3, 25);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.WoodFishingPole);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 7, 75);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Ale);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 10, 0);
            nextSlot++;

            // v1.4 Items
            shop.item[nextSlot].SetDefaults(ItemID.Lemon);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 25, 0);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.RoastedBird);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 50, 0);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.RoastedDuck);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 84, 00); // Default price for Roasted duck
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Grapes);
            //shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 60, 0);
            nextSlot++;

            if (NPC.downedBoss1)   // Eye of Cthulhu
            {
                shop.item[nextSlot].SetDefaults(ItemID.ApprenticeBait);
                nextSlot++;
            }
            if (NPC.downedBoss2)   // 2nd Boss 
            {
                shop.item[nextSlot].SetDefaults(ItemID.ReinforcedFishingPole);
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 50, 75);
                nextSlot++;
            }
            if (NPC.downedBoss3)   // Skeletron 
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Sting>()); //Custom item: Sting
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 25, 0, 0);
                nextSlot++;

            }
            if (Main.hardMode)     // Wall of Flesh
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.PhialOfGaladriel>()); //Custom item: Phial of Galadriel
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
                nextSlot++;
            }
        }

        public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
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
        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
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