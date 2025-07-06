#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "searching_algo.h"

const int sizes[] = {100, 1000, 10000, 100000};

void read_input_file(int *array, const char *filename, int count)
{
    FILE *f = fopen(filename, "r");
    if (!f)
    {
        printf("Can't open file: %s\n", filename);
        exit(EXIT_FAILURE);
    }
    for (int i = 0; i < count; i++)
    {
        fscanf(f, "%d", &array[i]);
    }
    fclose(f);
}

double measure_time(int (*search_func)(int *, int, int), int *data, int n, int target, int *found_index)
{
    clock_t start = clock();
    *found_index = search_func(data, target, n);
    clock_t end = clock();
    return (double)(end - start) / CLOCKS_PER_SEC;
}

void display_table(const char *algo_name, int (*search_func)(int *, int, int))
{
    printf("\n------- %s -------\n\n", algo_name);
    for (int i = 0; i < 4; i++)
    {
        int count = sizes[i];
        int *arrays;
        char filename[100];

        sprintf(filename, "./arrays/best_%d.txt", sizes[i]);
        arrays = malloc(count * sizeof(int));
        read_input_file(arrays, filename, count);

        printf("\nInput Size: %-10d\n", count);
        printf("--------------------------------------------------------------------------------------------------------\n");

        printf("        %-30s %-30s %-30s\n", "Best", "Average", "Worst");

        int targets[3], indices[3];
        double times[3];

        targets[0] = 1;
        targets[1] = sizes[i] / 2;
        targets[2] = sizes[i];

        for (int j = 0; j < 3; j++)
        {
            times[j] = measure_time(search_func, arrays, count, targets[j], &indices[j]);
        }

        printf("(target %d found at %d)    (target [%d] found at %d)    (target %d found at %d)\n",
               targets[0], indices[0], targets[1], indices[1], targets[2], indices[2]);

        printf("        %-30.6f %-30.6f %-30.6f\n", times[0], times[1], times[2]);
        printf("--------------------------------------------------------------------------------------------------------\n");

        free(arrays);
    }
}

void print_menu()
{
    printf("\n\nSEARCH ALGORITHM ANALYZER\n");
    printf("0) Exit\n");
    printf("1) Linear Search\n");
    printf("2) Binary Search\n");
    printf("Enter your choice: ");
}

int main()
{
    while (1)
    {
        int choice;
        print_menu();
        scanf("%d", &choice);

        switch (choice)
        {
        case 0:
            printf("\nExiting program...\n");
            return 0;

        case 1:
            display_table("Linear Search", linear_search);
            break;

        case 2:
            display_table("Binary Search", binary_search);
            break;

        default:
            printf("\nInvalid choice! Please select 0, 1, or 2.\n");
            break;
        }
    }

    return 0;
}