import java.util.*;

public class Dfs {
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

        System.out.print("\nEnter starting element: ");
        int startElemet = sc.nextInt();
        ArrayList<Integer> ans = new ArrayList<>();
        HashSet<Integer> visited = new HashSet<>();

        // With Stack
        /* Stack<Integer> st = new Stack<>();
        st.add(startElemet);
        visited.add(startElemet);

        while (!st.isEmpty()) {
            int cur = st.pop();
            ans.add(cur);

            for(int i : map.get(cur)) {
                if(visited.add(i)) {
                    st.add(i);
                }
            }
        } */

        dfs(map, visited, startElemet, ans);

        System.out.println(ans);

        sc.close();
    }

    public static void dfs(HashMap<Integer, ArrayList<Integer>> map, HashSet<Integer> visited, int startElemet, ArrayList<Integer> ans) {
        ans.add(startElemet);
        visited.add(startElemet);
        for(int cur : map.get(startElemet)) {
            if(visited.add(cur)) {
                dfs(map, visited, cur, ans);
            }
        }
    }
}
