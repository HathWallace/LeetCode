public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int first0 = -1, last0 = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                first0 = i;
                last0 = first0;
                break;
            }
        }

        if (first0 == -1) return;

        for (int i = first0 + 1; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                last0 = i;
            }
            else
            {
                nums[first0] = nums[i];
                nums[i] = 0;
                first0++;
                last0++;
            }
        }

    }
}