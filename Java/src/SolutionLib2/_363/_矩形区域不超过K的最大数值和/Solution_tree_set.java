package SolutionLib2._363._矩形区域不超过K的最大数值和;

import java.util.TreeSet;

class Solution_tree_set {
    public int maxSumSubmatrix(int[][] matrix, int k) {
        int m = matrix.length, n = matrix[0].length, ans = Integer.MIN_VALUE;
        for (int i = 0; i < m; i++) {
            int[] sum = new int[n];
            for (int j = i; j < m; j++) {
                for (int l = 0; l < n; l++) {
                    sum[l] += matrix[j][l];
                }
                TreeSet<Integer> treeSet = new TreeSet<>();
                int s = 0;
                treeSet.add(s);
                for (int v : sum) {
                    s += v;
                    Integer ceiling = treeSet.ceiling(s - k);
                    if (ceiling != null) {
                        ans = Math.max(ans, s - ceiling);
                    }
                    treeSet.add(s);
                }
            }
        }
        return ans;
    }
}
