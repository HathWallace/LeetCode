using System;

namespace SolutionLib._1579._保证图可完全遍历
{
    public class Solution2
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

            public bool Union(int x, int y)
            {
                int rootX = FindParent(x), rootY = FindParent(y);
                if (rootX == rootY) return false;
                parent[rootY] = rootX;
                unionCount--;
                return true;
            }

        }

        public int MaxNumEdgesToRemove(int n, int[][] edges)
        {
            var alice_uf = new UnionFind(n);
            var bob_uf = new UnionFind(n);
            int ans = 0;
            foreach (var edge in edges)
            {
                if (edge[0] != 3) continue;
                bool res = alice_uf.Union(edge[1] - 1, edge[2] - 1);
                res = bob_uf.Union(edge[1] - 1, edge[2] - 1) || res;
                if (!res) ans++;
            }
            foreach (var edge in edges)
            {
                if (edge[0] == 1 && !alice_uf.Union(edge[1] - 1, edge[2] - 1))
                    ans++;
                else if (edge[0] == 2 && !bob_uf.Union(edge[1] - 1, edge[2] - 1))
                    ans++;

            }
            if (alice_uf.UnionCount > 1 || bob_uf.UnionCount > 1)
                return -1;
            return ans;
        }

    }

    public class Solution
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

            public bool Union(int x, int y)
            {
                int rootX = FindParent(x), rootY = FindParent(y);
                if (rootX == rootY) return false;
                parent[rootY] = rootX;
                unionCount--;
                return true;
            }

        }

        public int MaxNumEdgesToRemove(int n, int[][] edges)
        {
            var alice_uf = new UnionFind(n);
            var bob_uf = new UnionFind(n);
            int ans = 0;
            Array.Sort(edges, MyComparer);
            foreach (var edge in edges)
            {
                int type = edge[0];
                bool alice = true, bob = true;
                if (type != 2)
                    alice = alice_uf.Union(edge[1] - 1, edge[2] - 1);
                if (type != 1)
                    bob = bob_uf.Union(edge[1] - 1, edge[2] - 1);
                if (type == 1 && !alice || type == 2 && !bob || type == 3 && !alice && !bob)
                    ans++;
            }
            if (alice_uf.UnionCount > 1 || bob_uf.UnionCount > 1)
                return -1;
            return ans;
        }

        private int MyComparer(int[] x, int[] y)
        {
            return y[0].CompareTo(x[0]);
        }

    }

}