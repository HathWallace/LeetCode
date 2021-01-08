namespace SolutionLib._189._旋转数组
{
    public class Solution_replace
    {
        public void Rotate(int[] nums, int k)
        {
            int size = nums.Length;
            k = k % size;
            int count = GCD(size, k);
            for (int i = 0; i < count; i++)
            {
                int j = (i + k) % size, memory = nums[i];
                while (j != i)
                {
                    int tmp = nums[j];
                    nums[j] = memory;
                    memory = tmp;
                    j = (j + k) % size;
                }
                nums[i] = memory;
            }
        }

        private int GCD(int x, int y)
        {
            return y > 0 ? GCD(y, x % y) : x;
        }
    }
}