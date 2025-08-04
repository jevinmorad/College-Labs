#include <stdio.h>

#define MAX 100

int parent[MAX];

typedef struct
{
    int u, v, w;
} Edge;

void sortEdges(Edge edges[], int e)
{
    for (int i = 0; i < e - 1; i++)
    {
        for (int j = 0; j < e - i - 1; j++)
        {
            if (edges[j].w > edges[j + 1].w)
            {
                Edge temp = edges[j];
                edges[j] = edges[j + 1];
                edges[j + 1] = temp;
            }
        }
    }
}

int find(int i)
{
    while (parent[i] != i)
        i = parent[i];
    return i;
}

void unionSet(int a, int b)
{
    parent[a] = b;
}

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

    for (int i = 0; i < n; i++)
        parent[i] = i;

    sortEdges(edges, e);

    Edge result[MAX];
    int cost = 0, j = 0;

    for (int i = 0; i < e; i++)
    {
        int u = edges[i].u;
        int v = edges[i].v;

        int parentU = find(u);
        int parentV = find(v);

        if (parentU != parentV)
        {
            result[j++] = edges[i];
            cost += edges[i].w;
            unionSet(parentU, parentV);
        }
    }

    for (int i = 0; i < j; i++)
        printf("%d -> %d : %d\n", result[i].u, result[i].v, result[i].w);
    printf("Total Cost: %d\n", cost);

    return 0;
}
