using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CreateSocket
{
    public class SocketListener
    {
        private static int a;
        public static void StartServer()
        {
            IPHostEntry host= Dns.GetHostEntry("localhost");//Get an IP/host name to establish a conection
            IPAddress ipAddress= host.AddressList[0];   //Get one IPAdress
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            try
            {
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp); //Create a socket to use protocol

                listener.Bind(localEndPoint);
                listener.Listen(a); // Specify how many request a socket can listen before give to sever 
                Console.WriteLine(" Waiting to conection... ");
                Socket handler = listener.Accept();
                string data = null;
                byte[] bytes = null;
                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }
                Console.WriteLine("Text received : {0}", data);
                byte [] message=Encoding.ASCII.GetBytes(data);
                handler.Send(message);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());    

            }
            Console.WriteLine("\nPress any key to continue... ");
            Console.ReadKey();
        }

    }
    public class CreateClient 
    {
        public static void StartClient(Exception exception)
        {
            byte[] bytes= new byte[1024];
            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress iPAddress = host.AddressList[0];
                IPEndPoint remoteE = new IPEndPoint(iPAddress, 11000);
                Socket sender = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    sender.Connect(remoteE);// Conect to remote endpoin
                    Console.WriteLine("Socket conect to {0}", sender.RemoteEndPoint.ToString());
                    byte[] message = Encoding.ASCII.GetBytes("This is text <EOF>");// Encode data string to byte
                    int byteSent = sender.Send(message); //Send data to Socket
                    int bytesRec = sender.Receive(message); //Receive the respone of remote device
                    Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException :{0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException :  {0}", se.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Exception :{0}", ex.ToString());
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}