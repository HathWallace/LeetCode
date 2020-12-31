using System;

namespace SolutionLib._300._最长递增子序列
{
    public class Test
    {
        public static void Run()
        {
            var s=new Solution_greedy();
            Console.WriteLine(s.LengthOfLIS(Public.ReadNums()));
        }
    }
}