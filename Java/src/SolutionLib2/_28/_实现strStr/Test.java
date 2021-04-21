package SolutionLib2._28._实现strStr;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution();
        io.println(s.strStr(io.getStr(), io.getStr()));
    }

}
