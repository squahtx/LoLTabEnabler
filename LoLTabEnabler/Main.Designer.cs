namespace LoLTabEnabler
{
    partial class Main
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
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LaunchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.resizeTeamFortress2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayMenu
            // 
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeTeamFortress2ToolStripMenuItem,
            this.LaunchMenuItem,
            this.toolStripMenuItem1,
            this.ExitMenuItem});
            this.TrayMenu.Name = "TrayMenu";
            this.TrayMenu.Size = new System.Drawing.Size(216, 98);
            // 
            // LaunchMenuItem
            // 
            this.LaunchMenuItem.Name = "LaunchMenuItem";
            this.LaunchMenuItem.Size = new System.Drawing.Size(215, 22);
            this.LaunchMenuItem.Text = "&Launch League of Legends";
            this.LaunchMenuItem.Click += new System.EventHandler(this.LaunchMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(212, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(215, 22);
            this.ExitMenuItem.Text = "E&xit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayMenu;
            this.TrayIcon.Text = "League of Legends Tab Enabler";
            this.TrayIcon.Visible = true;
            // 
            // resizeTeamFortress2ToolStripMenuItem
            // 
            this.resizeTeamFortress2ToolStripMenuItem.Name = "resizeTeamFortress2ToolStripMenuItem";
            this.resizeTeamFortress2ToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.resizeTeamFortress2ToolStripMenuItem.Text = "&Resize Team Fortress 2";
            this.resizeTeamFortress2ToolStripMenuItem.Click += new System.EventHandler(this.resizeTeamFortress2ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Name = "Main";
            this.Text = "League of Legends Tab Enabler";
            this.VisibleChanged += new System.EventHandler(this.Main_VisibleChanged);
            this.TrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ToolStripMenuItem LaunchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeTeamFortress2ToolStripMenuItem;
    }
}

