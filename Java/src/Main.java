import SolutionLib.ListNode;
import SolutionLib._83._删除排序链表中的重复元素.Solution;

public class Main {
    public static void main(String[] args) {
        var nums = new int[]{1, 2, 3, 3, 4, 4, 5};
        ListNode head = new ListNode(), pt = head;
        for (var num : nums) {
            pt.next = new ListNode(num);
            pt = pt.next;
        }
        head = (new Solution()).deleteDuplicates(head.next);
        pt = head;
        while (pt != null) {
            System.out.print(pt.val + " ");
            pt = pt.next;
        }
    }
}