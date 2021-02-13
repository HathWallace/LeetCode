namespace SolutionLib._1._两数之和
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var res = new int[2];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                res[0] = i;
                res[1] = -1;
                for (int j = i + 1; j < nums.Length; j++)
                    if (nums[i] + nums[j] == target)
                    {
                        res[1] = j;
                        break;
                    }
                if (res[1] != -1) break;
            }
            return res;
        }
    }
}