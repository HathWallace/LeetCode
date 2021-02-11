using System.Linq;

namespace SolutionLib._724._寻找数组的中心索引
{
    public class Solution
    {
        public int PivotIndex(int[] nums)
        {
            int sum = nums.Sum(), left = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (2 * left == sum - nums[i]) return i;
                left += nums[i];
            }
            return -1;
        }
    }
}