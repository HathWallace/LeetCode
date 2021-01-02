using System.Collections.Generic;

namespace SolutionLib.剑指_Offer_07._重建二叉树
{
    public class Solution_stack
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0) return null;
            var root = new TreeNode(preorder[0]);
            var stack = new Stack<TreeNode>();
            int inorderIndex = 0;
            stack.Push(root);
            for (int i = 1; i < preorder.Length; i++)
            {
                var node = stack.Peek();
                if (node.val != inorder[inorderIndex])
                    stack.Push(node.left = new TreeNode(preorder[i]));
                else
                {
                    while (stack.Count != 0 && stack.Peek().val == inorder[inorderIndex])
                    {
                        node = stack.Pop();
                        inorderIndex++;
                    }
                    stack.Push(node.right = new TreeNode(preorder[i]));
                }
            }
            return root;
        }
    }
}