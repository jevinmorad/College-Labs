#include<stdio.h>

int withIterative(int n) {
	int count = 0;
	while(n!=0) {
		n=n/10;
		count = count + 1;
	}
	return count;
}

int withRecurison(int n) {
	if(n==0) {
		return 0;
	}
	return 1 + withRecurison(n/10);
}

int main() {
	printf("Enter number: ");
	int n; 
	scanf("%d",&n);
	
	printf("Ans with iterative approach %d\n",withIterative(n));
	printf("Ans with recursive approach %d",withRecurison(n));

	return 0;
}
