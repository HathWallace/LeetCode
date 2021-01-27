using System.Collections.Generic;

namespace SolutionLib._830._较大分组的位置
{
    public class Solution
    {
        public IList<IList<int>> LargeGroupPositions(string s)
        {
            var res = new List<IList<int>>();
            int start = 0, end;
            for (int i = 1; i < s.Length; i++)
                if (s[i] != s[i - 1])
                {
                    end = i - 1;
                    if (end - start + 1 >= 3)
                        res.Add(new List<int> {start, end});
                    start = i;
                }
            end = s.Length - 1;
            if (end - start + 1 >= 3)
                res.Add(new List<int> { start, end });
            return res;
        }
    }
}