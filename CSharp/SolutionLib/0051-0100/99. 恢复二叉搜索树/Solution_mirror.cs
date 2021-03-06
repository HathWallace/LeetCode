﻿namespace SolutionLib._99._恢复二叉搜索树
{
    public class Solution_mirror
    {
        public void RecoverTree(TreeNode root)
        {
            TreeNode x = null, y = null, pred = null, predecessor = null;
            while (root != null)
            {
                if (root.left != null)
                {
                    predecessor = root.left;
                    while (predecessor.right!=null&&predecessor.right!=root)
                        predecessor = predecessor.right;
                    if (predecessor.right == null)
                    {
                        predecessor.right = root;
                        root = root.left;
                    }
                    else
                    {
                        if (pred != null && root.val < pred.val)
                        {
                            y = root;
                            if (x == null)
                                x = pred;
                        }
                        pred = root;
                        predecessor.right = null;
                        root = root.right;
                    }
                }
                else
                {
                    if (pred != null && root.val < pred.val)
                    {
                        y = root;
                        if (x == null)
                            x = pred;
                    }
                    pred = root;
                    root = root.right;
                }
            }

            int tmp = x.val;
            x.val = y.val;
            y.val = tmp;
        }
    }
}