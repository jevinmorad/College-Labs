
import java.util.Scanner;

public class MyLikedList<T> {

    Node head = null;

    public class Node {

        T data;
        Node next;

        public Node(T data) {
            this.data = data;
            this.next = null;
        }
    }

    public void insertFirst(T data) {
        Node newNode = new Node(data);
        if (head == null) {
            head = newNode;
            return;
        }
        newNode.next = head;
        head = newNode;
    }

    public void insertLast(T data) {
        Node newNode = new Node(data);
        if (head == null) {
            head = newNode;
            return;
        }
        Node curNode = head;
        while (curNode.next != null) {
            curNode = curNode.next;
        }
        curNode.next = newNode;
    }

    public void print() {
        Node curNode = head;
        System.out.print("list : [ ");
        while (curNode != null) {
            System.out.print(curNode.data+" ");
            curNode = curNode.next;
        }
        System.out.println("]");
    }

    public boolean isEmpty() {
        return head==null;
    }
    public static void main(String[] args) {
        MyLikedList<Integer> list = new MyLikedList<>();
        Scanner sc = new Scanner(System.in);
        int data;
        boolean check = true;
        while (check) {
            System.out.println("\n[1] Insert at first\n[2] Insert at last\n[3] Print");
            System.out.print("\nEnter your choice : ");
            int choice = sc.nextInt();
            switch (choice) {
                case 1:
                    System.out.print("Enter data : ");
                    data = sc.nextInt();
                    list.insertFirst(data);
                    break;

                case 2:
                    System.out.print("Enter data : ");
                    data = sc.nextInt();
                    list.insertLast(data);
                    break;

                case 3:
                    list.print();
                    break;

                case 4:
                    check = false;
                    break;
            }
        }
        sc.close();
    }
}
