using System.Collections.Generic;

namespace SolutionLib._1018._可被_5_整除的二进制前缀
{
    public class Solution2
    {
        public IList<bool> PrefixesDivBy5(int[] A)
        {
            var res = new List<bool>();
            int num = 0;
            foreach (var i in A)
            {
                num = ((num << 1) + i) % 5;
                res.Add(num == 0);
            }
            return res;
        }
    }

    public class Solution
    {
        public IList<bool> PrefixesDivBy5(int[] A)
        {
            var res = new List<bool>();
            int num = 0;
            foreach (var i in A)
            {
                num = (num * 2 + i) % 10;
                res.Add(num == 0 || num == 5);
            }
            return res;
        }
    }
}