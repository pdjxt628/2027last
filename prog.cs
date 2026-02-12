using System;
using System.Text;

class Program
{
    static void Main()
    {
        
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.WriteLine("=== 整数チェック ===");
        Console.Write("値を入力してください: ");
        string input = Console.ReadLine();

        
        if (int.TryParse(input, out int result))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ '{input}' は整数です。値: {result}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✗ '{input}' は整数ではありません");
            Console.ResetColor();
        }

        Console.WriteLine("\n終了するには任意のキーを押してください...");
        Console.ReadKey();
    }