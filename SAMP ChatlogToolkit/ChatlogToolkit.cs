using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SAMP_ChatlogToolkit
{
    
    public static class ChatlogToolkit
    {
        // A variable to check if SA:MP is running
        //public int SAMPactive;

        // Where the chatlog.txt file is located
        public static string ChatLogPath = "";

        // Which folder the chatlog should be saved to
        public static string ChatLogTarget = "";

        // A timer to check if GTA:SA is running in SA:MP mode
        static Timer MainTimer = new System.Timers.Timer(10000);

        // A method to launch the timer
        public static void LaunchTimer()
        {
            //MainTimer = new System.Timers.Timer(10000);

            // Hook up the Elapsed event for the timer.
            MainTimer.Elapsed += new ElapsedEventHandler(MainTimerEvent);

            // Set the Interval to 10 seconds (2000 milliseconds).
            MainTimer.Interval = 10000;
            MainTimer.Enabled = true;
            Console.WriteLine("Timer launched!");
        }

        public static void StopTimer()
        {
            MainTimer.Enabled = false;
            Console.WriteLine("Timer stopped!");
        }

        // A method to handle each timer event
        public static void MainTimerEvent(object source, ElapsedEventArgs e)
        {
            if(MainTimer.Enabled)
            {
                Console.WriteLine(" **** This is a timer event ****");
                var ProcessGTA = System.Diagnostics.Process.GetProcessesByName("gta_sa");
                if (ProcessGTA.Length > 0)
                {
                    var p = ProcessGTA.First();
                    p.EnableRaisingEvents = true;
                    Console.WriteLine("Found gta_sa.exe running in memory. Checking if SA:MP.");

                    if (p.MainWindowTitle == "GTA:SA:MP")
                    {
                        Console.WriteLine("Positive match for SA:MP, waiting for an exit event.");
                        p.Exited += (o, ev) =>
                        {
                            Console.WriteLine("Detected exit of SA:MP");

                            // We found SA:MP exiting, backup the chatlog!
                            BackupChatlog();
                        };
                    }
                }
            }
        }

        public static void BackupChatlog()
        {
            DateTime now = DateTime.Now;
            String datetime = String.Format("{0:d-M-yyyy HH-mm-ss}", now);
            string FinalTarget = ChatLogTarget + "\\" + datetime +".txt";
            Console.WriteLine("Saving the chatlog to: " + FinalTarget);
            //form.OutputBox.AppendText(Environment.NewLine + "Saving chatlog to: " + FinalTarget);
            if(!System.IO.File.Exists(FinalTarget))
            {
                try
                {
                    System.IO.File.Copy(ChatLogPath, FinalTarget);
                }
                catch (System.IO.IOException e)
                {

                }
            }
        }

        public static string GetChatLogPath()
        {
            return ChatLogPath;
        }

        public static string GetChatLogTarget()
        {
            return ChatLogTarget;
        }
    }
}