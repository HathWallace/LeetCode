//https://leetcode-cn.com/problems/longest-increasing-subsequence/solution/zui-chang-shang-sheng-zi-xu-lie-by-leetcode-soluti/

namespace SolutionLib._300._最长递增子序列
{
    public class Solution_greedy
    {
        public int LengthOfLIS(int[] nums)
        {
            var d = new int[nums.Length + 1];
            int len = 1;
            d[len] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (d[len] < nums[i]) d[++len] = nums[i];
                else
                {
                    int left = 1, right = len, pos = 1;
                    while (left <= right)
                    {
                        int mid = (left + right) / 2;
                        if (nums[i] > d[mid])
                            pos = left = mid + 1;
                        else
                            right = mid - 1;
                    }
                    d[pos] = nums[i];
                }
            }
            return len;
        }
    }
}