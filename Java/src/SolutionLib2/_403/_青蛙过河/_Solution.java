package SolutionLib2._403._青蛙过河;

import java.util.HashMap;
import java.util.HashSet;

class _Solution {
    private HashSet<Integer> stoneSet;
    private HashMap<Integer, HashSet<Integer>> memo;
    private int fin;

    public boolean canCross(int[] stones) {
        stoneSet = new HashSet<>();
        memo = new HashMap<>();
        fin = stones[stones.length - 1];
        for (int stone : stones) {
            stoneSet.add(stone);
        }
        return dfs(1, 1);
    }

    private boolean dfs(int index, int k) {
        if (index == fin) return true;
        if (!stoneSet.contains(index) || k <= 0) return false;
        HashSet<Integer> now = memo.getOrDefault(index, new HashSet<>());
        if (!now.add(k)) return false;
        int next = index + k;
        return dfs(next + 1, k + 1) || dfs(next, k) || dfs(next - 1, k - 1);
    }
}