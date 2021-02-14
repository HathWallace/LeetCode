using System.Collections;
using System.Collections.Generic;

namespace SolutionLib._765._情侣牵手
{
    public class Solution_BFS
    {
        public int MinSwapsCouples(int[] row)
        {
            int n = row.Length, tot = n / 2, ret = 0;
            var graph = new IList[tot];
            var visit = new bool[tot];
            for (int i = 0; i < tot; i++)
                graph[i] = new List<int>();
            for (int i = 0; i < n; i += 2)
            {
                int l = row[i] / 2, r = row[i + 1] / 2;
                if (l != r)
                {
                    graph[l].Add(r);
                    graph[r].Add(l);
                }
            }
            for (int i = 0; i < tot; i++)
            {
                if (visit[i]) continue;
                var queue = new Queue<int>();
                visit[i] = true;
                queue.Enqueue(i);
                int cnt = 0;
                while (queue.Count != 0)
                {
                    int x = queue.Dequeue();
                    cnt++;
                    foreach (int y in graph[x])
                    {
                        if (visit[y]) continue;
                        visit[y] = true;
                        queue.Enqueue(y);
                    }
                }
                ret += cnt - 1;
            }
            return ret;
        }
    }
}