using System.Collections.Generic;

namespace SolutionLib._169._多数元素
{
    public class Solution
    {
        public int MajorityElement(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = 0;
                dict[num]++;
                if (dict[num] > nums.Length / 2)
                    return num;
            }
            return -1;
        }
    }
}