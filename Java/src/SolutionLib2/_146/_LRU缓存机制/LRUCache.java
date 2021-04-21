package SolutionLib2._146._LRU缓存机制;

import java.util.HashMap;
import java.util.LinkedHashSet;

class LRUCache {
    HashMap<Integer, Integer> key2Val;
    LinkedHashSet<Integer> keyList;
    int cap;

    public LRUCache(int capacity) {
        key2Val = new HashMap<>();
        keyList = new LinkedHashSet<>();
        cap = capacity;
    }

    public int get(int key) {
        if (!key2Val.containsKey(key)) {
            return -1;
        }
        movetoFirst(key);
        return key2Val.get(key);
    }

    public void put(int key, int value) {
        if (cap == 0) return;
        if (key2Val.containsKey(key)) {
            key2Val.put(key, value);
            movetoFirst(key);
            return;
        }
        if (cap == key2Val.size()) {
            int deletedKey = keyList.iterator().next();
            key2Val.remove(deletedKey);
            keyList.remove(deletedKey);
        }
        key2Val.put(key, value);
        keyList.add(key);
    }

    private void movetoFirst(int key) {
        keyList.remove(key);
        keyList.add(key);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.get(key);
 * obj.put(key,value);
 */