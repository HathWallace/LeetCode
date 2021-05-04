package SolutionLib2._367._有效的完全平方数;

class Solution {
    public boolean isPerfectSquare(int num) {
        int left = 1, right = num;
        while (left < right) {
            int mid = left + (right - left) / 2;
            long d = (long) mid * mid;
            if (d == num) return true;
            if (d > num) right = mid - 1;
            if (d < num) left = mid + 1;
        }
        return left * left == num;
    }
}
