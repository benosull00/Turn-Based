using System;

Random enemyNumberGenerator = new Random();
int playerHP = 0;
int enemyHP = 0;
int roundNumber = 1;
string[] enemyTypeNames = { "Goblin", "Goblin",  "Warlock" };


Console.WriteLine("Select a class");
Console.WriteLine("\n1. Tank\n2. Fighter\n3. Mage");
string classSelectText = Console.ReadLine();
int classSelect = Convert.ToInt32(classSelectText);
// Input for class select

switch (classSelect)
{
    case 1:
        Console.WriteLine("You chose Tank\n\nHP: 200\n\nWeapons:\nGreatsword\nShield");
        playerHP = 200;
        break;

    case 2:
        Console.WriteLine("You chose Fighter\n\nHP: 140\n\nWeapons:\nShortsword x2");
        playerHP = 140;
        break;

    case 3:
        Console.WriteLine("You chose mage\n\nHP: 100\n\nWeapons:\nStaff of Fire\nStaff of Ice");
        playerHP = 100;
        break;
}
// Class select

Console.ReadKey(true);
Console.Clear();

Console.WriteLine($"Round: {roundNumber}\n");

int enemyIndex = enemyNumberGenerator.Next(enemyTypeNames.Length);

if (enemyIndex == 0 || enemyIndex == 1)
{
    enemyHP = 100;
    Console.WriteLine($"Enemy: Goblin\nHP: {enemyHP}");
}

if (enemyIndex == 2)
{
    enemyHP = 130;
    Console.WriteLine($"Enemy: Warlock\nHP: {enemyHP}");
}
// Generating random enemies


Console.WriteLine("What do you wish to do?");
Console.WriteLine("1. Attack\n2. Block\n3. Item");
int roundChoice = Console.ReadLine(Convert.ToInt32);