using System;

namespace SolutionLib._42._接雨水
{
    public class Solution_dp
    {
        public int Trap(int[] height)
        {
            if (height.Length < 3) return 0;
            int ans = 0;
            int size = height.Length;
            var leftMax = new int[size];
            var rightMax = new int[size];
            leftMax[0] = height[0];
            for (int i = 1; i < size - 1; i++)
                leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
            rightMax[size - 1] = height[size - 1];
            for (int i = size - 2; i > 0; i--)
                rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
            for (int i = 1; i < size - 1; i++)
                ans += Math.Min(leftMax[i], rightMax[i]) - height[i];
            return ans;
        }
    }
}