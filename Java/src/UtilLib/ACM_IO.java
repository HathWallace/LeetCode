package UtilLib;

import java.util.*;

public class ACM_IO {
    private final Scanner in;

    public ACM_IO(Scanner in) {
        this.in = in;
    }

    public int getNum() {
        return readInt(readLine());
    }

    public int[] getNums() {
        return readInts(readLine());
    }

    public String getStr() {
        return readLine();
    }

    public void println(int val) {
        System.out.println(val);
    }

    public void println(int[] nums) {
        var sj = new StringJoiner(",", "[", "]");
        for (int i = 0; i < nums.length; i++) {
            sj.add(String.valueOf(nums[i]));
        }
        System.out.println(sj.toString());
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

    private int[] readInts(String line) {
        List<Integer> res = new ArrayList<>();
        line = line.substring(1, line.length() - 1);
        for (var num : line.split(",")) {
            res.add(readInt(num));
        }
        int n = res.size();
        var input = new int[n];
        for (int i = 0; i < n; i++) {
            input[i] = res.get(i);
        }
        return input;
    }
}
