public class HighRollerGame : Game
{
    public HighRollerGame(int startingMoney) : base(startingMoney) { }

    public override int Play()
    {
        Console.WriteLine("Welcome to the High Roller game mode!");

        int dice1 = RollDice();
        int dice2 = RollDice();

        Console.WriteLine($"You rolled: {dice1} and {dice2}");

        if (dice1 + dice2 > 7)
        {
            Console.WriteLine("You win! Your total is greater than 7.");
            currentMoney += 10; // Win $10
        }
        else
        {
            Console.WriteLine("You lose! Your total is less than or equal to 7.");
            currentMoney -= 5; // Lose $5
        }

        Console.WriteLine($"Your current balance: ${currentMoney}");
        return currentMoney;
    }
}
