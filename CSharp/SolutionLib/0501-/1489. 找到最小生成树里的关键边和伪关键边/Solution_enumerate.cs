using System;
using System.Collections;
using System.Collections.Generic;

namespace SolutionLib._1489._找到最小生成树里的关键边和伪关键边
{
    public class Solution_enumerate
    {
        private class UnionFind
        {
            private int[] parent;
            private int unionCount;
            public int UnionCount => unionCount;

            public UnionFind(int n)
            {
                parent = new int[n];
                for (int i = 0; i < n; i++)
                    parent[i] = i;
                unionCount = n;
            }

            public int FindParent(int x)
            {
                return parent[x] == x ? x : parent[x] = FindParent(parent[x]);
            }

            public bool Insert(int x, int y)
            {
                int rootX = FindParent(x), rootY = FindParent(y);
                if (rootX == rootY)
                    return false;
                parent[rootY] = rootX;
                unionCount--;
                return true;
            }

        }

        private class Comparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return ((int[])x)[2].CompareTo(((int[])y)[2]);
            }
        }

        public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
        {
            int m = edges.Length;
            var newEdges = new int[m][];
            for (int i = 0; i < m; i++)
            {
                newEdges[i] = new int[4];
                Array.Copy(edges[i], newEdges[i], 3);
                newEdges[i][3] = i;
            }
            Array.Sort(newEdges, new Comparer());

            var ans = new List<IList<int>>();
            ans.Add(new List<int>());
            ans.Add(new List<int>());
            int mst = GetMST(n, newEdges);
            for (int i = 0; i < m; i++)
            {
                int value = GetMST(n, newEdges, i);
                if (value < 0 || value > mst)
                    ans[0].Add(newEdges[i][3]);
                else if (GetMST(n, newEdges, i, true) == mst)
                    ans[1].Add(newEdges[i][3]);
            }

            return ans;
        }

        private int GetMST(int n, int[][] edges, int checkEdge = -1, bool include = false)
        {
            int value = 0;
            var uf = new UnionFind(n);
            if (include)
            {
                uf.Insert(edges[checkEdge][0], edges[checkEdge][1]);
                value += edges[checkEdge][2];
            }
            for (int i = 0; i < edges.Length; i++)
            {
                if (i == checkEdge || !uf.Insert(edges[i][0], edges[i][1]))
                    continue;
                value += edges[i][2];
            }
            return uf.UnionCount <= 1 ? value : -1;
        }

    }
}
