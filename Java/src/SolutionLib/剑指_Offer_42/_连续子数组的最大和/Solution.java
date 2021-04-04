package SolutionLib.剑指_Offer_42._连续子数组的最大和;

public class Solution {
    public int maxSubArray(int[] nums) {
        int dp = 0, ans = Integer.MIN_VALUE;
        for (var num : nums) {
            dp = Math.max(dp + num, num);
            ans = Math.max(ans, dp);
        }
        return ans;
    }
}