package SolutionLib2._28._实现strStr;

class Solution {
    public int strStr(String haystack, String needle) {
        int n = haystack.length(), m = needle.length();
        if (m == 0) return 0;

        int[][] kmp = new int[m][26];
        int x = 0;
        kmp[0][needle.charAt(0) - 'a'] = 1;
        for (int i = 1; i < m; i++) {
            for (int j = 0; j < 26; j++) {
                kmp[i][j] = kmp[x][j];
            }
            int ch = needle.charAt(i) - 'a';
            kmp[i][ch] = i + 1;
            x = kmp[x][ch];
        }

        int j = 0;
        for (int i = 0; i < n; i++) {
            j = kmp[j][haystack.charAt(i) - 'a'];
            if (j == m) return i - m + 1;
        }

        return -1;
    }
}
