package SolutionLib.剑指_Offer_38._字符串的排列;

import UtilLib.Public;

public class Test {
    public static void run() {
        var s = new Solution();
        var res = s.permutation(Public.readStr());
        for (var str : res) {
            System.out.println(str);
        }
    }
}
