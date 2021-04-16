package SolutionLib2._87._扰乱字符串;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution_dfs();
        io.println(s.isScramble(io.getStr(), io.getStr()));
    }

}
