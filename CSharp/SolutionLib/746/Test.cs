using System;

namespace SolutionLib._746
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