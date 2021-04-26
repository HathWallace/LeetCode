package SolutionLib2._91._解码方法;

class Solution2 {
    public int numDecodings(String s) {
        if (s.charAt(0) == '0') return 0;
        int len = s.length();
        int dp = 1, preDp = 1, dig = s.charAt(0) - '0';
        for (int i = 1; i < len; i++) {
            int next = s.charAt(i) - '0', tmp = dp;
            if (next == 0) dp = 0;
            if (dig > 0 && dig * 10 + next <= 26) dp += preDp;
            preDp = tmp;
            dig = next;
            if (dp == 0 && preDp == 0) break;
        }
        return dp;
    }
}

class Solution {
    public int numDecodings(String s) {
        if (s.charAt(0) == '0') return 0;
        int len = s.length();
        int[] dp = new int[len + 1];
        dp[0] = 1;
        dp[1] = 1;
        for (int i = 1; i < len; i++) {
            int next = s.charAt(i) - '0', dig = s.charAt(i - 1) - '0';
            if (next > 0) dp[i + 1] += dp[i];
            if (dig > 0 && dig * 10 + next <= 26) dp[i + 1] += dp[i - 1];
            if (dp[i] == 0 && dp[i + 1] == 0) break;
        }
        return dp[len];
    }
}

class _Solution {
    private String s;
    private int ans;

    public int numDecodings(String s) {
        this.s = s;
        ans = 0;
        backtrack(1, s.charAt(0) - '0');
        return ans;
    }

    private void backtrack(int index, int pre) {
        if (pre > 26 || pre <= 0) return;
        if (index == s.length()) {
            if (pre > 0) ans++;
            return;
        }
        int ch = s.charAt(index) - '0';
        backtrack(index + 1, pre * 10 + ch);
        backtrack(index + 1, ch);
    }

}
