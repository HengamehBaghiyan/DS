using System.ComponentModel;
using System;
using System.Collections.Generic;
class node
{
    public double meghdar;
    public node(double me)
    {
        this.meghdar = me;
    }
}
class heap
{
    public node[] zakhire;
    public long akharin = 0;
    public heap(long n)
    {
        zakhire = new node[n];
        //for(int i = 0; i < n; i++)
        //{
        //    zakhire[i] = null;
        //}
    }
    public void Insert(double k)
    {
        //int jay_gozari = -1;
        //for(int i=0;i<zakhire.Length; i++)
        //{
        //    if (zakhire[i] == null)
        //    {
        //        zakhire[i] = new node(k);
        //        jay_gozari = i;
        //        break;
        //    }
        //}
        zakhire[akharin] = new node(k);
        jabejaee1(akharin);
        akharin++;
    }
    public void jabejaee1(long i)
    {
        if (i==0)
        {
            return;
        }
        else if (i % 2 == 0)
        {
            if (zakhire[i].meghdar >zakhire[(i-2)/2].meghdar)
            {
                node tmp = zakhire[i];
                zakhire[i] = zakhire[(i - 2) / 2];
                zakhire[(i - 2) / 2] = tmp;
                jabejaee1((i - 2) / 2);
            }
            return;
        }
        else if (i % 2 == 1)
        {
            if (zakhire[i].meghdar > zakhire[(i - 1) / 2].meghdar)
            {
                node tmp = zakhire[i];
                zakhire[i] = zakhire[(i - 1) / 2];
                zakhire[(i - 1) / 2] = tmp;
                jabejaee1((i - 1) / 2);
            }
            return;
        }
    }
    public void jabejaee(long i)
    {
        if (2 * i + 2 < zakhire.Length)
        {
            if (zakhire[2 * i + 1] == null && zakhire[2 * i + 2] == null)
            {
                return;
            }
            else if (zakhire[2 * i + 1] != null && zakhire[2 * i + 2] == null)
            {
                if (zakhire[i].meghdar < zakhire[2 * i + 1].meghdar)
                {
                    node tmp = zakhire[i];
                    zakhire[i] = zakhire[2 * i + 1];
                    zakhire[2 * i + 1] = tmp;
                    jabejaee(2 * i + 1);
                }
                return;
            }
            else if (zakhire[2 * i + 1] != null && zakhire[2 * i + 2] != null)
            {
                if (zakhire[i].meghdar < zakhire[2 * i + 1].meghdar || zakhire[i].meghdar < zakhire[2 * i + 2].meghdar)
                {
                    if (zakhire[2 * i + 1].meghdar >= zakhire[2 * i + 2].meghdar)
                    {
                        node tmp = zakhire[i];
                        zakhire[i] = zakhire[2 * i + 1];
                        zakhire[2 * i + 1] = tmp;
                        jabejaee(2 * i + 1);
                        return;
                    }
                    if (zakhire[2 * i + 1].meghdar < zakhire[2 * i + 2].meghdar)
                    {
                        node tmp = zakhire[i];
                        zakhire[i] = zakhire[2 * i + 2];
                        zakhire[2 * i + 2] = tmp;
                        jabejaee(2 * i + 2);
                        return;
                    }
                }
                return;
            }
        }
        else if (2 * i + 1 == zakhire.Length - 1 && zakhire[2*i+1]!=null)
        {
            if (zakhire[2 * i + 1].meghdar >= zakhire[i].meghdar)
            {
                node tmp = zakhire[i];
                zakhire[i] = zakhire[2 * i + 1];
                zakhire[2 * i + 1] = tmp;
                return;
            }
        }
        else
        {
            return;
        }
    }
    public double Delete_root()
    {
        double x = zakhire[0].meghdar;
        //int avalin_khali = -1;
        //for (int i = 0; i < zakhire.Length; i++)
        //{
        //    if (zakhire[i] == null)
        //    {
        //        avalin_khali = i;
        //        break;
        //    }
        //}
        zakhire[0] = zakhire[zakhire.Length - 1];
        //zakhire[zakhire.Length - 1] = null;
        akharin--;
        jabejaee(0);
        return x;
    }

}
class program
{
    static void Main()
    {
        double[] s = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
        //string[] s = Console.ReadLine().Split(' ');
        long n = long.Parse(Console.ReadLine());
        double meghdar = 0;
        heap sorat_soal = new heap(s.Length);
        for (int i = 0; i < s.Length; i++)
        {
            sorat_soal.Insert(s[i]);
        }
        for (int i = 0; i < n; i++)
        {
            //Console.WriteLine(sorat_soal.zakhire[0].meghdar);
            double x = sorat_soal.Delete_root();
            //Console.WriteLine(x);
            meghdar += (x);
            x = (long)(Math.Floor((double)(x / 2)));
            sorat_soal.Insert(x);

        }
        Console.WriteLine(meghdar%1000000003);
    }
}
    