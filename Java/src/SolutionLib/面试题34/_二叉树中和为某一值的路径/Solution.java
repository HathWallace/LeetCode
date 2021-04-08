package SolutionLib.面试题34._二叉树中和为某一值的路径;

import UtilLib.TreeNode;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * int val;
 * TreeNode left;
 * TreeNode right;
 * TreeNode() {}
 * TreeNode(int val) { this.val = val; }
 * TreeNode(int val, TreeNode left, TreeNode right) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */
class Solution {
    private List<List<Integer>> res = new ArrayList<>();
    private int target;

    public List<List<Integer>> pathSum(TreeNode root, int target) {
        if (root == null) return res;
        this.target = target;
        var path = new LinkedList<Integer>();
        path.add(root.val);
        BackTrack(root, root.val, path);
        return res;
    }

    private void BackTrack(TreeNode root, int sum, LinkedList<Integer> path) {
        if (root.left == null && root.right == null) {
            if (sum == target) res.add(new ArrayList<>(path));
            return;
        }
        if (root.left != null) {
            path.add(root.left.val);
            BackTrack(root.left, sum + root.left.val, path);
            path.removeLast();
        }
        if (root.right != null) {
            path.add(root.right.val);
            BackTrack(root.right, sum + root.right.val, path);
            path.removeLast();
        }
    }

}
