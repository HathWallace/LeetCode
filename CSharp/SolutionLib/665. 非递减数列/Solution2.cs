//来源：https://leetcode-cn.com/problems/non-decreasing-array/solution/javatan-xin-si-lu-by-shi-qu-de-feng-5t/

namespace SolutionLib._665._非递减数列
{
    public class Solution2
    {
        public bool CheckPossibility(int[] nums)
        {
            int length = nums.Length;
            if (length == 1) return true;
            int left = 0, right = 1;//双指针
            int count = 0;
            while (right < length)
            {
                //遇到递减的情况，基于贪心的思路，要么把前一个元素放到和后一个元素一样小
                //要么把后一个元素放到和前一个元素一样大
                //区分这两种情况哪种合理，判断更前一个元素的大小即可
                if (nums[right] < nums[left])
                {
                    count++;
                    if (left != 0 && nums[left - 1] > nums[right])
                        nums[right] = nums[left];
                }
                if (count == 2) return false;
                right++;
                left++;
            }
            return true;
        }
    }
}
