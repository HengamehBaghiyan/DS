using System;
using System.Collections.Generic;
class program
{
    class reshte
    {
        public List<char> ghavaed = new List<char>();
    }

    static void Main()
    {
        string vorodi = Console.ReadLine();
        reshte[,] reshte_ha = new reshte[vorodi.Length, vorodi.Length];
        for (int i = 0; i < vorodi.Length; i++)
        {
            for (int j = i; j < vorodi.Length; j++)
            {
                reshte_ha[i, j] = new reshte();
            }
        }
        for (int i = 0; i < vorodi.Length; i++)
        {
            if (vorodi[i] == 'a')
            {
                reshte_ha[i, i].ghavaed.Add('A');
            }
            else if (vorodi[i] == 'b')
            {
                reshte_ha[i, i].ghavaed.Add('B');
            }

        }
        for (int l = 1; l < vorodi.Length; l++)
        {
            for (int i = 0; i < vorodi.Length; i++)
            {
                int j = l + i;
                if (j < vorodi.Length)
                {
                    for (int k = i; k < j; k++)
                    {
                        for (int p = 0; p < reshte_ha[i, k].ghavaed.Count; p++)
                        {
                            for (int q = 0; q < reshte_ha[k + 1, j].ghavaed.Count; q++)
                            {
                                string x = reshte_ha[i, k].ghavaed[p].ToString() + reshte_ha[k + 1, j].ghavaed[q].ToString();
                                if (x == "AB")
                                {
                                    reshte_ha[i, j].ghavaed.Add('S');
                                    reshte_ha[i, j].ghavaed.Add('B');
                                }
                                else if (x == "BB")
                                {
                                    reshte_ha[i, j].ghavaed.Add('A');
                                }
                            }
                        }
                    }
                }
            }
        }
        bool peyda = false;
        for (int i = 0; i < reshte_ha[0, vorodi.Length - 1].ghavaed.Count; i++)
        {
            if (reshte_ha[0, vorodi.Length - 1].ghavaed[i] == 'S')
            {
                peyda = true;
                Console.WriteLine("Accepted");
                break;
            }
        }
        if (peyda == false)
        {
            Console.WriteLine("Rejected");
        }
    }
}
