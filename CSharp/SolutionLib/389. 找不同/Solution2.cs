//https://leetcode-cn.com/problems/find-the-difference/solution/zhao-bu-tong-by-leetcode-solution-mtqf/

namespace SolutionLib._389._找不同
{
    public class Solution2
    {
        public char FindTheDifference(string s, string t)
        {
            int ret = 0;
            foreach (var ch in s)
            {
                ret ^= ch;
            }
            foreach (var ch in t)//两次异或同一个数最后结果不变
            {
                ret ^= ch;
            }

            return (char) ret;
        }

    }
}