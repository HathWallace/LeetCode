import SolutionLib2._662._二叉树最大宽度.Test;
import UtilLib.ACM_IO;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        var scanner = new BufferedReader(new InputStreamReader(System.in));
        String str = Test.class.getPackage()
                .getName()
                .replace('_', ' ');
        if (str.length() > 13) str = str.substring(13);
        System.out.println(str);

        Scanner in = new Scanner(System.in);
        Test test = new Test(new ACM_IO(in));
        while (in.hasNextLine()) {
            try {
                test.run();
            } catch (Exception ex) {
                System.out.println(ex);
            }
        }
    }

}
