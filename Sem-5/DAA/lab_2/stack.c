#include <stdio.h>
#include <stdlib.h>
int size = 0;
struct Node
{
	int data;
	struct Node *next;
} *head = NULL;

void push(int n)
{
	struct Node *newNode = (struct Node *)malloc(sizeof(struct Node));
	newNode->next = NULL;
	newNode->data = n;
	if (head == NULL)
	{
		head = newNode;
		return;
	}
	newNode->next = head;
	head = newNode;
	size++;
}

int pop()
{
	if (head == NULL)
	{
		return -1;
	}
	int val = head->data;
	head = head->next;
	size--;
	return val;
}

void display()
{
	struct Node *node = head;
	while (node != NULL)
	{
		printf("%d ", node->data);
		node = node->next;
	}
}

int peep(int ind)
{
	struct Node *node = head;
	if (ind > size)
	{
		printf("Out of range");
		return 0;
	}
	while (ind >= 0)
	{
		node = node->next;
		ind--;
	}
	int val = node->data;
	return val;
}

int main()
{
	bool isContinue = true;
	while (isContinue)
	{
		printf("\n\n[1] Push\n [2] Pop\n [3] Peep\n [4] Display\n [5] Exit");
		printf("\n\nEnter your choice : ");
		int choice;
		scanf("%d", &choice);
		switch (choice)
		{
		case 1:
			scanf("Enter element to push : ");
			int n;
			scanf("%d", &n);
			push(n);
			break;

		case 2:
			int val = pop();
			printf("\nPoped elemet = %d\n", val);
			break;

		case 3:
			scanf("Enter ind to get : ");
			int n;
			scanf("%d", &n);
			int val = peep(n);
			break;

		case 4:
			display();
			printf("\n\n");
			break;

		case 5:
			isContinue = false;
			break;

		default:
			printf("\nInvalid choice\n");
			break;
		}
	}
	return 0;
}
