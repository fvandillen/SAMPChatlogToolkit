using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Timers;

namespace SAMP_ChatlogToolkit
{
    public partial class MainWindow : Form
    {
        int SAMPactive;
        int GTAactive;
        int RunMode;
        string ChatLogPath = "";
        string ChatLogTarget = "";
        static System.Timers.Timer aTimer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Console.Out.WriteLine("The text in TextBox3 should be changed now.");
            Console.Out.WriteLine(sender.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string initialPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\GTA San Andreas User Files\\SAMP";
            string fullPath = initialPath + "\\chatlog.txt";
            Console.WriteLine("Looking for: " + fullPath);
            ChatLogPath = fullPath;
            Console.WriteLine(File.Exists(fullPath) ? "File exists!" : "File does not exist!"); // test
            if(File.Exists(fullPath))
            {
                InputChatlog.Text = fullPath;
                InputChatlog.Enabled = false;
                LabelOKChatlog.Text = "OK";
                OutputBox.AppendText(Environment.NewLine + "Found chatlog.txt at: " + fullPath);
                ChatlogToolkit.ChatLogPath = fullPath;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\GTA San Andreas User Files\\SAMP\\chatlog_backup";
            Console.WriteLine("Looking for: " + fullPath);
            ChatLogTarget = fullPath;
            Console.WriteLine(Directory.Exists(fullPath) ? "Folder exists!" : "Folder does not exist!");
            if (Directory.Exists(fullPath))
            {
                InputOutput.Text = fullPath;
                InputOutput.Enabled = false;
                LabelOKOutput.Text = "OK";
                OutputBox.AppendText(Environment.NewLine + "Found output folder at: " + fullPath);
                ChatlogToolkit.ChatLogTarget = fullPath;
            }
            else
            {
                // Requested folder does not exist, create it.
                System.IO.Directory.CreateDirectory(fullPath);
                OutputBox.AppendText(Environment.NewLine + "Output folder not found, creating: " + fullPath);
            }
        }

        private void ButtonBrowseFile_Click(object sender, EventArgs e)
        {
                
            string fullPath = InputChatlog.Text;
            Console.WriteLine("Looking for: " + fullPath);
            ChatLogPath = fullPath;
            Console.WriteLine(File.Exists(fullPath) ? "File exists!" : "File does not exist!");
            if (File.Exists(fullPath))
            {
                InputChatlog.Text = fullPath;
                InputChatlog.Enabled = false;
                LabelOKChatlog.Text = "OK";
                OutputBox.AppendText(Environment.NewLine + "Found chatlog.txt at: " + fullPath);
                ChatlogToolkit.ChatLogPath = fullPath;
            }
        }


        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ChatlogToolkit.LaunchTimer();
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ButtonBrowseOutput_Click(object sender, EventArgs e)
        {
            string fullPath = InputOutput.Text;
            Console.WriteLine("Looking for: " + fullPath);
            ChatLogTarget = fullPath;
            Console.WriteLine(Directory.Exists(fullPath) ? "Folder exists!" : "Folder does not exist!");
            if (Directory.Exists(fullPath))
            {
                InputOutput.Text = fullPath;
                InputOutput.Enabled = false;
                LabelOKOutput.Text = "OK";
                OutputBox.AppendText(Environment.NewLine + "Found output folder at: " + fullPath);
                ChatlogToolkit.ChatLogTarget = fullPath;
            }
            else
            {
                // Requested folder does not exist, create it.
                System.IO.Directory.CreateDirectory(fullPath);
                OutputBox.AppendText(Environment.NewLine + "Output folder not found, creating: " + fullPath);
                //InputOutput.Text = fullPath;
                InputOutput.Enabled = false;
                LabelOKOutput.Text = "OK";
            }
        }

        private void ButtonMinimizeToTray_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void ButtonResetPaths_Click(object sender, EventArgs e)
        {
            // This will also stop the timer because no paths will be accessible anymore
            ChatlogToolkit.StopTimer();
            InputOutput.Enabled = true;
            InputOutput.Text = "";
            InputChatlog.Enabled = true;
            InputChatlog.Text = "";

            LabelOKChatlog.Text = "";
            LabelOKOutput.Text = "";

            checkBox1.Checked = false;
        }
    }
}
