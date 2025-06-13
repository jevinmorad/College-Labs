#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

struct Node {
    int data;
    struct Node* next;
};

struct Queue {
    struct Node* head;
    struct Node* tail;
    int size;
};

void initialize(struct Queue* q) {
    q->head = q->tail = NULL;
    q->size = 0;
}

bool isEmpty(struct Queue* q) {
    return q->head == NULL;
}

void enqueue(struct Queue* q, int value) {
    struct Node* newNode = (struct Node*)malloc(sizeof(struct Node));
    newNode->data = value;
    newNode->next = NULL;

    if (q->tail == NULL) {
        q->head = q->tail = newNode;
    } else {
        q->tail->next = newNode;
        q->tail = newNode;
    }

    q->size++;
    printf("Enqueued: %d\n", value);
}

int dequeue(struct Queue* q) {
    if (isEmpty(q)) {
        printf("Queue is underflow. Nothing to dequeue.\n");
        return -1;
    }

    struct Node* temp = q->head;
    int value = temp->data;
    q->head = q->head->next;

    if (q->head == NULL) {
        q->tail = NULL;
    }

    free(temp);
    q->size--;
    printf("Dequeued: %d\n", value);
    return value;
}

int peek(struct Queue* q) {
    if (isEmpty(q)) {
        printf("Queue is empty.\n");
        return -1;
    }
    printf("Top element: %d\n", q->head->data);
    return q->head->data;
}

void display(struct Queue* q) {
    if (isEmpty(q)) {
        printf("Queue is empty.\n");
        return;
    }

    struct Node* temp = q->head;
    printf("Queue is:\n");
    while (temp != NULL) {
        printf("          %d\n", temp->data);
        temp = temp->next;
    }
}

bool contains(struct Queue* q, int value) {
    struct Node* temp = q->head;
    while (temp != NULL) {
        if (temp->data == value) {
            return true;
        }
        temp = temp->next;
    }
    return false;
}

int getSize(struct Queue* q) {
    return q->size;
}

void clear(struct Queue* q) {
    struct Node* current = q->head;
    while (current != NULL) {
        struct Node* temp = current;
        current = current->next;
        free(temp);
    }
    initialize(q);
    printf("Queue cleared.\n");
}

int main() {
    struct Queue q;
    int choice, value;
    bool running = true;

    initialize(&q);

    printf("==== QUEUE IMPLEMENTATION ====\n");

    while (running) {
        printf("\nChoose an operation:\n");
        printf("1. Enqueue\n");
        printf("2. Dequeue\n");
        printf("3. Peek\n");
        printf("4. Display\n");
        printf("5. Contains\n");
        printf("6. Check if Empty\n");
        printf("7. Get Size\n");
        printf("8. Clear\n");
        printf("9. Exit\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);

        switch (choice) {
            case 1:
                printf("Enter the value to enqueue: ");
                scanf("%d", &value);
                enqueue(&q, value);
                break;

            case 2:
                dequeue(&q);
                break;

            case 3:
                peek(&q);
                break;

            case 4:
                display(&q);
                break;

            case 5:
                printf("Enter the value to search: ");
                scanf("%d", &value);
                if (contains(&q, value))
                    printf("%d is in the queue.\n", value);
                else
                    printf("%d is not in the queue.\n", value);
                break;

            case 6:
                if (isEmpty(&q))
                    printf("Yes, the queue is empty.\n");
                else
                    printf("No, the queue is not empty.\n");
                break;

            case 7:
                printf("Current queue size: %d\n", getSize(&q));
                break;

            case 8:
                clear(&q);
                break;

            case 9:
                printf("Exiting program. Goodbye!\n");
                clear(&q);
                running = false;
                break;

            default:
                printf("Invalid choice. Please enter a number between 1 and 9.\n");
                break;
        }
    }
    return 0;
}
