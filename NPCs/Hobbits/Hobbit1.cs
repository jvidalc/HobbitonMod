using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HobbitonMod.NPCs.Hobbits
{
    [AutoloadHead]
    public class Hobbit1 : ModNPC
    {
        public override void SetDefaults()
        {
			//npc.maxSpawn = 1;
			
            npc.GivenName = "Hobbit";   //the name displayed when hovering over the npc ingame.
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
 
        public override void SetupShop(Chest shop, ref int nextSlot)       //Allows you to add items to this town NPC's shop. Add an item by setting the defaults of shop.item[nextSlot] then incrementing nextSlot.
        {
            if (NPC.downedBoss1)   // Eye of Cthulhu
            {
                shop.item[nextSlot].SetDefaults(2674);  //Apprentice Bait
                nextSlot++;
            }
            if (NPC.downedBoss2)   // 2nd Boss 
            {
                shop.item[nextSlot].SetDefaults(2291);   //Reinforced Fishing Pole
                nextSlot++;
            }
            if (NPC.downedBoss3)   // Skeletron 
            {
                shop.item[nextSlot].SetDefaults(ItemID.BookofSkulls);
                nextSlot++;
            }
            shop.item[nextSlot].SetDefaults(ItemID.Mushroom); //Mushroom 5
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(ItemID.BottledHoney); //Bottled Honey
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(ItemID.Barrel); //Barrel 343
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(ItemID.Bench); //Bench 89
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(ItemID.Fireplace); //Fireplace 3364
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(ItemID.BugNet); //Bug net 1991
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(ItemID.Sickle); //Sickle 1786
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(ItemID.PumpkinPie); //Pumpkin Pie 1787
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(ItemID.WoodFishingPole); //Wood Fishing Pole 2289
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(ItemID.Ale); //Ale 353
            nextSlot++; 

            // v1.4 Items
            /*
            shop.item[nextSlot].SetDefaults(4291); //Lemon
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(4031); //Roasted Bird
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(4032); //Roasted Duck
            nextSlot++; 
            shop.item[nextSlot].SetDefaults(ItemID.Grapes); //Grapes 4023
            nextSlot++; 
            */
        }
 
        public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
        {
            switch (Main.rand.Next(4))         //these are the messages when you talk to the npc
            {
                case 0:
                    return "Hi! Do you know the way to Hobbiton? I think I'm a bit lost...";
                case 1:
                    return "¿Necesitas algo?";
                case 2:
                    return "Vaya casoncio, colega. En la comarca hay pocos que puedan permitirse algo así.";
                case 3:
                    return "¿Tienes fuego?";
                default:
                    return "Un día tengo que invitarte al Pony Pisador. Menudas birras ponen ahí. Son caras pero merece la pena.";
 
            }
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)//  Allows you to determine the damage and knockback of this town NPC attack
        {
            damage = 40;  //npc damage
            knockback = 2f;   //npc knockback
        }
 
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)  //Allows you to determine the cooldown between each of this town NPC's attack. The cooldown will be a number greater than or equal to the first parameter, and less then the sum of the two parameters.
        {
            cooldown = 5;
            randExtraCooldown = 10;
        }
        //------------------------------------This is an example of how to make the npc use a sward attack-------------------------------
        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). Item is the Texture2D instance of the item to be drawn (use Main.itemTexture[id of item]), itemSize is the width and height of the item's hitbox
        {
            scale = 1f;
            item = Main.itemTexture[mod.ItemType("CustomSword")]; //this defines the item that this npc will use
            itemSize = 56;
        }
 
        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
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
			projType = ProjectileID.SandBallGun;
			attackDelay = 1;
		}

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 7f;
		}
/*
        public override bool Autoload(ref string name)
        {
            base.Autoload(ref name);

            //EventManager.Initialize();
            //Mod.AddNPC("el Hobbit", new Hobbit1());
            return true;
        }
*/ 
        //----------------------------------This is an example of how to make the npc use a gun and a projectile ----------------------------------
        /*public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
          {
              scale = 1f;
              item = mod.ItemType("GunName");  
              closeness = 20;
          }
          public override void TownNPCAttackProj(ref int projType, ref int attackDelay)//Allows you to determine the projectile type of this town NPC's attack, and how long it takes for the projectile to actually appear
          {
              projType = ProjectileID.CrystalBullet;
              attackDelay = 1;
          }
 
          public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)//Allows you to determine the speed at which this town NPC throws a projectile when it attacks. Multiplier is the speed of the projectile, gravityCorrection is how much extra the projectile gets thrown upwards, and randomOffset allows you to randomize the projectile's velocity in a square centered around the original velocity
          {
              multiplier = 7f;
             // randomOffset = 4f;
 
          }   */
 
    }
}