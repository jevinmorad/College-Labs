import java.util.Scanner;

public class CircularLinkedList<T> {
    Node first, last;
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

    public CircularLinkedList() {
        first = last = null; 
    }

    public CircularLinkedList(T data) {
        first = last = new Node(data);
    }

    public void insertFirst(T data) {
        Node newNode = new Node(data);
        if (first==null) {
            first = newNode;
            last = newNode;
            last.next = first;
            return;
        }
        newNode.next = first;
        last.next = newNode;
        first = newNode;
    }

    public void insertLast(T data) {
        Node newNode = new Node(data);
        if (first==null) {
            last.next = newNode;
            first.next = last;
            return;
        }
        last.next = newNode;
        newNode.next = first;
        last = newNode;
    }

    public void remove(T data) {
        if (first==null) {
            System.out.println("List is empty.");
            return;
        }
        if (first.data==data) {
            first = first.next;
            last.next = first;
            size--;
            return;
        }
        Node prevNode = first.next;
        while (prevNode.next!=last && prevNode.next.data!=data) {
            prevNode = prevNode.next;
        }
        if (prevNode==last) {
            System.out.println("Number not found");
            return;
        }
        size--;
        if (prevNode.next==last) {
            last = prevNode;
            prevNode.next = first;
            return;
        }
        prevNode.next = prevNode.next.next;
    }

    public void print() {
        if (first==null) {
            System.out.println("LinkedList is empty.");
            return;
        }
        System.out.print("List : { ");
        Node curNode = first;
        while (curNode!=last) {
            System.out.print(curNode.data+" ");
            curNode = curNode.next;
        }
        System.out.print(last.data + " ");
        System.out.println("}");
    }

    public int size() {
        return size;
    }

    public static void main(String[] args) {
        CircularLinkedList<Integer> list = new CircularLinkedList<>();
        Scanner sc = new Scanner(System.in);
        int data;
        boolean check = true;
        while (check) {
            System.out.println("\n[1] Insert at first\n[2] Insert at last\n[3] Remove\n[4] Print\n[5] Size\n[6] Exit");
            System.out.print("\nEnter your choice : ");
            int choice = sc.nextInt();
            switch (choice) {
                case 1 -> {
                    System.out.print("Enter data : ");
                    data = sc.nextInt();
                    list.insertFirst(data);
                }

                case 2 -> {
                    System.out.print("Enter data : ");
                    data = sc.nextInt();
                    list.insertLast(data);
                }

                case 3 -> {
                    System.out.print("Enter number to remove : ");
                    data = sc.nextInt();
                    list.remove(data);
                }
                
                case 4 -> list.print();

                case 5 -> System.out.println("Size : "+list.size());

                case 6 -> check = false;
            }
        }
        sc.close();
    }
}