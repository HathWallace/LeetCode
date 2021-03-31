package SolutionLib.剑指_Offer_31._栈的压入_弹出序列;

import java.util.ArrayList;
import java.util.Stack;

public class Solution {
    public boolean validateStackSequences(int[] pushed, int[] popped) {
        int n = pushed.length;
        if (n == 0) return true;
        var stk = new Stack<Integer>();
        int i1 = 0, i2 = 0;
        while (i1 < n && i2 < n) {
            stk.push(pushed[i1++]);
            while (!stk.isEmpty() && stk.peek() == popped[i2]) {
                stk.pop();
                i2++;
            }
        }
        return i1 == n && i2 == n;
    }
}
