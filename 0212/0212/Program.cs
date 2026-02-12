using System.Text.RegularExpressions;

namespace App02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("数値を入力してください。");

            int inputNum = Convert.ToInt32(Console.ReadLine());
            string txt = inputNum.ToString();
            if (Regex.IsMatch(txt, @"^[0-9]+$")){
                Console.WriteLine("整数です");
            }
            else
            {
                Console.WriteLine("整数ではありません");
            }
        }
    }
}