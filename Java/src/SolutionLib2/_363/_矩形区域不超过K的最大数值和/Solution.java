package SolutionLib2._363._矩形区域不超过K的最大数值和;

class Solution {
    public int maxSumSubmatrix(int[][] matrix, int k) {
        int m = matrix.length, n = matrix[0].length, ans = Integer.MIN_VALUE;
        int[][] sum = new int[m + 1][n + 1];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                sum[i + 1][j + 1] = sum[i + 1][j] + sum[i][j + 1] - sum[i][j] + matrix[i][j];
            }
        }
        for (int x1 = 1; x1 <= m; x1++) {
            for (int y1 = 1; y1 <= n; y1++) {
                for (int x2 = 0; x2 < x1; x2++) {
                    for (int y2 = 0; y2 < y1; y2++) {
                        int val = sum[x1][y1] + sum[x2][y2] - sum[x1][y2] - sum[x2][y1];
                        if (val <= k && val > ans) ans = val;
                    }
                }
            }
        }
        return ans;
    }
}