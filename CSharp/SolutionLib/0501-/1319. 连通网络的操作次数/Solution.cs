namespace SolutionLib._1319._连通网络的操作次数
{
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

            public void Union(int x, int y)
            {
                int rootX = FindParent(x), rootY = FindParent(y);
                if (rootX == rootY)
                    return;
                parent[rootY] = rootX;
                unionCount--;
            }

        }

        public int MakeConnected(int n, int[][] connections)
        {
            int m = connections.Length;
            if (m < n - 1)
                return -1;
            var uf = new UnionFind(n);
            foreach (var connection in connections)
            {
                uf.Union(connection[0], connection[1]);
                if (uf.UnionCount == 1) return 0;
            }
            return uf.UnionCount - 1;
        }

    }
}