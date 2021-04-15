package SolutionLib2._1483._树节点的第K个祖先;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        io.getStr();
        var ta = new TreeAncestor(7, new int[]{-1, 0, 0, 1, 1, 2, 2});
        io.println(ta.getKthAncestor(3, 2));
        io.println(ta.getKthAncestor(4, 2));
        io.println(ta.getKthAncestor(5, 2));
        io.println(ta.getKthAncestor(6, 3));
    }

}
