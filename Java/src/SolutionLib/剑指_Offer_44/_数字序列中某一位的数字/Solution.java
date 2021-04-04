package SolutionLib.剑指_Offer_44._数字序列中某一位的数字;

class Solution2 {
    public int findNthDigit(int n) {
        int digit = 1;
        long start = 1, count = 9;
        while (n > count) {
            n -= count;
            digit++;
            start *= 10;
            count = digit * start * 9;
        }
        long num = start + (n - 1) / digit;
        return Long.toString(num).charAt((n - 1) % digit) - '0';
    }
}

class Solution {
    public int findNthDigit(int n) {
        if (n == 0) return 0;
        int digit = 1;
        long start = 1, count = 9;
        while (n - count > 0) {
            n -= count;
            digit++;
            start *= 10;
            count = 9 * digit * start;
        }
        count = start + (n - 1) / digit;
        digit -= (n - 1) % digit;
        while (digit > 1) {
            count /= 10;
            digit--;
        }
        return (int) count % 10;
    }
}