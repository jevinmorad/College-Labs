#include<stdio.h>

int withIterative(int n) {
	int ans = 1, i;
	for(i=2; i<=n; i++) {
		ans = ans * i;
	}
	return ans;
}

int withRecurison(int n) {
	if(n==0 || n == 1) {
		return 1;
	}
	return n*withRecurison(n-1);
}

int main() {
	printf("Enter number: ");
	int n; 
	scanf("%d",&n);
	
	printf("Ans with iterative approach %d\n",withIterative(n));
	printf("Ans with recursive approach %d",withRecurison(n));

	return 0;
}
