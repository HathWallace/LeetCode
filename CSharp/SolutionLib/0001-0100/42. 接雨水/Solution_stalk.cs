using System;
using System.Collections.Generic;

namespace SolutionLib._42._接雨水
{
    public class Solution_stalk
    {
        public int Trap(int[] height)
        {
            int ans = 0, current = 0;
            var stalk = new Stack<int>();
            while (current < height.Length)
            {
                while (stalk.Count != 0 && height[stalk.Peek()] < height[current])
                {
                    int popH = stalk.Pop();
                    if (stalk.Count == 0) break;
                    ans += (Math.Min(height[stalk.Peek()], height[current]) - height[popH]) * (current - stalk.Peek() - 1);
                }
                stalk.Push(current++);
            }
            return ans;
        }
    }
}