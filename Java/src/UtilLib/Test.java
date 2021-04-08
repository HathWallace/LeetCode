package UtilLib;

import java.util.ArrayList;
import java.util.Deque;
import java.util.LinkedList;
import java.util.List;

public class Test {
    public static void run() {
        Deque<Integer> deque = new LinkedList<>();
        deque.addLast(9);
        deque.addLast(8);
        System.out.println(deque.removeFirst());
        System.out.println(deque.removeFirst());
    }
}
