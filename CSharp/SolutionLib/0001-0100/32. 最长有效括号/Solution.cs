using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionLib._32._最长有效括号
{
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            int ans = 0;
            var stack = new Stack<int>();
            var list = new LinkedList<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    stack.Push(i);
                else if (stack.Count != 0)
                {
                    while (list.Count > 0 && list.Last() > stack.Peek())
                    {
                        list.RemoveLast();
                        list.RemoveLast();
                    }
                    list.AddLast(stack.Pop());
                    list.AddLast(i);
                }
            }
            while (list.Count != 0)
            {
                int open = list.First(), close;
                list.RemoveFirst();
                close = list.First();
                list.RemoveFirst();
                while (list.Count != 0 && close + 1 == list.First())
                {
                    list.RemoveFirst();
                    close = list.First();
                    list.RemoveFirst();
                }
                ans = Math.Max(ans, close - open + 1);
            }
            return ans;
        }
    }
}