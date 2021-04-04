package SolutionLib.面试题30._包含min函数的栈;

public class Test {
    public static void run() {
        var stk = new MinStack();
        stk.push(-2);
        stk.push(0);
        stk.push(-3);
        System.out.println(stk.min());
        stk.pop();
        System.out.println(stk.top());
        System.out.println(stk.min());
    }
}
