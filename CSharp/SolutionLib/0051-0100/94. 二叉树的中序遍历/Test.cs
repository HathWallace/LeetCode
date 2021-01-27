namespace SolutionLib._94._二叉树的中序遍历
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            var root=new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            Public.Print(s.InorderTraversal(root));
        }

        /*
         * 测试用例：
         */

    }
}