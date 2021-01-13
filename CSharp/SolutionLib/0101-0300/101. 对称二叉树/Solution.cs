using System.Collections.Generic;

namespace SolutionLib._101._对称二叉树
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
    public class Solution2
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;
            if (root.left == null || root.right == null)
                return root.left == root.right;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);
            while (queue.Count != 0)
            {
                int n = queue.Count;
                for (int i = 0; i < n / 2; i++)
                {
                    var left = queue.Dequeue();
                    var right = queue.Dequeue();
                    if (left == null || right == null || left.val != right.val)
                        return false;
                    if (left.left != null || right.right != null)
                    {
                        queue.Enqueue(left.left);
                        queue.Enqueue(right.right);
                    }
                    if (left.right != null || right.left != null)
                    {
                        queue.Enqueue(left.right);
                        queue.Enqueue(right.left);
                    }
                }
            }
            return true;
        }
    }

    public class Solution
    {
        public bool IsSymmetric(TreeNode root)
        {
            return root == null || IsSymmetric(root.left, root.right);
        }

        public bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
                return left == right;
            return left.val == right.val &&
                   IsSymmetric(left.left, right.right) &&
                   IsSymmetric(left.right, right.left);
        }

    }

}