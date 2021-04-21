package SolutionLib2._220._存在重复元素_III;

import java.util.Deque;
import java.util.LinkedList;
import java.util.TreeMap;
import java.util.TreeSet;

class Solution {
    public boolean containsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        int n = nums.length;
        TreeSet<Long> set = new TreeSet<>();
        for (int i = 0; i < n; i++) {
            Long celling = set.ceiling((long) nums[i] - t);
            if (celling != null && celling <= (long) nums[i] + t) {
                return true;
            }
            set.add((long) nums[i]);
            if (i >= k) {
                set.remove((long) nums[i - k]);
            }
        }
        return false;
    }
}

class _Solution {
    public boolean containsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        int n = nums.length;
        Deque<Integer> upDeque = new LinkedList<>();
        Deque<Integer> downDeque = new LinkedList<>();
        for (int i = 0; i < n; i++) {
            while (!upDeque.isEmpty()) {
                int first = upDeque.getFirst(), last = upDeque.getLast();
                if (i - first > k) {
                    upDeque.removeFirst();
                } else {
                    long tmp = (long) nums[first] - nums[i];
                    if (Math.abs(tmp) <= t) return true;
                    if (nums[i] < nums[last]) break;
                    upDeque.removeLast();
                }
            }
            upDeque.addLast(i);

            while (!downDeque.isEmpty()) {
                int first = downDeque.getFirst(), last = downDeque.getLast();
                if (i - first > k) {
                    downDeque.removeFirst();
                } else {
                    long tmp = (long) nums[first] - nums[i];
                    if (Math.abs(tmp) <= t) return true;
                    if (nums[i] > nums[last]) break;
                    downDeque.removeLast();
                }
            }
            downDeque.addLast(i);
        }
        return false;
    }
}
