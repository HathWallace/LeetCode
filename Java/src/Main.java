import UtilLib.ACM_IO;
import SolutionLib2._25._K个一组翻转链表.Test;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) throws IOException {
        var scanner = new BufferedReader(new InputStreamReader(System.in));
        String str = Test.class.getPackage()
                .getName()
                .replace('_', ' ');
        if (str.length() > 13) str = str.substring(13);
        System.out.println(str);

        Scanner in = new Scanner(System.in);
        Test test = new Test(new ACM_IO(in));
        while (in.hasNextLine()) {
            test.run();
        }

    }

}
