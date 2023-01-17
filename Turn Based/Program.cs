using System;

Console.WriteLine("Select a class");
Console.WriteLine("\n1. Tank\n2. Fighter\n3. Mage");
string classSelectText = Console.ReadLine();
int classSelect = Convert.ToInt32(classSelectText);

switch (classSelect)
{
    case 1:
        Console.WriteLine("You chose Tank\n\nHP: 200\n\nWeapons:\nGreatsword\nShield");
        break;

    case 2:
        Console.WriteLine("You chose Fighter\n\nHP: 140\n\nWeapons:\nShortsword x2");
        break;

    case 3:
        Console.WriteLine("You chose mage\n\nHP: 100\n\nWeapons:\nStaff of Fire\nStaff of Ice");
        break;
}

Console.WriteLine("gIT TEST");
