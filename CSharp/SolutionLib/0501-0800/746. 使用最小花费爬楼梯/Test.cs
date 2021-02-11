using System;

namespace SolutionLib._746._使用最小花费爬楼梯
{
    public class Test
    {
        public static void Run()
        {
            var cost = Public.ReadNums();

            var s = new Solution();

            Console.WriteLine(s.MinCostClimbingStairs(cost));

        }

    }
}