using System;
using System.Collections.Generic;

namespace SolutionLib._803._打砖块
{
    public class Solution_union
    {
        public class UnionFind
        {
            private int[] parent;
            private int[] size;

            public UnionFind(int n)
            {
                parent = new int[n];
                size = new int[n];
                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                    size[i] = 1;
                }
            }

            public int FindParent(int x)
            {
                return parent[x] = parent[x] == x ? x : FindParent(parent[x]);
            }

            public void Union(int x, int y)
            {
                int rootX = FindParent(x), rootY = FindParent(y);
                if (rootX == rootY) return;
                parent[rootX] = rootY;
                size[rootY] += size[rootX];
            }

            public int GetSize(int x)
            {
                return size[FindParent(x)];
            }

        }

        private int rows;
        private int cols;
        private readonly int[,] DIRECTIONS = { { 0, 1 }, { 1, 0 }, { -1, 0 }, { 0, -1 } };

        public int[] HitBricks(int[][] grid, int[][] hits)
        {
            rows = grid.Length;
            cols = grid[0].Length;

            var copy = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    copy[i, j] = grid[i][j];

            foreach (var hit in hits)
                copy[hit[0], hit[1]] = 0;

            int size = rows * cols;
            var unionFind = new UnionFind(size + 1);
            for (int i = 0; i < cols; i++)
            {
                if (copy[0, i] == 1)
                    unionFind.Union(i, size);
            }

            for (int i = 1; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (copy[i, j] == 0) continue;
                    if (copy[i - 1, j] == 1)
                        unionFind.Union(GetIndex(i - 1, j), GetIndex(i, j));
                    if (j > 0 && copy[i, j - 1] == 1)
                        unionFind.Union(GetIndex(i, j - 1), GetIndex(i, j));
                }

            var res = new int[hits.Length];
            for (int i = hits.Length - 1; i >= 0; i--)
            {
                int x = hits[i][0], y = hits[i][1];
                if (grid[x][y] == 0)
                    continue;
                int origin = unionFind.GetSize(size);
                if (x == 0)
                    unionFind.Union(GetIndex(x, y), size);
                for (int j = 0; j < 4; j++)
                {
                    int newX = x + DIRECTIONS[j, 0], newY = y + DIRECTIONS[j, 1];
                    if (InArea(newX, newY) && copy[newX, newY] == 1)
                        unionFind.Union(GetIndex(x, y), GetIndex(newX, newY));
                }
                int current = unionFind.GetSize(size);
                res[i] = Math.Max(0, current - origin - 1);
                copy[x, y] = 1;
            }

            return res;
        }

        private int GetIndex(int x, int y)
        {
            return x * cols + y;
        }

        private bool InArea(int x, int y)
        {
            return x >= 0 && x < rows && y >= 0 && y < cols;
        }
    }
}