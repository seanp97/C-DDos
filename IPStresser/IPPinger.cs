using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPNameSpace
{
    class IPPinger
    {
        public static string IPAddress { get; set; }
        public void PingIP()
        {
            Console.WriteLine("How many threads? ");
            int ThreadCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("IP Address? ");
            string ipAddress = Console.ReadLine();
            IPAddress = ipAddress;

            for (int i = 0; i < ThreadCount; i++)
            {
                new Thread(() =>
                {
                    PingMethod();
                }).Start();
            }
        }

        static void PingMethod()
        {

            try
            {
                while (true)
                {
                    Ping pinger = new Ping();
                    byte[] packet = new byte[65500];
                    PingReply reply = pinger.Send(IPAddress, 120, packet);
                    Console.WriteLine(reply.Status);
                }

            }

            catch (PingException pingEx)
            {
                Console.WriteLine(pingEx.ToString());
            }

        }


        public void NumOfThreads()
        {
            int threadCount = Process.GetCurrentProcess().Threads.Count;
            

            while(true)
            {
                Console.WriteLine($"Number of threads: {threadCount}");
                Thread.Sleep(10000);
            }
        }
    }
}
