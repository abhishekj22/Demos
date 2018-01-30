import java.net.*;

class MulticastSocketTest{

	public static void main(String[] args) throws Exception{
		InetAddress addr = InetAddress.getByName("230.0.0.1");
		MulticastSocket subscriber = new MulticastSocket(4032);
		subscriber.joinGroup(addr);
		for(int i = 0; i < 5; ++i){
			DatagramPacket message = new DatagramPacket(new byte[80], 80);
			subscriber.receive(message);
			String text = new String(message.getData(), 0, message.getLength());
			System.out.println(text);
		}
		subscriber.leaveGroup(addr);
		subscriber.close();
	}
}

