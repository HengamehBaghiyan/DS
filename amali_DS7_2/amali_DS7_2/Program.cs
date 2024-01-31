using System;
using System.Collections.Generic;
using System.Linq.Expressions;
class program
{
    class heap
    {
        public point[] zakhire;
        public long akharin = 0;
        public heap(long n)
        {
            zakhire = new point[n];
        }
        public void update()
        {
            point[] zakhire_help = new point[akharin];
            for (int i = 0; i < akharin; i++)
            {
                zakhire_help[i] = zakhire[i];
                //zakhire[i] = null;
            }
            long x = akharin;
            akharin = 0;
            for (int i = 0; i < x; i++)
            {
                Insert(zakhire_help[i]);
            }
            //for(int i = 0; i < akharin; i++)
            //{
            //    Console.WriteLine(zakhire[i]);
            //}
        }
        public void Insert(point p)
        {
            zakhire[akharin] = p;
            jabejaee_insert(akharin);
            akharin++;
        }
        public void jabejaee_insert(long i)
        {
            if (i == 0)
            {
                return;
            }
            else if (i % 2 == 0)
            {
                if (zakhire[i].meghdar < zakhire[(i - 2) / 2].meghdar)
                {
                    point tmp = zakhire[i];
                    zakhire[i] = zakhire[(i - 2) / 2];
                    zakhire[(i - 2) / 2] = tmp;
                    jabejaee_insert((i - 2) / 2);
                }
                return;
            }
            else if (i % 2 == 1)
            {
                if (zakhire[i].meghdar < zakhire[(i - 1) / 2].meghdar)
                {
                    point tmp = zakhire[i];
                    zakhire[i] = zakhire[(i - 1) / 2];
                    zakhire[(i - 1) / 2] = tmp;
                    jabejaee_insert((i - 1) / 2);
                }
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
                    if (zakhire[i].meghdar > zakhire[2 * i + 1].meghdar)
                    {
                        point tmp = zakhire[i];
                        zakhire[i] = zakhire[2 * i + 1];
                        zakhire[2 * i + 1] = tmp;
                        jabejaee_delete(2 * i + 1);
                    }
                    return;
                }
                else if (zakhire[2 * i + 1] != null && zakhire[2 * i + 2] != null)
                {
                    if (zakhire[i].meghdar > zakhire[2 * i + 1].meghdar || zakhire[i].meghdar > zakhire[2 * i + 2].meghdar)
                    {
                        if (zakhire[2 * i + 1].meghdar < zakhire[2 * i + 2].meghdar)
                        {
                            point tmp = zakhire[i];
                            zakhire[i] = zakhire[2 * i + 1];
                            zakhire[2 * i + 1] = tmp;
                            jabejaee_delete(2 * i + 1);
                            return;
                        }
                        if (zakhire[2 * i + 1].meghdar >= zakhire[2 * i + 2].meghdar)
                        {
                            point tmp = zakhire[i];
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
                if (zakhire[i].meghdar > zakhire[2 * i + 1].meghdar)
                {
                    point tmp = zakhire[i];
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
        public point Delete_root()
        {
            point x = zakhire[0];
            zakhire[0] = zakhire[akharin - 1];
            zakhire[akharin - 1] = null;
            akharin--;
            jabejaee_delete(0);
            return x;
        }
    }
    class point
    {
        public bool visit = false;
        public int shomare;
        public List<model> edge_reside = new List<model>();
        public int meghdar = int.MaxValue;
        public point(int x)
        {
            shomare = x;
            meghdar = int.MaxValue;
            edge_reside.Clear();
        }
    }
    class model
    {
        public int akharin_yal;
        public int bozorgtar;
        public model(int a, int b)
        {
            akharin_yal = a;
            bozorgtar = b;
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
        int s = int.Parse(reshte[2]);
        int t = int.Parse(reshte[3]);
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
        heap heap_points = new heap(n);
        points[s].meghdar = 0;
        for (int i = 0; i < n; i++)
        {
            heap_points.Insert(points[i]);
        }
        point root_in_marhale = null;
        while (heap_points.akharin != 0 && root_in_marhale != points[t])
        {
            //Console.WriteLine("   jj");
            root_in_marhale = heap_points.Delete_root();
            root_in_marhale.visit = true;
            for (int i = 0; i < m; i++)
            {
                if (edges[i].point1 == root_in_marhale)
                {
                    if (!edges[i].point2.visit)
                    {
                        if (edges[i].point2.meghdar > (edges[i].point1.meghdar + edges[i].weight))
                        {
                            //bool pak = false;
                            if (root_in_marhale == points[s])
                            {
                                edges[i].point2.meghdar = edges[i].point1.meghdar + edges[i].weight;
                                edges[i].point2.edge_reside.Add(new model(edges[i].weight, 2));
                            }
                            else
                            {
                                List<model> help = new List<model>();
                                for (int j = 0; j < edges[i].point1.edge_reside.Count; j++)
                                {
                                    if ((edges[i].point1.edge_reside[j].bozorgtar == 2 || edges[i].point1.edge_reside[j].bozorgtar == 1) && edges[i].point1.edge_reside[j].akharin_yal < edges[i].weight)
                                    {
                                        help.Add(new model(edges[i].weight, 0));
                                    }
                                    if ((edges[i].point1.edge_reside[j].bozorgtar == 0|| edges[i].point1.edge_reside[j].bozorgtar == 2) && edges[i].point1.edge_reside[j].akharin_yal > edges[i].weight)
                                    {
                                        help.Add(new model(edges[i].weight, 1));
                                    }

                                }
                                if (help.Count != 0)
                                {
                                    edges[i].point2.meghdar = edges[i].point1.meghdar + edges[i].weight;
                                    edges[i].point2.edge_reside = help;
                                }
                            }

                        }
                        else if (edges[i].point2.meghdar == (edges[i].point1.meghdar + edges[i].weight))
                        {
                            List<model> help = new List<model>();
                            for (int j = 0; j < edges[i].point1.edge_reside.Count; j++)
                            {
                                if ((edges[i].point1.edge_reside[j].bozorgtar==2|| edges[i].point1.edge_reside[j].bozorgtar==1) && edges[i].point1.edge_reside[j].akharin_yal < edges[i].weight)
                                {
                                    help.Add(new model(edges[i].weight, 0));
                                }
                                if ((edges[i].point1.edge_reside[j].bozorgtar == 2|| edges[i].point1.edge_reside[j].bozorgtar==0) && edges[i].point1.edge_reside[j].akharin_yal > edges[i].weight)
                                {
                                    help.Add(new model(edges[i].weight, 1));
                                }

                            }
                            for (int j = 0; j < help.Count; j++)
                            {
                                edges[i].point2.edge_reside.Add(help[j]);
                            }
                        }
                    }
                }
                else if (edges[i].point2 == root_in_marhale)
                {
                    if (!edges[i].point1.visit)
                    {
                        if (edges[i].point1.meghdar > (edges[i].point2.meghdar + edges[i].weight))
                        {
                            if (root_in_marhale == points[s])
                            {
                                edges[i].point1.meghdar = edges[i].point2.meghdar + edges[i].weight;
                                edges[i].point1.edge_reside.Add(new model(edges[i].weight, 2));
                            }
                            else
                            {
                                //bool pak = false;
                                List<model> help = new List<model>();
                                for (int j = 0; j < edges[i].point2.edge_reside.Count; j++)
                                {
                                    if ((edges[i].point2.edge_reside[j].bozorgtar == 2|| edges[i].point2.edge_reside[j].bozorgtar==1) && edges[i].point2.edge_reside[j].akharin_yal < edges[i].weight)
                                    {
                                        help.Add(new model(edges[i].weight, 0));
                                    }
                                    if ((edges[i].point2.edge_reside[j].bozorgtar == 2 || edges[i].point2.edge_reside[j].bozorgtar == 0) && edges[i].point2.edge_reside[j].akharin_yal > edges[i].weight)
                                    {
                                        help.Add(new model(edges[i].weight, 1));
                                    }

                                }
                                if (help.Count != 0)
                                {
                                    edges[i].point1.meghdar = edges[i].point2.meghdar + edges[i].weight;
                                    edges[i].point1.edge_reside = help;
                                }
                            }

                        }
                        else if (edges[i].point1.meghdar == (edges[i].point2.meghdar + edges[i].weight))
                        {
                            List<model> help = new List<model>();
                            for (int j = 0; j < edges[i].point2.edge_reside.Count; j++)
                            {
                                if ((edges[i].point2.edge_reside[j].bozorgtar == 2 || edges[i].point2.edge_reside[j].bozorgtar == 1) && edges[i].point2.edge_reside[j].akharin_yal < edges[i].weight)
                                {
                                    help.Add(new model(edges[i].weight, 0));
                                }
                                if ((edges[i].point2.edge_reside[j].bozorgtar == 2 || edges[i].point2.edge_reside[j].bozorgtar == 0) && edges[i].point2.edge_reside[j].akharin_yal > edges[i].weight)
                                {
                                    help.Add(new model(edges[i].weight, 1));
                                }

                            }
                            for (int j = 0; j < help.Count; j++)
                            {
                                edges[i].point1.edge_reside.Add(help[j]);
                            }
                        }
                    }
                }
            }
            heap_points.update();
        }
        if (points[t].meghdar != int.MaxValue)
        {
            Console.WriteLine(points[t].meghdar);
        }
        else
        {
            Console.WriteLine("inf");
        }
    }
}

