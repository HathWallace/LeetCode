namespace SolutionLib._23._合并K个升序链表
{
    public class Solution_divide
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            return MergeKLists(lists, 0, lists.Length - 1);
        }

        private ListNode MergeKLists(ListNode[] lists, int start, int end)
        {
            if (start > end) return null;
            if (start == end) return lists[start];
            if (start == end + 1) return Merge2Lists(lists[start], lists[end]);
            int mid = (start + end) / 2;
            var l1 = MergeKLists(lists, start, mid);
            var l2 = MergeKLists(lists, mid + 1, end);
            return Merge2Lists(l1, l2);
        }

        private ListNode Merge2Lists(ListNode list1, ListNode list2)
        {
            if (list1 == null || list2 == null)
                return list1 != null ? list1 : list2;
            var head = list1.val < list2.val ? list1 : list2;
            head.next = list1.val < list2.val ?
                Merge2Lists(list1.next, list2) :
                Merge2Lists(list1, list2.next);
            return head;
        }

    }
}