import java.io.*;

public class Replace {
    public static void main(String[] args) {
        String inputFile = "file1.txt";
        String outputFile = "file2.txt";

        try {
            BufferedReader reader = new BufferedReader(new FileReader(inputFile));
            BufferedWriter writer = new BufferedWriter(new FileWriter(outputFile));

            String line;

            while ((line = reader.readLine()) != null) {
                String modifiedLine = line.replaceAll("world1", "world2");
                writer.write(modifiedLine);
                writer.newLine();
            }

            reader.close();
            writer.close();
        } catch (IOException e) {
            System.err.println("Error reading/writing files: " + e.getMessage());
        }
    }
}
