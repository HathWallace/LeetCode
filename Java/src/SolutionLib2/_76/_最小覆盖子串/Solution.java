package SolutionLib2._76._最小覆盖子串;

import java.util.HashMap;

class Solution {
    public String minWindow(String s, String t) {
        int slen = s.length(), tlen = t.length();
        HashMap<Character, Integer> window = new HashMap<>();
        for (int i = 0; i < tlen; i++) {
            char ch = t.charAt(i);
            window.put(ch, window.getOrDefault(ch, 0) + 1);
        }
        int left = 0, right = 0, invalid = window.keySet().size();
        int subLeft = -1, subRight = slen;
        while (right < slen) {
            char rch = s.charAt(right++);
            if (!window.containsKey(rch)) continue;
            window.put(rch, window.get(rch) - 1);
            if (window.get(rch) == 0) invalid--;
            while (invalid == 0) {
                if (right - left < subRight - subLeft) {
                    subLeft = left;
                    subRight = right;
                }
                char lch = s.charAt(left++);
                if (!window.containsKey(lch)) continue;
                if (window.get(lch) == 0) invalid++;
                window.put(lch, window.get(lch) + 1);
            }
        }
        if (subLeft < 0) return "";
        return s.substring(subLeft, subRight);
    }
}
