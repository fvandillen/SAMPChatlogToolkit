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
using System.IO;
using System.Diagnostics;

namespace ChatlogToolkitV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public bool BackupActive = false;
        public Timer BackupTimer;
        public Timer LastBackupTimer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChatlogToolkitWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Upgrade();

            var trayIcon = new NotifyIcon();
            trayIcon.Icon = new Icon("chat.ico");
            trayIcon.Visible = true;
            trayIcon.DoubleClick += this.TrayIcon_DoubleClick;

            if (!Properties.Settings.Default.InitialSetupComplete)
            {
                // Force the user to setup the toolkit by specifying the paths to the chatlog and backup folder.
                this.FirstTimeSetupPanel.Visibility = Visibility.Visible;
                this.Settingsbutton.IsEnabled = false;
            }
            else
            {
                this.StatusPanel.Visibility = Visibility.Visible;
                this.Settingsbutton.IsEnabled = true;
                if(Properties.Settings.Default.LastBackup.Year < 1900)
                {
                    this.LastBackupTimeTextBox.Text = "Never";
                }
                else
                {
                    this.LastBackupTimeTextBox.Text = ChatlogUtil.GetTimeAgo(Properties.Settings.Default.LastBackup);
                }
            }


            this.SettingsToggleOnStartup.IsChecked = Properties.Settings.Default.RunAtStartup;
            this.SettingsToggleBackupOnStart.IsChecked = Properties.Settings.Default.BackupAtStartup;

            this.LastBackupTimer = new Timer();
            this.LastBackupTimer.Interval = 10000;
            this.LastBackupTimer.Tick += this.LastBackupTimer_Tick;
            this.LastBackupTimer.Enabled = true;

            if (Properties.Settings.Default.BackupAtStartup)
            {
                Console.WriteLine("Backup on startup is true, enabling backup!");

                // Turn on.
                this.BackupTimer = new Timer();
                this.BackupTimer.Interval = 10000;
                this.BackupTimer.Tick += this.BackupTimer_Tick;
                this.BackupTimer.Enabled = true;

                // TODO: Change button.
                this.BackupStatusText.Text = "Backup active";
                this.BackupStatusText.Foreground = System.Windows.Media.Brushes.ForestGreen;
                this.BackupStatusSubText.Text = "Click to disable backup";

                this.BackupActive = true;
            }
            else
            {
                Console.WriteLine("Backup on startup is false, not enabling backup.");
            }
        }

        private void LastBackupTimer_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LastBackup.Year < 1900)
            {
                this.LastBackupTimeTextBox.Text = "Never";
            }
            else
            {
                this.LastBackupTimeTextBox.Text = ChatlogUtil.GetTimeAgo(Properties.Settings.Default.LastBackup);
            }
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
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

        private void FirstSetupChatlogLocationButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            bool? result = dialog.ShowDialog();
            if ((result.HasValue) && (result.Value))
            {
                this.FirstSetupChatlogLocationTextBox.Text = dialog.FileName;
            }
        }

        private void FirstSetupBackupLocationButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                this.FirstSetupBackupLocationTextBox.Text = dialog.SelectedPath;
            }
        }

        private void FirstSetupConfirm_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Check paths exist, then set on startup.
            // TODO: Persist settings.
            if (Directory.Exists(this.FirstSetupBackupLocationTextBox.Text))
            {
                Properties.Settings.Default.BackupDirectory = this.FirstSetupBackupLocationTextBox.Text;
                Properties.Settings.Default.Save();

                if (File.Exists(this.FirstSetupChatlogLocationTextBox.Text))
                {
                    Properties.Settings.Default.ChatlogPath = this.FirstSetupChatlogLocationTextBox.Text;

                    if (this.FirstSetupRunAtStartup.IsChecked.Value)
                    {
                        ChatlogUtil.SetStartup(true);
                    }

                    if (this.FirstSetupBackupOnStart.IsChecked.Value)
                    {
                        Properties.Settings.Default.BackupAtStartup = true;
                    }

                    Properties.Settings.Default.InitialSetupComplete = true;
                    Properties.Settings.Default.Save();
                    this.Settingsbutton.IsEnabled = true;

                    this.FirstTimeSetupPanel.Visibility = Visibility.Collapsed;
                    this.StatusPanel.Visibility = Visibility.Visible;
                }
                else
                {
                    // Error state.
                }
            }
            else
            {
                // Error state.
            }
        }

        private void SettingsToggleOnStartup_IsCheckedChanged(object sender, EventArgs e)
        {
            if (this.SettingsToggleOnStartup.IsChecked.Value)
            {
                Console.WriteLine("Setting application to run at startup.");
                ChatlogUtil.SetStartup(true);
            }
            else
            {
                Console.WriteLine("Disabled application running at startup.");
                ChatlogUtil.SetStartup(false);
            }
        }

        private void ToggleBackupButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.BackupActive)
            {
                // Turn off.
                this.BackupTimer.Enabled = false;

                // TODO: Change button.
                this.BackupStatusText.Text = "Ready to start";
                this.BackupStatusText.Foreground = System.Windows.Media.Brushes.DarkOrange;
                this.BackupStatusSubText.Text = "Click to enable backup";

                this.BackupActive = false;
            }
            else
            {
                // Turn on.
                this.BackupTimer = new Timer();
                this.BackupTimer.Interval = 10000;
                this.BackupTimer.Tick += this.BackupTimer_Tick;
                this.BackupTimer.Enabled = true;

                // TODO: Change button.
                this.BackupStatusText.Text = "Backup active";
                this.BackupStatusText.Foreground = System.Windows.Media.Brushes.ForestGreen;
                this.BackupStatusSubText.Text = "Click to disable backup";

                this.BackupActive = true;
            }
        }

        private void BackupTimer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Performing check for gta_sa.exe..");
            var processes = System.Diagnostics.Process.GetProcessesByName("gta_sa");
            if(processes.Any(x => x.MainWindowTitle == "GTA:SA:MP"))
            {
                var process = processes.First();
                process.EnableRaisingEvents = true;
                process.Exited += this.Process_Exited;
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            Console.WriteLine("Detected exit of gta_sa.exe, backing up chatlog.");
            ChatlogUtil.Backup();
        }

        private void SettingsChangeChatlogLocation_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            bool? result = dialog.ShowDialog();
            if ((result.HasValue) && (result.Value))
            {
                Properties.Settings.Default.ChatlogPath = dialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void SettingsChangeBackupLocation_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.BackupDirectory = dialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void ShowBackupDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Properties.Settings.Default.BackupDirectory);
        }

        private void SettingsToggleBackupOnStart_IsCheckedChanged(object sender, EventArgs e)
        {
            if (this.SettingsToggleBackupOnStart.IsChecked.Value)
            {
                Console.WriteLine("Toggled backup on startup, setting true.");
                Properties.Settings.Default.BackupAtStartup = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Console.WriteLine("Toggled backup on startup, setting false.");
                Properties.Settings.Default.BackupAtStartup = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
