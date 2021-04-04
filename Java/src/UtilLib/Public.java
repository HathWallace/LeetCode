package UtilLib;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Public {
    private static BufferedReader scanner = new BufferedReader(new InputStreamReader(System.in));

    public static String readStr() {
        System.out.println("输入一行字符串，以回车结尾：");
        String str = readLine();
        if (str.charAt(0) == '"') str = str.substring(1, str.length() - 1);
        return str;
    }

    public static int readNum() {
        System.out.println("输入一个数，以回车结尾：");
        return Integer.parseInt(readLine());
    }

    public static int[] readNums() {
        System.out.println("输入一组数，以回车结尾：");
        return getNums(readLine());
    }

    private static String readLine() {
        try {
            return scanner.readLine();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return "";
    }

    private static int[] getNums(String str) {
        String readLine = str;
        if (readLine.charAt(0) == '[')
            readLine = readLine.substring(1, readLine.length() - 1);
        var split = readLine.split(",");
        var res = new int[split.length];
        for (int i = 0; i < split.length; i++) {
            res[i] = Integer.parseInt(split[i]);
        }
        return res;
    }

}
