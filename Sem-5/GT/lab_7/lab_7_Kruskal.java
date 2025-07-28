
import java.util.Arrays;

public class lab_7_Kruskal {

    public static void main(String[] args) {
        int[][] inputEdges = {
            {0, 1, 10},
            {0, 2, 6},
            {0, 3, 5},
            {1, 3, 15},
            {2, 3, 4}
        };
        Arrays.sort(inputEdges, (a, b) -> a[2] - b[2]);
        int totelweight = 0;
        int[] parent = new int[4];
        for (int i = 0; i < 4; i++) {
            parent[i] = i;
        }
        for (int j = 0; j < parent.length; j++) {
            int s = inputEdges[j][0];
            int d = inputEdges[j][1];
            int w = inputEdges[j][2];
            if (find(parent, s) != find(parent, d)) {
                totelweight+=w;
                union(parent, s, d);
            }
        }
        System.out.println("Total weight: "+ totelweight);
    }

    public static int find(int[] parent, int i) {
        if (parent[i] == i) {
            return i;
        }
        return find(parent, parent[i]);
    }

    public static void union(int[] parent, int u, int v) {
        parent[find(parent, u)] = find(parent, v);
    }
}
