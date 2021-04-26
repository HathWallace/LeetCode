package SolutionLib2._363._矩形区域不超过K的最大数值和;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution_tree_set();
        io.println(s.maxSumSubmatrix(io.getMaxtrix(), io.getNum()));
    }

}
