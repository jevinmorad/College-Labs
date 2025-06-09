#include<stdio.h>

float withIterative(double n, int n) {
	float ans = 1.0, i;
	int absM = abs(m);
	for(i=0; i<absM; i++) {
		ans = ans * n;
	}
	return (n > 0) ? ans : (1 / ans);
}

float withRecurison(double n, double m) {
	if(m==0) return 1;
	else if(m>0) return n*withRecurison(n, m-1);
	else return 1/withRecurison(n, -m);
}

int main() {
	printf("Enter base: ");
	double n; 
	scanf("%lf",&n);
	printf("Enter power: ");
	int m; 
	scanf("%d",&m);
	
	printf("Ans with iterative approach %.6lf\n",withIterative(n,m));
	printf("Ans with recursive approach %.6lf\n",withIterative(n,m));

	return 0;
}
