using System;
using System.Threading;

namespace BasicAntiCheat
{
    class Program
    {
        public static Thread thread;
        static void Main(string[] args)
        {
            thread = new Thread(ConsoleThread);
            thread.Name = "ConsoleThread";
            thread.Start();
            Console.ReadLine();
        }

        public static void ConsoleThread()
        {
            while (true)
            {
                ProcessDetection.UpdateProcList();
                ProcessDetection.FindProcess();
                Thread.Sleep(4000);
            }
        }
    }
}