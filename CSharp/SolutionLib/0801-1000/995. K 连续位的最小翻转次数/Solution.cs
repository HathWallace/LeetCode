namespace SolutionLib._995._K_连续位的最小翻转次数
{
    public class Solution
    {
        public int MinKBitFlips(int[] A, int K)
        {
            return -1;
        }
    }

    //超出时间限制
    public class _Solution
    {
        public int MinKBitFlips(int[] A, int K)
        {
            int ans = 0;
            for (int i = 0; i + K <= A.Length; i++)
            {
                if (A[i] == 1) continue;
                ans++;
                for (int j = 0; j < K; j++)
                    A[i + j] = (A[i + j] + 1) % 2;
            }
            for (int i = 0; i < A.Length; i++)
                if (A[i] == 0) return -1;
            return ans;
        }
    }

}