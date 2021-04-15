package SolutionLib2._1483._树节点的第K个祖先;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

class TreeAncestor_BinaryLifting {
    private List<List<Integer>> dp;

    public TreeAncestor_BinaryLifting(int n, int[] parent) {
        dp = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            dp.add(new ArrayList<>());
            dp.get(i).add(parent[i]);
        }
        for (int j = 1; ; j++) {
            boolean allneg = true;
            for (int i = 0; i < n; i++) {
                List<Integer> pt = dp.get(i);
                int t = pt.get(j - 1) != -1 ? dp.get(pt.get(j - 1)).get(j - 1) : -1;
                pt.add(t);
                if (t != -1) allneg = false;
            }
            if (allneg) break;
        }
    }

    public int getKthAncestor(int node, int k) {
        if (k == 0 || node == -1) return node;
        int pos = ffs(k) - 1;
        List<Integer> pt = dp.get(node);
        return pos < pt.size() ? getKthAncestor(pt.get(pos), k & (k - 1)) : -1;
    }

    private int ffs(int n) {
        if (n == 0) return 0;
        int pos = 1;
        while ((n & 1) == 0) {
            pos++;
            n >>= 1;
        }
        return pos;
    }
}


class TreeAncestor {
    private int n;
    private int[] parent;
    private HashMap<Integer, HashMap<Integer, Integer>> momo;

    public TreeAncestor(int n, int[] parent) {
        this.n = n;
        this.parent = parent;
        momo = new HashMap<>();
    }

    public int getKthAncestor(int node, int k) {
        if (k == n || node == -1) return -1;
        if (k == 0) return node;
        if (!momo.containsKey(node)) {
            momo.put(node, new HashMap<>());
        }
        HashMap map = momo.get(node);
        if (map.containsKey(k)) return (int) map.get(k);
        map.put(k, getKthAncestor(parent[node], k - 1));
        return (int) map.get(k);
    }
}

/**
 * Your TreeAncestor object will be instantiated and called as such:
 * TreeAncestor obj = new TreeAncestor(n, parent);
 * int param_1 = obj.getKthAncestor(node,k);
 */