using System;
using System.Collections.Generic;
class node
{
    //public node right_child;
    //public node left_child;
    // public node parent;
    public int meghdar;
    public node(int me)
    {
        this.meghdar = me;
    }
}
class BST
{
    public BST left_sub = null;
    public BST right_sub = null;
    public node root = null;
    public BST parent_Right = null;
    public BST parent_Left = null;
    public static List<node> preorder = new List<node>();
    public BST(List<node> pre, BST parent_left = null, BST parent_right = null)
    {
        if (pre.Count == 0)
        {
            return;
        }
        int x = -1;
        for (int i = 0; i < pre.Count; i++)
        {
            if (pre[i].meghdar > pre[0].meghdar)
            {
                x = i;
                break;
            }
        }

        root = pre[0];
        parent_Left = parent_left;
        parent_Right = parent_right;
        List<node> list1 = new List<node>();
        if (x != -1)
        {
            for (int i = 1; i < x; i++)
            {
                list1.Add(pre[i]);
            }
        }
        else
        {
            for (int i = 1; i < pre.Count; i++)
            {
                list1.Add(pre[i]);
            }
        }
        //if (pre[0].meghdar == 36)
        //{
        //    Console.WriteLine(list1.Count);
        //}
        List<node> list2 = new List<node>();
        if (x != -1)
        {
            for (int i = x; i <= pre.Count - 1; i++)
            {
                list2.Add(pre[i]);
            }
        }
        if (list1.Count == 0)
        {
            left_sub = null;
        }
        else
        {
            left_sub = new BST(list1, this);
        }
        if (list2.Count == 0)
        {
            right_sub = null;
        }
        else
        {
            right_sub = new BST(list2, null, this);
        }
        return;
    }
    public void Insert(int k)
    {
        if (k < root.meghdar)
        {
            if (left_sub == null)
            {
                List<node> x = new List<node>();
                x.Add(new node(k));
                left_sub = new BST(x, this);
            }
            else
            {
                left_sub.Insert(k);
            }
        }
        if (k > root.meghdar)
        {
            if (right_sub == null)
            {
                List<node> x = new List<node>();
                x.Add(new node(k));
                right_sub = new BST(x, null, this);
            }
            else
            {
                right_sub.Insert(k);
            }
        }
        //if (shoro == -1) 
        //{
        //    pre.Insert(payan+1, k);
        //    return;
        //}
        //if (payan - shoro == 0)
        //{
        //    pre.Insert(shoro+1, k);
        //    return;
        //}
        //int x = -1;
        //for (int i = 0; i < payan-shoro; i++)
        //{
        //    if (pre[i + shoro] > pre[shoro])
        //    {
        //        x = i + shoro;
        //        break;
        //    }
        //}
        //if (k < pre[shoro])
        //{
        //    if (x == -1)
        //    {
        //        x = payan + 1;
        //    }
        //    Insert(k, shoro + 1, x - 1, pre);
        //    return;
        //}
        //else
        //{
        //    Insert(k,  x, payan, pre);
        //    return;
        //}
    }
    public void Delete(int k)
    {
        if (k == root.meghdar)
        {
            if (left_sub == null && right_sub == null)
            {
                if (parent_Right != null)
                {
                    parent_Right.right_sub = null;
                }
                else if (parent_Left != null)
                {
                    parent_Left.left_sub = null;
                }
                else 
                {                
                    root = null;
                }

            }
            else if (right_sub == null && left_sub != null)
            {
                if (parent_Right != null)
                {
                    parent_Right.right_sub = left_sub;
                    left_sub.parent_Right = parent_Right;
                    left_sub.parent_Left = parent_Left;
                }
                else
                {
                    parent_Left.left_sub = left_sub;
                    left_sub.parent_Right = parent_Right;
                    left_sub.parent_Left = parent_Left;
                }
                //root = left_sub.root;
                //left_sub = left_sub.left_sub;
                //right_sub = right_sub.right_sub;
            }
            else if (right_sub != null && left_sub == null)
            {
                if (parent_Right != null)
                {
                    parent_Right.right_sub = right_sub;
                    right_sub.parent_Right = parent_Right;
                    right_sub.parent_Left = parent_Left;
                }
                else
                {
                    parent_Left.left_sub = right_sub;
                    right_sub.parent_Right = parent_Right;
                    right_sub.parent_Left = parent_Left;
                }
                //root=right_sub.root;
                //right_sub = right_sub.right_sub;
                //left_sub = left_sub.left_sub;
            }
            else
            {
                BST x = left_sub;
                while (x.right_sub != null)
                {
                    x = x.right_sub;
                }
                node pressesor = x.root;
                int ka = x.root.meghdar;
                root = pressesor;
                x.Delete(ka);

            }
        }
        else if (k < root.meghdar)
        {
            left_sub.Delete(k);
        }
        else if (k > root.meghdar)
        {
            right_sub.Delete(k);
        }
    }
    public bool Search(int k)
    {
        bool peyda = false;
        for(int i = 0; i < preorder.Count; i++)
        {
            if(preorder[i].meghdar == k)
            {
                peyda = true;
                break;
            }
        }
        return peyda;
    }
    public void sakht_pre(bool pak = false)
    {
        if (pak == true)
        {
            preorder.Clear();
        }
        preorder.Add(root);
        if (left_sub != null)
        {
            //Console.WriteLine(root.meghdar);
            left_sub.sakht_pre();

        }
        if (right_sub != null)
        {
            right_sub.sakht_pre();
        }
    }
}
class program
{
    static void tabdil_in(List<int> post, List<int> preorder)
    {
        if (post.Count == 0)
        {
            return;
        }
        int x = -1;
        for (int i = post.Count - 1; i >= 0; i--)
        {
            if (post[i] < post[post.Count - 1])
            {
                x = i;
                break;
            }
        }

        List<int> list1 = new List<int>();
        for (int i = 0; i <= x; i++)
        {
            list1.Add(post[i]);
        }
        List<int> list2 = new List<int>();
        for (int i = x + 1; i < post.Count - 1; i++)
        {
            list2.Add(post[i]);
        }

        tabdil_in(list1, preorder);
        preorder.Add(post[post.Count - 1]);
        tabdil_in(list2, preorder);
        return;
    }
    static void tabdil(List<node> post, List<node> preorder)
    {
        if (post.Count == 0)
        {
            return;
        }
        int x = -1;
        for (int i = post.Count - 1; i >= 0; i--)
        {
            if (post[i].meghdar < post[post.Count - 1].meghdar)
            {
                x = i;
                break;
            }
        }
        preorder.Add(post[post.Count - 1]);
        List<node> list1 = new List<node>();
        for (int i = 0; i <= x; i++)
        {
            list1.Add(post[i]);
        }
        List<node> list2 = new List<node>();
        for (int i = x + 1; i < post.Count - 1; i++)
        {
            list2.Add(post[i]);
        }

        tabdil(list1, preorder);
        tabdil(list2, preorder);
        return;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());//
        string[] s = Console.ReadLine().Split(' ');//
        int[] post = new int[n];//
        for (int i = 0; i < n; i++)
        {
            post[i] = int.Parse(s[i]);
        }//
        List<node> postorder = new List<node>();
        for (int i = 0; i < n; i++)
        {
            postorder.Add(new node(post[i]));
        }
        List<node> preorder = new List<node>();
        tabdil(postorder, preorder);
        //for (int i = 0; i < preorder.Count; i++)
        //{
        //    Console.Write(preorder[i].meghdar);
        //    Console.Write(' ');
        //}
        BST sorat_soal = new BST(preorder);
        int hazf = int.Parse(Console.ReadLine());
        sorat_soal.Delete(hazf);
        int inse = int.Parse(Console.ReadLine());
        sorat_soal.Insert(inse);
       sorat_soal.sakht_pre(true);
        int sear= int.Parse(Console.ReadLine());
       Console.WriteLine( sorat_soal.Search(sear));
        //List<node> preorder = new List<node>();
        // tabdil(postorder, preorder);
 
        for (int i = 0; i < BST.preorder.Count; i++)
        {
            Console.Write(BST.preorder[i].meghdar);
            Console.Write(' ');
        }
    }
}
