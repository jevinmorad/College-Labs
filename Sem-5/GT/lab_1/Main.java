import java.util.*;

public class Main{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        

        boolean isEnd = false;
        while(!isEnd) {
            System.out.println("Enter you array type \n  [1] 1D array\n  [2] 2D array\n  [3] Exit");
            System.out.print("Enter your choice: ");
            int choice = sc.nextInt();

            switch (choice) {
                case 1:
                    System.out.print("\nEnter length of array: ");
                    int n = sc.nextInt();
                    int[] arr = new int[n];
        
                    for(int i=0; i<n; i++) {
                        System.out.print("Enter arr["+i+"]: ");
                        arr[i] = sc.nextInt();
                    }
        
                    System.out.println("\nArray is: "+Arrays.toString(arr));

                    System.out.println("\nWhat you want to do\n  [1] Find min\n  [2] Find max\n  [3] Addition\n [4] Multiplication");
                    System.out.print("Enter your choice: ");
                    int choice2 = sc.nextInt();
                    switch (choice2) {
                        case 1:
                            int max = 0;
                            for(int i=0; i<n; i++) {
                                if(arr[i] > max) {
                                    max = arr[i];
                                }
                            }
                            System.out.println("\nMin element is: "+max);
                            break;

                        case 2:
                            int min = 0;
                            for(int i=0; i<n; i++) {
                                if(arr[i] < min) {
                                    min = arr[i];
                                }
                            }
                            System.out.println("\nMax element is: "+min);
                            break;

                        case 3:
                            System.out.println("\nYou need to enter another array");
                            int[] arr2Add = new int[n];
                
                            for(int i=0; i<n; i++) {
                                System.out.print("Enter arr2["+i+"]: ");
                                arr2Add[i] = sc.nextInt();
                            }

                            System.out.println("\nArray1 is: "+Arrays.toString(arr));
                            System.out.println("\nArray2 is: "+Arrays.toString(arr2Add));
                            
                            int[] addition = new int[n];
                            for(int i=0; i<n; i++) {
                                addition[i] = arr[i] + arr2Add[i];
                            }
                            System.out.println("\nAddition array is: "+Arrays.toString(addition));
                            break;

                        case 4:
                            System.out.println("\nYou need to enter another array");
                            int[] arr2Mul = new int[n];
                
                            for(int i=0; i<n; i++) {
                                System.out.print("Enter arr2["+i+"]: ");
                                arr2Mul[i] = sc.nextInt();
                            }

                            System.out.println("\nArray1 is: "+Arrays.toString(arr));
                            System.out.println("\nArray2 is: "+Arrays.toString(arr2Mul));

                            int[] multiplication = new int[n];
                            for(int i=0; i<n; i++) {
                                multiplication[i] = arr[i] * arr2Mul[i];
                            }

                            System.out.println("\nMultiplication array is: "+Arrays.toString(multiplication));
                    
                        default:
                            System.out.println("Invalid choice");
                            break;
                    }
                    break;

                case 2:
                    System.out.print("\nEnter length1 of array: ");
                    int n1 = sc.nextInt();
                    System.out.print("Enter length2 of array: ");
                    int n2 = sc.nextInt();
                    int[][] arr2D = new int[n1][n2];

                    for(int i=0; i<n1; i++) {
                        for(int j=0; j<n2; j++) {
                            System.out.println("Enter arr["+i+"]["+j+"]: ");
                            arr2D[i][j] = sc.nextInt();
                        }
                    }

                    System.out.println("\nArray is: ");
                    for(int i=0; i<n1; i++) {
                        for(int j=0; j<n2; j++) {
                            System.out.println(arr2D[i][j]+" ");
                        }
                        System.out.println();
                    }

                    System.out.println("\nWhat you want to do\n  [1] Find min\n  [2] Find max\n  [3] Addition\n  [4] Multiplication");
                    System.out.print("Enter your choice: ");
                    int choice3 = sc.nextInt();
                    switch (choice3) {
                        case 1:
                            int max = 0;
                            for(int i=0; i<n1; i++) {
                                for(int j=0; j<n2; j++)
                                if(arr2D[i][j] > max) {
                                    max = arr2D[i][j];
                                }
                            }
                            System.out.println("\nMax element is: "+max);
                            break;

                        case 2:
                            int min = 0;
                            for(int i=0; i<n1; i++) {
                                for(int j=0; j<n2; j++){
                                    if(arr2D[i][j] < min) {
                                        min = arr2D[i][j];
                                    }
                                }
                            }
                            System.out.println("\nMax element is: "+min);
                            break;

                        case 3:
                            boolean isValid = false;
                            while(!isValid) {
                                System.out.println("\nYou need to enter another array");
                                System.out.print("\nEnter length1 of array: ");
                                int n1Add = sc.nextInt();
                                System.out.print("Enter length2 of array: ");
                                int n2Add = sc.nextInt();
                                int[][] arr2DAdd = new int[n1Add][n2Add];

                                if((n1Add == n1 || n1Add == n2) && (n2Add == n1 || n2Add == n2)) {
                                    int[][] addition = new int 
                                }
                                else {
                                    isValid = false;
                                    System.out.println("Invalid array length");
                                }
                            }
                            break;
                    
                        default:
                            System.out.println("Invalid choice");
                            break;
                    }
                    break;

                case 3:
                    isEnd = true;
                    break;
            
                default:
                    System.out.println("Invalid choice");
                    break;
            }
        }
        sc.close();
    }
}