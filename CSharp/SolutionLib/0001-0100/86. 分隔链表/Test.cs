using System;

namespace SolutionLib._86._分隔链表
{
    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            var head = s.Partition(GetList(), Public.ReadNum());
            PrintList(head);
        }

        private static ListNode GetList()
        {
            var nums = Public.ReadNums();
            if (nums.Length == 0) return null;
            var head = new ListNode(nums[0]);
            var pt = head;
            for (int i = 1; i < nums.Length; i++)
            {
                pt.next = new ListNode(nums[i]);
                pt = pt.next;
            }
            return head;
        }

        private static ListNode _GetList()
        {
            var list = Public.ReadStr().Replace("->", "-").Split('-');
            var head = new ListNode(int.Parse(list[0]));
            var pt = head;
            for (int i = 1; i < list.Length; i++)
            {
                pt.next = new ListNode(int.Parse(list[i]));
                pt = pt.next;
            }
            return head;
        }

        private static void PrintList(ListNode head)
        {
            var pt = head;
            while (pt != null)
            {
                Console.Write(pt.val);
                pt = pt.next;
                if (pt == null) continue;
                Console.Write("->");
            }
            Console.WriteLine();
        }

        /*
         * 测试用例：
         * [1,4,3,2,5,2]
         * [3,1,2]
         */

    }
}