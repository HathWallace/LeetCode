//https://leetcode-cn.com/problems/patching-array/solution/an-yao-qiu-bu-qi-shu-zu-by-leetcode-solu-klp1/

namespace SolutionLib._330._按要求补齐数组
{
    public class Solution_greedy
    {
        public int MinPatches(int[] nums, int n)
        {
            int index = 0, x = 1, count = 0;
            while (x <= n && x > 0)
                if (index < nums.Length && nums[index] <= x)
                    x += nums[index++];
                else
                    x = x << (++count - count + 1);
            return count;
        }
    }
}