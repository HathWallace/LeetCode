package SolutionLib2._137._只出现一次的数字_II;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution();
        io.println(s.singleNumber(io.getNums()));
    }

}
