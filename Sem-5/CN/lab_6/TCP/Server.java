import java.io.*;
import java.net.*;

public class Server {
    private Socket socket = null;
    private ServerSocket server = null;
    private DataInputStream in = null;
    private DataOutputStream out = null;

    public Server(int port) {
        try {
            server = new ServerSocket(port);
            System.out.println("Server started");
            System.out.println("Waiting for a client ...");

            socket = server.accept();
            System.out.println("Client accepted");

            in = new DataInputStream(new BufferedInputStream(socket.getInputStream()));
            out = new DataOutputStream(socket.getOutputStream());

            // Thread to listen for incoming messages from the client
            Thread receiveThread = new Thread(() -> {
                String message;
                try {
                    while (true) {
                        message = in.readUTF();
                        System.out.println("Client: " + message);
                    }
                } catch (IOException e) {
                    System.out.println("Connection closed.");
                }
            });

            receiveThread.start();

            // Main thread to send messages to the client
            BufferedReader consoleInput = new BufferedReader(new InputStreamReader(System.in));
            String message;
            while (true) {
                message = consoleInput.readLine();
                out.writeUTF(message);
            }

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
        Server server = new Server(5000);
    }
}
