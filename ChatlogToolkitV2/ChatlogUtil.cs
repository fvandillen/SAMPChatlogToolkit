using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatlogToolkitV2
{
    public static class ChatlogUtil
    {
        public static void Backup()
        {
            // TODO: Get chatlog path.
            if(System.IO.File.Exists(Properties.Settings.Default.ChatlogPath) && System.IO.Directory.Exists(Properties.Settings.Default.BackupDirectory))
            {
                var timestamp = String.Format("{0:d-M-yyyy HH-mm-ss}", DateTime.Now);
                var targetFilename = $"{Properties.Settings.Default.BackupDirectory}\\{timestamp}.txt";

                if (!System.IO.File.Exists(targetFilename))
                {
                    try
                    {
                        System.IO.File.Copy(Properties.Settings.Default.ChatlogPath, targetFilename);
                        Properties.Settings.Default.LastBackup = DateTime.Now;
                        Properties.Settings.Default.Save();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            // TODO: Get backup path.
            // TODO: Check existence of paths.

        }

        public static void SetStartup(bool toggle)
        {
            if (toggle)
            {
                WshShell wshShell = new WshShell();
                IWshShortcut shortcut;
                string startUpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

                // Create the shortcut.
                shortcut =
                  (IWshShortcut)wshShell.CreateShortcut(
                    startUpFolderPath + "\\" +
                    Application.ProductName + ".lnk");

                shortcut.TargetPath = Application.ExecutablePath;
                shortcut.WorkingDirectory = Application.StartupPath;
                shortcut.Description = "Launch SA:MP Chatlog Toolkit";
                shortcut.IconLocation = Application.StartupPath + @"\chat.ico";
                shortcut.Save();

                Properties.Settings.Default.RunAtStartup = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                WshShell wshShell = new WshShell();
                string startUpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                System.IO.File.Delete(startUpFolderPath + "\\" + Application.ProductName + ".lnk");

                Properties.Settings.Default.RunAtStartup = false;
                Properties.Settings.Default.Save();
            }

        }

        public static string GetTimeAgo(DateTime time)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.Ticks - time.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}
