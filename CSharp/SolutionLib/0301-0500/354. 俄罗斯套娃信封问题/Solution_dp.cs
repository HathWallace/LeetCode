using System;
using System.Collections;
using System.Collections.Generic;

namespace SolutionLib._354._俄罗斯套娃信封问题
{
    public class Solution_dp
    {
        public int MaxEnvelopes(int[][] envelopes)
        {
            int n = envelopes.Length, ans = 0;
            if (n == 0) return ans;
            var dp = new int[n];
            Array.Sort(envelopes, MyComparer);
            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                    if (envelopes[i][0] > envelopes[j][0] && envelopes[i][1] > envelopes[j][1])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                ans = Math.Max(ans, dp[i]);
            }
            return ans;
        }

        private int MyComparer(int[] x, int[] y)
        {
            if (x[0] != y[0])
                return x[0].CompareTo(y[0]);
            return y[1].CompareTo(x[1]);
        }

    }
}