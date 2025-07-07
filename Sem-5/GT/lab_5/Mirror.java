
import java.util.LinkedList;
import java.util.Queue;


class Node {

    Node left, right;
    int val;

    Node(int val) {
        this.val = val;
        this.left = null;
        this.right = null;
    }
}

public class Mirror {
    public static void main(String[] args) {
        int[] input = {1, 2, 2, -1, 4, -1, 3};
        Node root = makeTree(input, 0);

        if (root.left != null || root.right != null) {
            System.out.println("Wth loop: "+isMirrorLoop(root));
            System.out.println("With recursion: "+isMirrorRecur(root.left, root.right));
        } else {
            System.out.println("false");
        }
    }

    public static Node makeTree(int[] input, int i) {
        if (i >= input.length || input[i] == -1) {
            return null;
        }

        Node root = new Node(input[i]);
        root.left = makeTree(input, i * 2 + 1);
        root.right = makeTree(input, i * 2 + 2);

        return root;
    }

    public static boolean isMirrorLoop(Node root) {
        Queue<Node> q = new LinkedList<>();
        q.add(root.left);
        q.add(root.right);
        while (q.isEmpty()) {
            Node node1 = q.poll();
            Node node2 = q.poll();

            if (node1 == null && node2 == null) continue;
            
            if (node1 == null || node2 == null || node1.val != node2.val) {
                return false;
            }

            q.add(node1.left);
            q.add(node2.right);

            q.add(node1.right);
            q.add(node2.left);
        }
        return true;
    }

    public static boolean  isMirrorRecur(Node node1, Node node2) {
        if (node1 == null && node2 == null) return true;
        if (node1 == null || node2 ==null || node1.val != node2.val ) return false;
        return  isMirrorRecur(node1.left, node2.right) && isMirrorRecur(node1.right, node2.left);
    }
}
