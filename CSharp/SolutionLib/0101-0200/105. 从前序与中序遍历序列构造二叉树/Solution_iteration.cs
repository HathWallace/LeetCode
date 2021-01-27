using System.Collections.Generic;

namespace SolutionLib._105._从前序与中序遍历序列构造二叉树
{
    public class Solution_iteration
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length <= 0) return null;
            var stack = new Stack<TreeNode>();
            var root = new TreeNode(preorder[0]);
            int inorederIndex = 0;
            stack.Push(root);
            for (int i = 1; i < preorder.Length; i++)
            {
                var node = stack.Peek();
                int preorederVal = preorder[i];
                if (node.val != inorder[inorederIndex])
                {
                    node.left = new TreeNode(preorederVal);
                    stack.Push(node.left);
                }
                else
                {
                    while (stack.Count != 0 && stack.Peek().val == inorder[inorederIndex])
                    {
                        node = stack.Pop();
                        inorederIndex++;
                    }
                    node.right = new TreeNode(preorederVal);
                    stack.Push(node.right);
                }
            }
            return root;
        }
    }
}