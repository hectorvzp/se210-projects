using System;

class Program
{


    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string GetUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int GetUserNumber()
    {
        Console.Write("Please enter your Favorite Number:");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int SquareNumber(int number)
    {
        return number * number;
    }
    static void DisplayResult(string name, int number, int squared)
    {
        Console.WriteLine($"{name}, the square of your favorite number {number} is {squared}.");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = GetUserName();
        int number = GetUserNumber();
        int squared = SquareNumber(number);
        DisplayResult(name, number, squared);
    }
}