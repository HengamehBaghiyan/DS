using System;
class program
{
    static void Main()
    {
        int n=int.Parse(Console.ReadLine());
        int x = n / 10;
        int y = (n - x * 10) / 5;
        int z = n - x * 10 - y * 5;
        Console.WriteLine(x + y + z);
    }
}
