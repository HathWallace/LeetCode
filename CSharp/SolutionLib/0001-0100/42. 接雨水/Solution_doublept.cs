using System;

namespace SolutionLib._42._接雨水
{
    public class Solution_doublept
    {
        public int Trap(int[] height)
        {
            int ans = 0, left = 0, right = height.Length - 1;
            int leftMax = int.MinValue, rightMax = int.MinValue;
            while (left < right)
                if (height[left] < height[right])
                {
                    if (height[left] >= leftMax) leftMax = height[left];
                    else ans += leftMax - height[left];
                    left++;
                }
                else
                {
                    if (height[right] >= rightMax) rightMax = height[right];
                    else ans += rightMax - height[right];
                    right--;
                }
            return ans;
        }
    }

    public class _Solution_doublept
    {
        public int Trap(int[] height)
        {
            int ans = 0, left = 0, right = height.Length - 1;
            int leftMax = int.MinValue, rightMax = int.MinValue;
            while (left < right)
                if (height[left] < height[right])
                    ans += (leftMax = Math.Max(leftMax, height[left])) - height[left++];
                else
                    ans += (rightMax = Math.Max(height[right], rightMax)) - height[right--];
            return ans;
        }
    }

}