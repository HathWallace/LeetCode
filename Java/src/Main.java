import UtilLib.Test;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {
        var scanner = new BufferedReader(new InputStreamReader(System.in));
        String str = Test.class.getPackage()
                .getName()
                .replace('_', ' ');
        if (str.length() > 12) str = str.substring(12);
        System.out.println(str);
        do {
            try {
                Test.run();
            } catch (Exception e) {
                System.out.println(e.getMessage());
                e.printStackTrace();
            } finally {
                System.out.println("输入exit退出，其他键继续。");
                str = scanner.readLine().toLowerCase();
            }
        } while (!str.equals("exit"));
    }
}