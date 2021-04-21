package SolutionLib2._460._LFU缓存;

import java.util.HashMap;

class Node {
    public final int key;
    public int val, freq;
    public Node pre, next;

    public Node(int key, int val) {
        this.key = key;
        this.val = val;
        freq = 0;
    }

    public void remove() {
        pre.next = next;
        next.pre = pre;
    }

    public void insertNext(Node oPre) {
        Node oNext = oPre.next;
        oPre.next = this;
        this.next = oNext;
        this.pre = oPre;
        next.pre = this;
    }
}

class FreqNode {
    public final int freq;
    public FreqNode pre, next;
    public Node head, tail;

    public FreqNode(int freq) {
        this.freq = freq;
        head = new Node(-1, -1);
        tail = new Node(-1, -1);
        head.next = tail;
        tail.pre = head;
    }

    public boolean isEmpty() {
        return head.next.key == -1;
    }

    public void remove() {
        pre.next = next;
        next.pre = pre;
    }

    public void insertNext(FreqNode oPre) {
        FreqNode oNext = oPre.next;
        oPre.next = this;
        this.next = oNext;
        this.pre = oPre;
        next.pre = this;
    }
}

class LFUCache {
    private final int capacity;
    private FreqNode head, tail;
    private HashMap<Integer, Node> nodes;
    private HashMap<Integer, FreqNode> freqNodes;

    public LFUCache(int capacity) {
        this.capacity = capacity;
        head = new FreqNode(0);
        tail = new FreqNode(0);
        nodes = new HashMap<>();
        freqNodes = new HashMap<>();
        head.next = tail;
        tail.pre = head;
    }

    public int get(int key) {
        if (capacity == 0 || !nodes.containsKey(key)) return -1;
        return addFreq(key);
    }

    public void put(int key, int value) {
        if (capacity == 0) return;
        Node node;
        if (!nodes.containsKey(key)) {
            if (nodes.keySet().size() == capacity) {
                removeLowest();
            }
            node = new Node(key, value);
            nodes.put(key, node);
        } else {
            node = nodes.get(key);
            node.val = value;
        }
        addFreq(key);
    }

    private int addFreq(int key) {
        Node node = nodes.get(key);
        if (node.freq > 0) {
            node.remove();
            if (freqNodes.get(node.freq).isEmpty()) {
                freqNodes.remove(node.freq);
            }
        }
        node.freq++;
        FreqNode freqNode;
        if (!freqNodes.containsKey(node.freq)) {
            freqNode = new FreqNode(node.freq);
            freqNode.insertNext(head);
            freqNodes.put(node.freq, freqNode);
        }
        freqNode = freqNodes.get(node.freq);
        node.insertNext(freqNode.head);
        return node.val;
    }

    private void removeLowest() {
        FreqNode lFreqList = tail.pre;
        Node llNode = lFreqList.tail.pre;
        llNode.remove();
        nodes.remove(llNode.key);
        if (lFreqList.isEmpty()) {
            lFreqList.remove();
            freqNodes.remove(lFreqList.freq);
        }
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.get(key);
 * obj.put(key,value);
 */