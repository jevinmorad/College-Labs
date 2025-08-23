import java.io.*;
import java.net.*;

class Client {
    public static void main(String[] args) {
        try {
            BufferedReader user_input = new BufferedReader(new InputStreamReader(System.in));

            DatagramSocket client_socket = new DatagramSocket();

            InetAddress IP_add = InetAddress.getByName("localhost");

            byte[] out_data;
            byte[] in_data = new byte[1024];

            System.out.print("Enter message: ");
            String str = user_input.readLine();
            out_data = str.getBytes();

            DatagramPacket Packet1 = new DatagramPacket(out_data, out_data.length, IP_add, 1234);
            client_socket.send(Packet1);

            DatagramPacket Packet4 = new DatagramPacket(in_data, in_data.length);
            client_socket.receive(Packet4);

            String receive_str = new String(Packet4.getData(), 0, Packet4.getLength());
            System.out.println("Server response: " + receive_str);

            client_socket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}