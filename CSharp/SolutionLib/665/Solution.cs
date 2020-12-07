namespace SolutionLib._665
{
    public class Solution
    {
        public bool CheckPossibility(int[] nums)
        {
            if (nums.Length == 1) return true;
            int i = 0;

            while (i < nums.Length - 1)
            {
                if (nums[i] <= nums[i + 1])
                {
                    i++;
                    continue;
                }
            }

            return true;
        }
    }
}