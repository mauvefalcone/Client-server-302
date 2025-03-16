using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class Server
{
    static void Main()
    {
        int port = 12345;
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);

        server.Start();
        Console.WriteLine($"Server started on 127.0.0.1:{port}");

        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Client connected.");

        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        Console.WriteLine("Received from client: " + message);

        byte[] response = Encoding.ASCII.GetBytes("Hello Sir from Alfred!");
        stream.Write(response, 0,  response.Length);

        client.Close();
        server.Stop();
    }
}
