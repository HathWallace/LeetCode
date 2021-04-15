import SolutionLib2._1483._树节点的第K个祖先.Test;
import UtilLib.ACM_IO;

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
