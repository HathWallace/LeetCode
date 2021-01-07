using System;
using System.Collections.Generic;

namespace SolutionLib._32._最长有效括号
{
    public class Solution_stack
    {
        public int LongestValidParentheses(string s)
        {
            int ans = 0;
            var stack = new Stack<int>();
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') stack.Push(i);
                else
                {
                    stack.Pop();
                    if (stack.Count == 0) stack.Push(i);
                    else ans = Math.Max(ans, i - stack.Peek());
                }
            }
            return ans;
        }
    }
}