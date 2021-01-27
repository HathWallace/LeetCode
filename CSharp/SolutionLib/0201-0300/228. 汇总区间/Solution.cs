using System.Collections.Generic;
using System.Text;

namespace SolutionLib._228._汇总区间
{
    public class Solution
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            var res = new List<string>();
            int index = 0;
            while (index < nums.Length)
            {
                var str = new StringBuilder();
                int start = nums[index++];
                str.Append(start);
                while (index < nums.Length && nums[index - 1] + 1 == nums[index])
                    index++;
                if (nums[index - 1] != start)
                    str.Append("->" + nums[index - 1]);
                res.Add(str.ToString());
            }
            return res;
        }
    }
}