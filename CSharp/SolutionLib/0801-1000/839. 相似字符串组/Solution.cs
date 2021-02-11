namespace SolutionLib._839._相似字符串组
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
                parent[rootX] = rootY;
                unionCount--;
            }

        }

        public int NumSimilarGroups(string[] strs)
        {
            int n = strs.Length;
            var uf = new UnionFind(n);
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (IsSimilar(strs[i], strs[j]))
                        uf.Union(i, j);
            return uf.UnionCount;
        }

        private bool IsSimilar(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;
            int swap = -1;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == str2[i]) continue;
                if (swap == -1) swap = i;
                else if (swap >= 0 && str1[i] == str2[swap])
                    swap = -2;
                else
                    return false;
            }
            return swap < 0;
        }

    }
}