package SolutionLib.剑指_Offer_68_I._二叉搜索树的最近公共祖先;

import UtilLib.TreeNode;

public class Solution {
    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null) return root;
        Integer rVal = root.val, pVal = p.val, qVal = q.val;
        int cmp1 = rVal.compareTo(pVal), cmp2 = rVal.compareTo(qVal);
        if (cmp1 * cmp2 <= 0) return root;
        return cmp1 > 0 ? lowestCommonAncestor(root.left, p, q) : lowestCommonAncestor(root.right, p, q);
    }
}
