var input = Console.ReadLine().Trim();
var number = float.Parse(input);

if(number % 1 == 0)
{
    Console.WriteLine("整数です");

}
else if(number % 1 > 0)
{
    Console.WriteLine("整数ではありません");
}




