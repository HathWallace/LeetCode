using System;

namespace SolutionLib._778._水位上升的泳池中游泳
{
    public class Solution
    {
        private int n;

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

        public int SwimInWater(int[][] grid)
        {
            n = grid.Length;
            var grids = new int[n * n][];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    grids[GetIndex(i, j)] = new[] { i, j, grid[i][j] };
            Array.Sort(grids, MyComparer);
            var uf = new UnionFind(n * n);
            int start = GetIndex(0, 0), final = GetIndex(n - 1, n - 1);
            int[,] directions = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
            foreach (var g in grids)
            {
                int index = GetIndex(g[0], g[1]);
                for (int i = 0; i < 4; i++)
                {
                    int ia = g[0] + directions[i, 0], ja = g[1] + directions[i, 1];
                    if (ia < 0 || ia >= n || ja < 0 || ja >= n || g[2] < grid[ia][ja]) continue;
                    uf.Union(index, GetIndex(ia, ja));
                }
                if (uf.IsConnected(start, final)) return g[2];
            }
            return -1;
        }

        private int GetIndex(int i, int j)
        {
            return i * n + j;
        }

        private int MyComparer(int[] x, int[] y)
        {
            return x[2].CompareTo(y[2]);
        }

    }
}