//https://leetcode-cn.com/problems/largest-rectangle-in-histogram/solution/zhu-zhuang-tu-zhong-zui-da-de-ju-xing-by-leetcode-/
using System;
using System.Collections.Generic;

namespace SolutionLib._84._柱状图中最大的矩形
{
    public class Solution_stalk
    {
        public int LargestRectangleArea(int[] heights)
        {
            var mono_stack = new Stack<int>();
            var left = new int[heights.Length];
            var right = new int[heights.Length];
            for (int i = 0; i < heights.Length; i++)
            {
                while (mono_stack.Count != 0 && heights[mono_stack.Peek()] >= heights[i])
                    mono_stack.Pop();
                left[i] = mono_stack.Count == 0 ? -1 : mono_stack.Peek();
                mono_stack.Push(i);
            }
            while (mono_stack.Count != 0) mono_stack.Pop();
            for (int i = heights.Length - 1; i >= 0; i--)
            {
                while (mono_stack.Count != 0 && heights[mono_stack.Peek()] >= heights[i])
                    mono_stack.Pop();
                right[i] = mono_stack.Count == 0 ? heights.Length : mono_stack.Peek();
                mono_stack.Push(i);
            }
            int ret = 0;
            for (int i = 0; i < heights.Length; i++)
                ret = Math.Max(ret, heights[i] * (right[i] - left[i] - 1));
            return ret;
        }
    }
}
