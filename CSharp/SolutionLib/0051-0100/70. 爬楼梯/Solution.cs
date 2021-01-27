namespace SolutionLib._70._爬楼梯
{
    public class Solution
    {
        public int ClimbStairs(int n)
        {
            if (n < 2) return 1;
            int ans = 2, pre = 1;
            for (int i = 3; i <= n; i++)
                pre = (ans += pre) - pre;
            return ans;
        }
    }
}