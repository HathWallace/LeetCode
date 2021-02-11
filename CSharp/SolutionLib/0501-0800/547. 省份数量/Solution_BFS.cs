using System.Collections.Generic;

namespace SolutionLib._547._省份数量
{
    public class Solution_BFS
    {
        public int FindCircleNum(int[][] isConnected)
        {
            int ans = 0, n = isConnected.Length;
            var visit = new bool[n];
            var queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (visit[i]) continue;
                queue.Enqueue(i);
                while (queue.Count != 0)
                {
                    int city = queue.Dequeue();
                    for (int j = 0; j < n; j++)
                    {
                        if (visit[j] || isConnected[city][j] != 1) continue;
                        visit[j] = true;
                        queue.Enqueue(j);
                    }
                }
                ans++;
            }
            return ans;
        }
    }
}