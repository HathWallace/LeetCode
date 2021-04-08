package SolutionLib._956._最高的广告牌;

class Solution {
    private int NINF = Integer.MIN_VALUE / 3;
    private int[] rods;
    private Integer[][] memo;

    public int tallestBillboard(int[] rods) {
        this.rods = rods;
        memo = new Integer[rods.length][10001];
        return dp(0, 5000);
    }

    private int dp(int i, int s) {
        if (i >= rods.length) return s == 5000 ? 0 : NINF;
        if (memo[i][s] != null) return memo[i][s];
        int ans = dp(i + 1, s);
        ans = Math.max(ans, dp(i + 1, s - rods[i]));
        ans = Math.max(ans, rods[i] + dp(i + 1, s + rods[i]));
        return memo[i][s] = ans;
    }

}

class _Solution {
    public int tallestBillboard(int[] rods) {
        int sum = 0, n = rods.length, ans = 0;
        for (var rod : rods) {
            sum += rod;
        }
        sum /= 2;
        var dp = new int[n][sum + 1];
        dp[0][0] = 1;
        if (rods[0] <= sum) dp[0][rods[0]] = 1;
        for (int i = 1; i < n; i++) {
            for (int j = 0; j <= sum; j++) {
                dp[i][j] = dp[i - 1][j];
                if (j >= rods[i]) {
                    dp[i][j] += dp[i - 1][j - rods[i]];
                }
                if (dp[i][j] > 1) {
                    ans = Math.max(ans, j);
                }
            }
        }
        return ans;
    }
}