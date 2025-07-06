package lab_4;

import java.util.*;

public class SocialNetwork {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter number of nodes: ");
        int n = Integer.parseInt(sc.nextLine());

        Map<Integer, List<Integer>> adjList = new HashMap<>();
        for (int i = 0; i < n; i++) {
            System.out.print("Enter node element: ");
            int node = Integer.parseInt(sc.nextLine());
            adjList.putIfAbsent(node, new ArrayList<>());

            System.out.print("Enter adjacent nodes for node " + node + " (space-separated): ");
            String line = sc.nextLine().trim();
            if (!line.isEmpty()) {
                String[] parts = line.split("\\s+");
                for (String part : parts) {
                    int neighbor = Integer.parseInt(part);
                    adjList.get(node).add(neighbor);
                }
            }
        }

        HashSet<Integer> visited = new HashSet<>();
        int count = 0;

        for (int node : adjList.keySet()) {
            if (!visited.contains(node)) {
                dfs(adjList, visited, node);
                count++;
            }
        }

        System.out.println("Number of groups = " + count);

        sc.close();
    }

    static void dfs(Map<Integer, List<Integer>> adjList, HashSet<Integer> visited, int node) {
        visited.add(node);
        for (int neighbor : adjList.get(node)) {
            if (!visited.contains(neighbor)) {
                dfs(adjList, visited, neighbor);
            }
        }
    }
}
