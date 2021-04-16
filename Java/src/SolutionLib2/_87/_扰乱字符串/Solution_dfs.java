package SolutionLib2._87._扰乱字符串;

class Solution_dfs {
    private String s1, s2;
    private int[][][] memo;

    public boolean isScramble(String s1, String s2) {
        int len = s1.length();
        this.s1 = s1;
        this.s2 = s2;
        memo = new int[len][len][len + 1];
        return dfs(0, 0, len);
    }

    private boolean dfs(int i1, int i2, int len) {
        if (memo[i1][i2][len] != 0) {
            return memo[i1][i2][len] == 1;
        }
        String sub1 = s1.substring(i1, i1 + len), sub2 = s2.substring(i2, i2 + len);
        if (sub1.equals(sub2)) {
            memo[i1][i2][len] = 1;
            return true;
        }
        if (!checkIfSimilar(sub1, sub2)) {
            memo[i1][i2][len] = -1;
            return false;
        }
        for (int l = 1; l < len; l++) {
            if (dfs(i1, i2, l) && dfs(i1 + l, i2 + l, len - l)) {
                memo[i1][i2][len] = 1;
                return true;
            }
            if (dfs(i1, i2 + len - l, l) && dfs(i1 + l, i2, len - l)) {
                memo[i1][i2][len] = 1;
                return true;
            }
        }
        memo[i1][i2][len] = -1;
        return false;
    }

    private boolean checkIfSimilar(String sub1, String sub2) {
        int len = sub1.length();
        int[] dict = new int[26];
        int invalid = 0;
        for (int i = 0; i < len; i++) {
            int i1 = sub1.charAt(i) - 'a', i2 = sub2.charAt(i) - 'a';
            if (i1 == i2) continue;
            dict[i1]++;
            dict[i2]--;
            if (dict[i1] == 1) invalid++;
            else if (dict[i1] == 0) invalid--;
            if (dict[i2] == -1) invalid++;
            else if (dict[i2] == 0) invalid--;
        }
        return invalid == 0;
    }
}