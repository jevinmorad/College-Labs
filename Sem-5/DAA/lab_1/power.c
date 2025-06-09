#include<stdio.h>

float withIterative(float n, float m) {
	int ans = 1, i;
	for(i=0; i<m; i++) {
		ans = ans * n;
	}
	return ans;
}

float withRecurison(float n, float m) {
	if(m==0) {
		return 1;
	}
	else if(m>0) {
		if(m==1) {
			return n;
		}
		return n*withRecurison(n, m-1);
	} else {
		if(m==-1) {
			return 1/n;
		}
		return 1/withRecurison(n, -m);
	}
}

int main() {
	printf("Enter base: ");
	float n; 
	scanf("%f",&n);
	printf("Enter power: ");
	float m; 
	scanf("%f",&m);
	
	printf("Ans with iterative approach %d\n",withIterative(n,m));
	printf("Ans with recursive approach %d",withRecurison(n,m));

	return 0;
}
