using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number;
        int sum = 0;
        int large = 0;
        int count = 0;
        float average = 0;
        int smaller = 1000000; // A very large number to ensure any input will be smaller
        Console.WriteLine("Enter numbers (type 0 to finish):");
        do
        {
            number = int.Parse(Console.ReadLine());
            if (number != 0)
                numbers.Add(number);
        } while (number != 0);
        foreach (int num in numbers)
        {
            sum += num;
            count++;
            if (num > large)
                large = num;
            if (num >= 0 && num < smaller)
                smaller = num;
        }
        average = sum / count;
        Console.WriteLine($"The Sum is: {sum}");
        Console.WriteLine($"The Average is: {average}");
        Console.WriteLine($"The Largest is: {large}");
        Console.WriteLine($"The Smallest Positive Number  is: {smaller}");
        numbers.Sort();
        Console.WriteLine("The Sorted List is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}