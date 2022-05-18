using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPPingerProject
{
    class IPPinger
    {
        public static string IPAddress { get; set; }
        public static int ThreadCount { get; set; }

        public static int ThreadSleep { get; set; }

        public static bool ShowConsole { get; set; }


        public IPPinger(int threadCount, string ipAddress, int threadSleep = 0, bool showConsole = false)
        {
            ThreadCount = threadCount;
            IPAddress = ipAddress;
            ThreadSleep = threadSleep;
            ShowConsole = showConsole;

            PingIP();
        }

        public void PingIP()
        {

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
                while(true)
                {
                    Ping pinger = new Ping();
                    byte[] packet = new byte[65500];
                    PingReply reply = pinger.Send(IPAddress, 120, packet);

                    if (ShowConsole)
                    {
                        Console.WriteLine(reply.Status.ToString());
                    }

                    Thread.Sleep(ThreadSleep);
                }

            }

            catch (PingException pingEx)
            {
                Console.WriteLine(pingEx.ToString());
            }

        }
    }
}
