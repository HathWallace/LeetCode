using System;
using System.Collections.Generic;

namespace SolutionLib._104._二叉树的最大深度
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
        public int MaxDepth(TreeNode root)
        {
            return GetHeight(root);
        }

        private int GetHeight(TreeNode root)
        {
            if (root == null) return 0;
            return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
        }

    }

    public class Solution2
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            int ans = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                ans++;
                int num = queue.Count;
                for (int i = 0; i < num; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }
            return ans;
        }
    }
}