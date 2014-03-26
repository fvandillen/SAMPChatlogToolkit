namespace SAMP_ChatlogToolkit
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.InputChatlog = new System.Windows.Forms.TextBox();
            this.ButtonBrowseFile = new System.Windows.Forms.Button();
            this.LabelChatlog = new System.Windows.Forms.Label();
            this.LabelOutput = new System.Windows.Forms.Label();
            this.ButtonBrowseOutput = new System.Windows.Forms.Button();
            this.InputOutput = new System.Windows.Forms.TextBox();
            this.LabelIntro = new System.Windows.Forms.Label();
            this.ButtonResetPaths = new System.Windows.Forms.Button();
            this.LabelBugReport = new System.Windows.Forms.Label();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.ButtonCheckChatlog = new System.Windows.Forms.Button();
            this.LabelOKChatlog = new System.Windows.Forms.Label();
            this.LabelOKOutput = new System.Windows.Forms.Label();
            this.ButtonCheckOutput = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ButtonMinimizeToTray = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputChatlog
            // 
            this.InputChatlog.Location = new System.Drawing.Point(16, 35);
            this.InputChatlog.Name = "InputChatlog";
            this.InputChatlog.Size = new System.Drawing.Size(420, 20);
            this.InputChatlog.TabIndex = 0;
            // 
            // ButtonBrowseFile
            // 
            this.ButtonBrowseFile.Location = new System.Drawing.Point(485, 33);
            this.ButtonBrowseFile.Name = "ButtonBrowseFile";
            this.ButtonBrowseFile.Size = new System.Drawing.Size(75, 23);
            this.ButtonBrowseFile.TabIndex = 1;
            this.ButtonBrowseFile.Text = "Set";
            this.ButtonBrowseFile.UseVisualStyleBackColor = true;
            this.ButtonBrowseFile.Click += new System.EventHandler(this.ButtonBrowseFile_Click);
            // 
            // LabelChatlog
            // 
            this.LabelChatlog.AutoSize = true;
            this.LabelChatlog.Location = new System.Drawing.Point(13, 19);
            this.LabelChatlog.Name = "LabelChatlog";
            this.LabelChatlog.Size = new System.Drawing.Size(136, 13);
            this.LabelChatlog.TabIndex = 2;
            this.LabelChatlog.Text = "SA:MP Chatlog.txt location:";
            // 
            // LabelOutput
            // 
            this.LabelOutput.AutoSize = true;
            this.LabelOutput.Location = new System.Drawing.Point(13, 63);
            this.LabelOutput.Name = "LabelOutput";
            this.LabelOutput.Size = new System.Drawing.Size(71, 13);
            this.LabelOutput.TabIndex = 5;
            this.LabelOutput.Text = "Output folder:";
            // 
            // ButtonBrowseOutput
            // 
            this.ButtonBrowseOutput.Location = new System.Drawing.Point(485, 77);
            this.ButtonBrowseOutput.Name = "ButtonBrowseOutput";
            this.ButtonBrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.ButtonBrowseOutput.TabIndex = 4;
            this.ButtonBrowseOutput.Text = "Set";
            this.ButtonBrowseOutput.UseVisualStyleBackColor = true;
            this.ButtonBrowseOutput.Click += new System.EventHandler(this.ButtonBrowseOutput_Click);
            // 
            // InputOutput
            // 
            this.InputOutput.Location = new System.Drawing.Point(16, 79);
            this.InputOutput.Name = "InputOutput";
            this.InputOutput.Size = new System.Drawing.Size(420, 20);
            this.InputOutput.TabIndex = 3;
            // 
            // LabelIntro
            // 
            this.LabelIntro.AutoSize = true;
            this.LabelIntro.Location = new System.Drawing.Point(13, 135);
            this.LabelIntro.Name = "LabelIntro";
            this.LabelIntro.Size = new System.Drawing.Size(434, 26);
            this.LabelIntro.TabIndex = 6;
            this.LabelIntro.Text = "Click the two buttons above to set your paths. You can select your own paths in t" +
    "he future.\r\nUse the checkbox below to start the automatic backup process.\r\n";
            // 
            // ButtonResetPaths
            // 
            this.ButtonResetPaths.Location = new System.Drawing.Point(485, 118);
            this.ButtonResetPaths.Name = "ButtonResetPaths";
            this.ButtonResetPaths.Size = new System.Drawing.Size(75, 23);
            this.ButtonResetPaths.TabIndex = 7;
            this.ButtonResetPaths.Text = "Reset paths";
            this.ButtonResetPaths.UseVisualStyleBackColor = true;
            this.ButtonResetPaths.Click += new System.EventHandler(this.ButtonResetPaths_Click);
            // 
            // LabelBugReport
            // 
            this.LabelBugReport.AutoSize = true;
            this.LabelBugReport.ForeColor = System.Drawing.Color.Red;
            this.LabelBugReport.Location = new System.Drawing.Point(13, 338);
            this.LabelBugReport.Name = "LabelBugReport";
            this.LabelBugReport.Size = new System.Drawing.Size(396, 39);
            this.LabelBugReport.TabIndex = 8;
            this.LabelBugReport.Text = "If you encounter errors, please open a bug report. Be sure to provide the full ou" +
    "tput\r\nfrom the area above!\r\n\r\n";
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(16, 190);
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputBox.Size = new System.Drawing.Size(541, 140);
            this.OutputBox.TabIndex = 9;
            this.OutputBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // ButtonCheckChatlog
            // 
            this.ButtonCheckChatlog.Location = new System.Drawing.Point(16, 105);
            this.ButtonCheckChatlog.Name = "ButtonCheckChatlog";
            this.ButtonCheckChatlog.Size = new System.Drawing.Size(149, 23);
            this.ButtonCheckChatlog.TabIndex = 12;
            this.ButtonCheckChatlog.Text = "Use default chatlog location";
            this.ButtonCheckChatlog.UseVisualStyleBackColor = true;
            this.ButtonCheckChatlog.Click += new System.EventHandler(this.button5_Click);
            // 
            // LabelOKChatlog
            // 
            this.LabelOKChatlog.AutoSize = true;
            this.LabelOKChatlog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOKChatlog.ForeColor = System.Drawing.Color.Green;
            this.LabelOKChatlog.Location = new System.Drawing.Point(452, 38);
            this.LabelOKChatlog.Name = "LabelOKChatlog";
            this.LabelOKChatlog.Size = new System.Drawing.Size(0, 13);
            this.LabelOKChatlog.TabIndex = 13;
            // 
            // LabelOKOutput
            // 
            this.LabelOKOutput.AutoSize = true;
            this.LabelOKOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOKOutput.ForeColor = System.Drawing.Color.Green;
            this.LabelOKOutput.Location = new System.Drawing.Point(452, 82);
            this.LabelOKOutput.Name = "LabelOKOutput";
            this.LabelOKOutput.Size = new System.Drawing.Size(0, 13);
            this.LabelOKOutput.TabIndex = 14;
            // 
            // ButtonCheckOutput
            // 
            this.ButtonCheckOutput.Location = new System.Drawing.Point(171, 105);
            this.ButtonCheckOutput.Name = "ButtonCheckOutput";
            this.ButtonCheckOutput.Size = new System.Drawing.Size(265, 23);
            this.ButtonCheckOutput.TabIndex = 15;
            this.ButtonCheckOutput.Text = "Use default chatlog backup folder (chatlog_backup)";
            this.ButtonCheckOutput.UseVisualStyleBackColor = true;
            this.ButtonCheckOutput.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(391, 365);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(174, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Start automatic chatlog backup";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SA:MP ChatlogToolkit";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // ButtonMinimizeToTray
            // 
            this.ButtonMinimizeToTray.Location = new System.Drawing.Point(281, 361);
            this.ButtonMinimizeToTray.Name = "ButtonMinimizeToTray";
            this.ButtonMinimizeToTray.Size = new System.Drawing.Size(93, 23);
            this.ButtonMinimizeToTray.TabIndex = 17;
            this.ButtonMinimizeToTray.Text = "Minimize to tray";
            this.ButtonMinimizeToTray.UseVisualStyleBackColor = true;
            this.ButtonMinimizeToTray.Click += new System.EventHandler(this.ButtonMinimizeToTray_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 394);
            this.Controls.Add(this.ButtonMinimizeToTray);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ButtonCheckOutput);
            this.Controls.Add(this.LabelOKOutput);
            this.Controls.Add(this.LabelOKChatlog);
            this.Controls.Add(this.ButtonCheckChatlog);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.LabelBugReport);
            this.Controls.Add(this.ButtonResetPaths);
            this.Controls.Add(this.LabelIntro);
            this.Controls.Add(this.LabelOutput);
            this.Controls.Add(this.ButtonBrowseOutput);
            this.Controls.Add(this.InputOutput);
            this.Controls.Add(this.LabelChatlog);
            this.Controls.Add(this.ButtonBrowseFile);
            this.Controls.Add(this.InputChatlog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "SA:MP Chatlog Toolkit by DHR.Marcel";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputChatlog;
        private System.Windows.Forms.Button ButtonBrowseFile;
        private System.Windows.Forms.Label LabelChatlog;
        private System.Windows.Forms.Label LabelOutput;
        private System.Windows.Forms.Button ButtonBrowseOutput;
        private System.Windows.Forms.TextBox InputOutput;
        private System.Windows.Forms.Label LabelIntro;
        private System.Windows.Forms.Button ButtonResetPaths;
        private System.Windows.Forms.Label LabelBugReport;
        public System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.Button ButtonCheckChatlog;
        private System.Windows.Forms.Label LabelOKChatlog;
        private System.Windows.Forms.Label LabelOKOutput;
        private System.Windows.Forms.Button ButtonCheckOutput;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button ButtonMinimizeToTray;
    }
}

