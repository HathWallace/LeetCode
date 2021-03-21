using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                var split = line.Split(' ');
                int n = int.Parse(split[0]), m = int.Parse(split[1]);
                line = Console.ReadLine();
                split = line.Split(' ');
                var capacity = new int[n];
                for (int i = 0; i < n; i++)
                {
                    capacity[i] = int.Parse(split[i]);
                }
                var edges = new int[m][];
                for (int i = 0; i < m; i++)
                {
                    line = Console.ReadLine();
                    split = line.Split(' ');
                    edges[i] = new[] { int.Parse(split[0]) - 1, int.Parse(split[1]) - 1 };
                }

                Console.WriteLine(string.Join(", ", capacity));
                foreach (var edge in edges)
                {
                    Console.WriteLine("[" + string.Join(", ", edge) + "]");
                }

                var res = new Solution().Rob(capacity, edges);
                Console.WriteLine(res[0] + " " + res[1]);
            }
        }
    }

    public class Solution
    {
        private int[] money;
        private bool[] visited;
        private bool[,] graph;

        public int[] Rob(int[] money, int[][] edges)
        {
            int n = money.Length;
            this.money = money;
            visited = new bool[n];
            graph = new bool[n, n];

            foreach (var edge in edges)
            {
                graph[edge[0], edge[1]] = true;
                graph[edge[1], edge[0]] = true;
            }

            var res = DFS(0);
            return Max(res[0], res[1]);
        }

        private int[][] DFS(int index)
        {
            visited[index] = true;
            var res = new int[2][];
            res[0] = new[] { 0, int.MaxValue };
            res[1] = new[] { money[index], money[index] };
            for (int i = 0; i < money.Length; i++)
            {
                if (!graph[index, i] || visited[i]) continue;
                var tmp = DFS(i);
                var max = Max(tmp[0], tmp[1]);
                res[0][0] += max[0];
                res[0][1] = Math.Min(res[0][1], max[1]);
                res[1][0] += tmp[0][0];
                res[1][1] = Math.Min(res[1][1], tmp[0][1]);
            }
            return res;
        }

        private int[] Max(int[] a, int[] b)
        {
            return Compare(a, b) >= 0 ? a : b;
        }

        private int Compare(int[] a, int[] b)
        {
            if (a[0] != b[0]) return a[0] - b[0];
            return a[1] - b[1];
        }

    }

}
