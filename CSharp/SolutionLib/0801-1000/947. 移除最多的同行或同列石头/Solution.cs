using System.Collections.Generic;

namespace SolutionLib._947._移除最多的同行或同列石头
{
    public class Solution_union
    {
        private class UnionFind
        {
            private Dictionary<int, int> parent = new Dictionary<int, int>();
            private int count = 0;
            public int Count => count;

            public int FindParent(int x)
            {
                if (!parent.ContainsKey(x))
                {
                    parent[x] = x;
                    count++;
                }
                return parent[x] = parent[x] == x ? x : FindParent(parent[x]);
            }

            public void Insert(int x, int y)
            {
                int rootX = FindParent(x), rootY = FindParent(y);
                if (rootX == rootY) return;
                parent[rootY] = rootX;
                count--;
            }

        }

        public int RemoveStones(int[][] stones)
        {
            var union = new UnionFind();
            foreach (var stone in stones)
            {
                union.Insert(~stone[0], stone[1]);
            }
            return stones.Length - union.Count;
        }
    }
}