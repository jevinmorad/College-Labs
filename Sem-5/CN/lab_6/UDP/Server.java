import java.io.*;
import java.net.*;

class Server {
    public static void main(String[] args) {
        try {
            DatagramSocket server_socket = new DatagramSocket(1234);

            byte[] in_data = new byte[1024];
            byte[] out_data;

            while (true) {

                DatagramPacket Packet2 = new DatagramPacket(in_data, in_data.length);
                server_socket.receive(Packet2);

                String str = new String(Packet2.getData(), 0, Packet2.getLength());
                System.out.println("Received from client: " + str);

                InetAddress IP_add1 = Packet2.getAddress();
                int port = Packet2.getPort();

                BufferedReader server_input = new BufferedReader(new InputStreamReader(System.in));
                System.out.print("Enter response: ");
                String send_str = server_input.readLine();
                out_data = send_str.getBytes();

                DatagramPacket Packet3 = new DatagramPacket(out_data, out_data.length, IP_add1, port);
                server_socket.send(Packet3);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}