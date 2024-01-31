using System;
class program
{
    static int merg(int[] arrye, int shoro, int middle, int payan)
    {
        int[] help = new int[payan - shoro + 1];
        int a1 = shoro;
        int a2 = middle + 1;
        int count = 0;
        for (int i = 0; i < payan - shoro + 1; i++)
        {
            if (a1 == middle+1)
            {
                help[i] = arrye[a2];
                a2++;
            }
            else if (a2 == payan+1)
            {
                help[i] = arrye[a1];
                a1++;
            }
            else if (arrye[a1] > arrye[a2])
            {
                help[i] = arrye[a1];
                a1++;
                count += payan - a2+1;
            }
            else if (arrye[a2] >= arrye[a1])
            {
                help[i] = arrye[a2];
                a2++;
            }
        }
        for(int i = shoro; i <= payan; i++)
        {
            arrye[i] = help[i - shoro];
        }
        //for (int i= 0; i< payan - shoro + 1;i++)
        //{
        //    Console.Write(help[i]);
        //    Console.Write("  ");
        //}
        //Console.WriteLine( count);
        //Console.WriteLine();
        return count;
    }
    static int merg_sort(int[] arrye, int shoro, int payan)
    {
        if (shoro == payan)
        {
            return 0;
        }
        int middle = (shoro + payan) / 2;
        //merg_sort(arrye, shoro, middle);
        //merg_sort(arrye, middle + 1, payan);
        return merg_sort(arrye, middle + 1, payan)+ merg_sort(arrye, shoro, middle)+merg(arrye, shoro, middle, payan);
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] araye = new int[n];
        for (int i = 0; i < n; i++)
        {
            araye[i] = int.Parse(Console.ReadLine());
        }
      
        Console.WriteLine(merg_sort(araye,0,n-1));
        //for (int i = 0; i < n; i++)
        //{
        //    Console.WriteLine(araye[i]);
        //}
    }
}
