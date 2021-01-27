namespace SolutionLib._114._二叉树展开为链表
{
    public class Test
    {
        public static void Run()
        {
            var root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var s = new Solution();
            s.Flatten(root);
        }

        /*
         * 测试用例：
         */

    }
}