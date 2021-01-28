using System;

namespace SolutionLib._354._俄罗斯套娃信封问题
{
    public class Solution_greedy
    {
        public int MaxEnvelopes(int[][] envelopes)
        {
            int n = envelopes.Length, ans = 0;
            if (n == 0) return ans;
            var d = new int[n];
            Array.Sort(envelopes, MyComparer);
            for (int i = 0; i < n; i++)
            {
                int envelopeH = envelopes[i][1];
                int left = 0, right = ans;
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (d[mid] >= envelopeH)
                        right = mid;
                    else
                        left = mid + 1;
                }
                if (left == ans) ans++;
                d[left] = envelopeH;
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