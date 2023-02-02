using System;
using System.Threading;

namespace Turn_Based
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int roundNo = 1;
            int testVar = 0;
            bool gameIsRunning = true;
           
            

            Console.WriteLine("This is a turn based combat game\nEvery round you will be presented with a new enemy and can use various abilities to defeat them\n\nAfter each round you will recover some health\n\nEvery 5 rounds you will recieve an extra health potion and every 3 rounds you will recieve an extra special ability\n\nEvery 10 rounds there will be a boss\n\ngl&hf");
            AnyKeyContinue();


            Console.WriteLine("Enter your name");
            string nameText = Console.ReadLine();
            Character playerCharacter = GetCharacter();
            playerCharacter.name = nameText;
            Console.WriteLine($"\nHealth: {playerCharacter.health}\nDamage: {playerCharacter.damage}\nBlock: {playerCharacter.block}\n\nWeapons:\n{playerCharacter.weapons}\n\nItems: x{playerCharacter.itemCount} {playerCharacter.itemNames}\nSpecial Ability: {playerCharacter.specialMove}");

            AnyKeyContinue();


            while (gameIsRunning)
            {
                if (roundNo % 10 != 0)
                {
                    Enemy enemyCharacter = GetEnemy();


                    if (playerCharacter.health > 0 && roundNo != 1)
                    {
                        playerCharacter.health += RoundTransfer();
                    }

                    while (gameIsRunning)
                    {
                        if (playerCharacter.health <= 0)
                        {
                            gameIsRunning = false;
                        }


                        else
                        {
                            if (playerCharacter.block == 8)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Round: " + (roundNo) + "\nCurrent health :" + (playerCharacter.health) + "\nCurrent Potions:" + (playerCharacter.itemCount) + "\nCurrent Shield Bash uses:" + (playerCharacter.specialItemCount) + "\n\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else if (playerCharacter.block == 6)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Round: " + (roundNo) + "\nCurrent health :" + (playerCharacter.health) + "\nCurrent Potions:" + (playerCharacter.itemCount) + "\nCurrent Double Slash uses:" + (playerCharacter.specialItemCount) + "\n\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Round: " + (roundNo) + "\nCurrent health :" + (playerCharacter.health) + "\nCurrent Potions:" + (playerCharacter.itemCount) + "\nSpecial Staff uses:" + (playerCharacter.specialItemCount) + "\n\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }


                            Console.WriteLine($"Enemy: {enemyCharacter.name}\nHealth: {enemyCharacter.health:#.##}\nWeapons: {enemyCharacter.weapons}");


                            if (playerCharacter.block == 8)
                            {
                                Console.WriteLine("\nWhat would you like to do?\n\n1. Attack\n2. Heal\n3. Shield Bash\n4. Wait\n");
                            }

                            if (playerCharacter.block == 6)
                            {
                                Console.WriteLine("\nWhat would you like to do?\n\n1. Attack\n2. Heal\n3. Double Slash\n4. Wait\n");
                            }

                            if (playerCharacter.block == 4)
                            {
                                Console.WriteLine("\nWhat would you like to do?\n\n1. Attack\n2. Heal\n3. Use Staff\n4. Wait\n");
                            }
                            int moveChoice = Convert.ToInt32(Console.ReadLine());

                            switch (moveChoice)
                            {
                                case 1:
                                    Console.WriteLine("\nAttacking...");
                                    Thread.Sleep(1250);
                                    playerCharacter.AttackOpponent(enemyCharacter);
                                    break;

                                case 2:
                                    if (playerCharacter.itemCount > 0)
                                    {
                                        playerCharacter.health += 35;
                                        Console.WriteLine("\nYou use a health potion\nYou recieved 35 health");
                                        playerCharacter.itemCount -= 1;
                                        break;
                                    }
                                    else if (playerCharacter.itemCount <= 0)
                                    {
                                        Console.WriteLine("\nYou don't have any health potions left");
                                        break;
                                    }
                                    break;

                                case 3:
                                    if (playerCharacter.block == 8 && playerCharacter.specialItemCount > 0)
                                    {
                                        if (enemyCharacter.name == "Skeleton")
                                        {
                                            Console.WriteLine("\nAttacking...");
                                            Thread.Sleep(1250);
                                            Console.WriteLine($"You shield bashed {enemyCharacter.name}\nHis bones crumpled to the floor");
                                            enemyCharacter.health -= 500;
                                            playerCharacter.specialItemCount--;
                                        }

                                        else
                                        {
                                            Console.WriteLine("\nAttacking...");
                                            Thread.Sleep(1250);
                                            Console.WriteLine($"You shield bashed {enemyCharacter.name} for 2 damage");
                                            enemyCharacter.health -= 2;
                                        }
                                        break;
                                    }

                                    if (playerCharacter.block == 6 && playerCharacter.specialItemCount > 0)
                                    {
                                        if (playerCharacter.block == 6 && enemyCharacter.name == "Worm")
                                        {
                                            Console.WriteLine("\nAttacking...");
                                            Thread.Sleep(1250);
                                            Console.WriteLine($"You sliced the worm into a million pieces");
                                            enemyCharacter.health -= 500;
                                            playerCharacter.specialItemCount--;
                                        }

                                        else
                                        {

                                            Console.WriteLine("\nAttacking...");
                                            Thread.Sleep(1250);
                                            playerCharacter.DoubleSlashOpponent(enemyCharacter);
                                            playerCharacter.specialItemCount--;
                                            break;
                                        }

                                    }
                                    if (playerCharacter.specialItemCount == 0)
                                    {
                                        Console.WriteLine("\nYou are all out of special attacks");
                                        break;

                                    }

                                    if (playerCharacter.block == 4 && playerCharacter.specialItemCount > 0)
                                    {
                                        Console.WriteLine("\nWhich staff do you want to use?\n1. Staff of Fire\n2. Staff of Ice");
                                        int staffChoice = Convert.ToInt32(Console.ReadLine());

                                        switch (staffChoice)
                                        {

                                            case 1:
                                                if (enemyCharacter.name == "Wolf")
                                                {
                                                    Console.WriteLine("\nAttacking...");
                                                    Thread.Sleep(1250);
                                                    Console.WriteLine($"\nYou set {enemyCharacter.name} on fire!\nHe is vulnerable to fire");
                                                    playerCharacter.FireAttack(enemyCharacter);
                                                    playerCharacter.specialItemCount--;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nAttacking...");
                                                    Thread.Sleep(1250);
                                                    Console.WriteLine($"\nYou set {enemyCharacter.name} on fire!\nHe quickly put himself out");
                                                    playerCharacter.AttackOpponent(enemyCharacter);
                                                    playerCharacter.specialItemCount--;

                                                }
                                                break;

                                            default:
                                                if (enemyCharacter.name == "Slime")
                                                {
                                                    Console.WriteLine("\nAttacking...");
                                                    Thread.Sleep(1250);
                                                    Console.WriteLine($"\nYou froze {enemyCharacter.name}!\nHe is vulnerable to ice");
                                                    playerCharacter.IceAttack(enemyCharacter);
                                                    playerCharacter.specialItemCount--;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nAttacking...");
                                                    Thread.Sleep(1250);
                                                    Console.WriteLine($"\nYou froze {enemyCharacter.name}!\nIt has no added affect on him");
                                                    playerCharacter.AttackOpponent(enemyCharacter);
                                                    playerCharacter.specialItemCount--;
                                                }
                                                break;
                                        }
                                    }
                                    break;


                                default:
                                    Console.WriteLine("\nYou've decided to wait...");
                                    break;
                            }

                            if (enemyCharacter.health <= 0)
                            {
                                Console.WriteLine($"\nVictory!\nEnemy Defeated");
                                roundNo++;
                                if (roundNo % 5 == 0)
                                {
                                    playerCharacter.itemCount++;
                                    Console.WriteLine("\nYou recieved an extra health potion!");
                                }
                                if (roundNo % 3 == 0)
                                {
                                    playerCharacter.specialItemCount++;
                                    Console.WriteLine("You recieved an extra special ability!");
                                }
                                AnyKeyContinue();
                                break;
                            }

                            else
                            {

                                AnyKeyContinue();

                                if (moveChoice == 3 && playerCharacter.block == 8 && playerCharacter.specialItemCount > 0)
                                {
                                    Console.WriteLine($"{enemyCharacter.name} is stunned and cannot make a move");
                                    playerCharacter.specialItemCount--;
                                }

                                else
                                {

                                    Console.WriteLine($"{enemyCharacter.name}'s Turn\n\n{enemyCharacter.name} is thinking...");
                                    Thread.Sleep(1250);
                                    Console.WriteLine($"{enemyCharacter.name} decides to attack");
                                    enemyCharacter.AttackOpponent(playerCharacter);
                                }


                                AnyKeyContinue();
                            }
                        }
                    }
                }

                else if (roundNo % 10 == 0)
                {
                    Enemy enemyCharacter = GetDragon();

                    if (playerCharacter.health > 0 && roundNo != 1)
                    {
                        playerCharacter.health += RoundTransfer();
                    }

                    while (gameIsRunning)
                    {
                        if (playerCharacter.health <= 0)
                        {
                            gameIsRunning = false;
                        }


                        else
                        {
                            if (playerCharacter.block == 8)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Round: " + (roundNo) + "\nCurrent health :" + (playerCharacter.health) + "\nCurrent Potions:" + (playerCharacter.itemCount) + "\nCurrent Shield Bash uses:" + (playerCharacter.specialItemCount) + "\n\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else if (playerCharacter.block == 6)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Round: " + (roundNo) + "\nCurrent health :" + (playerCharacter.health) + "\nCurrent Potions:" + (playerCharacter.itemCount) + "\nCurrent Double Slash uses:" + (playerCharacter.specialItemCount) + "\n\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Round: " + (roundNo) + "\nCurrent health :" + (playerCharacter.health) + "\nCurrent Potions:" + (playerCharacter.itemCount) + "\nSpecial Staff uses:" + (playerCharacter.specialItemCount) + "\n\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Enemy: {enemyCharacter.name}\nHealth: {enemyCharacter.health:#.##}\nWeapons: {enemyCharacter.weapons}");
                            Console.ForegroundColor = ConsoleColor.White;

                            if (playerCharacter.block == 8)
                            {
                                Console.WriteLine("\nWhat would you like to do?\n\n1. Attack\n2. Heal\n3. Shield Bash\n4. Wait\n");
                            }

                            if (playerCharacter.block == 6)
                            {
                                Console.WriteLine("\nWhat would you like to do?\n\n1. Attack\n2. Heal\n3. Double Slash\n4. Wait\n");
                            }

                            if (playerCharacter.block == 4)
                            {
                                Console.WriteLine("\nWhat would you like to do?\n\n1. Attack\n2. Heal\n3. Use Staff\n4. Wait\n");
                            }
                            int moveChoice = Convert.ToInt32(Console.ReadLine());

                            switch (moveChoice)
                            {
                                case 1:
                                    Console.WriteLine("\nAttacking...");
                                    Thread.Sleep(1250);
                                    playerCharacter.AttackOpponent(enemyCharacter);
                                    break;

                                case 2:
                                    if (playerCharacter.itemCount > 0)
                                    {
                                        playerCharacter.health += 35;
                                        Console.WriteLine("\nYou use a health potion\nYou recieved 35 health");
                                        playerCharacter.itemCount -= 1;
                                        break;
                                    }
                                    else if (playerCharacter.itemCount <= 0)
                                    {
                                        Console.WriteLine("\nYou don't have any health potions left");
                                        break;
                                    }
                                    break;

                                case 3:
                                    if (playerCharacter.block == 8 && playerCharacter.specialItemCount > 0)
                                    {
                                     
                                        
                                            Console.WriteLine("\nAttacking...");
                                            Thread.Sleep(1250);
                                            Console.WriteLine($"{enemyCharacter.name} cannot be stunned");
                                        playerCharacter.specialItemCount--;
                                          
                                        
                                        break;
                                    }

                                    if (playerCharacter.block == 6 && playerCharacter.specialItemCount > 0)
                                    {
                                        Console.WriteLine("\nAttacking...");
                                        Thread.Sleep(1250);
                                        playerCharacter.DoubleSlashOpponent(enemyCharacter);
                                        playerCharacter.specialItemCount--;
                                        break;

                                    }
                                    if (playerCharacter.specialItemCount == 0)
                                    {
                                        Console.WriteLine("\nYou are all out of special attacks");
                                        break;

                                    }

                                    if (playerCharacter.block == 4 && playerCharacter.specialItemCount > 0)
                                    {
                                        Console.WriteLine("\nWhich staff do you want to use?\n1. Staff of Fire\n2. Staff of Ice");
                                        int staffChoice = Convert.ToInt32(Console.ReadLine());

                                        switch (staffChoice)
                                        {

                                            case 1:
                                                if (enemyCharacter.name == "Dragon")
                                                {
                                                    Console.WriteLine("\nAttacking...");
                                                    Thread.Sleep(1250);
                                                    Console.WriteLine($"\nYou set {enemyCharacter.name} on fire!\nHe is invulnerable to fire");
                                                    playerCharacter.specialItemCount--;
                                                }
                                                break;

                                            default:
                                                if (enemyCharacter.name == "Dragon")
                                                {
                                                    Console.WriteLine("\nAttacking...");
                                                    Thread.Sleep(1250);
                                                    Console.WriteLine($"\nYou froze {enemyCharacter.name}!\nHe is vulnerable to ice");
                                                    playerCharacter.IceAttack(enemyCharacter);
                                                    playerCharacter.specialItemCount--;
                                                }
                                                break;
                                        }
                                    }
                                    break;


                                default:
                                    Console.WriteLine("\nYou've decided to wait...");
                                    break;
                            }

                            if (enemyCharacter.health <= 0)
                            {
                                Console.WriteLine($"\nVictory!\n{enemyCharacter.name} Defeated");
                                roundNo++;
                                if (roundNo % 5 == 0 || roundNo == 11 || roundNo == 21 || roundNo == 31 || roundNo == 41)
                                {
                                    playerCharacter.itemCount++;
                                    Console.WriteLine("\nYou recieved an extra health potion!");
                                }
                                if (roundNo % 3 == 0 || roundNo == 11 || roundNo == 21 || roundNo == 31 || roundNo == 41)
                                {
                                    playerCharacter.specialItemCount++;
                                    Console.WriteLine("You recieved an extra special ability!");
                                }
                                AnyKeyContinue();
                                break;
                            }

                            else
                            {

                                AnyKeyContinue();

                                if (playerCharacter.block == 8)
                                {

                                    Console.WriteLine($"{enemyCharacter.name}'s Turn\n\n{enemyCharacter.name} is thinking...");
                                    Thread.Sleep(1250);
                                    Console.WriteLine($"{enemyCharacter.name} decides to attack\n\nYou use your shield to block some of the flames");
                                    enemyCharacter.FlameBreathVSTank(playerCharacter);
                                }

                                else
                                {
                                    if (enemyCharacter.name == "Dragon" && playerCharacter.block == 8)
                                    {

                                        Console.WriteLine($"{enemyCharacter.name}'s Turn\n\n{enemyCharacter.name} is thinking...");
                                        Thread.Sleep(1250);
                                        Console.WriteLine($"{enemyCharacter.name} decides to attack but your shield stops some of it\n");
                                        enemyCharacter.FlameBreathVSTank(playerCharacter);

                                    }
                                    else
                                    {

                                        Console.WriteLine($"{enemyCharacter.name}'s Turn\n\n{enemyCharacter.name} is thinking...");
                                        Thread.Sleep(1250);
                                        Console.WriteLine($"{enemyCharacter.name} decides to attack\n");
                                        enemyCharacter.AttackOpponent(playerCharacter);
                                    }
                                }


                                AnyKeyContinue();
                            }
                        }
                    }
                }
            }
            
            Console.WriteLine("Game over");
            Console.WriteLine($"You lasted {roundNo} rounds\nThank you for playing");
            Console.ReadKey(true);


            

        }

        public static void AnyKeyContinue()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static int RoundTransfer()
        {
            Random healthRegenRND = new Random();
            int healthRegen = healthRegenRND.Next(1, 10);
            Console.WriteLine($"You regained {healthRegen} health!");
            Console.WriteLine("\nGet ready for the next round...");
            AnyKeyContinue();
            return healthRegen;

        }



        public static Character GetCharacter()
        {
            Console.WriteLine("Select a class:\n1. Tank\n2. Fighter\n3. Mage");
            int classChoice = Convert.ToInt32(Console.ReadLine());

            switch (classChoice)
            {
                case 1:
                    return new Tank();
                    
                case 2:
                    return new Fighter();
                  
                default:
                    return new Mage();
            }
        }


        public static  Enemy GetEnemy()
        {
            int roundNoEnemy = 1;
            roundNoEnemy++; 
            Random rndEnemy = new Random();
            int enemySelect = rndEnemy.Next(1, 6);

            if (enemySelect == 1)
            {
                return new Goblin();
            }

            else if (enemySelect == 2)
            {
                return new Wolf();
            }

            else if (enemySelect == 3)
            {
                return new Skeleton();
            }

            else if (enemySelect == 4)
            {
                return new Worm();
            }

            else
            {
                return new Slime();
            }
        }

        public static Enemy GetDragon()
        {
            return new Dragon();
        }

    }

}
  