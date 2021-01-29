using System;

namespace SolutionLib._1631._最小体力消耗路径
{
    public class Solution_union
    {
        private int n;
        private int m;
        private int[][] graph;

        private class UnionFind
        {
            private int[] parent;

            public UnionFind(int n)
            {
                parent = new int[n];
                for (int i = 0; i < n; i++)
                    parent[i] = i;
            }

            public int FindParent(int x)
            {
                return parent[x] == x ? x : parent[x] = FindParent(parent[x]);
            }

            public bool IsConnected(int x, int y)
            {
                return FindParent(x) == FindParent(y);
            }

            public void Union(int x, int y)
            {
                if (IsConnected(x, y)) return;
                parent[FindParent(x)] = FindParent(y);
            }

        }

        public int MinimumEffortPath(int[][] heights)
        {
            n = heights.Length;
            m = heights[0].Length;
            if (n * m == 1) return 0;
            var edges = new int[2 * n * m - m - n][];
            int e = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    int index = GetIndex(i, j);
                    if (i != 0)
                        edges[e++] = new[] { index, GetIndex(i - 1, j), Math.Abs(heights[i][j] - heights[i - 1][j]) };
                    if (j != 0)
                        edges[e++] = new[] { index, GetIndex(i, j - 1), Math.Abs(heights[i][j] - heights[i][j - 1]) };
                }
            Array.Sort(edges, MyComparer);
            var uf = new UnionFind(n * m);
            int start = GetIndex(0, 0), final = GetIndex(n - 1, m - 1);
            foreach (var edge in edges)
            {
                uf.Union(edge[0], edge[1]);
                if (uf.IsConnected(start, final)) return edge[2];
            }
            return int.MaxValue;
        }

        private int MyComparer(int[] x, int[] y)
        {
            return x[2].CompareTo(y[2]);
        }

        private int GetIndex(int i, int j)
        {
            return i * m + j;
        }

    }
}