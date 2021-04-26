package SolutionLib2._1011._在D天内送达包裹的能力;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution();
        io.println(s.shipWithinDays(io.getNums(), io.getNum()));
    }

}
