package SolutionLib2._91._解码方法;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution2();
        io.println(s.numDecodings(io.getStr()));
    }

}
