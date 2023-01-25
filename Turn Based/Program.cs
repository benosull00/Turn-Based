using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Turn_Based
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string nameText = Console.ReadLine();
            Character playerCharacter = GetCharacter();
            playerCharacter.name = nameText;
            Console.WriteLine($"Name: {playerCharacter.name}\nHealth: {playerCharacter.health}\nDamage: {playerCharacter.damage}\nBlock: {playerCharacter.block}");
        }






        public static Character GetCharacter()
        {
            Console.WriteLine("Select a class:\nTank\nFighter\nMage");
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
    }












   /* public class Character
    {
        public string name;
        public int health;
        public int damage;
        public int block;
        
        public Character(string name, int health, int damage, int block)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.block = block;
        }

        public void RecieveDamageFromOpponent(int incomingDamage)
        {
            this.health -= incomingDamage;
        }

        public void DealDamageToOpponent(Character opoonent)
        {
            opoonent.RecieveDamageFromOpponent(this.damage);
        }
    }


    */
}
  