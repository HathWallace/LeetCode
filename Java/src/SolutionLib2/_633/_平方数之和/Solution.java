package SolutionLib2._633._平方数之和;

class Solution {
    public boolean judgeSquareSum(int c) {
        if (c == 0) return true;
        for (long i = 0; i * i < c; i++) {
            long bb = c - i * i, b = (int) Math.sqrt(bb);
            if (bb == b * b) return true;
        }
        return false;
    }
}