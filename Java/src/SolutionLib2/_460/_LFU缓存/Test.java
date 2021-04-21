package SolutionLib2._460._LFU缓存;

import UtilLib.ACM_IO;

public class Test {
    private ACM_IO io;

    public Test(ACM_IO io) {
        this.io = io;
    }

    public void run() {
        io.getStr();
        case1();
        io.println();
        case2();
    }

    private void case1() {
        var lfu = new LFUCache_labuladong(2);
        lfu.put(1, 10);
        lfu.put(2, 20);
        io.println(lfu.get(1));
        lfu.put(3, 30);
        io.println(lfu.get(2));
        io.println(lfu.get(3));
        lfu.put(4, 40);
        io.println(lfu.get(1));
        io.println(lfu.get(3));
        io.println(lfu.get(4));
    }

    private void case2() {
        var lfu = new LFUCache_labuladong(3);
        lfu.put(2, 2);
        lfu.put(1, 1);
        io.println(lfu.get(2));
        io.println(lfu.get(1));
        io.println(lfu.get(2));
        lfu.put(3, 3);
        lfu.put(4, 4);
        io.println(lfu.get(3));
        io.println(lfu.get(2));
        io.println(lfu.get(1));
        io.println(lfu.get(4));
    }

}
