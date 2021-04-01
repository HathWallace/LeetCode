package SolutionLib.剑指_Offer_37._序列化二叉树;

import UtilLib.Public;

public class Test {
    public static void run() {
        var codeC = new Codec();
        var root = codeC.deserialize(Public.readStr());
        System.out.println(codeC.serialize(root));
    }
}
