import java.util.PriorityQueue;
import java.util.Scanner;
import java.util.stream.Gatherer.Integrator;

public class RadixSort {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int arr[] = new int[5];
        System.out.println("Enter five elements");
        for (int i = 0; i < 5; i++) {
            System.out.print("arr[" + i + "] : ");
            arr[i] = sc.nextInt();
        }
        System.out.print("Unsorted : ");
        for (int i = 0; i < arr.length; i++) {
            System.out.print(arr[i] + " ");
        }

        int len = getMaxLength(arr);
        RadixSort.radixSort(arr,len,arr.length,1);


        System.out.print("\nSorted : ");
        for (int i = 0; i < arr.length; i++) {
            System.out.print(arr[i] + " ");
        }
        sc.close();
    }

    public static void radixSort(int[] arr,int len,int n,int divide) {
        while (len/divide>0) {
            PriorityQueue<Integer>[] pque = new PriorityQueue[10];
            for (int i = 0; i < arr.length; i++) {
                
            }
        }
    }

    public static int getMaxLength(int[] arr) {
        int max=0;
        for (int i = 0; i < arr.length; i++) {
            int count = 0;
            for (int j = 0; j < arr.length; j++) {
                count++;
            }
            if (max<count) {
                max=count;
            }
        }
        return max;
    }
}
