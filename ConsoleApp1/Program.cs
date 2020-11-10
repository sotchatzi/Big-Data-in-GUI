using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello main thread!");

            ThreadStart childref = CallToChildThread;
            Thread childThread = new Thread(childref);
            childThread.Start();
        }

        public static void CallToChildThread()
        {
            Console.WriteLine("My heart beat starts");

            int pulse = 500;
            int numHeartbeats = 0;
            while (true)
            {
                Console.WriteLine("Heartbeat "+ numHeartbeats);
                numHeartbeats++;
                Thread.Sleep(pulse);
            }
        }
    }
}
