using System;

namespace SolutionLib._188._买卖股票的最佳时机_IV
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_dp();
            Console.WriteLine(s.MaxProfit(Public.ReadNum(), Public.ReadNums()));
        }

        /*
         * 测试用例：
         * [3,2,6,5,0,3,2,4,1]
         */

    }
}