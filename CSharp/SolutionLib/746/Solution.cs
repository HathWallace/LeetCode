using System;

namespace SolutionLib._746
{
    public class Solution
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            int noJump = cost[0], jump = 0;
            for (int i = 1; i < cost.Length; i++)
            {
                int pre = noJump;
                noJump = Math.Min(noJump, jump) + cost[i];
                jump = pre;
            }
            return Math.Min(noJump, jump);
        }
    }
}