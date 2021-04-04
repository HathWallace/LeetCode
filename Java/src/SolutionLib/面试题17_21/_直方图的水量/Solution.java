package SolutionLib.面试题17_21._直方图的水量;

class Solution {
    public int trap(int[] height) {
        var t = height.length;
        return 0;
    }
}

class Solution2 {
    public int trap(int[] height) {
        int n = height.length, ans = 0;
        if (n < 3) return ans;
        var leftMax = new int[n];
        var rightMax = new int[n];
        leftMax[0] = height[0];
        rightMax[n - 1] = height[n - 1];
        for (int i = 1; i < n; i++) {
            leftMax[i] = Math.max(leftMax[i - 1], height[i]);
            rightMax[n - 1 - i] = Math.max(rightMax[n - i], height[n - 1 - i]);
        }
        for (int i = 0; i < n; i++) {
            ans += Math.min(leftMax[i], rightMax[i]) - height[i];
        }
        return ans;
    }
}