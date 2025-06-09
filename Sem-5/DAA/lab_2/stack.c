#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

struct Node {
    int data;
    struct Node* next;
};

struct Node* head = NULL;
int size = 0;

void push(int value) {
    struct Node* newNode = (struct Node*)malloc(sizeof(struct Node));
    newNode->data = value;
    newNode->next = head;
    head = newNode;
    size++;
    printf("Element %d pushed to stack.\n", value);
}

int pop() {
    if (head == NULL) {
        printf("Stack underflow! Nothing to pop.\n");
        return -1;
    }
    int value = head->data;
    struct Node* temp = head;
    head = head->next;
    free(temp);
    size--;
    printf("%d popped.\n", value);
    return value;
}

int peek() {
    if (head == NULL) {
        printf("Stack is empty.\n");
        return -1;
    }
    printf("Top element is: %d\n", head->data);
    return head->data;
}

void display() {
    if (head == NULL) {
        printf("Stack is empty.\n");
        return;
    }
    struct Node* current = head;
    printf("Stack is:\n");
    while (current != NULL) {
        printf("          %d\n", current->data);
        current = current->next;
    }
    printf("\n");
}

bool isEmpty() {
    return head == NULL;
}

int getSize() {
    return size;
}

void clear() {
    struct Node* current = head;
    while(current != NULL) {
        struct Node* temp = current;
        current = current->next;
        free(temp);
    }
    head = NULL;
    size = 0;
    printf("Stack cleared")
}

int main() {
    int choice, value;
    bool running = true;

    printf("==== STACK IMPLEMENTATION ====\n");

    while (running) {
        printf("\nChoose an operation:\n");
        printf("1. Push\n");
        printf("2. Pop\n");
        printf("3. Peek\n");
        printf("4. Display Stack\n");
        printf("5. Check if Stack is Empty\n");
        printf("6. Get Stack Size\n");
        printf("7. Clear stack\n");
        printf("8. Exit\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);

        switch (choice) {
            case 1:
                printf("Enter the value to push: ");
                scanf("%d", &value);
                push(value);
                break;

            case 2:
                pop();
                break;

            case 3:
                peek();
                break;

            case 4:
                display();
                break;

            case 5:
                if (isEmpty())
                    printf("Yes, the stack is empty.\n");
                else
                    printf("No, the stack is not empty.\n");
                break;
                
            case 6:
                printf("Current stack size: %d\n", getSize());
                break;
                
            case 7:
                clear();
                break;

            case 8:
                printf("Exiting program. Goodbye!\n");
                clear();
                running = false;
                break;

            default:
                printf("Invalid choice. Please enter a number between 1 and 8.\n");
                break;
        }
    }
    return 0;
}
