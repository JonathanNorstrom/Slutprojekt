public class StandardGame : Game
{
    public StandardGame(int startingMoney) : base(startingMoney) { }

    public override int Play()
    {
        Console.WriteLine("Welcome to the Standard game mode!");
        Console.WriteLine("Guess a number between 1 and 10:");

        int randomNumber = random.Next(1, 11);
        int guess;
        bool guessedCorrectly = false;

        do
        {
            guess = Convert.ToInt32(Console.ReadLine());

            if (guess == randomNumber)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations! You guessed the correct number!");
                Console.ResetColor();
                guessedCorrectly = true;
                currentMoney += 10; // Win $10
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, that's not the correct number. Try again!");
                Console.ResetColor();
                currentMoney -= 5; // Lose $5
            }
        } while (!guessedCorrectly);

        Console.WriteLine($"Your current balance: ${currentMoney}");
        return currentMoney;
    }
}
