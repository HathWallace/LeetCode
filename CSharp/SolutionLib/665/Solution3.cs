//来源：https://leetcode-cn.com/problems/non-decreasing-array/solution/tan-xin-si-xiang-by-zhang-mo-san/

namespace SolutionLib._665
{
    public class Solution3
    {
        public bool CheckPossibility(int[] nums)
        {
            if (nums.Length <= 2) return true;

            bool flag = true;

            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (nums[i] > nums[i + 1])
                {
                    if (flag)
                    {
                        if (i == 0 || nums[i + 1] >= nums[i - 1])
                        {
                            nums[i] = nums[i + 1]; //优先第一种方案
                        }
                        else
                        {
                            nums[i + 1] = nums[i]; //万不得已第2种方案
                        }

                        flag = false; //判断第几次修改
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}