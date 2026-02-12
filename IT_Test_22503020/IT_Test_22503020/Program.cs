// See https://aka.ms/new-console-template for more information

using System;
using MySqlConnector;

namespace NumberSeisu
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!!!!");
            Console.WriteLine("整数を入力してください");

            var input = Console.ReadLine();
            var num = 0;
            if (int.TryParse(input, out num))
            {
                Console.WriteLine("入力した数は");
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("入力されたものは整数じゃありませんでした");
            }
        }
    }
}
