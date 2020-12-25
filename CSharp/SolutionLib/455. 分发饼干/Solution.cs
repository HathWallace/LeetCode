using System;

namespace SolutionLib._455._分发饼干
{
    public class Solution
    {
        private void SortArray(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j > 0 && nums[(j - 1) / 2] < nums[j]; j = (j - 1) / 2)
                {
                    int tmp = nums[j];
                    nums[j] = nums[(j - 1) / 2];
                    nums[(j - 1) / 2] = tmp;
                }
            }
            for (int length = nums.Length - 1; length > 0; length--)
            {
                int tmp = nums[length];
                nums[length] = nums[0];
                nums[0] = tmp;
                for (int i = 0; 2 * i + 1 < length;)
                {
                    int child = 2 * i + 1;
                    if (child + 1 < length && nums[child + 1] > nums[child]) child++;
                    if (nums[i] < nums[child])
                    {
                        int _tmp = nums[child];
                        nums[child] = nums[i];
                        nums[i] = _tmp;
                        i = child;
                    }
                    else
                        break;
                }
            }
        }

        public int FindContentChildren(int[] g, int[] s)
        {
            int res = 0;
            SortArray(g);
            SortArray(s);
            int j = 0;
            for (int i = 0; i < s.Length && j < g.Length; i++)
            {
                if (g[j] > s[i]) continue;
                res++;
                j++;
            }
            return res;
        }
    }
}