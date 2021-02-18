namespace SolutionLib._995._K_连续位的最小翻转次数
{
    public class Solution_slidewindow
    {
        public int MinKBitFlips(int[] A, int K)
        {
            int n = A.Length, ans = 0, revCnt = 0;
            for (int i = 0; i < n; i++)
            {
                if (i - K >= 0 && A[i - K] > 1)
                {
                    revCnt ^= 1;
                    //A[i - K] -= 2;
                }
                if (A[i] == revCnt)
                {
                    if (i + K > n) return -1;
                    ans++;
                    revCnt ^= 1;
                    A[i] += 2;
                }
            }
            return ans;
        }
    }

    public class _Solution_slidewindow
    {
        public int MinKBitFlips(int[] A, int K)
        {
            int n = A.Length, ans = 0, revCnt = 0;
            var diff = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                revCnt ^= diff[i];
                if (A[i] == revCnt)
                {
                    if (i + K > n) return -1;
                    ans++;
                    revCnt ^= 1;
                    diff[i + K] ^= 1;
                }
            }
            return ans;
        }
    }

}