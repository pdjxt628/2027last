using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Write something");

        string UserInput = Console.ReadLine() ?? "";

        if (int.TryParse(UserInput, out int number))
        {
            Console.WriteLine($"'{UserInput}' is an integer.");
        }
        else
        {
            Console.WriteLine($"'{UserInput}' is not an integer.");
        }
    }
}