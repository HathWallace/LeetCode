using System;

namespace SolutionLib._1631._最小体力消耗路径
{
    public class Solution
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
            graph = heights;
            int maxE = int.MinValue, minE = int.MaxValue;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (i != 0)
                    {
                        int edge = Math.Abs(graph[i][j] - graph[i - 1][j]);
                        maxE = Math.Max(maxE, edge);
                        minE = Math.Min(minE, edge);
                    }
                    if (j != 0)
                    {
                        int edge = Math.Abs(graph[i][j] - graph[i][j - 1]);
                        maxE = Math.Max(maxE, edge);
                        minE = Math.Min(minE, edge);
                    }
                }
            while (minE < maxE)
            {
                int mid = (minE + maxE) / 2;
                if (Check(mid))
                    maxE = mid;
                else
                    minE = mid + 1;
            }
            return minE;
        }

        private bool Check(int k)
        {
            var uf = new UnionFind(n * m);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    int index = GetIndex(i, j);
                    if (i != 0 && Math.Abs(graph[i][j] - graph[i - 1][j]) <= k)
                        uf.Union(index, GetIndex(i - 1, j));
                    if (j != 0 && Math.Abs(graph[i][j] - graph[i][j - 1]) <= k)
                        uf.Union(index, GetIndex(i, j - 1));
                }
            return uf.IsConnected(GetIndex(n - 1, m - 1), GetIndex(0, 0));
        }

        private int GetIndex(int i, int j)
        {
            return i * m + j;
        }

    }
}