package SolutionLib._1006._笨阶乘;

public class Solution {
    public int clumsy(int N) {
        int a = N / 4, b = N % 4;
        long ans = 0;
        switch (b) {
            case 1:
                ans = 1;
                break;
            case 2:
                ans = 2;
                break;
            case 3:
                ans = 6;
                break;
        }
        if (a == 0) return (int) ans;
        ans = (long) N * 2 - 2 + 2 / (N - 2) - (long) (a - 1) * 4 - ans;
        if (b == 0 && a > 1) ans--;
        return (int) ans;
    }

}