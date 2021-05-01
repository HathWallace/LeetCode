package SolutionLib2._403._青蛙过河;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Hashtable;

class Solution {
    public boolean canCross(int[] stones) {
        if (stones[1] - stones[0] != 1) return false;
        int n = stones.length;
        HashMap<Integer, HashSet<Integer>> index2K = new HashMap<>();
        for (int stone : stones) {
            index2K.put(stone, new HashSet<>());
        }
        index2K.get(stones[1]).add(1);
        for (int i = 2; i < n; i++) {
            int index = stones[i - 1];
            for (int k : index2K.get(index)) {
                for (int j = Math.max(1, k - 1); j <= k + 1; j++) {
                    int next = index + j;
                    if (!index2K.containsKey(next)) continue;
                    index2K.get(next).add(j);
                }
            }
        }
        return !index2K.get(stones[n - 1]).isEmpty();
    }
}