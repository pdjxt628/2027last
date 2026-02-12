// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

var l = Console.ReadLine();

if (int.TryParse(l, out int result))
{
    Console.WriteLine($"{result}...こいつはせいすうだな");

}
else
{
    Console.WriteLine($"{l}...こいつ、せいすうじゃねえ！");
}


