
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var str =int.Parse(Console.ReadLine());

            if(str==(int)str)
            {
                Console.WriteLine(str+"!整数だ！");
            }
            else
            {
                Console.WriteLine("整数じゃないです--");
            }
                      

        }
    }
}