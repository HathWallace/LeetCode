package SolutionLib2._1011._在D天内送达包裹的能力;

import java.util.Arrays;

class Solution {
    public int shipWithinDays(int[] weights, int D) {
        int left = Arrays.stream(weights).max().getAsInt(), right = Arrays.stream(weights).sum();
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (howMuchDays(weights, mid) > D) left = mid + 1;
            else right = mid;
        }
        return left;
    }

    private int howMuchDays(int[] weights, int max) {
        int need = 1, cur = 0;
        for (int weight : weights) {
            if (cur + weight > max) {
                need++;
                cur = 0;
            }
            cur += weight;
        }
        return need;
    }
}
