import java.io.*;

public class CheckFileOrFolder {
    public static void main(String[] args) {
        if (args.length != 1) {
            System.out.println("Enter a valis file name");
            return;
        } else {
            File file = new File(args[0]);

            if (!file.exists()) {
                System.err.println("File or directory not found: " + file.getAbsolutePath());
            }
            else {
            if (file.isFile()) {
                System.out.println("File size: " + file.length() + " bytes");
            } else {
                System.out.println("Directory contents:");
                for (File child : file.listFiles()) {
                    System.out.println(child.getName());
                }
            }
        }
        }
    }
}