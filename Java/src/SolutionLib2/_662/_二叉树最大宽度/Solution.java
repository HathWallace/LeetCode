package SolutionLib2._662._二叉树最大宽度;

import UtilLib.TreeNode;

import java.util.LinkedList;
import java.util.Queue;

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
    public int widthOfBinaryTree(TreeNode root) {
        int ans = 0;
        Queue<TreeNode> queue = new LinkedList<>();
        Queue<Integer> indexQueue = new LinkedList<>();
        if (root != null) {
            queue.add(root);
            indexQueue.add(1);
        }
        while (!queue.isEmpty()) {
            int count = queue.size(), left = 0, right = 0;
            for (int i = 0; i < count; i++) {
                TreeNode node = queue.poll();
                int index = indexQueue.poll();
                if (left == 0) left = right = index;
                else right = index;
                if (node.left != null) {
                    queue.add(node.left);
                    indexQueue.add(index * 2);
                }
                if (node.right != null) {
                    queue.add(node.right);
                    indexQueue.add(index * 2 + 1);
                }
            }
            ans = Math.max(ans, right - left + 1);
        }
        return ans;
    }
}