namespace SolutionLib._959._由斜杠划分区域
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
                if (rootX == rootY) return;
                parent[rootY] = rootX;
                unionCount--;
            }

        }

        private int N;

        public int RegionsBySlashes(string[] grid)
        {
            N = grid.Length;
            var uf = new UnionFind(N * N * 2);

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    int ceiling = GetIndex(i, j, true);
                    int floor = GetIndex(i, j, false);
                    int left = grid[i][j] == '/' ? ceiling : floor;
                    if (grid[i][j] == ' ')
                        uf.Union(ceiling, floor);
                    if (i != 0)
                        uf.Union(ceiling, GetIndex(i - 1, j, false));
                    if (j != 0)
                        if (grid[i][j - 1] == '/')
                            uf.Union(left, GetIndex(i, j - 1, false));
                        else
                            uf.Union(left, GetIndex(i, j - 1, true));
                }

            return uf.UnionCount;
        }

        private int GetIndex(int i, int j, bool hasUp)
        {
            return i * N + j + N * N * (hasUp ? 0 : 1);
        }

    }
}