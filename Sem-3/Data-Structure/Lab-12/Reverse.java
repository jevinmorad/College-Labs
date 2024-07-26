/* Compile: javac -d out -sourcepath . Lab_10\MyLinkedList.java Lab-12\Reverse.java */
/* Run: java -cp out reverse */

import java.util.Scanner;

public class Reverse{
    public static void main(String[] args) {
        MyLinkedList<Integer> list = new MyLinkedList<>();
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter total number of elements : ");
        int n = sc.nextInt();
        for (int i = 1; i <= n; i++) {
            System.out.print("Enter element "+i+": ");
            list.insertLast(sc.nextInt());
        }
        System.out.println("Before : ");
        list.print();

        list.reverse();

        System.out.println("Before : ");
        list.print();
        sc.close();
    }
}