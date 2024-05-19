using System;

public abstract class Game
{
    protected int currentMoney;
    protected Random random = new Random();

    public Game(int startingMoney)
    {
        currentMoney = startingMoney;
    }

    public abstract int Play();

    protected int RollDice()
    {
        return random.Next(1, 7); // Roll a number between 1 and 6
    }
}
