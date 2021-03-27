package SolutionLib.剑指_Offer_21._调整数组顺序使奇数位于偶数前面;

public class Solution {
    public int[] exchange(int[] nums) {
        int n = nums.length, odd = -1;
        for (int i = 0; i < n; i++) {
            if (nums[i] % 2 == 0) continue;
            swap(nums, ++odd, i);
        }
        return nums;
    }

    private void swap(int[] nums, int i, int j) {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }

}
