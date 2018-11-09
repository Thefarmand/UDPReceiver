using System;

namespace UDPReceiver
{
    class Program
    {
        private const int PORT = 7;

        static void Main(string[] args)
        {
            UDPReceiver receiver = new UDPReceiver(PORT);
            receiver.Start();

            Console.ReadLine();

        }
    }
}
