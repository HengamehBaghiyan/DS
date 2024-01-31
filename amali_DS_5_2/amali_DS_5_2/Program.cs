using System;
class node
{
    public long meghdar;
    public node(long me)
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
    }
    public void Insert(long k)
    {
        zakhire[akharin] = new node(k);
        jabejaee_insert(akharin);
        akharin++;
        //Console.WriteLine("+++++++++++++++++");
        //for(int i=0; i<akharin; i++)
        //{
        //    Console.WriteLine(zakhire[i].meghdar);
        //}
        //Console.WriteLine("+++++++++++++++++");
    }
    public void jabejaee_insert(long i)
    {
        if (i == 0)
        {
            return;
        }
        else if (i % 2 == 0)
        {
            if (long.Parse(zakhire[i].meghdar.ToString()+ zakhire[(i - 2) / 2].meghdar.ToString()) > long.Parse(zakhire[(i - 2) / 2].meghdar.ToString()+ zakhire[i].meghdar.ToString()))
            {
                node tmp = zakhire[i];
                zakhire[i] = zakhire[(i - 2) / 2];
                zakhire[(i - 2) / 2] = tmp;
                jabejaee_insert((i - 2) / 2);
            }
            //Console.WriteLine("=============");
            //for (int j = 0; j < akharin; j++)
            //{
            //    Console.WriteLine(zakhire[j].meghdar);
            //}
            //Console.WriteLine("=============");
            return;
        }
        else if (i % 2 == 1)
        {
            if (long.Parse(zakhire[i].meghdar.ToString() + zakhire[(i - 1) / 2].meghdar.ToString()) > long.Parse(zakhire[(i - 1) / 2].meghdar.ToString() + zakhire[i].meghdar.ToString()))
            {
                node tmp = zakhire[i];
                zakhire[i] = zakhire[(i - 1) / 2];
                zakhire[(i - 1) / 2] = tmp;
                jabejaee_insert((i - 1) / 2);
            }
            //Console.WriteLine("=============");
            //for(int j = 0; j < akharin; j++)
            //{
            //    Console.WriteLine(zakhire[j].meghdar);
            //}
            //Console.WriteLine("=============");
            return;
            
        }
    }
    public void jabejaee_delete(long i)
    {
        if (2 * i + 2 < zakhire.Length)
        {
            if (zakhire[2 * i + 1] == null && zakhire[2 * i + 2] == null)
            {
                return;
            }
            else if (zakhire[2 * i + 1] != null && zakhire[2 * i + 2] == null)
            {
                if (long.Parse(zakhire[i].meghdar.ToString()+ zakhire[2 * i + 1].meghdar.ToString()) < long.Parse(zakhire[2 * i + 1].meghdar.ToString()+ zakhire[i].meghdar.ToString()))
                {
                    node tmp = zakhire[i];
                    zakhire[i] = zakhire[2 * i + 1];
                    zakhire[2 * i + 1] = tmp;
                    jabejaee_delete(2 * i + 1);
                }
                return;
            }
            else if (zakhire[2 * i + 1] != null && zakhire[2 * i + 2] != null)
            {
                if (long.Parse(zakhire[i].meghdar.ToString() + zakhire[2 * i + 1].meghdar.ToString()) < long.Parse(zakhire[2 * i + 1].meghdar.ToString() + zakhire[i].meghdar.ToString()) || long.Parse(zakhire[i].meghdar.ToString() + zakhire[2 * i + 2].meghdar.ToString()) < long.Parse(zakhire[2 * i + 2].meghdar.ToString() + zakhire[i].meghdar.ToString()))
                {
                    if (long.Parse(zakhire[2*i+1].meghdar.ToString() + zakhire[2*i+2].meghdar.ToString()) >= long.Parse(zakhire[2 * i + 2].meghdar.ToString() + zakhire[2*i+1].meghdar.ToString()))
                    {
                        node tmp = zakhire[i];
                        zakhire[i] = zakhire[2 * i + 1];
                        zakhire[2 * i + 1] = tmp;
                        jabejaee_delete(2 * i + 1);
                        return;
                    }
                    if (long.Parse(zakhire[2 * i + 1].meghdar.ToString() + zakhire[2*i+2].meghdar.ToString()) < long.Parse(zakhire[2 * i + 2].meghdar.ToString() + zakhire[2*i+1].meghdar.ToString()))
                    {
                        node tmp = zakhire[i];
                        zakhire[i] = zakhire[2 * i + 2];
                        zakhire[2 * i + 2] = tmp;
                        jabejaee_delete(2 * i + 2);
                        return;
                    }
                }
                return;
            }
        }
        else if (2 * i + 1 == zakhire.Length - 1 && zakhire[2 * i + 1] != null)
        {
            if (long.Parse(zakhire[i].meghdar.ToString() + zakhire[2 * i + 1].meghdar.ToString()) <long.Parse(zakhire[2 * i + 1].meghdar.ToString() + zakhire[i].meghdar.ToString()))
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
    public long Delete_root()
    {
        //if (akharin == 1)
        //{
        //    return zakhire[0].meghdar;
        //}
        long x = zakhire[0].meghdar;
        zakhire[0] = zakhire[akharin-1];
        zakhire[akharin - 1] = null;
        akharin--;
        jabejaee_delete(0);
        //Console.WriteLine("----------");
        //for(int i = 0; i < akharin; i++)
        //{
        //    Console.WriteLine(zakhire[i].meghdar);
        //}
        //Console.WriteLine("----------");
        return x;
    }

}
class program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        heap heap_sort = new heap(n);
        //long[] araye = new long[n];
        string s = "";
        for (int i = 0; i < n; i++)
        {
           heap_sort.Insert(long.Parse(Console.ReadLine()));
        }
        //for(int i = 0; i < n; i++)
        //{
        //    Console.WriteLine(heap_sort.zakhire[i].meghdar);
        //}
        for(int i = 0; i < n; i++)
        {
            long x = heap_sort.Delete_root();
            if(i==0& x == 0)
            {
                Console.WriteLine("0");
                break;
            }
            //Console.WriteLine(x);
            s += x.ToString();
        }
        Console.WriteLine(s);
    }
}
