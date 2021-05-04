package SolutionLib2._633._平方数之和;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution();
        io.println(s.judgeSquareSum(io.getNum()));
    }

}
