#include <stdio.h>
#include <stdlib.h>

#define MAX 100

typedef struct
{
    int u, v, w;
} Edge;

int main()
{
    int n = 5, e = 7;

    Edge edges[] = {
        {0, 1, 2},
        {0, 3, 6},
        {1, 2, 3},
        {1, 3, 8},
        {1, 4, 5},
        {2, 4, 7},
        {3, 4, 9}};

    int graph[MAX][MAX] = {0};

    for (int i = 0; i < e; i++)
    {
        int u = edges[i].u;
        int v = edges[i].v;
        int w = edges[i].w;
        graph[u][v] = graph[v][u] = w;
    }

    int visited[MAX] = {0};
    int vCount = 0, min, u = 0, v = 0, cost = 0;

    visited[0] = 1;

    while (vCount < n - 1)
    {
        min = __INT_MAX__;
        for (int i = 0; i < n; i++)
        {
            if (visited[i])
            {
                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && graph[i][j] && graph[i][j] < min)
                    {
                        min = graph[i][j];
                        u = i;
                        v = j;
                    }
                }
            }
        }
        visited[v] = 1;
        printf("%d -> %d : %d\n", u, v, graph[u][v]);
        cost += graph[u][v];
        vCount++;
    }
    printf("Total Cost: %d\n", cost);

    return 0;
}