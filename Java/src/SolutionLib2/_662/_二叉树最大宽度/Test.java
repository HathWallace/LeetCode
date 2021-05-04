package SolutionLib2._662._二叉树最大宽度;

import UtilLib.ACM_IO;
import UtilLib.TreeNode;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        var s = new Solution();
        var root = TreeNode.deserialize(io.getStr());
        io.println(s.widthOfBinaryTree(root));
    }

}
