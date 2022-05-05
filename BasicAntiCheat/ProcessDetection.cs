using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BasicAntiCheat
{
    class ProcessDetection
    {
        public static bool detected;
        public static List<string> processDetectionList = new List<string>();
        public static string[] suspiciousNames = { "x64dbg", "cheatengine", "Debugger", "IDA Pro", "Cheat" };
        public static string ignore = AppDomain.CurrentDomain.FriendlyName;

        public static void UpdateProcList()
        {
            Process[] running = Process.GetProcesses();
            foreach(Process proc in running)
            {
                processDetectionList.Add(proc.ProcessName);
            }
        }

        public static void FindProcess()
        {
            foreach(string procName in processDetectionList)
            {
                for (int i = 0; i < suspiciousNames.Length; i++)
                {
                    if (procName != ignore)
                    {
                        if (procName.Contains(suspiciousNames[i]))
                        {
                            detected = true;
                            Console.WriteLine("Detectado: " + suspiciousNames[i]);
                            return;
                        }
                        else
                        {
                            detected = false;
                            Console.WriteLine("Nada detectado!");
                            return;
                        }
                    }
                }
            }
        }
    }
}
