using System.Collections.Generic;

namespace SolutionLib._94._二叉树的中序遍历
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
        public IList<int> InorderTraversal(TreeNode root)
        {
            var res = new List<int>();
            var stk = new Stack<TreeNode>();
            while (root != null || stk.Count != 0)
            {
                while (root != null)
                {
                    stk.Push(root);
                    root = root.left;
                }
                root = stk.Pop();
                res.Add(root.val);
                root = root.right;
            }
            return res;
        }
    }

    public class _Solution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            var list = new List<int>();
            if (root == null) return list;
            var stack = new Stack<TreeNode>();
            var set = new HashSet<TreeNode>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                if (set.Add(node))
                {
                    if (node.right != null) stack.Push(node.right);
                    stack.Push(node);
                    if (node.left != null) stack.Push(node.left);
                }
                else
                {
                    list.Add(node.val);
                }
            }
            return list;
        }
    }

}