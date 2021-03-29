package SolutionLib;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Public {
    public static int[] readNums() {
        System.out.println("输入一组数，以回车结尾：");
        //return GetNums(readLine());
        return null;
    }

    private static String readLine() {
        try {
            return new BufferedReader(new InputStreamReader(System.in)).readLine();
        } catch (IOException e) {
        }
        return "";
    }

}
