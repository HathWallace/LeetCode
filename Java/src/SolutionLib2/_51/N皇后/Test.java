package SolutionLib2._51.N皇后;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution();
        var output = s.solveNQueens(io.getNum());
        if (output.size() == 0) {
            io.println();
            return;
        }
        for (var caseOf : output) {
            for (var line : caseOf) {
                io.println(line);
            }
            io.println();
        }
    }

}
