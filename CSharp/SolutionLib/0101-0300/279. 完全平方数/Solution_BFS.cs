using System.Collections.Generic;

namespace SolutionLib._279._完全平方数
{
    public class Solution_BFS
    {
        public int NumSquares(int n)
        {
            var square_nums = new HashSet<int>();
            for (int i = 1; i * i <= n; i++)
                square_nums.Add(i * i);
            int level = 0;
            var queue = new HashSet<int>();
            queue.Add(n);
            while (queue.Count != 0)
            {
                level++;
                var nextQueue = new HashSet<int>();
                foreach (var num in queue)
                {
                    foreach (var squareNum in square_nums)
                    {
                        if (num == squareNum) return level;
                        if (num < squareNum) break;
                        nextQueue.Add(num - squareNum);
                    }   
                }
                queue = nextQueue;
            }
            return level;
        }
    }
}