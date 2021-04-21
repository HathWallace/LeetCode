package SolutionLib2._5._最长回文子串;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution();
        io.println(s.longestPalindrome(io.getStr()));
    }

}
