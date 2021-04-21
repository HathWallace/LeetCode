package SolutionLib2._5._最长回文子串;

class Solution {
    public String longestPalindrome(String s) {
        int len = s.length();
        if (len == 0) return "";
        StringBuilder sb = new StringBuilder();
        sb.append("?#");
        for (int i = 0; i < len; i++) {
            sb.append(s.charAt(i) + "#");
        }
        sb.append("!");

        int left = 0, right = 0;
        int center = -1, rightMax = -1;
        int[] f = new int[2 * len + 3];
        for (int i = 2; i < 2 * len + 1; i++) {
            int arm = i > rightMax ? 1 : Math.min(rightMax - i + 1, f[2 * center - i]);
            while (sb.charAt(i + arm) == sb.charAt(i - arm))
                arm++;
            f[i] = arm;
            if (i + arm - 1 >= rightMax) {
                rightMax = i + arm - 1;
                center = i;
            }
            if (arm - 1 > right - left) {
                int l = i - arm + 1, r = i + arm - 1;
                left = (l + 1) / 2 - 1;
                right = (r - 1) / 2;
            }
        }

        return s.substring(left, right);
    }
}