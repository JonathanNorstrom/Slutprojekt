public class LuckySevensGame : Game
{
    public LuckySevensGame(int startingMoney) : base(startingMoney) { }

    public override int Play()
    {
        Console.WriteLine("Welcome to the Lucky Sevens game mode!");

        while (currentMoney > 0)
        {
            Console.WriteLine("Press Enter to roll the dice...");
            Console.ReadLine();

            int dice1 = RollDice();
            int dice2 = RollDice();

            Console.WriteLine($"You rolled: {dice1} and {dice2}");

            if (dice1 + dice2 == 7)
            {
                Console.WriteLine("Congratulations! You rolled lucky sevens and win $10!");
                currentMoney += 10; // Win $10
            }
            else
            {
                Console.WriteLine("Sorry, no lucky sevens this time. You lose $5.");
                currentMoney -= 5; // Lose $5
            }

            Console.WriteLine($"Your current balance: ${currentMoney}");
        }

        Console.WriteLine("You're out of money! Game over.");
        return currentMoney;
    }
}
