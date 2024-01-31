using System;
using System.Collections.Generic;
class program
{
    class point
    {
        public bool visit = false;
        public int shomare;
        public double meghdar = double.MinValue;
        public point(int x)
        {
            shomare = x;
            meghdar = 0;
        }
    }
    class edge
    {
        public int weight;
        public point point1;
        public point point2;
        public edge(int we, point p1, point p2)
        {
            weight = we;
            point1 = p1;
            point2 = p2;
        }
    }
    static void Main()
    {
        string[] reshte = Console.ReadLine().Split(' ');
        int n = int.Parse(reshte[0]);
        int m = int.Parse(reshte[1]);
        point[] points = new point[n];
        for (int i = 0; i < n; i++)
        {
            points[i] = new point(i);
        }
        edge[] edges = new edge[m];
        for (int i = 0; i < m; i++)
        {
            string[] reshte1 = Console.ReadLine().Split(' ');
            edges[i] = new edge(int.Parse(reshte1[2]), points[int.Parse(reshte1[0])], points[int.Parse(reshte1[1])]);
        }
        List<point> point_sort = new List<point>();
        points[0].meghdar = 1;
        for (int i = 0; i < n; i++)
        {
            point_sort.Add(points[i]);
        }
        point root_in_marhale = null;
        while (point_sort.Count != 0 && root_in_marhale != points[n-1])
        {
            root_in_marhale = point_sort[0];
            int peyda = 0;
            for(int i = 0; i < point_sort.Count; i++)
            {
                if (root_in_marhale.meghdar < point_sort[i].meghdar)
                {
                    root_in_marhale = point_sort[i];
                    peyda = i;
                }
            }
            point_sort.RemoveAt(peyda);
            root_in_marhale.visit = true;
            for (int i = 0; i < m; i++)
            {
                if (edges[i].point1 == root_in_marhale)
                {
                    if (!edges[i].point2.visit)
                    {
                        if (edges[i].point2.meghdar < (edges[i].point1.meghdar * edges[i].weight / 100))
                        {
                            edges[i].point2.meghdar = (edges[i].point1.meghdar * edges[i].weight / 100);
                        }
                    }
                }
                else if (edges[i].point2 == root_in_marhale)
                {
                    if (!edges[i].point1.visit)
                    {
                        if (edges[i].point1.meghdar < (edges[i].point2.meghdar * edges[i].weight / 100))
                        {
                            edges[i].point1.meghdar = (edges[i].point2.meghdar * edges[i].weight / 100);
                        }
                    }
                }
            }
        }
        
            Console.WriteLine(Math.Round(points[n-1].meghdar,3).ToString("N3"));
        
    }
}
