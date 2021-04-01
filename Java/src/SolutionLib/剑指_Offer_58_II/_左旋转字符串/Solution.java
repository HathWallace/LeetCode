package SolutionLib.剑指_Offer_58_II._左旋转字符串;

public class Solution {
    public String reverseLeftWords(String s, int n) {
        var sb = new StringBuilder(s.substring(n));
        sb.append(s.substring(0, n));
        return sb.toString();
    }
}