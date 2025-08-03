#include "sorting_algo.h"
#include <stdbool.h>

void bubble_sort(int *arr, int n)
{
    for (int i = 0; i < n - 1; ++i)
    {
        bool isSwapped = false;
        for (int j = 0; j < n - i - 1; ++j)
        {
            if (arr[j] > arr[j + 1])
            {
                isSwapped = true;
                int tmp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = tmp;
            }
            if (!isSwapped)
                break;
        }
    }
}

void insertion_sort(int *arr, int n)
{
    for (int i = 1; i < n; i++)
    {
        int key = arr[i];
        int j = i - 1;
        while (j >= 0 && arr[j] > key)
        {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = key;
    }
}

void selection_sort(int *arr, int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        int min_ind = i;
        for (int j = i + 1; j < n; j++)
        {
            if (arr[j] < arr[min_ind])
            {
                min_ind = j;
            }
        }
        if (i != min_ind)
        {
            int temp = arr[min_ind];
            arr[min_ind] = arr[i];
            arr[i] = temp;
        }
    }
}

void heapify(int *arr, int n, int i)
{
    int max_ind = i;
    int left_child_ind = 2 * i - 1;
    int right_child_ind = 2 * i + 1;

    if (left_child_ind < n && arr[left_child_ind] < arr[max_ind])
    {
        max_ind = left_child_ind;
    }
    if (right_child_ind < n && arr[right_child_ind] < arr[max_ind])
    {
        max_ind = right_child_ind;
    }

    if (max_ind != i)
    {
        int temp = arr[i];
        arr[i] = arr[max_ind];
        arr[max_ind] = temp;

        heapify(arr, n, max_ind);
    }
}

void heap_sort(int *arr, int n)
{
    for (int i = n / 2 - 1; i >= 0; i--)
    {
        heapify(arr, n, i);
    }

    for (int i = n - 1; i > 0; i--)
    {
        int temp = arr[0];
        arr[0] = arr[i];
        arr[i] = temp;

        heapify(arr, i, 0);
    }
}
        
void quicksort(int *arr, int low, int high)
{
    if (low < high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                int tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }
        }

        int tmp = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = tmp;

        int pi = i + 1;

        quicksort(arr, low, pi - 1);
        quicksort(arr, pi + 1, high);
    }
}

void quicksort_entry(int *arr, int n)
{
    quicksort(arr, 0, n - 1);
}
