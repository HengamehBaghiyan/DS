using System.Text;
using System;

class program
{
    class node
    {
        public string meghar;
        public node next = null;
        public node(string x)
        {
            meghar = x;
        }
    }
    class linked_list
    {
        public node root = null;
        // public int count = 0;
        public void insert(string x)
        {
            if (root == null)
            {
                root = new node(x);
                return;
            }
            node node_in_marhale = root;
            while (node_in_marhale.next != null)
            {
                node_in_marhale = node_in_marhale.next;
            }
            node jadid = new node(x);
            node_in_marhale.next = jadid;
            // count++;
        }
        public void remove(string x)
        {
            if (root != null)
            {
                node node_in_marhale = root;
                if (root.meghar == x)
                {
                    root = root.next;
                    return;
                }
                while (node_in_marhale.next != null)
                {
                    if (node_in_marhale.next.meghar == x)
                    {
                        node_in_marhale.next = node_in_marhale.next.next;
                        return;
                        //count--;
                    }
                    node_in_marhale = node_in_marhale.next;
                }
            }

        }
    }
    class khane
    {
        public linked_list list = new linked_list();
        public void add(string s)
        {
            if (list.root != null)
            {
                node node_in_marhale = list.root;
                while (node_in_marhale != null)
                {
                    if (node_in_marhale.meghar == s)
                    {
                        return;
                    }
                    node_in_marhale = node_in_marhale.next;
                }
            }
            list.insert(s);
        }
        public void del(string s)
        {
            list.remove(s);
        }
        public bool find(string s)
        {
            if (list.root != null)
            {
                node node_in_marhale = list.root;
                while (node_in_marhale != null)
                {
                    if (node_in_marhale.meghar == s)
                    {
                        return true;
                    }
                    node_in_marhale = node_in_marhale.next;
                }
            }
            return false;

        }
        public string check()
        {
            string s = "";
            if (list.root != null)
            {
                node node_in_marhale = list.root;
                while (node_in_marhale != null)
                {
                    s += node_in_marhale.meghar + " ";
                    node_in_marhale = node_in_marhale.next;
                }
            }
            string[] komaki = s.Split(' ');
            string javab = "";
            for (int i = komaki.Length - 2; i >= 0; i--)
            {
                javab += komaki[i] + " ";
            }
            return javab;
        }
    }
    static long tabdil(string s, int n)
    {
        long jame = 0;
        long marhale = 1;
        long x = 263;
        long p = 1000000007;
        byte[] meghdar = Encoding.ASCII.GetBytes(s);
        for (int i = 0; i < s.Length; i++)
        {
            marhale = meghdar[i];
            for (int j = 0; j < i; j++)
            {
                marhale = (marhale * x) % p;
            }
            jame = (jame % p + marhale % p) % p;
        }
        return jame % n;
    }
    static void Main()
    {
        int n, x;
        x = int.Parse(Console.ReadLine());
        n = int.Parse(Console.ReadLine());
        khane[] jadval = new khane[x];
        for (int i = 0; i < x; i++)
        {
            jadval[i] = new khane();
        }
        string s = "";

        for (int i = 0; i < n; i++)
        {
            s = Console.ReadLine();
            string[] dastor = s.Split(' ');
            if (dastor[0] == "add")
            {
                long m = tabdil(dastor[1], x);
                //  Console.WriteLine(m);
                jadval[m].add(dastor[1]);

            }
            else if (dastor[0] == "del")
            {
                long m = tabdil(dastor[1], x);
                jadval[m].del(dastor[1]);
            }
            else if (dastor[0] == "find")
            {
                long m = tabdil(dastor[1], x);
                bool peyda = jadval[m].find(dastor[1]);
                if (peyda == true)
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
            else if (dastor[0] == "check")
            {
                int j = int.Parse(dastor[1]);
                Console.WriteLine(jadval[j].check());
            }

        }
    }
}
