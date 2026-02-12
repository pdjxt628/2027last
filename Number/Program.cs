using System;

string input = Console.ReadLine();

if (int.TryParse(input, out int result))
{
    Console.WriteLine("整数です");
}
else
{
    Console.WriteLine("整数ではありません");
}
