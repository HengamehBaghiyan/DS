using System;
using System.Collections.Generic;
class node
{
    public node right_child;
    public node left_child;
    public node parent;
    public char meghdar;
    public int shomarande;
    public node(int sho, char me)
    {
        this.shomarande = sho;
        this.meghdar = me;
    }
}
class yal
{
    public node parent;
    public node child;
    public yal(node p, node ch)
    {
        parent = p;
        child = ch;
    }
}

class program
{
    static string preorder(node node_in_marhale)
    {
        if (node_in_marhale == null)
        {
            return "";
        }
        return node_in_marhale.meghdar + preorder(node_in_marhale.left_child) + preorder(node_in_marhale.right_child);
    }
    static string postorder(node node_in_marhale)
    {
        if (node_in_marhale == null)
        {
            return "";
        }
        return postorder(node_in_marhale.left_child) + postorder(node_in_marhale.right_child) + node_in_marhale.meghdar;

    }
    static string inorder(node node_in_marhale)
    {
        if (node_in_marhale == null)
        {
            return "";
        }
        return inorder(node_in_marhale.left_child) + node_in_marhale.meghdar + inorder(node_in_marhale.right_child);
    }
    static void Main()
    {
        List<yal> listyal = new List<yal>();
        List<node> nodes = new List<node>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] sa = Console.ReadLine().Split(' ');
            nodes.Add(new node(int.Parse(sa[0]), char.Parse(sa[1])));
        }
        int x = int.Parse(Console.ReadLine());
        node root = null;
        for (int i = 0; i < n; i++)
        {
            if (nodes[i].shomarande == x)
            {
                root = nodes[i];
            }
        }
        for (int i = 0; i < n - 1; i++)
        {
            string[] sa = Console.ReadLine().Split(' ');
            int x1 = int.Parse(sa[0]);
            int x2 = int.Parse(sa[1]);
            node node1 = null;
            node node2 = null;
            for (int j = 0; j < n; j++)
            {
                if (nodes[j].shomarande == x1)
                {
                    node1 = nodes[j];
                }
            }
            for (int j = 0; j < n; j++)
            {
                if (nodes[j].shomarande == x2)
                {
                    node2 = nodes[j];
                }
            }
            listyal.Add(new yal(node1, node2));
            if (node1.left_child == null)
            {
                node1.left_child = node2;
            }
            else
            {
                node1.right_child = node2;
            }
            node2.parent = node1;
        }
        List<char> post = new List<char>();
        Console.WriteLine(postorder(root));
        Console.WriteLine(inorder(root));
        Console.WriteLine(preorder(root));
        //Console.WriteLine(inorder(root));
        string reshte = postorder(root);
        Stack<double> javab = new Stack<double>();
        for (int i = 0; i < reshte.Length; i++)
        {
            if (reshte[i] == '+')
            {
                double x1 = javab.Pop();
                double x2 = javab.Pop();
                javab.Push(x1 + x2);
            }
            else if (reshte[i] == '-')
            {
                double x1 = javab.Pop();
                double x2 = javab.Pop();
                javab.Push(x2 - x1);
            }
            else if (reshte[i] == '*')
            {
                double x1 = javab.Pop();
                double x2 = javab.Pop();
                javab.Push(x1 * x2);
            }
            else if (reshte[i] == '/')
            {
                double x1 = javab.Pop();
                double x2 = javab.Pop();
                javab.Push(x2 / x1);
            }
            else if (reshte[i] == '^')
            {
                double x1 = javab.Pop();
                double x2 = javab.Pop();
                javab.Push(Math.Pow(x2, x1));
            }
            else
            {
                javab.Push(double.Parse(reshte[i].ToString()));
            }
        }
        Console.WriteLine(string.Format("{0:F2}",javab.Pop()));

    }
}
