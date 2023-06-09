using System;

class TopDownAdventure
{
    static void Main()
    {
        Console.WriteLine("Welcome to Test!");

        while (true)
        {
            PlayGame();
            Console.WriteLine("Game over! Play again? (Y/N)");

            if (Console.ReadKey().Key != ConsoleKey.Y)
                break;
        }

        Console.WriteLine("Thank you for playing Test!");
    }

    static void PlayGame()
    {
        Console.Clear();
        Console.WriteLine("You have awoken in a dungeon. Your goal is to find the key and reach the exit.");
        Console.WriteLine("Move with WASD keys. Press Q to quit.");

        // Initialize game variables
        int playerX = 1;
        int playerY = 1;
        bool hasKey = false;
        bool gameOver = false;

        while (!gameOver)
        {
            DrawMap(playerX, playerY, hasKey);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.W:
                    playerY--;
                    break;
                case ConsoleKey.S:
                    playerY++;
                    break;
                case ConsoleKey.A:
                    playerX--;
                    break;
                case ConsoleKey.D:
                    playerX++;
                    break;
                case ConsoleKey.Q:
                    gameOver = true;
                    break;
            }

            // Check if the player picked up the key
            if (playerX == 3 && playerY == 3)
            {
                hasKey = true;
                Console.WriteLine("You found the key!");
            }

            // Check if the player reached the exit
            if (playerX == 7 && playerY == 7 && hasKey)
            {
                Console.WriteLine("Congratulations! You escaped the dungeon!");
                gameOver = true;
            }
        }
    }

    static void DrawMap(int playerX, int playerY, bool hasKey)
    {
        Console.Clear();

        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                if (x == playerX && y == playerY)
                {
                    Console.Write("P");
                }
                else if (x == 3 && y == 3)
                {
                    if (hasKey)
                    {
                        Console.Write("K");
                    }
                    else
                    {
                        Console.Write("X");
                    }
                }
                else if (x == 7 && y == 7)
                {
                    Console.Write("E");
                }
                else
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine();
        }
    }
}
