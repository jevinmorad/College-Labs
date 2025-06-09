import java.util.*;

class PrintAdjacency {
    public static void main(String[] args) {
        System.out.print("Enter length of array : ");
        Scanner sc = new Scanner(System.in);
        int k = sc.nextInt();
        int[][] edges = new int[k][2];
        for(int i=0; i<k; i++) {
            for(int j=0; j<2; j++) {
                System.out.print("Enter arr["+i+"]"+"["+j+"]: ");
                edges[i][j] = sc.nextInt();
            }
        }
        Map<Integer,  ArrayList<Integer>> map = new HashMap<>();
        for (int[] edge : edges) {
            ArrayList<Integer> list = map.getOrDefault(edge[0], new ArrayList<>());
            list.add(edge[1]);
            map.put(edge[0], list);
        }
        for(Map.Entry<Integer, ArrayList<Integer>> entry : map.entrySet()) {
            int key = entry.getKey();
            ArrayList<Integer> list = map.get(key);
            System.out.print(key+" -> ");
            for(int n : list) {
                System.out.print(n+" ");
            }
            System.out.println();
        }
        sc.close();
    }
}
