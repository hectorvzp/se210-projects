using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        Console.WriteLine("Welcome to the Number Guessing Game!");

        int attempts = 0;
        int userGuessInt;

        do
        {
            Console.Write("Guess the number between 1 and 100: ");
            userGuessInt = int.Parse(Console.ReadLine());

            attempts++;

            if (userGuessInt < number)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else if (userGuessInt > number)
            {
                Console.WriteLine("Too high! Try again.");
            }

        }
        while (userGuessInt != number);
        Console.WriteLine("Congratulations! You guessed the correct number!");
        Console.WriteLine($"You made {attempts} attempts.");
    }
}