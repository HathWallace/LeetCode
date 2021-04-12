package UtilLib;

import java.util.Scanner;

public class ACM_IO {
    private Scanner in;

    public ACM_IO(Scanner in) {
        this.in = in;
    }

    public int getNum() {
        String line = readLine();
        return readInt(line);
    }

    public String getStr() {
        return readLine();
    }

    public void println(String str) {
        System.out.println(str);
    }

    private String readLine() {
        return in.nextLine();
    }

    private int readInt(String line) {
        return Integer.parseInt(line);
    }

}
