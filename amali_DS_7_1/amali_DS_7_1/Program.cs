using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
class program
{
    //static bool BFS(point p1, point p2, edge[] edges)
    //{
    //    List<point> graph = new List<point>();
    //    for (int i = 0; i < edges.Length; i++)
    //    {
    //        if (edges[i] == null)
    //        {
    //            break;
    //        }
    //        if (!graph.Contains(edges[i].point1))
    //        {
    //            graph.Add(edges[i].point1);
    //        }
    //        if (!graph.Contains(edges[i].point2))
    //        {
    //            graph.Add(edges[i].point2);
    //        }
    //    }
    //    for (int i = 0; i < graph.Count; i++)
    //    {
    //        graph[i].color = "white";
    //    }
    //    Queue<point> queue = new Queue<point>();
    //    queue.Enqueue(p1);
    //    p1.color = "gray";
    //    while (queue.Count > 0)
    //    {
    //        point p = queue.Dequeue();
    //        for (int i = 0; i < edges.Length; i++)
    //        {
    //            if (edges[i] == null)
    //            {
    //                break;
    //            }
    //            if (edges[i].point1 == p)
    //            {
    //                if (edges[i].point2.color == "white")
    //                {
    //                    edges[i].point2.color = "gray";
    //                    queue.Enqueue(edges[i].point2);
    //                }
    //                if (edges[i].point2 == p2)
    //                {
    //                    return true;
    //                }
    //            }
    //            else if (edges[i].point2 == p)
    //            {
    //                if (edges[i].point1.color == "white")
    //                {
    //                    edges[i].point1.color = "gray";
    //                    queue.Enqueue(edges[i].point1);
    //                }
    //                if (edges[i].point1 == p2)
    //                {
    //                    return true;
    //                }
    //            }
    //        }
    //        p.color = "black";
    //    }
    //    return false;
    //}
    static bool yaftan_dor(point p1,point p2)
    {
        point p3 = p1;
        while (p3.parent != null)
        {
            p3 = p3.parent;
        }
        point p4 = p2;
        while (p4.parent != null)
        {
            p4 = p4.parent;
        }
        if (p4 == p3)
        {
            return true;
        }
        else
        {
            p3.parent = p4;
            return false;
        }
    }
    class point
    {
        public string color = "white";
        public int x;
        public int y;
        public point parent=null;
        public point(int xx, int yy)
        {
            x = xx; y = yy;
        }
    }
    class edge
    {
        public long distance;
        public point point1;
        public point point2;
        public edge(point p1, point p2)
        {
            point1 = p1;
            point2 = p2;
            this.distance = Math.Abs(point1.x - point2.x) + Math.Abs(point1.y - point2.y);

        }
    }
    static void merg(edge[] arrye, int shoro, int middle, int payan)
    {
        edge[] help = new edge[payan - shoro + 1];
        int a1 = shoro;
        int a2 = middle + 1;
        for (int i = 0; i < payan - shoro + 1; i++)
        {
            if (a1 == middle + 1)
            {
                help[i] = arrye[a2];
                a2++;
            }
            else if (a2 == payan + 1)
            {
                help[i] = arrye[a1];
                a1++;
            }
            else if (arrye[a1].distance <= arrye[a2].distance)
            {
                help[i] = arrye[a1];
                a1++;
            }
            else if (arrye[a2].distance < arrye[a1].distance)
            {
                help[i] = arrye[a2];
                a2++;
            }
        }
        for (int i = shoro; i <= payan; i++)
        {
            arrye[i] = help[i - shoro];
        }
    }
    static int partition(edge[] arrye, int shoro, int payan)
    {
        long a = arrye[shoro].distance;
        long b = arrye[(shoro + payan) / 2].distance;
        long c = arrye[payan].distance;
        int ke = shoro;
        if (a >= b)
        {
            if (b >= c)
            {
                ke = (shoro + payan) / 2;
            }
            else
            {
                if (a >= c)
                {
                    ke = payan;
                }
                else
                {
                    ke = shoro;
                }
            }
        }
        else
        {
            if (a >= c)
            {
                ke = shoro;
            }
            else
            {
                if (b >= c)
                {
                    ke = payan;
                }
                else
                {
                    ke = (shoro + payan) / 2;
                }
            }
        }
        edge key = arrye[ke];
        arrye[ke] = arrye[payan];
        arrye[payan] = key;
        int i = shoro - 1;
        for (int j = shoro; j < payan; j++)
        {
            if (arrye[j].distance < key.distance)
            {
                //Console.WriteLine(j);
                i++;
                edge tmp = arrye[i];
                arrye[i] = arrye[j];
                arrye[j] = tmp;
            }
        }
        arrye[payan] = arrye[i + 1];
        arrye[i + 1] = key;
        return i + 1;
    }
    static void quick_sort(edge[] arrye, int shoro, int payan)
    {
        if (shoro >= payan)
        {
            return;
        }
        int q = partition(arrye, shoro, payan);
        //int middle = (shoro + payan) / 2;
        if (q > 0)
            quick_sort(arrye, shoro, q - 1);
        if (q < payan)
            quick_sort(arrye, q + 1, payan);
        //merg(arrye, shoro, middle, payan);
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        point[] points = new point[n];
        for (int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();
            int x = int.Parse(s.Split(' ')[0]);
            int y = int.Parse(s.Split(' ')[1]);
            point p = new point(x, y);
            points[i] = p;
        }
        edge[] edges = new edge[(n * (n - 1)) / 2];
        int marhale = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                edge e = new edge(points[i], points[j]);
                edges[marhale] = e;
                marhale++;
            }
        }
        quick_sort(edges, 0, edges.Length - 1);
        // for (int i = 0; i < edges.Length; i++)
        // {
        //    Console.WriteLine(edges[i].distance);
        //}
        edge[] ch_edge = new edge[n - 1];
        int entekhab = 0;

        for (int i = 0; i < n - 1; i++)
        {
            bool exit = false;
            while (!exit)
            {
                point p1 = edges[entekhab].point1;
                point p2 = edges[entekhab].point2;
                if (!yaftan_dor(p1, p2))
                {
                    ch_edge[i] = edges[entekhab];
                    exit = true;
                }
                //else
                //{
                //    Console.WriteLine("nashod");
                //    Console.WriteLine(edges[entekhab].distance);
                //    Console.WriteLine("--------");
                //}
                entekhab++;
            }

        }
        long sum = 0;
        for (int i = 0; i < n - 1; i++)
        {
            sum += ch_edge[i].distance;
        }
        Console.WriteLine(sum);
    }
}