#include <stdbool.h>
#include "searching_algo.h"

int linear_search(int *arr, int target, int size)
{
    int i = 0;
    while (i < size)
    {
        if (arr[i] == target)
        {
            return i;
        }
        i++;
    }

    return -1;
}

int binary_search(int *arr, int target, int size)
{
    int start = 0, end = size - 1;

    while (start <= end)
    {
        int mid = start + (end - start) / 2;

        if (arr[mid] == target)
        {
            return mid;
        }
        else if (arr[mid] < target)
        {
            start = mid + 1;
        }
        else
        {
            end = mid - 1;
        }
    }
    return -1;
}