//https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/solution/mai-mai-gu-piao-de-zui-jia-shi-ji-han-sh-rzlz/

using System;

namespace SolutionLib._714
{
    public class Solution2
    {
        public int MaxProfit(int[] prices, int fee)
        {
            int sell = 0, buy = -prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                sell = Math.Max(sell, buy + prices[i] - fee);
                buy = Math.Max(sell - prices[i], buy);
            }

            return sell;
        }

        public int MaxProfit2(int[] prices, int fee)//贪心
        {
            int buy = prices[0] + fee, profit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] + fee < buy)
                    buy = prices[i] + fee;
                else if (prices[i] > buy)
                {
                    profit += prices[i] - buy;
                    buy = prices[i];
                }
            }

            return profit;
        }

    }
}