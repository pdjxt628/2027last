// input
var n = Console.ReadLine();
if (n == null) return;


// judge
bool isInt = true;
try {
    int m = int.Parse(n);
}
catch {
    isInt = false;
}


// output
if (isInt) {
    Console.WriteLine(n.ToString() + " is integer");
}
else {
    Console.WriteLine(n.ToString() + " is not integer");
}

