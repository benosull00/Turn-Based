using System;

namespace Turn_Based
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int roundNo = 0;
            bool gameIsRunning = true;


            Console.WriteLine("Enter your name");
            string nameText = Console.ReadLine();
            Character playerCharacter = GetCharacter();
            playerCharacter.name = nameText;
            Console.WriteLine($"\nHealth: {playerCharacter.health}\nDamage: {playerCharacter.damage}\nBlock: {playerCharacter.block}\n\nWeapons:\n{playerCharacter.weapons}");

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey(true);
            Console.Clear();


            while (gameIsRunning)
            {
                roundNo++;
                Console.WriteLine("Round: " + (roundNo));

                Enemy enemyCharacter = GetEnemy();
                Console.WriteLine($"{enemyCharacter.name}\n {enemyCharacter.health}");

                break;

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
            int enemySelect = rndEnemy.Next(1, 3);

            if (enemySelect == 2)
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
  