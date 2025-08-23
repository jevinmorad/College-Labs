import java.io.*;
import java.net.*;

public class Client {
    private Socket socket = null;
    private DataInputStream in = null;
    private DataOutputStream out = null;

    public Client(String address, int port) {
        try {
            socket = new Socket(address, port);
            System.out.println("Connected to the server");

            in = new DataInputStream(socket.getInputStream());
            out = new DataOutputStream(socket.getOutputStream());

            // Thread to listen for incoming messages from the server
            Thread receiveThread = new Thread(() -> {
                String message;
                try {
                    while (true) {
                        message = in.readUTF();
                        System.out.println("Server: " + message);
                    }
                } catch (IOException e) {
                    System.out.println("Connection closed.");
                }
            });

            receiveThread.start();

            // Main thread to send messages to the server
            BufferedReader consoleInput = new BufferedReader(new InputStreamReader(System.in));
            String message;
            while (true) {
                message = consoleInput.readLine();
                out.writeUTF(message);
            }

        } catch (UnknownHostException u) {
            System.out.println(u);
        } catch (IOException e) {
            System.out.println(e);
        } finally {
            try {
                socket.close();
                in.close();
                out.close();
            } catch (IOException e) {
                System.out.println(e);
            }
        }
    }

    public static void main(String[] args) {
        Client client = new Client("127.0.0.1", 5000);
    }
}
