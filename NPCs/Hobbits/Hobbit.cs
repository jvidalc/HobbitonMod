using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
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

            npc.GivenName = "Hobbit"; //the name displayed when hovering over the npc ingame.
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18; //the npc sprite width
            npc.height = 33; //a hobbits height
            npc.aiStyle = 7; //this is the npc ai style, 7 is Pasive Ai
            npc.defense = 25;  //the npc defense
            npc.lifeMax = 200;  // the npc life
            npc.HitSound = SoundID.NPCHit1;  //the npc sound when is hit
            npc.DeathSound = SoundID.NPCDeath1;  //the npc sound when he dies
            npc.knockBackResist = 0.5f;  //the npc knockback resistance

            Main.npcFrameCount[npc.type] = 25; //this defines how many frames the npc sprite sheet has
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 150; //this defines the npc danger detect range
            NPCID.Sets.AttackType[npc.type] = 0; //this is the attack type,  0 (throwing), 1 (shooting), or 2 (magic). 3 (melee)
            NPCID.Sets.AttackTime[npc.type] = 30; //this defines the npc attack speed
            NPCID.Sets.AttackAverageChance[npc.type] = 10; //this defines the npc atack chance
            NPCID.Sets.HatOffsetY[npc.type] = 4; //this defines the party hat position
            animationType = NPCID.Guide;  //this copy the guide animation
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
        public override string TownNPCName()     //Allows you to give this town NPC any name when it spawns
        {
            string name;
            switch (WorldGen.genRand.Next(4))
            {
                case 0:
                    name = "Bilbo";
                    break;
                case 1:
                    name = "Frodo";
                    break;
                case 2:
                    name = "Sam";
                    break;
                case 3:
                    name = "Merry";
                    break;
                default:
                    name = "Pippin";
                    break;
            }
            return name;
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
            nextSlot++;


            // v1.4 Items
            /*
            shop.item[nextSlot].SetDefaults(ItemID.Lemon);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 15);
            nextSlot++; 

            shop.item[nextSlot].SetDefaults(ItemID.RoastedBird);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 15);
            nextSlot++; 

            shop.item[nextSlot].SetDefaults(ItemID.RoastedDuck);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 15);
            nextSlot++; 

            shop.item[nextSlot].SetDefaults(ItemID.Grapes);
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 15);
            nextSlot++;
            */

            if (NPC.downedBoss1)   // Eye of Cthulhu
            {
                shop.item[nextSlot].SetDefaults(2674);  //Apprentice Bait
                nextSlot++;
            }
            if (NPC.downedBoss2)   // 2nd Boss 
            {
                shop.item[nextSlot].SetDefaults(2291);   //Reinforced Fishing Pole
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 50, 75);
                nextSlot++;
            }
            if (NPC.downedBoss3)   // Skeletron 
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("Sting")); //Custom item: Sting
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 25, 0, 0);
                nextSlot++;

            }
            if (Main.hardMode)     // Wall of Flesh
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("PhialOfGaladriel")); //Custom item: Phial of Galadriel
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
                nextSlot++;
            }
        }

        public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
        {
            CustomChats chatGenerator = new CustomChats();

            if (npc.GivenName.Equals("Bilbo"))
                return chatGenerator.chatsBilbo.ElementAt(Main.rand.Next(chatGenerator.chatsBilbo.Count));

            else if (npc.GivenName.Equals("Frodo"))
                return chatGenerator.chatsFrodo.ElementAt(Main.rand.Next(chatGenerator.chatsFrodo.Count));

            else if (npc.GivenName.Equals("Sam"))
                return chatGenerator.chatsSam.ElementAt(Main.rand.Next(chatGenerator.chatsSam.Count));

            else if (npc.GivenName.Equals("Merry") || npc.GivenName.Equals("Pippin"))
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
            scale = 1f;
            item = Main.itemTexture[mod.ItemType("Sting")]; //this defines the item that this npc will use
            itemSize = 56;
        }

        //Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
        {
            itemWidth = 56;
            itemHeight = 56;
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            scale = 1f;
            item = 266;
            closeness = 20;
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