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


            Console.WriteLine("Enter your name");
            string nameText = Console.ReadLine();
            Character playerCharacter = GetCharacter();
            playerCharacter.name = nameText;
            Console.WriteLine($"\nHealth: {playerCharacter.health}\nDamage: {playerCharacter.damage}\nBlock: {playerCharacter.block}\n\nWeapons:\n{playerCharacter.weapons}");

            AnyKeyContinue();


            while (gameIsRunning)
            {
                Enemy enemyCharacter = GetEnemy();

                while (gameIsRunning)
                {
                    if (playerCharacter.health <= 0)
                    {
                        gameIsRunning = false;
                    }

                    else
                    {
                        
                        Console.WriteLine("Round: " + (roundNo) + "\nCurrent health :" + (playerCharacter.health) + "\n\n");


                        Console.WriteLine($"Enemy: {enemyCharacter.name}\nHealth: {enemyCharacter.health}\nWeapons: {enemyCharacter.weapons}");



                        Console.WriteLine("\nWhat would you like to do?\n1. Attack\n2. Wait");
                        int moveChoice = Convert.ToInt32(Console.ReadLine());

                        switch (moveChoice)
                        {
                            case 1:
                                playerCharacter.AttackOpponent(enemyCharacter);
                                Console.WriteLine($"\nYou've dealt {playerCharacter.damage / enemyCharacter.block} damage");
                                break;

                            default:
                                Console.WriteLine("\nYou've decided to wait");
                                break;
                        }

                        if (enemyCharacter.health <= 0)
                        {
                            Console.WriteLine("\nVictory!\nEnemy Defeated\n\nNext Opponent");
                            roundNo++;
                            AnyKeyContinue();
                            break;
                        }

                        else
                        {

                            AnyKeyContinue();

                            Console.WriteLine($"{enemyCharacter.name}'s Turn\n\n{enemyCharacter.name} is thinking...");
                            Thread.Sleep(1250);

                            enemyCharacter.AttackOpponent(playerCharacter);
                            Console.WriteLine($"{enemyCharacter.name} decides to attack");
                            Console.WriteLine($"You take {enemyCharacter.damage / playerCharacter.block} damage");

                            
                            AnyKeyContinue();
                        }
                    }
                }

            }
            Console.WriteLine("Game over");
            Console.WriteLine($"You lasted {roundNo} rounds\nThank you for playing");
            Console.ReadKey(true);


            void AnyKeyContinue()
            {
                Console.WriteLine("\nPres any key to continue");
                Console.ReadKey(true);
                Console.Clear();
            }

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
            int enemySelect = rndEnemy.Next(1, 4);

            if (enemySelect == 2 || enemySelect == 3)
            {
                return new Goblin();
            }

            else 
            {
                return new Wolf();            
            }
        }
    }

}
  