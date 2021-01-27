using System;

namespace SolutionLib._142._环形链表_II
{
    public class Test
    {
        public static void Run()
        {
            var head = GetList(Public.ReadNums(), Public.ReadNum());
            var s = new Solution_doublept();
            Console.WriteLine(s.DetectCycle(head)?.val);
            Console.WriteLine("END");
        }

        private static ListNode GetList(int[] nums, int pos)
        {
            if (nums.Length == 0) return null;
            int index = 0;
            var head = new ListNode(nums[0]);
            var pt = head;
            var position = pos == 0 ? head : null;
            for (int i = 1; i < nums.Length; i++)
            {
                pt.next = new ListNode(nums[i]);
                pt = pt.next;
                if (i == pos) position = pt;
            }
            pt.next = position;
            return head;
        }

        /*
         * 测试用例：
         */

    }
}