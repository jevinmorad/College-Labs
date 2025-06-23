#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "sorting_algo.h"

const int sizes[] = {100, 1000, 10000, 100000};
const char *cases[] = {"best", "average", "worst"};

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

double measure_time(void (*sort_fun)(int *, int), int *data, int n)
{
    int *temp = malloc(sizeof(int) * n);
    memcpy(temp, data, sizeof(int) * n);

    clock_t start = clock();
    sort_fun(temp, n);
    clock_t end = clock();

    free(temp);
    return (double)(end - start) / CLOCKS_PER_SEC;
}

void display_table(const char *algo_name, void (*sort_fun)(int *, int))
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
            sprintf(filename, "./arrays/%s_%d.txt", cases[j], sizes[j]);
            arrays[j] = malloc(count * sizeof(int));
            read_input_file(arrays[j], filename, count);
        }

        double times[3];
        for (int j = 0; j < 3; j++)
        {
            times[j] = measure_time(sort_fun, arrays[j], count);
        }

        printf("%-20d %-9.6lfs | %-9.6lfs | %-9.6lfs\n", count, times[0], times[1], times[2]);

        for (int j = 0; j < 3; j++)
        {
            free(arrays[j]);
        }
    }
}

int main()
{
    while (1)
    {
        int choice;
        printf("\nChoose a sorting algorithm:\n");
        printf("0. Exit\n");
        printf("1. Bubble Sort\n");
        printf("2. Insertion Sort\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);

        switch (choice)
        {
        case 0:
            printf("\nExiting....\n");
            return 0;

        case 1:
            display_table("Bubble sort", bubble_sort);
            break;

        case 2:
            display_table("Insertion sort", insertion_sort);
            break;

        default:
            printf("\nSelect valid number\n");
            break;
        }
    }

    return 0;
}