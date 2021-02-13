using System;

namespace SolutionLib._322._零钱兑换
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_dp();
            Console.WriteLine(s.CoinChange(Public.ReadNums(), Public.ReadNum()));
        }
    }
}