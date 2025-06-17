#include "linkedlist.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

void printInt(void *data)
{
    printf("%d", *(int *)data);
}

int compareInt(void *a, void *b)
{
    return *(int *)a - *(int *)b;
}

void printFloat(void *data)
{
    printf("%.2f", *(float *)data);
}

int compareFloat(void *a, void *b)
{
    float diff = *(float *)a - *(float *)b;
    return (diff > 0) ? 1 : ((diff < 0) ? -1 : 0);
}

void printString(void *data)
{
    printf("\"%s\"", (char *)data);
}

int compareString(void *a, void *b)
{
    return strcmp((char *)a, (char *)b);
}

int main()
{
    printf("\n\t\t=== Linked List Operations ===\n\n");

    int typeChoice;
    printf("Select data type:\n");
    printf("1. Integer\n");
    printf("2. Float\n");
    printf("3. String\n");
    printf("Choice: ");
    scanf("%d", &typeChoice);

    LinkedList *list;
    size_t dataSize;
    void (*printFun)(void *);
    int (*compareFunc)(void *, void *);

    switch (typeChoice)
    {
    case 1:
        dataSize = sizeof(int);
        printFun = printInt;
        compareFunc = compareInt;
        break;
    case 2:
        dataSize = sizeof(float);
        printFun = printFloat;
        compareFunc = compareFloat;
        break;
    case 3:
        dataSize = sizeof(char *);
        printFun = printString;
        compareFunc = compareString;
        break;
    default:
        printf("Invalid choice!\n");
        break;
    }

    list = initLinkedList(dataSize, printFun, compareFunc);

    int choice;
    while (1)
    {
        printf("\n1. Add element\n");
        printf("2. Add at index\n");
        printf("3. Remove from front\n");
        printf("4. Remove at index\n");
        printf("5. Find index of element\n");
        printf("6. Check if empty\n");
        printf("7. Get size\n");
        printf("8. Display list\n");
        printf("9. Exit\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);

        switch (choice)
        {
        case 1:
            printf("Enter value: ");
            if (dataSize == sizeof(int))
            {
                int value;
                scanf("%d", &value);
                add(list, &value);
            }
            else if (dataSize == sizeof(float))
            {
                float value;
                scanf("%f", &value);
                add(list, &value);
            }
            else
            {
                char value[100];
                scanf("%s", value);
                char *str = strdup(value);
                add(list, str);
            }
            printf("Element added.\n");
            break;

        case 2:
        {
            int index;
            printf("Enter index: ");
            scanf("%d", &index);
            printf("Enter value: ");

            if (dataSize == sizeof(int))
            {
                int value;
                scanf("%d", &value);
                addAt(list, &value, index);
            }
            else if (dataSize == sizeof(float))
            {
                float value;
                scanf("%f", &value);
                addAt(list, &value, index);
            }
            else
            {
                char value[100];
                scanf("%s", value);
                char *str = strdup(value);
                addAt(list, str, index);
            }
            printf("Element added at index %d.\n", index);
            break;
        }

        case 3:
            if (dataSize == sizeof(int))
            {
                int value;
                if (removeFront(list, &value))
                {
                    printf("Removed: %d\n", value);
                }
                else
                {
                    printf("List is empty!\n");
                }
            }
            else if (dataSize == sizeof(float))
            {
                float value;
                if (removeFront(list, &value))
                {
                    printf("Removed: %.2f\n", value);
                }
                else
                {
                    printf("List is empty!\n");
                }
            }
            else
            {
                char *value = malloc(100);
                if (removeFront(list, value))
                {
                    printf("Removed: %s\n", value);
                    free(value);
                }
                else
                {
                    printf("List is empty!\n");
                }
            }
            break;

        case 4:
        {
            printf("Enter index: ");
            int index;
            scanf("%d", &index);

            if (dataSize == sizeof(int))
            {
                int value;
                if (removeAt(list, index, &value))
                {
                    printf("Removed: %d\n", value);
                }
                else
                {
                    printf("Invalid index!\n");
                }
            }
            else if (dataSize == sizeof(float))
            {
                float value;
                if (removeAt(list, index, &value))
                {
                    printf("Removed: %.2f\n", value);
                }
                else
                {
                    printf("Invalid index!\n");
                }
            }
            else
            {
                char *value = malloc(100);
                if (removeAt(list, index, value))
                {
                    printf("Removed: %s\n", value);
                    free(value);
                }
                else
                {
                    printf("Invalid index!\n");
                }
            }
            break;
        }

        case 5:
            printf("Enter value to find: ");
            if (dataSize == sizeof(int))
            {
                int value;
                scanf("%d", &value);
                int index = indexOf(list, &value);
                printf("Index: %d\n", index);
            }
            else if (dataSize == sizeof(float))
            {
                float value;
                scanf("%f", &value);
                int index = indexOf(list, &value);
                printf("Index: %d\n", index);
            }
            else
            {
                char value[100];
                scanf("%s", value);
                int index = indexOf(list, value);
                printf("Index: %d\n", index);
            }
            break;

        case 6:
            printf(isEmpty(list) ? "List is empty\n" : "List is not empty\n");
            break;

        case 7:
            printf("Size: %d\n", size(list));
            break;

        case 8:
            display(list);
            break;

        case 9:
            clear(list);
            printf("Goodbye!\n");
            return 0;

        default:
            printf("Invalid choice!\n");
        }
    }

    return 0;
}