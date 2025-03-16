using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        string serverIp = "127.0.0.1";
        int port = 12345;

        TcpClient client = new TcpClient();
        client.Connect(serverIp, port);
        Console.WriteLine("Connected to server.");

        NetworkStream stream = client.GetStream();

        byte[] message = Encoding.ASCII.GetBytes("Hello from Bruce!");
        stream.Write(message, 0, message.Length);

        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        Console.WriteLine("Recieved from server: " + response);

        client.Close();
    }
}
