using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LTDT_lab2
{
    class Program
    {
        public static int n;
        public static int xp;
        public static int t;
        public static LinkedList<int>[] ds;
        public static bool[] visited;
        public static Queue<int> q;
        public static Stack<int> st;
        public static int[] front;
        public static List<int> list;

        public static void Input()
        {
            StreamReader sr = new StreamReader("Graph.inp");
            string[] so = sr.ReadLine().Split(' ');
            n = int.Parse(so[0]);
            xp = int.Parse(so[1]);
            t = int.Parse(so[2]);
            visited = new bool[n];
            ds = new LinkedList<int>[n];
            list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                string[] s = sr.ReadLine().Split(' ');
                ds[i] = new LinkedList<int>();
                for (int j = 0; j < s.Length; j++)
                {
                    ds[i].AddLast(int.Parse(s[j]));
                }
            }
            sr.Close();
        }
        public static void Output()
        {
            for (int i = 0; i < n; i++)
            {
                foreach (var x in ds[i])
                    Console.Write(x + " ");
                Console.WriteLine();
            }
        }
        public static void BFS()
        {
            visited[xp - 1] = true;
            list.Add(xp);
            //Console.Write(xp + " ");
            q.Enqueue(xp);
            front[xp - 1] = -1;
            while (q.Count != 0)
            {
                int d = q.Dequeue();
                foreach (int x in ds[d - 1])
                {
                    if (visited[x - 1]) continue;
                    q.Enqueue(x);
                    visited[x - 1] = true;
                    front[x - 1] = d - 1;
                    list.Add(x);
                    //Console.Write(x + " ");
                }
            }
        }
        public static void Solve()
        {
            Console.Write("Duong co the di toi : ");
            foreach(var items in list)
            {
                Console.Write(items + " ");
            }
            Console.WriteLine();
            FindStreet(xp, t - 1);
        }
        public static void FindStreet(int a, int b)
        {
            st.Push(b);
            while(front[b] != -1)
            {
                st.Push(front[b]);
                b = front[b];
            }

            Console.Write("Danh sach duong di tu {0} toi {1} la : ", xp, t);
            if (CheckInArray(t))
            {
                while (st.Count != 0)
                {
                    Console.Write(st.Pop() + 1 + " ");
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("khong co duong di");
        }
        public static bool CheckInArray(int x)
        {
            foreach (int items in list)
            {
                if (items == x)
                    return true;
            }
            return false;

        }
        static void Main(string[] args)
        {
            Input();
            Output();
            q = new Queue<int>();
            st = new Stack<int>();
            visited = new bool[n];
            front = new int[n];
            BFS();
            Solve();
        }
    }
}
