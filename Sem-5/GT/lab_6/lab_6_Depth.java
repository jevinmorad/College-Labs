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

public class lab_6_Depth {
    public static void main(String[] args) {
        int[] input = {10, 5, 15, 2, 7, -1, 20, -1, -1, 6, -1, 17, -1, -1, -1, -1, 8, -1, 25};
        Node root = makeTree(input);
        System.out.println("Depth with iterative: "+findDepthIterative(root));
        System.out.println("Depth with recursive: "+findDepthRecursion(root));
    }

    public static int findDepthIterative(Node root) {
        if (root == null) {
            return 0;
        }
        Queue<Node> q = new LinkedList<>();
        int count = 0;
        q.offer(root);
        while (!q.isEmpty()) {
            int levelSize = q.size();
            
            for (int i = 0; i < levelSize; i++) {
                Node curNode = q.poll();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                if (curNode.left != null) {
                    q.offer(curNode.left);
                }
                if (curNode.right != null) {
                    q.offer(curNode.right);
                }
            }
            count++;
        }

        return count;
    }

    public static int findDepthRecursion(Node root) {
        if (root == null) {
            return 0;
        }

        return 1+Math.max(findDepthRecursion(root.left), findDepthRecursion(root.right));
    }

    public static Node makeTree(int[] input) {
        if (input.length == 0 || input[0] == -1) return null;

        Node root = new Node(input[0]);
        Queue<Node> queue = new LinkedList<>();
        queue.offer(root);

        int i = 1;
        while (!queue.isEmpty() && i < input.length) {
            Node current = queue.poll();

            if (i < input.length) {
                if (input[i] != -1) {
                    current.left = new Node(input[i]);
                    queue.offer(current.left);
                }
                i++;
            }

            if (i < input.length) {
                if (input[i] != -1) {
                    current.right = new Node(input[i]);
                    queue.offer(current.right);
                }
                i++;
            }
        }

        return root;
    }
}