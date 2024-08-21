import java.util.Scanner;

class Node {
    int val;
    Node left;
    Node right;
    Node root;

    public Node(int val) {
        this.val = val;
        left = null;
        right = null;
        root = null;
    }
}

class Tree {
    Node left;
    Node right;
    Node root;


    public Node constTree(int[] arr, int i) {
        if (i >= arr.length) {
            return null;
        }
        Node temp = new Node(arr[i]);
        temp.left = constTree(arr, i * 2 + 1);
        temp.right = constTree(arr, i * 2 + 2);

        return temp;
    }

    public void printPreOrder(Node root) {
        if (root==null) {
            return;
        }
        System.out.print(root.val+" ");
        printPreOrder(root.left);
        printPreOrder(root.right);
    }

    public void printInorder(Node root) {
        if (root==null) {
            return;
        }
        printPreOrder(root.left);
        System.out.print(root.val+" ");
        printPreOrder(root.right);
    }

    public void printPostorder(Node root) {
        if (root==null) {
            return;
        }
        printPreOrder(root.left);
        printPreOrder(root.right);
        System.out.print(root.val+" ");
    }
}

public class BinaryTree {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Tree t = new Tree();
        System.out.print("Enter length of array : ");
        int n = sc.nextInt();
        int[] arr = new int[n];
        for (int i = 0; i < n; i++) {
            System.out.print("a["+i+"] : ");
            arr[i] = sc.nextInt();
        }
        Node temp = t.constTree(arr, 0);

        System.out.print("Preorder : ");
        t.printPreOrder(temp);

        System.out.print("\nInorder : ");
        t.printInorder(temp);

        System.out.print("\nPostorder : ");
        t.printPostorder(temp);

        sc.close();
    }
}