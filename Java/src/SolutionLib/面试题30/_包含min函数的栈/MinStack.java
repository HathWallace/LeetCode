package SolutionLib.面试题30._包含min函数的栈;

import java.util.*;

class MinStack {
    private Stack<Integer> stk;
    private Stack<Integer> mono;

    /**
     * initialize your data structure here.
     */
    public MinStack() {
        stk = new Stack<>();
        mono = new Stack<>();
    }

    public void push(int x) {
        stk.push(x);
        if (mono.isEmpty() || mono.peek() >= x) mono.push(x);
    }

    public void pop() {
        Integer x = stk.pop();
        if (x.equals(mono.peek())) mono.pop();
    }

    public int top() {
        return stk.peek();
    }

    public int min() {
        return mono.peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.push(x);
 * obj.pop();
 * int param_3 = obj.top();
 * int param_4 = obj.min();
 */
