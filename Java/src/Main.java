
import SolutionLib._90._子集_II.Solution;
import SolutionLib._90._子集_II.Test;

import java.io.BufferedReader;
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
                System.out.println("输入exit退出，其他键继续。");
                str = scanner.readLine().toLowerCase();
            } catch (Exception e) {
                e.printStackTrace();
            }
        } while (!str.equals("exit"));
    }
}