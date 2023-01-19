using System;
int[] classHealth = new int[3] { 200, 140, 100 }; // Each classes health

SelectingClass();










int SelectingClass()
{
    Console.WriteLine("Select a class:\n1. Tank\n2. Fighter\n3. Mage");
    string classChoiceText = Console.ReadLine();
    int classChoice = Convert.ToInt32(classChoiceText);

    switch (classChoice)
    {
        case 1:
            Console.WriteLine("You chose Tank");
            return classChoice;
            break;

        case 2:
            Console.WriteLine("You chose Fighter");
            return classChoice;
            break;

        case 3:
            Console.WriteLine("You chose Mage");
            return classChoice;
            break;

        default:
            Console.WriteLine("That wasn't an option");
            return classChoice;
            break;
    }
} // Setting up class selection

class ClassChoice
{
    public string classType;
    public int classHealth;
    public string classWeapons;
} // Things that depend on the class you choose

enum Classes { Tank, Fighter, Mage } // The different classes
enum ClassWeapons { Greatsword, Shield, TwoShortSwords, FireStaff, IceStaff} // Each classes weapons
