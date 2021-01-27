namespace SolutionLib._684._冗余连接
{
    public class Solution
    {
        public int[] FindRedundantConnection(int[][] edges)
        {
            int n = edges.Length;
            var parent = new int[n + 1];
            for (int i = 1; i <= n; i++)
                parent[i] = i;
            foreach (var edge in edges)
            {
                if (!Insert(parent, edge[0], edge[1]))
                    return edge;
            }
            return new int[] { };
        }

        private bool Insert(int[] parent, int x, int y)
        {
            int rootX = FindParent(parent, x),
                rootY = FindParent(parent, y);
            if (rootX == rootY) return false;
            parent[rootY] = rootX;
            return true;
        }

        private int FindParent(int[] parent, int x)
        {
            return parent[x] = parent[x] == x ? x : FindParent(parent, parent[x]);
        }

    }
}