// RPG Scenario Interactive Terminal Assignment #1
using System;
using System.Runtime.Intrinsics.X86;

// Used to check inventory and injuries
bool healthPotion = false;
bool swordShield = false;
bool strangeKey = false;
bool hurtLeg = false;
bool injuredLeg = false;
bool moonlightSword = false;

// Background story
Console.WriteLine("You're a novice adventurer who overheard a group of people talking about adventurers\nwho" +
    " had gone missing in a mysterious dungeon that the locals call 'The Tomb of the Fallen Knight'. \nThis" +
    " information intrigues you, so you grab your 'Short Sword' and bag and head towards the dungeon.");
Console.WriteLine("Press Enter to continue.");
Console.ReadLine();

// Merchant interaction
Console.WriteLine("You've nearly reached the dungeon but you see a merchant on the side of the road.");
Console.WriteLine("Do you speak to the merchant?");
Console.WriteLine(">YES     >NO");
string doTalk = Console.ReadLine()!; // Get answer

if (doTalk.ToUpper() == "YES") // Talk to the merchant
{
    Console.WriteLine("\nHello there adventurer! What might your name be?");
    string playerName = Console.ReadLine()!;
    Console.WriteLine($"\nNice to meet you {playerName}, how much gold might you have in your bag?");
    string heldGoldText = Console.ReadLine()!;
    long heldGold = long.Parse(heldGoldText); // Turn gold text input into long integer

    if (heldGold < 50) // If the player has less than 50 gold
    {
        Console.WriteLine($"\nHmm... only {heldGold} gold... \nI stumbled across this bag, why don't you have it" +
            $" and keep whatever is inside?");
        heldGold += 50; // Adds 50 gold to existing gold
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("You found 50 gold in the bag.");
        Console.WriteLine($"You now have {heldGold} gold.");
        Console.WriteLine("\nTake a look at my wares I have for sale.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
    else // If the player has 50 or more gold
    {
        Console.WriteLine("\nTake a look at my wares I have for sale.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    Console.WriteLine("The merchant shows you what they have for sale.");
    Console.WriteLine("You see a 'Health Potion' that may come in handy if you run into danger inside the dungeon, an\n" +
        "'Iron Sword' that looks a little worn but still looks sharper than the one you have now, and\na 'Wooden Shield'" +
        " that looks a bit tattered but would still be better than nothing. There is also\na 'Strange Key' that catches your eye.");
    Console.WriteLine("Press Enter to continue.");
    Console.ReadLine();
    Console.WriteLine("*Type the name or cost of the item you want to purchase*");
    Console.WriteLine($"*Merchant Shop*          Bag: {heldGold}G");
    Console.WriteLine(">Health Potion: 15G\n>Iron Sword and Wooden Shield: 50G\n\nType LEAVE to continue with no more purchases");
    string playerPurchase = Console.ReadLine()!;

    // Health potion start
    if (playerPurchase.ToUpper() == "HEALTH POTION" || playerPurchase.ToUpper() == "15G" || playerPurchase.ToUpper() == "HEALTH POTION 15G") // Buy health potion first
    {
        heldGold -= 15; // Subtract 15 gold
        healthPotion = true; // Health potion is in inventory
        Console.WriteLine($"\nYou purchased the 'Health Potion'. You have {heldGold} gold left.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("*Type the name or cost of the item you want to purchase*");
        Console.WriteLine($"*Merchant Shop*          Bag: {heldGold}G"); // Merchant shop loop
        Console.WriteLine(">Iron Sword and Wooden Shield: 50G\n\nType LEAVE to continue with no more purchases");
        string secondPurchase = Console.ReadLine()!;

        if (secondPurchase.ToUpper() == "IRON SWORD AND WOODEN SHIELD" || secondPurchase.ToUpper() == "50G" || secondPurchase.ToUpper() == "IRON SWORD AND WOODEN SHIELD 50G") // Buy sword and shield second
        {
            heldGold -= 50; // Subtract 50 gold
            swordShield = true; // Sword and shield is in inventory
            Console.WriteLine($"\nYou purchased the 'Iron Sword and Wooden Shield'. You have {heldGold} gold left.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.WriteLine("The merchant has nothing left for sale, do you ask about the 'Strange Key'?");
            Console.WriteLine(">YES     >NO");
            string askAboutKey = Console.ReadLine()!;
            
            if (askAboutKey.ToUpper() == "YES") // Ask about the strange key
            {
                Console.WriteLine("\nA strange looking key isn't it? I found it near 'The Tomb of the Fallen Knight'.");
                Console.WriteLine("It's all yours for 124G.");
                Console.WriteLine("Do you buy the 'Strange Key'?");
                Console.WriteLine(">YES     >NO");
                string buyKey = Console.ReadLine()!;

                if (buyKey.ToUpper() == "YES") // Buy the strange key
                {
                    if (heldGold >= 124) // If player has 124 gold or more
                    {
                        heldGold -= 124; // Subtract 124 gold from inventory
                        strangeKey = true; // Key is in inventory
                        Console.WriteLine("\nHere you go. Hopefully you can find a use for it.");
                        Console.WriteLine($"I have nothing else left to offer you. Good luck on your journey {playerName}.");
                    }
                    else // If player doesn't have 124 gold
                    {
                        Console.WriteLine("\nYou don't have enough gold for that.");
                        Console.WriteLine($"I have nothing else left to offer you. Good luck on your journey {playerName}.");
                    }
                }
                else // Player doesn't want to buy the strange key
                {
                    Console.WriteLine("\nI guess I'll hold onto it for now.");
                    Console.WriteLine($"I have nothing else left to offer you. Good luck on your journey {playerName}.");
                }
            }
            else // Player doesn't want to ask about the strange key
            {
                Console.WriteLine("Not curious about the key?\nI guess I'll hold onto it for now.");
            }
        }
        else // Player doesn't purchase anything else
        {
            Console.WriteLine($"\nGood luck on your journey {playerName}.");
        }
    }

    // Sword and shield start
    else if (playerPurchase.ToUpper() == "IRON SWORD AND WOODEN SHIELD" || playerPurchase.ToUpper() == "50G" || playerPurchase.ToUpper() == "IRON SWORD AND WOODEN SHIELD 50G") // Buy sword and shield first
    {
        heldGold -= 50; // Subtract 50 gold from inventory
        swordShield = true; // Sword and shield is in inventory
        Console.WriteLine($"\nYou purchased the 'Iron Sword and Wooden Shield'. You have {heldGold} gold left.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("*Type the name or cost of the item you want to purchase*");
        Console.WriteLine($"*Merchant Shop*          Bag: {heldGold}G");
        Console.WriteLine(">Health Potion: 15G\n\nType LEAVE to continue with no more purchases");
        string secondPurchase = Console.ReadLine()!;

        if (secondPurchase.ToUpper() == "HEALTH POTION" || secondPurchase.ToUpper() == "15G" || secondPurchase.ToUpper() == "HEALTH POTION 15G") // Buy health potion second
        {
            heldGold -= 15; // Subtract 15 gold
            healthPotion = true; // Health potion is in inventory
            Console.WriteLine($"\nYou purchased the 'Health Potion'. You have {heldGold} gold left.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.WriteLine("The merchant has nothing left for sale, do you ask about the 'Strange Key'?");
            Console.WriteLine(">YES     >NO");
            string askAboutKey = Console.ReadLine()!;

            if (askAboutKey.ToUpper() == "YES") // Ask about the strange key
            {
                Console.WriteLine("\nA strange looking key isn't it? I found it near 'The Tomb of the Fallen Knight'.");
                Console.WriteLine("It's all yours for 124G.");
                Console.WriteLine("Do you buy the 'Strange Key'?");
                Console.WriteLine(">YES     >NO");
                string buyKey = Console.ReadLine()!;

                if (buyKey.ToUpper() == "YES") // Buy the strange key
                {
                    if (heldGold >= 124) // If player has 124 gold or more
                    {
                        heldGold -= 124; // Subtract 124 gold from inventory
                        strangeKey = true; // Key is in inventory
                        Console.WriteLine("\nHere you go. Hopefully you can find a use for it.");
                        Console.WriteLine($"I have nothing else left to offer you. Good luck on your journey {playerName}.");
                    }
                    else // If player doesn't have 124 gold
                    {
                        Console.WriteLine("\nYou don't have enough gold for that.");
                        Console.WriteLine($"I have nothing else left to offer you. Good luck on your journey {playerName}.");
                    }
                }
                else // Player doesn't want to buy the strange key
                {
                    Console.WriteLine("\nI guess I'll hold onto it for now.");
                    Console.WriteLine($"I have nothing else left to offer you. Good luck on your journey {playerName}.");
                }
            }
            else // Player doesn't want to ask about the strange key
            {
                Console.WriteLine("Not curious about the key?\nI guess I'll hold onto it for now.");
            }
        }
        else // Player doesn't purchase anything else
        {
            Console.WriteLine($"\nGood luck on your journey {playerName}.");
        }
    }
    else // Player doesn't buy anything
    {
        Console.WriteLine($"\nGood luck on your journey {playerName}.");
    }
}
else // Player doesn't talk to the merchant
{
    Console.WriteLine("\nYou decide not to speak to the merchant and continue on your way to the dungeon.");
}

// Reached the dungeon
Console.WriteLine("Press Enter to continue.");
Console.ReadLine();
Console.WriteLine("You reach the ruins of what looks like a giant tower.");
Console.WriteLine("You make your way through the ruins and find stairs that lead down into the tomb.");
Console.WriteLine("Press Enter to continue.");
Console.ReadLine();
Console.WriteLine("When you enter the first room you feel a tile sink under your foot.\nYou hear a click, and before you know it an arrow flies towards you.");
Console.WriteLine("Think fast! What do you do?");

if (swordShield == true) // If player purchased sword and shield
{
    Console.WriteLine(">MOVE     >STAY     >USE SHIELD");
    string roomOneChoice = Console.ReadLine()!;

    if (roomOneChoice.ToUpper() == "MOVE") // Player chooses MOVE
    {
        Console.WriteLine("\nYou dive out of the way of the arrow at the last second.\nThe arrow grazed your leg but you can still walk, luckily you weren't injured more.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        if (healthPotion == true) // If player purchased health potion
        {
            Console.WriteLine("Good thing you bought a 'Health Potion' from the Merchant. You drink some to heal your wound.");
            Console.WriteLine("You have half of the 'Health Potion' left.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.WriteLine("You make your way across the room and venture deeper into the dungeon.");
        }
        else // Player doesn't have the health potion
        {
            hurtLeg = true; // Leg is hurt, no potion to heal
            Console.WriteLine("You make your way across the room and venture deeper into the dungeon, wincing in pain.");
        }
    }
    else if (roomOneChoice.ToUpper() == "STAY") // Player chooses STAY
    {
        Console.WriteLine("\nYou don't move, hoping that the arrow will miss it's target.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("The arrow pierces your leg and you scream in agony.");
        if (healthPotion == true) // If player purchased health potion
        {
            Console.WriteLine("Good thing you bought a 'Health Potion' from the Merchant. You drink some to heal your wound.");
            Console.WriteLine("You have half of the 'Health Potion' left.\nYour leg is still in pain from the arrow.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            hurtLeg = true; // Leg is hurt, healed from being pierced by the arrow
            Console.WriteLine("You make your way across the room and venture deeper into the dungeon, wincing in pain.");
        }
        else // Player doesn't have the health potion
        {
            injuredLeg = true; // Leg is injured, no potion to heal
            Console.WriteLine("You hobble your way across the room and venture deeper into the dungeon.\nThe pain may be too much, but you continue anyway.");
        }

    }
    else if (roomOneChoice.ToUpper() == "USE SHIELD" || roomOneChoice.ToUpper() == "USE" || roomOneChoice.ToUpper() == "SHIELD") // Hidden option, only available with wooden shield
    {
        Console.WriteLine("\nYou quickly use your 'Wooden Shield' to block the incoming arrow.");
        Console.WriteLine("You quickly make your way across the room to venture deeper into the dungeon.");
    }
    else // Player inputs something unknown
    {
        Console.WriteLine("\nYou froze up and got struck by the arrow.");
        Console.WriteLine("The arrow pierces your leg and you scream in agony.");
        if (healthPotion == true) // If player purchased health potion
        {
            Console.WriteLine("Good thing you bought a 'Health Potion' from the Merchant. You drink some to heal your wound.");
            Console.WriteLine("You have half of the 'Health Potion' left.\nYour leg is still in pain from the arrow.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            hurtLeg = true; // Leg is hurt, healed from being pierced by the arrow
            Console.WriteLine("You make your way across the room and venture deeper into the dungeon, wincing in pain.");
        }
        else // Player doesn't have the health potion
        {
            injuredLeg = true; // Leg is injured, no potion to heal
            Console.WriteLine("You hobble your way across the room and venture deeper into the dungeon.\nThe pain may be too much, but you continue anyway.");
        }
    }
}
else // Didn't purchase sword and shield
{
    Console.WriteLine(">MOVE     >STAY");
    string roomOneChoice = Console.ReadLine()!;

    if (roomOneChoice.ToUpper() == "MOVE") // Player chooses MOVE
    {
        Console.WriteLine("\nYou dive out of the way of the arrow at the last second.\nThe arrow grazed your leg but you can still walk, luckily you weren't injured more.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        if (healthPotion == true) // If player purchased health potion
        {
            Console.WriteLine("Good thing you bought a 'Health Potion' from the Merchant. You drink some to heal your wound.");
            Console.WriteLine("You have half of the 'Health Potion' left.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.WriteLine("You make your way across the room and venture deeper into the dungeon.");
        }
        else // Player doesn't have the health potion
        {
            hurtLeg = true; // Leg is hurt, no potion to heal
            Console.WriteLine("You make your way across the room and venture deeper into the dungeon, wincing in pain.");
        }
    }
    else if (roomOneChoice.ToUpper() == "STAY") // Player chooses STAY
    {
        Console.WriteLine("\nYou don't move, hoping that the arrow will miss it's target.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("The arrow pierces your leg and you scream in agony.");
        if (healthPotion == true) // If player purchased health potion
        {
            Console.WriteLine("Good thing you bought a 'Health Potion' from the Merchant. You drink some to heal your wound.");
            Console.WriteLine("You have half of the 'Health Potion' left.\nYour leg is still in pain from the arrow.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            hurtLeg = true; // Leg is hurt, healed from being pierced by the arrow
            Console.WriteLine("You make your way across the room and venture deeper into the dungeon, wincing in pain.");
        }
        else // Play doesn't have the health potion
        {
            injuredLeg = true; // Leg is injured, no potion to heal
            Console.WriteLine("You hobble your way across the room and venture deeper into the dungeon.\nThe pain may be too much, but you continue anyway.");
        }
    }
    else // Player inputs something unknown
    {
        Console.WriteLine("\nYou froze up and got struck by the arrow.");
        Console.WriteLine("The arrow pierces your leg and you scream in agony.");
        if (healthPotion == true) // If player purchased health potion
        {
            Console.WriteLine("Good thing you bought a 'Health Potion' from the Merchant. You drink some to heal your wound.");
            Console.WriteLine("You have half of the 'Health Potion' left.\nYour leg is still in pain from the arrow.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            hurtLeg = true; // Leg is hurt, healed from being pierced by the arrow
            Console.WriteLine("You make your way across the room and venture deeper into the dungeon, wincing in pain.");
        }
        else // Player doesn't have the health potion
        {
            injuredLeg = true; // Leg is injured, no potion to heal
            Console.WriteLine("You hobble your way across the room and venture deeper into the dungeon.\nThe pain may be too much, but you continue anyway.");
        }
    }
}

// Second room in dungeon
Console.WriteLine("Press Enter to continue.");
Console.ReadLine();
Console.WriteLine("As you enter the next room, a chill crawls down your spine.\nBefore your eyes a pile of bones springs to life, ready to fight.");
Console.WriteLine("The skeleton rushes towards you with sword in hand.");
Console.WriteLine("What do you do?");

// Skeleton fight
if (swordShield == true) // If player purchased sword and shield
{
    Console.WriteLine(">FIGHT     >DODGE     >USE IRON SWORD"); // Hidden option
    string roomTwoChoice = Console.ReadLine()!;
    if (roomTwoChoice.ToUpper() == "FIGHT") // Player chooses to fight
    {
        Console.WriteLine("\nYou choose to fight! You grab your 'Short Sword' and clash with the skeleton.\nThe skeleton strikes your leg as you deal a fatal blow.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        if (hurtLeg == true) // Checks if player is already hurt
        {
            hurtLeg = false;
            injuredLeg = true; // If player is hurt, become injured
        }
        else // If player is not hurt
        {
            hurtLeg = true; // Player becomes hurt
        }
        if (healthPotion == true) // If player purchased health potion
        {
            if (hurtLeg == true) // If player is hurt, goes from hurt to healed
            {
                hurtLeg = false;
                Console.WriteLine("You use the 'Health Potion' from the Merchant to heal your wound. Your leg feels better.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
            else // If player is injured, goes from injured to hurt
            {
                injuredLeg = false;
                hurtLeg = true;
                Console.WriteLine("You use the 'Health Potion' from the Merchant to heal your wound.\nYour leg is still hurt but it won't slow you down.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
        }
        else // Player doesn't have a health potion
        {
            if (hurtLeg == true) // If player is hurt
            {
                Console.WriteLine("Your leg is hurt but it won't slow you down.");
            }
            else if (injuredLeg == true) // If player is injured
            {
                Console.WriteLine("Your is sore but luckily the skeleton didn't pierce your skin.");
            }
        }
    }
    else if (roomTwoChoice.ToUpper() == "DODGE") // Player chooses to dodge
    {
        Console.WriteLine("\nYou choose to dodge! You roll out of the way as the skeleton rushes towards you.\nYou pull out your 'Short Sword' and slash the " +
            "skeleton in the back, dealing a fatal blow.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
    else if (roomTwoChoice.ToUpper() == "USE IRON SWORD") // Player chooses to use the sword
    {
        Console.WriteLine("\nYou pull out your 'Iron Sword' and deflect the skeleton's attack!\nThe skeleton stumbles back. You slash the skeleton, dealing a fatal blow.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
    else // Player inputs something unknown
    {
        Console.WriteLine("\nYou froze up and got struck by the skeleton! You swing your 'Short Sword' in retaliation and take down the skeleton.\nYour leg is now " +
            "badly injured.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        if (healthPotion == true) // If player purchased health potion
        {
            injuredLeg = false;
            hurtLeg = true; // Player becomes hurt
            Console.WriteLine("You use the 'Health Potion' from the Merchant to heal your wound.\nYour leg is still hurt but it won't slow you down.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        else // Player doesn't have a health potion
        {
            Console.WriteLine("If only you had a 'Health Potion' to heal your wounds.\nThe pain may be too much, but you continue anyway.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}
else if (swordShield == true && injuredLeg == true) // If player purchased sword and shield AND has an injured leg
{
    Console.WriteLine(">FIGHT     >USE IRON SWORD"); // Can't dodge
    string roomTwoChoice = Console.ReadLine()!;
    if (roomTwoChoice.ToUpper() == "FIGHT") // Player chooses to fight
    {
        Console.WriteLine("\nYou choose to fight! You grab your 'Short Sword' and clash with the skeleton.\nThe skeleton strikes your leg as you deal a fatal blow.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        if (healthPotion == true) // If player purchased health potion
        {
            injuredLeg = false;
            hurtLeg = true;
            Console.WriteLine("You use the 'Health Potion' from the Merchant to heal your wound. Your leg feels better.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        else // Player doesn't have a health potion
        {
            Console.WriteLine("If only you had a 'Health Potion' to heal your wounds.\nThe pain may be too much, but you continue anyway.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
    else if (roomTwoChoice.ToUpper() == "USE IRON SWORD") // Player chooses to use the sword
    {
        Console.WriteLine("\nYou pull out your 'Iron Sword' and deflect the skeleton's attack!\nThe skeleton stumbles back. You slash the skeleton, dealing a fatal blow.");
        Console.WriteLine("Press Enter to continue.");
    }
    else // Player inputs something unknown
    {
        Console.WriteLine("\nYou froze up and got struck by the skeleton! You swing your 'Short Sword' in retaliation and take down the skeleton.\nYour leg is now " +
            "badly injured.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        if (healthPotion == true) // If player purchased health potion
        {
            injuredLeg = false;
            hurtLeg = true; // Player becomes hurt
            Console.WriteLine("You use the 'Health Potion' from the Merchant to heal your wound.\nYour leg is still hurt but it won't slow you down.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        else // Player doesn't have a health potion
        {
            Console.WriteLine("If only you had a 'Health Potion' to heal your wounds.\nThe pain may be too much, but you continue anyway.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}
else if (injuredLeg == true) // If player has an injured leg
{
    Console.WriteLine(">FIGHT"); // Can't dodge
    string roomTwoChoice = Console.ReadLine()!;
    if (roomTwoChoice.ToUpper() == "FIGHT") // Player chooses to fight
    {
        Console.WriteLine("\nYou choose to fight! You grab your 'Short Sword' and clash with the skeleton.\nThe skeleton strikes your leg as you deal a fatal blow.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        if (healthPotion == true) // If player purchased health potion
        {
            injuredLeg = false;
            hurtLeg = true;
            Console.WriteLine("You use the 'Health Potion' from the Merchant to heal your wound. Your leg feels better.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        else // Player doesn't have a health potion
        {
            Console.WriteLine("If only you had a 'Health Potion' to heal your wounds.\nThe pain may be too much, but you continue anyway.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
    else // Player inputs something unknown
    {
        Console.WriteLine("\nYou froze up and got struck by the skeleton! You swing your 'Short Sword' in retaliation and take down the skeleton.\nYour leg is now " +
            "badly injured.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        if (healthPotion == true) // If player purchased health potion
        {
            injuredLeg = false;
            hurtLeg = true; // Player becomes hurt
            Console.WriteLine("You use the 'Health Potion' from the Merchant to heal your wound.\nYour leg is still hurt but it won't slow you down.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        else // Player doesn't have a health potion
        {
            Console.WriteLine("If only you had a 'Health Potion' to heal your wounds.\nThe pain may be too much, but you continue anyway.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}
else // If player didn't purchase sword and shield
{
    Console.WriteLine(">FIGHT     >DODGE");
    string roomTwoChoice = Console.ReadLine()!;
    if (roomTwoChoice.ToUpper() == "FIGHT") // Player chooses to fight
    {
        Console.WriteLine("\nYou choose to fight! You grab your 'Short Sword' and clash with the skeleton.\nThe skeleton strikes your leg as you deal a fatal blow.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        if (hurtLeg == true) // Checks if player is already hurt
        {
            hurtLeg = false;
            injuredLeg = true; // If player is hurt, become injured
        }
        else // If player is not hurt
        {
            hurtLeg = true; // Player becomes hurt
        }
        if (healthPotion == true) // If player purchased health potion
        {
            if (hurtLeg == true) // If player is hurt, goes from hurt to healed
            {
                hurtLeg = false;
                Console.WriteLine("You use the 'Health Potion' from the Merchant to heal your wound. Your leg feels better.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
            else // If player is injured, goes from injured to hurt
            {
                injuredLeg = false;
                hurtLeg = true;
                Console.WriteLine("You use the 'Health Potion' from the Merchant to heal your wound.\nYour leg is still hurt but it won't slow you down.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
        }
        else // Player doesn't have a health potion
        {
            if (hurtLeg == true) // If player is hurt
            {
                Console.WriteLine("Your leg is hurt but it won't slow you down.");
            }
            else if (injuredLeg == true) // If player is injured
            {
                Console.WriteLine("Your is sore but luckily the skeleton didn't pierce your skin.");
            }
        }
    }
    else if (roomTwoChoice.ToUpper() == "DODGE") // Player chooses to dodge
    {
        Console.WriteLine("\nYou choose to dodge! You roll out of the way as the skeleton rushes towards you.\nYou pull out your 'Short Sword' and slash the " +
            "skeleton in the back, dealing a fatal blow.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
    else // Player inputs something unknown
    {
        Console.WriteLine("\nYou froze up and got struck by the skeleton! You swing your 'Short Sword' in retaliation and take down the skeleton.\nYour leg is now " +
            "badly injured.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
        if (hurtLeg == true) // Checks if player is already hurt
        {
            hurtLeg = false;
            injuredLeg = true; // If player is hurt, become injured
        }
        else // If player is not hurt
        {
            injuredLeg = true; // Player becomes injured
        }
        if (healthPotion == true) // If player purchased health potion
        {
            injuredLeg = false;
            hurtLeg = true; // Player becomes hurt
            Console.WriteLine("You use the 'Health Potion' from the Merchant to heal your wound.\nYour leg is still hurt but it won't slow you down.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        else // Player doesn't have a health potion
        {
            Console.WriteLine("If only you had a 'Health Potion' to heal your wounds.\nThe pain may be too much, but you continue anyway.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}

// After skeleton battle
Console.WriteLine("After your fight with the skeleton you notice a key hole on the wall.");
Console.WriteLine("Press Enter to continue.");
Console.ReadLine();
if (strangeKey == true) // Player purchased the key
{
    Console.WriteLine("You use the 'Strange Key' in the key hole. The wall slides open, revealing a secret room.\nA single beam of light from above reflects " +
        "off of a sword in the middle of the room.\nYou walk over and pick up the sword.");
    Console.WriteLine("Press Enter to continue.");
    Console.ReadLine();
    Console.WriteLine("You obtained 'Mysterious Sword'");
    Console.WriteLine("Press Enter to continue.");
    Console.ReadLine();
}
else // Player didn't purchase the key
{
    Console.WriteLine("You wonder what's behind the secret door and how you could open it.\nYou turn and head to the last room of the dungeon.");
    Console.WriteLine("Press Enter to continue.");
    Console.ReadLine();
}

// Final room
Console.WriteLine("You walk into the final room of the dungeon.");