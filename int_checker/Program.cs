using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace int_checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.WriteLine("数値を入力してください");

                string value = Console.ReadLine();
                int convert;
                bool isNumber = int.TryParse(value, out convert);

                if (isNumber) {
                    Console.WriteLine($"{value}は整数です");
                }
                else {
                    Console.WriteLine($"{value}は整数以外ではありません");
                }

                    while (true) {
                        Console.WriteLine("続けますか？(y/n)");
                        var check = Console.ReadLine();

                        if (check == "y") {

                            break;
                        }
                        if (check == "n") {
                            return;
                        }
                    }
            }
        }
    }
}
