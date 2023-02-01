using System;
using System.Threading;

namespace Turn_Based
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int roundNo = 1;
            bool gameIsRunning = true;
            

            Console.WriteLine("Welcome\nThis is a turn based combat game\nEvery round you will be presented with a new enemy and can use various abilities to defeat them\n\nAfter each round you will recover some health\n\nEvery 5 rounds you will recieve an extra health potion and every 3 rounds you will recieve and extra special ability\n\nEvery x rounds there will be a boss (ALSO NOT ADDED YET)\n\ngl&hf");
            AnyKeyContinue();


            Console.WriteLine("Enter your name");
            string nameText = Console.ReadLine();
            Character playerCharacter = GetCharacter();
            playerCharacter.name = nameText;
            Console.WriteLine($"\nHealth: {playerCharacter.health}\nDamage: {playerCharacter.damage}\nBlock: {playerCharacter.block}\n\nWeapons:\n{playerCharacter.weapons}\n\nItems: x{playerCharacter.itemCount} {playerCharacter.itemNames}");

            AnyKeyContinue();


            while (gameIsRunning)
            {
                Enemy enemyCharacter = GetEnemy();

                if (playerCharacter.health < 100 && playerCharacter.health > 0)
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
                        if (playerCharacter.block == 7)
                        {
                            Console.WriteLine("Round: " + (roundNo) + "\nCurrent health :" + (playerCharacter.health) + "\nCurrent Potions:" + (playerCharacter.itemCount) + "\nCurrent Shield Bash uses:" + (playerCharacter.specialItemCount) + "\n\n");
                        }

                        else if (playerCharacter.block == 5)
                        {
                            Console.WriteLine("Round: " + (roundNo) + "\nCurrent health :" + (playerCharacter.health) + "\nCurrent Potions:" + (playerCharacter.itemCount) + "\nCurrent Double Slash uses:" + (playerCharacter.specialItemCount) + "\n\n");
                        }

                        else
                        {
                            Console.WriteLine("Round: " + (roundNo) + "\nCurrent health :" + (playerCharacter.health) + "\nCurrent Potions:" + (playerCharacter.itemCount) + "\nSpecial Staff uses:" + (playerCharacter.specialItemCount) + "\n\n");
                        }


                        Console.WriteLine($"Enemy: {enemyCharacter.name}\nHealth: {enemyCharacter.health:#.##}\nWeapons: {enemyCharacter.weapons}");


                        if (playerCharacter.block == 7)
                        {
                            Console.WriteLine("\nWhat would you like to do?\n\n1. Attack\n2. Heal\n3. Shield Bash\n4. Wait\n");
                        }

                        if (playerCharacter.block == 5)
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
                                    playerCharacter.health += 15;
                                    Console.WriteLine("\nYou use a health potion\nYou recieved 15 health");
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
                                if (playerCharacter.block == 7 && playerCharacter.specialItemCount > 0)
                                {
                                    Console.WriteLine("\nAttacking...");
                                    Thread.Sleep(1250);
                                    Console.WriteLine($"You shield bashed {enemyCharacter.name} for 2 damage");
                                    enemyCharacter.health -= 2;
                                    
                                    break;
                                }

                                if (playerCharacter.block == 5 && playerCharacter.specialItemCount > 0)
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
                                            Console.WriteLine("\nAttacking...");
                                            Thread.Sleep(1250);
                                            Console.WriteLine($"\nYou set {enemyCharacter.name} on fire!\nHe's nice and toasty");
                                            playerCharacter.AttackOpponent(enemyCharacter);
                                            playerCharacter.specialItemCount--;
                                            break;

                                        default:
                                            Console.WriteLine("\nAttacking...");
                                            Thread.Sleep(1250);
                                            Console.WriteLine($"\nYou froze {enemyCharacter.name}!\nHe's really cold");
                                            playerCharacter.AttackOpponent(enemyCharacter);
                                            playerCharacter.specialItemCount--;
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

                            if (moveChoice == 3 && playerCharacter.block == 7 && playerCharacter.specialItemCount > 0)
                            {
                                Console.WriteLine($"{enemyCharacter.name} is stunned and cannot make a move");
                                playerCharacter.specialItemCount--;
                            }

                            else
                            {

                                Console.WriteLine($"{enemyCharacter.name}'s Turn\n\n{enemyCharacter.name} is thinking...");
                                Thread.Sleep(1250);

                                enemyCharacter.AttackOpponent(playerCharacter);
                                Console.WriteLine($"{enemyCharacter.name} decides to attack");
                                Console.WriteLine($"\nYou take {enemyCharacter.damage / playerCharacter.block} damage");
                            }

                            
                            AnyKeyContinue();
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
            int healthRegen = healthRegenRND.Next(0, 6);
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
            Random rndEnemy = new Random();
            int enemySelect = rndEnemy.Next(1, 10);

            if (enemySelect >= 1 && enemySelect <= 5)
            {
                return new Goblin();
            }

            else if (enemySelect >= 6 && enemySelect < 9)
            {
                return new Wolf();            
            }

            else
            {
                return new BanKiMoon();
            }
        }
    }

}
  