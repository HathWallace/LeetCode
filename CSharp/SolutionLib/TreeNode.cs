namespace SolutionLib
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x, TreeNode left = null, TreeNode right = null)
        {
            val = x;
            this.left = left;
            this.right = right;
        }
    }
}