package SolutionLib._74._搜索二维矩阵;

public class Solution {
    public boolean searchMatrix(int[][] matrix, int target) {
        int m = matrix.length, n = matrix[0].length;
        int left = 0, right = m * n;
        while (left < right) {
            int mid = (left + right) / 2;
            int midVal = matrix[mid / n][mid % n];
            if (midVal == target) return true;
            if (midVal > target) right = mid;
            if (midVal < target) left = mid + 1;
        }
        return false;
    }
}
