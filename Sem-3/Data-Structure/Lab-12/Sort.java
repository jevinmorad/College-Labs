
class MyLinkedList<T> {

    Node head;
    int size = 0;

    class Node {

        T val;
        Node next;

        public Node(T val) {
            this.val = val;
            this.next = null;
            size++;
        }
    }

    public MyLinkedList() {
        head = null;
    }

    public MyLinkedList(T val) {
        head = new Node(val);
    }

    public boolean isEmpty() {
        return head == null;
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

    public void print() {
        Node curNode = head;
        System.out.print("{ ");
        while (curNode != null) {
            System.out.print(curNode.val + " ");
            curNode = curNode.next;
        }
        System.out.println("}");
    }
}
public class Sort {
    public static void main(String[] args) {
        
    }
}
