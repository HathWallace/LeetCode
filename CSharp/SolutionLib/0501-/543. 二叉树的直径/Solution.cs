using System;

namespace SolutionLib._543._二叉树的直径
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */
    public class Solution
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {
            int ans = 0;
            GetHeight(root, ref ans);
            return ans;
        }

        private int GetHeight(TreeNode root, ref int ans)
        {
            if (root == null) return 0;
            int leftH = GetHeight(root.left, ref ans);
            int rightH = GetHeight(root.right, ref ans);
            ans = Math.Max(ans, leftH + rightH);
            return Math.Max(leftH, rightH) + 1;
        }

    }
}