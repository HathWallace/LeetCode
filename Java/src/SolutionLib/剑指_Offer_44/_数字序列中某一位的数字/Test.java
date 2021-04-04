package SolutionLib.剑指_Offer_44._数字序列中某一位的数字;

import UtilLib.Public;

public class Test {
    public static void run() {
        var s = new Solution();
        var s2 = new Solution2();
        int a = Public.readNum();
        System.out.println(s.findNthDigit(a));
        System.out.println(s2.findNthDigit(a));
    }
}
