package SolutionLib2._367._有效的完全平方数;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution();
        io.println(s.isPerfectSquare(io.getNum()));
    }

}
