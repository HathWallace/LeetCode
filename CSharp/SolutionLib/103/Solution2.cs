using System.Collections.Generic;

namespace SolutionLib._103
{
    public class Solution2
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null) return res;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool reverse = false;
            while (queue.Count != 0)
            {
                var stalk = new Stack<int>();
                var list = new List<int>();
                int num = queue.Count;
                for (int i = 0; i < num; i++)
                {
                    var node = queue.Dequeue();
                    if (reverse) stalk.Push(node.val);
                    else list.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                if(reverse) while (stalk.Count != 0) list.Add(stalk.Pop());
                reverse = !reverse;
                res.Add(list);
            }
            return res;
        }
    }
}