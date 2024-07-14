import java.util.*;

class VOWANX
{
	public static void main (String[] args) throws java.lang.Exception
	{
		// your code goes here
        Scanner sc = new Scanner(System.in);
        int t = sc.nextInt();
        
        for(int i=0; i<t; i++) {
            int n = sc.nextInt();
            String str = sc.next();
            System.out.println(checkVowel(str,n));
        }

        sc.close();
	}

    public static String checkVowel(String s, int n) {

        return "asfsdf";
    }

    /* Without use of stack */
    // public static String checkVowel(String s, int n) {
    //     StringBuffer sBuf = new StringBuffer();
    //     for (char c : s.toCharArray()) {
    //         if (c=='a'||c=='e'||c=='i'||c=='o'||c=='u') {
    //             sBuf.reverse();
    //             sBuf.append(c);
    //         }
    //         else {
    //             sBuf.append(c);
    //         }
    //     }
    //     return sBuf.toString();
    // }
}