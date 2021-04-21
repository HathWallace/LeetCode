package SolutionLib2._220._存在重复元素_III;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution();
        io.println(s.containsNearbyAlmostDuplicate(io.getNums(), io.getNum(), io.getNum()));
    }

}
