#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

#include "linkedlist.h"

LinkedList *initLinkedList(size_t dataSize, void (*printFun)(void *), int (*compareFun)(void *, void *))
{
    LinkedList *list = (LinkedList *)malloc(sizeof(LinkedList));
    list->head = NULL;
    list->dataSize = dataSize;
    list->printFun = printFun;
    list->compareFun = compareFun;
    list->size = 0;
    return list;
}

bool isEmpty(LinkedList *list)
{
    return (list->size == 0);
}

bool add(LinkedList *list, void *value)
{
    Node *newNode = (Node *)malloc(sizeof(Node));
    newNode->data = malloc(list->dataSize);
    memcpy(newNode->data, value, list->dataSize);
    newNode->next = NULL;

    if (list->head == NULL)
    {
        list->head = newNode;
    }
    else
    {
        Node *cur = list->head;
        while (cur->next != NULL)
        {
            cur = cur->next;
        }
        cur->next = newNode;
    }
    list->size++;
    return true;
}

bool addAt(LinkedList *list, void *value, int ind)
{
    if (ind < 0 || ind > list->size)
    {
        return false;
    }

    Node *newNode = (Node *)malloc(sizeof(Node));
    newNode->data = malloc(list->dataSize);
    memcpy(newNode->data, value, list->dataSize);

    if (ind == 0)
    {
        newNode->next = list->head;
        list->head = newNode;
    }
    else
    {
        Node *cur = list->head;
        for (int i = 0; i < ind - 1; i++)
        {
            cur = cur->next;
        }
        newNode->next = cur->next;
        cur->next = newNode;
    }

    list->size++;
    return true;
}

bool removeFront(LinkedList *list, void *output)
{
    if (isEmpty(list))
    {
        return false;
    }

    Node *temp = list->head;
    memcpy(output, temp->data, list->dataSize);
    list->head = list->head->next;
    free(temp->data);
    free(temp);
    list->size--;

    return true;
}

bool removeAt(LinkedList *list, int ind, void *output)
{
    if (ind < 0 || ind >= list->size || isEmpty(list))
    {
        return false;
    }

    if (ind == 0)
    {
        return removeFront(list, output);
    }

    Node *cur = list->head;
    for (int i = 0; i < ind - 1; i++)
    {
        cur = cur->next;
    }

    Node *temp = cur->next;
    memcpy(output, temp->data, list->dataSize);
    cur->next = temp->next;
    free(temp->data);
    free(temp);
    list->size--;

    return true;
}

int indexOf(LinkedList *list, void *target)
{
    Node *cur = list->head;
    int index = 0;
    while (cur != NULL)
    {
        if (list->compareFun(cur->data, target) == 0)
        {
            return index;
        }
        cur = cur->next;
        index++;
    }
    return -1;
}

void display(LinkedList *list)
{
    printf("List contents: ");
    Node *cur = list->head;
    printf("[");
    while (cur != NULL)
    {
        list->printFun(cur->data);
        if (cur->next != NULL)
        {
            printf(", ");
        }
        cur = cur->next;
    }
    printf("]\n");
}

int size(LinkedList *list)
{
    return list->size;
}

void clear(LinkedList *list)
{
    Node *cur = list->head;
    while (cur != NULL)
    {
        Node *temp = cur;
        cur = cur->next;
        free(temp->data);
        free(temp);
    }
    free(list);
}