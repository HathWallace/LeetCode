using System;

namespace SolutionLib._309._最佳买卖股票时机含冷冻期
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            if (n == 0) return 0;
            int buy = -prices[0], sale0 = 0, sale1 = 0;
            for (int i = 1; i < n; i++)
            {
                buy = Math.Max(buy, sale0 - prices[i]);
                sale0 = Math.Max(sale0, sale1);
                sale1 = prices[i] + buy;
            }
            return Math.Max(sale0, sale1);
        }
    }

    public class _Solution
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            if (n == 0) return 0;
            var buy = new int[n];
            var sale = new int[n, 2];
            buy[0] = -prices[0];
            for (int i = 1; i < n; i++)
            {
                buy[i] = Math.Max(buy[i - 1], sale[i - 1, 0] - prices[i]);
                sale[i, 0] = Math.Max(sale[i - 1, 0], sale[i - 1, 1]);
                sale[i, 1] = prices[i] + buy[i - 1];
            }
            return Math.Max(sale[n - 1, 0], sale[n - 1, 1]);
        }
    }
}