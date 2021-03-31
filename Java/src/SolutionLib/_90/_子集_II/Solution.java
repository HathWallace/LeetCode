package SolutionLib._90._子集_II;

import java.util.*;

public class Solution {
    private List<List<Integer>> res;
    private HashSet<String> visited = new HashSet();
    private int[] nums;

    public List<List<Integer>> subsetsWithDup(int[] nums) {
        res = new ArrayList<>();
        Arrays.sort(nums);
        this.nums = nums;
        BackTrack(0, new ArrayList<>());
        return res;
    }

    private void BackTrack(int start, List<Integer> tmp) {
        if (start == nums.length) {
            var sb = new StringBuilder();
            for (var num : tmp) {
                sb.append(num.toString() + ",");
            }
            if (!visited.add(sb.toString())) return;
            res.add(new ArrayList<>(tmp));
        }
        for (int i = start; i < nums.length; i++) {
            BackTrack(i + 1, tmp);
            tmp.add(nums[i]);
            BackTrack(i + 1, tmp);
            tmp.remove(tmp.size() - 1);
        }
    }

}