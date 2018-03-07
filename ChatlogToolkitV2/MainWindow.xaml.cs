using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Reflection;
using MahApps.Metro.Controls;
using System.Windows.Forms;
using System.Drawing;

namespace ChatlogToolkitV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChatlogToolkitWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var trayIcon = new NotifyIcon();
            trayIcon.Icon = new Icon("chat.ico");
            trayIcon.Visible = true;
            trayIcon.DoubleClick += this.TrayIcon_DoubleClick;

            if (!Properties.Settings.Default.InitialSetupComplete)
            {
                // Force the user to setup the toolkit by specifying the paths to the chatlog and backup folder.
                Console.WriteLine("The settings indicate the first time setup has not yet been run.");
                //Properties.Settings.Default.InitialSetupComplete = true;
                //Properties.Settings.Default.Save();
            }
            else
            {
                Console.WriteLine("The settings indicate the first time setup has already been run.");
            }
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        public void SetStartup(bool toggle)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (toggle)
                rk.SetValue("SAMP Chatlog Toolkit", Assembly.GetEntryAssembly().Location);
            else
                rk.DeleteValue("SAMP Chatlog Toolkit", false);

        }

        private void Settingsbutton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Toggle the settings flyout.
            this.SettingsFlyout.IsOpen = !this.SettingsFlyout.IsOpen;
        }

        private void ChatlogToolkitWindow_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
                this.Hide();
            }
        }
    }
}
