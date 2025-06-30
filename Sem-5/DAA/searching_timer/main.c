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

double measure_time(int (*sort_fun)(int *, int, int), int *data, int n,  int target)
{
    clock_t start = clock();
    int ind = sort_fun(data, target, n);
    clock_t end = clock();

    printf("\n\n %d is at %d index\n", target, ind);

    return (double)(end - start) / CLOCKS_PER_SEC;
}

void display_table(const char *algo_name, int (*sort_fun)(int *, int, int))
{
    printf("\n------- %s -------\n\n", algo_name);
    printf("%-20s %-10s | %-10s | %-10s\n", "Number of Inputs", "   Best", "  Average", "  Worst");
    printf("%-20s %-10s | %-10s | %-10s\n", "-----------------", "----------", "----------", "----------");

    for (int i = 0; i < 4; i++)
    {
        int count = sizes[i];
        int *arrays[3];
        char filename[100];

        for (int j = 0; j < 3; j++)
        {
            sprintf(filename, "./arrays/best_%d.txt", sizes[i]);
            arrays[j] = malloc(count * sizeof(int));
            read_input_file(arrays[j], filename, count);
        }

        double times[3];
        for (int j = 0; j < 3; j++)
        {
            int target = (j==1) ? 1 : ((j==2) ? (sizes[i]/2) : sizes[i]);
            times[j] = measure_time(sort_fun, arrays[j], count, target);
        }

        printf("%-20d %-9.6lfs | %-9.6lfs | %-9.6lfs\n", count, times[0], times[1], times[2]);

        for (int i = 0; i < 3; i++)
        {
            free(arrays[i]);
        }
    }
}

int main()
{
    while (1)
    {
        int choice;
        printf("\nChoose a sorting algorithm:\n");
        printf("0) Exit\n");
        printf("1) Linear Search\n");
        printf("2) Binary Search\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);

        switch (choice)
        {
        case 0:
            printf("\nExiting....\n");
            return 0;

        case 1:
            display_table("Linear Search", linear_search);
            break;

        case 2:
            display_table("Binary Search", binary_search);
            break;

        default:
            printf("\nSelect valid number\n");
            break;
        }
    }

    return 0;
}