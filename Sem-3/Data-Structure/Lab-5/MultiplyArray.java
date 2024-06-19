import java.util.Scanner;

public class MultiplyArray {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int a[][] = new int[3][2];        
        int b[][] = new int[2][3];        
        int c[][] = new int[3][3];
        System.out.println("Enter array a");
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 2; j++) {
                System.out.print("a["+i+"]["+j+"] : ");
                a[i][j] = sc.nextInt();
            }
        }
        System.out.println("Enter array b");
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 3; j++) {
                System.out.print("b["+i+"]["+j+"] : ");
                b[i][j] = sc.nextInt();
            }
        }  
        int sum = 0;
        for (int i = 0; i < 3; i++) {
            int k = 0;
            for (int j = 0; j < 2; j++) {
                sum += a[i][j] + b[k][j];
            }
            c[i][k] = sum;
            k++;
        }
        System.out.print("c(a+b) : { ");
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++) {
                c[i][j] = a[i][j] + b[i][j];
                System.out.print(c[i][j]+",");
            }
            System.out.println();
        }
        sc.close();    
    }
}
