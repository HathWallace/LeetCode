using System.Collections.Generic;

namespace SolutionLib._23._合并K个升序链表
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution_divide();
            var list = new List<ListNode>();
            var lists = Public.ReadMatrix();
            foreach (var data in lists)
            {
                list.Add(Public.ReadList(data));
            }
            Public.Print(s.MergeKLists(list.ToArray()), true);
        }

        /*
         * 测试用例：
         */

    }
}