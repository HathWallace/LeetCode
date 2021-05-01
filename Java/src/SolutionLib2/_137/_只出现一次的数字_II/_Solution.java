package SolutionLib2._137._只出现一次的数字_II;

import java.util.HashMap;

class _Solution {
    public int singleNumber(int[] nums) {
        int ans = nums[0];
        HashMap<Integer, Integer> hashMap = new HashMap<>();
        for (int num : nums) {
            hashMap.put(num, hashMap.getOrDefault(num, 0) + 1);
        }
        for (int key : hashMap.keySet()) {
            if (hashMap.get(key) == 1) return key;
        }
        return -1;
    }
}