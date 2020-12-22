using System;

namespace SolutionLib._322._零钱兑换
{
    public class Solution
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            int res = -1;
            foreach (var c in coins)
            {
                if (amount == c) return 1;
                if (amount < c) continue;
                int tmp = CoinChange(coins, amount - c);
                if (res == -1 && tmp >= 0) res = tmp + 1;
                res = tmp == -1 ? res : Math.Min(res, tmp + 1);
            }
            return res;
        }
    }
}