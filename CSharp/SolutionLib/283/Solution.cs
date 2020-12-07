namespace SolutionLib._283
{
    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            int first0 = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    first0 = i;
                    break;
                }
            }

            if (first0 == -1) return;

            for (int i = first0 + 1; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[first0] = nums[i];
                    nums[i] = 0;
                    first0++;
                }
            }

        }
    }
}