using System;
using System.Collections.Generic;

namespace SolutionLib._279._完全平方数
{
    public class Solution
    {
        public int NumSquares(int n)
        {
            var dp = new int[n + 1];
            for (int i = 0; i * i <= n; i++)
                dp[i * i] = 1;
            return NumSquares(n, dp);
        }

        private int NumSquares(int n, int[] dp)
        {
            if (dp[n] != 0) return dp[n];
            dp[n] = n;
            for (int i = 1; i * i <= n; i++)
                dp[n] = Math.Min(dp[n], NumSquares(n - i * i, dp) + 1);
            return dp[n];
        }

    }

    //超出时间限制
    public class __Solution
    {
        public int NumSquares(int n)
        {
            var dp = new int[n + 1];
            for (int i = 1; i * i <= n; i++)
                dp[i * i] = 1;
            for (int i = 2; i <= n; i++)
            {
                if (dp[i] != 0) continue;
                dp[i] = i;
                for (int j = 1; j <= i / 2; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[j] + dp[i - j]);
                }
            }
            return dp[n];
        }
    }

    //超出时间限制
    public class _Solution
    {
        private int[] result;

        public int NumSquares(int n)
        {
            result = new int[n + 1];
            return Devide(n);
        }

        private int Devide(int num)
        {
            if (result[num] != 0)
                return result[num];
            int sqrt = (int)Math.Sqrt(num);
            if (sqrt * sqrt == num)
                return result[num] = 1;
            int res = num;
            for (int i = 1; i <= num / 2; i++)
                res = Math.Min(res, Devide(i) + Devide(num - i));
            return res;
        }

    }
}