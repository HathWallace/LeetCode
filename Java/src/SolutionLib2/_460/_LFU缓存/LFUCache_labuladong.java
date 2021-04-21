package SolutionLib2._460._LFU缓存;

import java.util.HashMap;
import java.util.LinkedHashSet;

class LFUCache_labuladong {
    HashMap<Integer, Integer> key2Val, key2Freq;
    HashMap<Integer, LinkedHashSet<Integer>> freq2Keys;
    int minFreq, cap;

    public LFUCache_labuladong(int capacity) {
        key2Val = new HashMap<>();
        key2Freq = new HashMap<>();
        freq2Keys = new HashMap<>();
        minFreq = 0;
        cap = capacity;
    }

    public int get(int key) {
        if (!key2Val.containsKey(key)) return -1;
        increaseFreq(key);
        return key2Val.get(key);
    }

    public void put(int key, int value) {
        if (cap == 0) return;
        if (key2Val.containsKey(key)) {
            key2Val.put(key, value);
            increaseFreq(key);
            return;
        }
        if (cap == key2Val.size()) {
            removeMinFreqKey();
        }
        key2Val.put(key, value);
        key2Freq.put(key, 1);
        freq2Keys.putIfAbsent(1, new LinkedHashSet<>());
        freq2Keys.get(1).add(key);
        minFreq = 1;
    }

    private void increaseFreq(int key) {
        int freq = key2Freq.get(key);
        LinkedHashSet<Integer> keyList = freq2Keys.get(freq);
        key2Freq.put(key, freq + 1);
        keyList.remove(key);
        if (keyList.isEmpty()) {
            freq2Keys.remove(freq);
            if (minFreq == freq) minFreq++;
        }
        freq2Keys.putIfAbsent(freq + 1, new LinkedHashSet<>());
        freq2Keys.get(freq + 1).add(key);
    }

    private void removeMinFreqKey() {
        LinkedHashSet<Integer> keyList = freq2Keys.get(minFreq);
        int deletedKey = keyList.iterator().next();
        keyList.remove(deletedKey);
        if (keyList.isEmpty()) {
            freq2Keys.remove(minFreq);
        }
        key2Val.remove(deletedKey);
        key2Freq.remove(deletedKey);
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.get(key);
 * obj.put(key,value);
 */
