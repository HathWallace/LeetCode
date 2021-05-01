package SolutionLib2._137._只出现一次的数字_II;

class Solution {
    public int singleNumber(int[] nums) {
        int one = 0, two = 0;
        for (int num : nums) {
            one ^= (two & num) ^ num;
            two ^= (one & num) ^ num;
        }
        return one;
    }
}