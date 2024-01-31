using System;
using System.Collections.Generic;

class DS
{
    class stack
    {
        public int shomarande;
        public char meghdar;
        public stack(int x, char y)
        {
            shomarande = x;
            meghdar = y;
        }
    }
    static void Main()
    {
        string reshte = Console.ReadLine();
        List<stack> list = new List<stack>();
        int khata = -1;
        for (int i = 0; i < reshte.Length; i++)
        {
            if(reshte[i] == '[')
                list.Add(new stack(i,reshte[i]));
            if (reshte[i] == '(')
                list.Add(new stack(i, reshte[i]));
            if (reshte[i] == '{')
                list.Add(new stack(i, reshte[i]));
            if (reshte[i] == ']')
            {
                if (list.Count == 0)
                {
                    khata = i + 1;
                    break;
                }
                if (list[list.Count - 1].meghdar !='[')
                {
                    //Console.WriteLine(i);
                    khata = i+1;
                    break;
                }
                else
                {
                    list.RemoveAt(list.Count - 1);
                }
            }
            if (reshte[i] == ')')
            {
                if (list.Count == 0)
                {
                    khata = i + 1;
                    break;
                }
                if (list[list.Count - 1].meghdar != '(')
                {
                    khata = i+1;
                    break;
                }
                else
                {
                    list.RemoveAt(list.Count - 1);
                }
            }
            if (reshte[i] == '}')
            {
                if (list.Count == 0)
                {
                    khata = i + 1;
                    break;
                }
                if (list[list.Count - 1].meghdar != '{')
                {
                    khata = i+1;
                    break;
                }
                else
                {
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
        if (khata == -1)
        {
            if (list.Count != 0)
            {
                Console.WriteLine(list[0].shomarande+1);
            }
            else
            {
                Console.WriteLine(khata);
            }
        }
        else
        {
            Console.WriteLine(khata);
        }
    }
}
