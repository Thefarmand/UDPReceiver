using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPSender
{
    internal class Sender
    {
        private int PORT;

        public Sender(int port)
        {
            this.PORT = port;
        }

        public void start()
        {
            String navn = "Jan";

            byte[] data = Encoding.ASCII.GetBytes(navn);
            IPEndPoint receiverEP = new IPEndPoint(IPAddress.Broadcast, PORT);

            using (UdpClient senderSock = new UdpClient()) // ingen port = lytter IKKE
            {
                senderSock.EnableBroadcast = true;

                senderSock.Send(data, data.Length, receiverEP);

                IPEndPoint FromReceiverEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] inData = senderSock.Receive(ref FromReceiverEP);

                String inStr = Encoding.ASCII.GetString(inData);

                Console.WriteLine("Modtaget = " + inStr);

            }
        }
    }
}