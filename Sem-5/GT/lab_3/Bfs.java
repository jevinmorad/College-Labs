import java.util.*;

class Bfs {
    public static void main(String[] args) {
        System.out.print("Enter length of array : ");
        Scanner sc = new Scanner(System.in);
        int k = sc.nextInt();
        HashMap<Integer, ArrayList<Integer>> map = new HashMap<>();

        for(int i=0; i<k; i++) {
            System.out.print("Enter node element: ");
            int key = sc.nextInt();
            sc.nextLine(); 
            System.out.print("Enter adjecent elements of "+key+" with space separated: ");
            String adjString = sc.nextLine();

            String[] adjElemArray = adjString.trim().split("\\s+");
            ArrayList<Integer> adjList = new ArrayList<>();
            for(String adjElem : adjElemArray) {
                adjList.add(Integer.valueOf(adjElem));
            }
            map.put(key, adjList);
        }

        Queue<Integer> q = new LinkedList<>();

        System.out.print("\nEnter starting element: ");
        int startElemet = sc.nextInt();
        ArrayList<Integer> ans = new ArrayList<>();
        HashSet<Integer> visited = new HashSet<>();

        q.add(startElemet);
        visited.add(startElemet);

        while (!q.isEmpty()) {
            int cur = q.poll();
            ans.add(cur);

            for(int i : map.get(cur)) {
                if(visited.add(i)) {
                    q.add(i);
                }
            }
        }

        System.out.println(ans);

        sc.close();
    }
}