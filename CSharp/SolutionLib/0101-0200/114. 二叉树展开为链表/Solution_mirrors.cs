namespace SolutionLib._114._二叉树展开为链表
{
    public class Solution_mirrors
    {
        public void Flatten(TreeNode root)
        {
            while (root != null)
            {
                if (root.left != null)
                {
                    var last = root.left;
                    while (last.right != null)
                        last = last.right;
                    last.right = root.right;
                    root.right = root.left;
                    root.left = null;
                }
                root = root.right;
            }
        }
    }
}