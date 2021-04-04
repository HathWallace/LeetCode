package SolutionLib.剑指_Offer_45._把数组排成最小的数;

import java.util.PriorityQueue;

public class Solution {
    public String minNumber(int[] nums) {
        var sb = new StringBuilder();
        var queue = new PriorityQueue<>(this::compare);
        for (var num : nums) {
            queue.offer(num);
        }
        while (!queue.isEmpty()) {
            sb.append(queue.poll());
        }
        return sb.toString();
    }

    private int compare(int a, int b) {
        if (a == 0) return -1;
        if (b == 0) return 1;
        int la = (int) Math.log10(a), lb = (int) Math.log10(b);
        Long joinA = (long) (a * Math.pow(10, lb + 1) + b);
        Long joinB = (long) (b * Math.pow(10, la + 1) + a);
        return joinA.compareTo(joinB);
    }

}
