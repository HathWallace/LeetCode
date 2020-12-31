using System.Collections.Generic;

namespace SolutionLib._103._二叉树的锯齿形层序遍历
{
    public class Solution
    {
        List<IList<int>> list;

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            list = new List<IList<int>>();

            AddList(root, 1);

            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0) continue;
                Reverse(list[i]);
            }

            return list;
        }

        private void AddList(TreeNode root, int level)
        {
            if (root == null) return;
            if (list.Count < level) list.Add(new List<int>());
            list[level - 1].Add(root.val);
            AddList(root.left, level + 1);
            AddList(root.right, level + 1);
        }

        private void Reverse(IList<int> list)
        {
            for (int i = 0; i < list.Count / 2; i++)
            {
                int tmp = list[i];
                list[i] = list[list.Count - 1 - i];
                list[list.Count - 1 - i] = tmp;
            }
        }

    }
}