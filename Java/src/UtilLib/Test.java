package UtilLib;

import java.util.ArrayList;
import java.util.Deque;
import java.util.LinkedList;
import java.util.List;

public class Test {
    public static void run() {
        var root = TreeNode.deserialize(Public.readStr());
        System.out.println(TreeNode.serialize(root));
    }
}
