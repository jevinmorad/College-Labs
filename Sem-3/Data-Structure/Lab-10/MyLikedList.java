
import java.util.Scanner;

public class MyLikedList<T> {

    Node head = null;
    int size=0;

    class Node {

        T data;
        Node next;

        public Node(T data) {
            this.data = data;
            this.next = null;
            size++;
        }
    }

    public void insertFirst(T data) {
        Node newNode = new Node(data);
        if (isEmpty()) {
            head = newNode;
            return;
        }
        newNode.next = head;
        head = newNode;
    }

    public void insertLast(T data) {
        Node newNode = new Node(data);
        if (isEmpty()) {
            head = newNode;
            return;
        }
        Node curNode = head;
        while (curNode.next != null) {
            curNode = curNode.next;
        }
        curNode.next = newNode;
    }

    public void remove(T data) {
        if (isEmpty()) {
            System.out.println("LinekdList is empty");
            return;
        }
        if (head.data==data) {
            head = head.next;
            size--;
            return;
        }
        Node prevNode = head;
        while (prevNode.next!=null && prevNode.next.data!=data) {
            prevNode = prevNode.next;
        }
        if (prevNode.next==null) {
            System.out.println("Number not found");
            return;
        }
        prevNode.next = prevNode.next.next;
        size--;
        System.out.println("Number deleted");
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

    public int size() {
        return size;
    }

    public void reverse() {
        if (isEmpty()) {
            System.out.println("List is null");
            return;
        }
        Node prevNode = null;
        Node curNode = head;
        while (curNode!=null) {
            Node nxtNode = curNode.next;
            curNode.next = prevNode;
            prevNode = curNode;
            curNode = nxtNode;
        }
        head = prevNode;
        System.out.println("List reversed");
    }

    public static void main(String[] args) {
        MyLikedList<Integer> list = new MyLikedList<>();
        Scanner sc = new Scanner(System.in);
        int data;
        boolean check = true;
        while (check) {
            System.out.println("\n[1] Insert at first\n[2] Insert at last\n[3] Remove\n[4] Reverse\n[5] Print\n[6] Size\n[7] Exit");
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
                    System.out.print("Enter number to remove : ");
                    data = sc.nextInt();
                    list.remove(data);
                    break;

                case 4:
                    list.reverse();
                    break;

                case 5:
                    list.print();
                    break;

                case 6:
                    System.out.println("Size : "+list.size());
                    break;

                case 7:
                    check = false;
                    break;
            }
        }
        sc.close();
    }
}
