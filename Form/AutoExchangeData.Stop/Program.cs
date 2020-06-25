using System;
using System.Diagnostics;

namespace POS.StopAutoExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            var processName = "POS";
            var result = false;

            Process[] runningProcess = Process.GetProcessesByName(processName);

            if (runningProcess.Length == 0)
            {
                //Do nothing: POS is not running
                result = true;
            }
            else
            {
                result = false;
                try
                {
                    //Stop POS
                    foreach (var process in Process.GetProcessesByName(processName))
                    {
                        process.Kill();
                        result = true;
                    }
                }
                catch (Exception)
                {
                }
            }

            processName = "AutoExchangeData";
            runningProcess = Process.GetProcessesByName(processName);

            if (runningProcess.Length == 0)
            {
                //Do nothing: AutoExchangeData is not running
                result = true;
            }
            else
            {
                result = false;
                try
                {
                    //Stop AutoExchangeData
                    foreach (var process in Process.GetProcessesByName(processName))
                    {
                        process.Kill();
                        result = true;
                    }
                }
                catch (Exception)
                {
                }
            }

            Console.WriteLine(result == true ? "Successful!" : "Something went wrong!");
            Console.Read();
        }
    }
}
