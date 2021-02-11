using System.Collections.Generic;

namespace SolutionLib._992._K_个不同整数的子数组
{
    public class Solution_doublept
    {
        public int SubarraysWithKDistinct(int[] A, int K)
        {
            return AtMostKDistinct(A, K) - AtMostKDistinct(A, K - 1);
        }

        public int AtMostKDistinct(int[] A, int K)
        {
            int left = 0, right = 0, len = A.Length, valid = 0, ans = 0;
            var windows = new Dictionary<int, int>();
            while (right < len)
            {
                int rnum = A[right++];
                if (!windows.ContainsKey(rnum)) windows[rnum] = 0;
                windows[rnum]++;
                if (windows[rnum] == 1) valid++;
                while (valid > K)
                {
                    int lnum = A[left++];
                    if (windows[lnum] == 1) valid--;
                    windows[lnum]--;
                }
                ans += right - left;
            }
            return ans;
        }

    }
}