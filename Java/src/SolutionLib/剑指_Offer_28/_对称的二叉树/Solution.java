package SolutionLib.剑指_Offer_28._对称的二叉树;

import UtilLib.TreeNode;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * int val;
 * TreeNode left;
 * TreeNode right;
 * TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public boolean isSymmetric(TreeNode root) {
        if (root == null) return true;
        return isSymmetric(root.left, root.right);
    }

    private boolean isSymmetric(TreeNode left, TreeNode right) {
        if (left == null || right == null) return left == right;
        return left.val == right.val &&
                isSymmetric(left.left, right.right) &&
                isSymmetric(left.right, right.left);
    }

}