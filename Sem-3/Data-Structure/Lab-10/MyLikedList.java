import java.util.Scanner;

public class MyLikedList<T> {

    Node head;
    int size=0;

    class Node {

        T val;
        Node next;

        public Node(T val) {
            this.val = val;
            this.next = null;
            size++;
        }
    }

    public MyLikedList() {
        head = null;
    }

    public MyLikedList(T val) {
        head = new Node(val);
    }

    public boolean isEmpty() {
        return head==null;
    }

    public int size() {
        return size;
    }

    public void insertFirst(T val) {
        Node newNode = new Node(val);
        if (isEmpty()) {
            head = newNode;
            return;
        }
        newNode.next = head;
        head = newNode;
    }

    public void insertLast(T val) {
        Node newNode = new Node(val);
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

    public void remove(T val) {
        if (isEmpty()) {
            System.out.println("LinkedList is empty");
            return;
        }
        if (head.val==val) {
            head = head.next;
            size--;
            return;
        }
        Node prevNode = head;
        while (prevNode.next!=null && prevNode.next.val!=val) {
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
        System.out.print("{ ");
        while (curNode != null) {
            System.out.print(curNode.val+" ");
            curNode = curNode.next;
        }
        System.out.println("}");
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

    public void compareTo(MyLikedList<T> list2) {
        Node current1 = this.head;
        Node current2 = list2.head;

        while (current1 != null && current2 != null) {
            if (current1.val != current2.val) {
                System.out.println("Both Linked List are not same");
                return;
            }
            current1 = current1.next;
            current2 = current2.next;
        }

        if (current1 != null || current2 != null) {
            System.out.println("Both LinkedList are not same");
            return;
        }

        System.out.println("Both LinkedList are same");
    }

    public static void main(String[] args) {
        MyLikedList<Integer> list = new MyLikedList<>();
        Scanner sc = new Scanner(System.in);
        int val;
        boolean check = true;
        while (check) {
            System.out.println("\n[1] Insert at first\n[2] Insert at last\n[3] Remove\n[4] Reverse\n[5] Print\n[6] Size\n[7] Exit");
            System.out.print("\nEnter your choice : ");
            int choice = sc.nextInt();
            switch (choice) {
                case 1 -> {
                    System.out.print("Enter val : ");
                    val = sc.nextInt();
                    list.insertFirst(val);
                }

                case 2 -> {
                    System.out.print("Enter val : ");
                    val = sc.nextInt();
                    list.insertLast(val);
                }

                case 3 -> {
                    System.out.print("Enter number to remove : ");
                    val = sc.nextInt();
                    list.remove(val);
                }

                case 4 -> list.reverse();

                case 5 -> list.print();

                case 6 -> System.out.println("Size : "+list.size());

                case 7 -> check = false;
            }
        }
        sc.close();
    }
}
