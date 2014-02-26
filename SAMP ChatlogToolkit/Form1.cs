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

namespace SAMP_ChatlogToolkit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void form1_Resize(object Sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                //mynotifyicon.Visible = true;
                //mynotifyicon.ShowBalloonTip(500);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                // mynotifyicon.Visible = false;
            }
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
            if(textBox3.TextLength < 1)
            {
                // Do not print the newline since it's the first text.
                textBox3.AppendText(textBox4.Text);
                textBox4.ResetText();
            }
            else
            {
                // Print the newline because it's not the first text.
                textBox3.AppendText(Environment.NewLine + textBox4.Text);
                textBox4.ResetText();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string initialPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\GTA San Andreas User Files\\SAMP";
            string fullPath = initialPath + "\\chatlog.txt";
            Console.WriteLine("Looking for: " + fullPath);
            Console.WriteLine(File.Exists(fullPath) ? "File exists!" : "File does not exist!");
        }
    }
}
