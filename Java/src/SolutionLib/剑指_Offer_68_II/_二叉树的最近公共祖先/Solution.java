package SolutionLib.剑指_Offer_68_II._二叉树的最近公共祖先;

import SolutionLib.TreeNode;

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
    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || root == p || root == q) return root;
        var leftFind = lowestCommonAncestor(root.left, p, q);
        var rightFind = lowestCommonAncestor(root.right, p, q);
        if (leftFind != null && rightFind != null) return root;
        return leftFind != null ? leftFind : rightFind;
    }
}