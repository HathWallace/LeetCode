using System.Collections.Generic;

namespace SolutionLib._448._找到所有数组中消失的数字
{
    public class Solution
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            int n = nums.Length;
            var res = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int j = i;
                while (nums[j] != j + 1 && nums[nums[j] - 1] != nums[j])
                {
                    int tmp = nums[j];
                    nums[j] = nums[tmp - 1];
                    nums[tmp - 1] = tmp;
                }
            }
            for (int i = 0; i < n; i++)
                if (nums[i] != i + 1)
                    res.Add(i + 1);
            return res;
        }
    }

    public class _Solution
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            int n = nums.Length;
            var counter = new int[n];
            var res = new List<int>();
            foreach (var num in nums)
                counter[num - 1]++;
            for (int i = 0; i < n; i++)
                if (counter[i] == 0)
                    res.Add(i + 1);
            return res;
        }
    }

}