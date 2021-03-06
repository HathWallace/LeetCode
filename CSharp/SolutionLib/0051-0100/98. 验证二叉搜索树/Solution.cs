using System.Collections.Generic;

namespace SolutionLib._98._验证二叉搜索树
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
    public class Solution2
    {
        public bool IsValidBST(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            int? pre = null;
            while (root != null || stack.Count != 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                if (pre != null && pre >= root.val)
                    return false;
                pre = root.val;
                root = root.right;
            }
            return true;
        }
    }

    public class Solution
    {
        public bool IsValidBST(TreeNode root)
        {
            int? pre = null;
            return Inorder(root, ref pre);
        }

        private bool Inorder(TreeNode root, ref int? pre)
        {
            if (root == null)
                return true;
            if (!Inorder(root.left, ref pre))
                return false;
            if (pre != null && root.val <= pre)
                return false;
            pre = root.val;
            return Inorder(root.right, ref pre);
        }

    }
}