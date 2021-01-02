using System.Collections.Generic;

namespace SolutionLib.剑指_Offer_07._重建二叉树
{
    public class Solution
    {
        private int[] preorder;

        private int[] inorder;

        private Dictionary<int, int> dict = new Dictionary<int, int>();

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            this.preorder = preorder;
            this.inorder = inorder;
            for (int i = 0; i < inorder.Length; i++)
                dict[inorder[i]] = i;
            return BuildTree(0, preorder.Length - 1, 0, inorder.Length - 1);
        }

        private TreeNode BuildTree(int pBeg, int pEnd, int ibeg, int iEnd)
        {
            if (pBeg > pEnd) return null;
            var root = new TreeNode(preorder[pBeg]);
            int rooti = dict[preorder[pBeg]], leftEnd = pBeg + rooti - ibeg;
            root.left = BuildTree(pBeg + 1, leftEnd, ibeg, rooti - 1);
            root.right = BuildTree(leftEnd + 1, pEnd, rooti + 1, iEnd);
            return root;
        }

    }

    public class _Solution
    {
        private int[] preorder;

        private int[] inorder;

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            this.preorder = preorder;
            this.inorder = inorder;
            return BuildTree(0, preorder.Length - 1, 0, inorder.Length - 1);
        }

        private TreeNode BuildTree(int pBeg, int pEnd, int ibeg, int iEnd)
        {
            if (pBeg > pEnd) return null;
            var root = new TreeNode(preorder[pBeg]);
            int rooti = ibeg;
            while (inorder[rooti] != root.val)
                rooti++;
            int leftEnd = pBeg + rooti - ibeg;
            root.left = BuildTree(pBeg + 1, leftEnd, ibeg, rooti - 1);
            root.right = BuildTree(leftEnd + 1, pEnd, rooti + 1, iEnd);
            return root;
        }

    }
}