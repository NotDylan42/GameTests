using System;

class sideScroller
{
    static void Main()
    {
        Console.WriteLine("Welcome to Infinite Mario!");

        while (true)
        {
            PlayGame();
            Console.WriteLine("Game over! Play again? (Y/N)");

            if (Console.ReadKey().Key != ConsoleKey.Y)
                break;
        }

        Console.WriteLine("Thank you for playing Infinite Mario!");
    }

    static void PlayGame()
    {
        // Initialize game variables
        int score = 0;
        int level = 1;
        bool gameOver = false;

        while (!gameOver)
        {
            Console.Clear();
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"Score: {score}");
            Console.WriteLine("Press SPACE to jump or Q to quit.");

            GenerateLevel();

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine("Jump!");
                score += 10;
            }
            else if (keyInfo.Key == ConsoleKey.Q)
            {
                gameOver = true;
            }
            else
            {
                continue;
            }

            level++;
        }
    }

    static void GenerateLevel()
{
    int levelWidth = 20;
    int levelHeight = 10;

    char[,] level = new char[levelHeight, levelWidth];

    for (int y = 0; y < levelHeight; y++)
    {
        for (int x = 0; x < levelWidth; x++)
        {
            level[y, x] = ' ';
        }
    }

    Random random = new Random();
    int numPlatforms = random.Next(3, 6);

    for (int i = 0; i < numPlatforms; i++)
    {
        int platformWidth = random.Next(4, 8);
        int platformHeight = 1;

        int platformX = random.Next(0, levelWidth - platformWidth);
        int platformY = random.Next(0, levelHeight - platformHeight);

        // Place the platform in the level
        for (int y = platformY; y < platformY + platformHeight; y++)
        {
            for (int x = platformX; x < platformX + platformWidth; x++)
            {
                level[y, x] = '#';
            }
        }
    }

    for (int y = 0; y < levelHeight; y++)
    {
        for (int x = 0; x < levelWidth; x++)
        {
            Console.Write(level[y, x]);
        }
        Console.WriteLine();
    }
}
}
