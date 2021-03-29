import SolutionLib.剑指_Offer_24._反转链表.Solution;
import SolutionLib.剑指_Offer_24._反转链表.Test;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) {
        var scanner = new BufferedReader(new InputStreamReader(System.in));
        String str = Solution.class.getPackage()
                .getName()
                .substring(12)
                .replace('_', ' ');
        System.out.println(str);
        do {
            try {
                Test.run();
                System.out.println("输入exit继续，其他键继续。");
                str = scanner.readLine();
            } catch (Exception e) {
                e.printStackTrace();
            }
        } while (!str.equals("exit"));
    }
}