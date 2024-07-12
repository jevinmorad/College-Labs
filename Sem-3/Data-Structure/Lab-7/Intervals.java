import java.util.Scanner;

public class Intervals {

    static class Data {
        int first, last;
        public Data(int first, int last)
        {
            this.first = first;
            this.last = last;
        }
    }

	public static void merge(Data interval[])
	{
		// Test if the given set has at least one interval
		if (interval.length == 0)
			return;

		interval = sort(interval);

		MyStack<Data> st = new MyStack<>();
		st.push(interval[0]);

		for (int i = 1; i < interval.length; i++) {
			Data top = st.peek();
            
            if (top.last < interval[i].first) {
				st.push(interval[i]);
            }

			else if (top.last < interval[i].last) {
				top.last = interval[i].last;
				st.pop();
				st.push(top);
			}
		}

		System.out.print("After merging, intervals are : ");
		while (!st.isEmpty()) {
			Data d = st.pop();
			System.out.print("{" + d.first + "," + d.last+ "} ");
		}
	}

	public static Data[] sort(Data interval[]) {
		for (int i = 0; i < interval.length; i++) {
			for (int j = 0; j < interval.length-i-1; j++) {
				if (interval[j].first > interval[j+1].first) {
					Data temp = interval[i];
					interval[i] = interval[j];
					interval[j] = temp;
				}
			}
		}

		return interval;
	}

	public static void main(String args[])
	{
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter total intervals : ");
        int n = sc.nextInt();
		Data interval[] = new Data[n];
        for (int i = 0; i < n; i++) {
            System.out.println("For interval "+(i+1));
            System.out.print("\tEnter start : ");
            int s = sc.nextInt();
            System.out.print("\tEnter end : ");
            int e = sc.nextInt();

            interval[i] = new Data(s, e);
        }

		merge(interval);
        sc.close();
	}
}