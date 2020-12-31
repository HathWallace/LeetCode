//https://leetcode-cn.com/problems/coin-change/solution/322-ling-qian-dui-huan-by-leetcode-solution/

using System;

namespace SolutionLib._322._零钱兑换
{
    public class Solution_dp
    {
        public int CoinChange(int[] coins, int amount)
        {
            return CoinChange(coins, amount, new int[amount]);
        }

        private int CoinChange(int[] coins, int amount, int[] count)
        {
            if (amount <= 0) return Math.Sign(amount);
            if (count[amount - 1] != 0) return count[amount - 1];
            int min = int.MaxValue;
            for (int i = 0; i < coins.Length; i++)
            {
                int res = CoinChange(coins, amount - coins[i], count);
                if (res >= 0 && res + 1 < min) min = res + 1;

            }
            count[amount - 1] = min == int.MaxValue ? -1 : min;
            return count[amount - 1];
        }
    }
}