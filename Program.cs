using System;
using System.IO;

enum GameMode
{
    Standard,
    HighRoller,
    LuckySevens
}

class Program
{
    static string saveFilePath = "playerdata.txt";

    static void Main(string[] args)
    {
        int currentMoney = LoadPlayerData();

        bool exit = false;

        while (!exit)
        {
            GameMode selectedMode = ChooseGameMode();

            Game game = selectedMode switch
            {
                GameMode.Standard => new StandardGame(currentMoney),
                GameMode.HighRoller => new HighRollerGame(currentMoney),
                GameMode.LuckySevens => new LuckySevensGame(currentMoney),
                _ => throw new InvalidOperationException("Invalid game mode selected")
            };

            currentMoney = game.Play();

            Console.WriteLine("Do you want to play another game? (yes/no)");
            string playAgain = Console.ReadLine().ToLower();

            if (playAgain != "yes")
            {
                exit = true;
            }
        }

        SavePlayerData(currentMoney);
        Console.WriteLine("Thanks for playing!");
    }

    static GameMode ChooseGameMode()
    {
        Console.WriteLine("Select a game mode:");
        Console.WriteLine("1. Standard");
        Console.WriteLine("2. High Roller");
        Console.WriteLine("3. Lucky Sevens");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
        {
            Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
        }

        return choice switch
        {
            1 => GameMode.Standard,
            2 => GameMode.HighRoller,
            3 => GameMode.LuckySevens,
            _ => throw new InvalidOperationException("Invalid game mode selected")
        };
    }

    static int LoadPlayerData()
    {
        if (File.Exists(saveFilePath))
        {
            try
            {
                string savedData = File.ReadAllText(saveFilePath);
                int money = int.Parse(savedData);
                Console.WriteLine($"Loaded saved data. Current money: ${money}");
                return money;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading saved data: {ex.Message}");
            }
        }
        return 100; // Default starting money if no data is found
    }

    static void SavePlayerData(int currentMoney)
    {
        try
        {
            File.WriteAllText(saveFilePath, currentMoney.ToString());
            Console.WriteLine($"Saved current money: ${currentMoney}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }
}
