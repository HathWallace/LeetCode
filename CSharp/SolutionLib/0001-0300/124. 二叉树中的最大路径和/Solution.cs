using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionLib._124._二叉树中的最大路径和
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution
    {
        public int MaxPathSum(TreeNode root)
        {
            int ans = int.MinValue;
            Devide(root, ref ans);
            return ans;
        }

        private int Devide(TreeNode root, ref int ans)
        {
            if (root == null) return 0;
            int left = Math.Max(Devide(root.left, ref ans), 0);
            int right = Math.Max(Devide(root.right, ref ans), 0);
            ans = Math.Max(ans, left + root.val + right);
            return root.val + Math.Max(left, right);
        }

    }
}