using System;
class DS
{
    static void bazgashti(float[]x,int ebteda,int enteha,float key)
    {
        if (enteha - ebteda + 1 <= 2)
        {
            if(enteha - ebteda + 1 == 2)
            {
                Console.WriteLine(x[ebteda] + key);
                return;
            }
        }
        if ((enteha-ebteda+1) % 2 == 0)//tool zoj
        {
            int vasat = (ebteda + enteha) / 2;
            int vasat1 = vasat + 1;
            if ((x[vasat1] - x[vasat]) > key)
            {
                Console.WriteLine((x[vasat] + key));
                return;
            }
            if ((x[vasat] - x[ebteda]) > (x[enteha] - x[vasat1]))
            {
                bazgashti(x, ebteda, vasat, key);
            }
            else
            {
                bazgashti(x, vasat1, enteha, key);
            }
        }
        else
        {
            int vasat = (ebteda + enteha) / 2;
            if ((x[vasat] - x[ebteda]) > (x[enteha] - x[vasat]))
            {
                bazgashti(x, ebteda,vasat, key);
            }
            else
            {
                bazgashti(x, vasat, enteha, key);
            }
        }
    }
    static void Main()
    {
        int n =int.Parse(Console.ReadLine());
        float[] favasel = new float[n];
        string[] voroodi = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
        {
            favasel[i] = float.Parse(voroodi[i]);
        }
        if (n == 2)
        {
            Console.WriteLine((favasel[0] + favasel[1]) / 2);
        }
        float key = favasel[1] - favasel[0];
        if (key > favasel[2] - favasel[1])
            Console.WriteLine(favasel[0] + (favasel[2] - favasel[1]));
        bazgashti(favasel, 0, n - 1,key);
        //else
        //{
        //    for (int i = 2; i < n; i++)
        //    {
        //        if (key < favasel[i] - favasel[i - 1])
        //        {
        //            Console.WriteLine(favasel[i - 1] + key);
        //        }
        //    }
        //}
    }
}
