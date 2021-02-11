using System.Collections.Generic;

namespace SolutionLib._992._K_个不同整数的子数组
{
    public class Solution
    {
        public int SubarraysWithKDistinct(int[] A, int K)
        {
            return -1;
        }
    }

    //超出时间限制
    public class _Solution
    {
        public int SubarraysWithKDistinct(int[] A, int K)
        {
            int len = A.Length, ans = 0;
            for (int i = 0; i < len; i++)
            {
                var window = new HashSet<int>();
                for (int j = i; j >= 0 && window.Count <= K; j--)
                {
                    int num = A[j];
                    window.Add(num);
                    if (window.Count == K) ans++;
                }
            }
            return ans;
        }
    }

}