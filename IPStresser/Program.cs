using System;
using IPPingerProject;

namespace IPStresser
{
    class Program
    {
        static void Main(string[] args)
        {
            new IPPinger("111.222.73.102", 400);
        }
    }
}
