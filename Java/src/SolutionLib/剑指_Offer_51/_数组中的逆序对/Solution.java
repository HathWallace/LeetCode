package SolutionLib.剑指_Offer_51._数组中的逆序对;

import java.util.Arrays;

public class Solution {
    public int reversePairs(int[] nums) {
        int len = nums.length;
        var copy = Arrays.copyOf(nums, len);
        return reversePairs(copy, 0, len - 1, new int[len]);
    }

    private int reversePairs(int[] nums, int left, int right, int[] tmp) {
        if (left >= right) return 0;
        int mid = left + (right - left) / 2;
        int leftPairs = reversePairs(nums, left, mid, tmp);
        int rightPairs = reversePairs(nums, mid + 1, right, tmp);
        return leftPairs + rightPairs + mergeAndCount(nums, left, mid, right, tmp);
    }

    private int mergeAndCount(int[] nums, int left, int mid, int right, int[] tmp) {
        if (nums[mid] <= nums[mid + 1]) return 0;
        for (int k = left; k <= right; k++) tmp[k] = nums[k];
        int i = left, j = mid + 1, count = 0;
        for (int k = left; k <= right; k++) {
            if (i == mid + 1) nums[k] = tmp[j++];
            else if (j == right + 1) nums[k] = tmp[i++];
            else if (tmp[i] <= tmp[j]) nums[k] = tmp[i++];
            else {
                nums[k] = tmp[j++];
                count += (mid + 1 - i);
            }
        }
        return count;
    }

}
