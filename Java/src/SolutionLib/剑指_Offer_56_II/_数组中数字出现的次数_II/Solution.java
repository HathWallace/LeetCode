package SolutionLib.剑指_Offer_56_II._数组中数字出现的次数_II;

import java.util.HashMap;
import java.util.Random;

class Solution {
    public int singleNumber(int[] nums) {
        int ones = 0, twos = 0;
        for(int num : nums){
            ones = (num ^ ones) & ~twos;
            twos = (num ^ twos) & ~ones;
        }
        return ones;
    }
}

class Solution2 {
    public int singleNumber(int[] nums) {
        var hashMap = new HashMap<Integer, Integer>();
        for (var num : nums) {
            hashMap.put(num, hashMap.getOrDefault(num, 0) + 1);
        }
        for (var key : hashMap.keySet()) {
            if (hashMap.get(key) == 1) return key;
        }
        return -1;
    }
}