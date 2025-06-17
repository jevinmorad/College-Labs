#include <stdio.h>
#include <string.h>
#include <stdbool.h>

typedef struct Node {
    void *data;
    struct Node *next;
} Node;

typedef struct LinkedList {
    Node *head;
    size_t dataSize;
    void (*printFun)(void *);
    int (*compareFun)(void *, void *);
    int size;
} LinkedList;

LinkedList* initLinkedList(size_t dataSize, void (*printFun)(void *), int (*compareFun)(void *, void *));
bool isEmpty(LinkedList *list);
bool add(LinkedList *list, void *value);
bool addAt(LinkedList *list, void *value, int ind);
bool removeFront(LinkedList *list, void *output);
bool removeAt(LinkedList *list, int ind, void *output);
int indexOf(LinkedList *list, void *target);
void display(LinkedList *list);
int size(LinkedList *list);
void clear(LinkedList *list);