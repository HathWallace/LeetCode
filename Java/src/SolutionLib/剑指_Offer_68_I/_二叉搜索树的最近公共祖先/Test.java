package SolutionLib.剑指_Offer_68_I._二叉搜索树的最近公共祖先;

import UtilLib.TreeNode;

public class Test {
    public static void run() {
        var s = new Solution();
        var root = new TreeNode(6);
        root.left = new TreeNode(2);
        root.right = new TreeNode(8);
        root.left.left = new TreeNode(4);
        System.out.println(s.lowestCommonAncestor(root, root.left, root.left.left).val);
    }
}
