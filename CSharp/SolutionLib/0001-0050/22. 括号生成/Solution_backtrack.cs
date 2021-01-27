using System.Collections.Generic;
using System.Text;

namespace SolutionLib._22._括号生成
{
    public class Solution_backtrack
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var res=new List<string>();
            Backtrack(res, new StringBuilder(), 0, 0, n);
            return res;
        }

        private void Backtrack(List<string> res, StringBuilder stringBuilder, int open, int close, int max)
        {
            if (stringBuilder.Length == 2 * max)
            {
                res.Add(stringBuilder.ToString());
                return;
            }

            if (open < max)
            {
                stringBuilder.Append('(');
                Backtrack(res, stringBuilder, open + 1, close, max);
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }

            if (close < open)
            {
                stringBuilder.Append(')');
                Backtrack(res, stringBuilder, open, close + 1, max);
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }

        }
    }
}