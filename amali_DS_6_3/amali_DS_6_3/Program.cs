using System;
class program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n + 1];
        array[0] = 0;
        array[1] = 1;
        array[2] = 2;
        array[3] = 1;
        array[4] = 1;

        for (int i = 5; i < n + 1; i++)
        {
            if (array[i - 1] <= array[i-4] && array[i - 1] <= array[i - 3])
            {
                array[i] = array[i - 1] + 1;
            }
            else if (array[i - 3] <= array[i - 4] && array[i - 3] <= array[i - 1])
            {
                array[i] = array[i - 3] + 1;
            }
            else if (array[i - 4] <= array[i - 1] && array[i - 4] <= array[i - 3])
            {
                array[i] = array[i - 4] + 1;
            }
        }
        Console.WriteLine(array[n]);
    }
}
