using System;
using System.Globalization;

Console.WriteLine("数字を入力してください");

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();
    if (TryParseDecimal(input, out var number))
    {
        if (IsInteger(number))
        {
            Console.WriteLine($"入力された数値は整数です: {number}");
        }
        else
        {
            Console.WriteLine($"入力された数値は整数ではない: {number}");
        }
    }
}

static bool TryParseDecimal(string s , out decimal result)
{
    if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.CurrentCulture, out result))
        return true;
    if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out result))
        return true;
    return false;
}

static bool IsInteger(decimal d) => d % 1 == 0;
