using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2027last
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberVal;
            string input;

            Console.WriteLine("数値を入力してください:");
            input = Console.ReadLine();
            try
            {
                numberVal = Int32.Parse(input);
                Console.WriteLine("入力したバリューは整数です");
                Console.ReadKey();
            }
            catch (Exception error)
            {
                Console.WriteLine("入力したのバリューは整数じゃない");
                Console.ReadKey();
            }
        }
    }
}
