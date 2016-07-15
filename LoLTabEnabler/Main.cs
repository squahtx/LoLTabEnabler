using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoLTabEnabler.Interop.Win32;
using LoLTabEnabler.Properties;
using System.Diagnostics;

namespace LoLTabEnabler
{
    public partial class Main : Form
    {
        public Main()
        {
            this.InitializeComponent();
            this.TrayIcon.Icon = Icon.FromHandle(Resources.wrench.GetHicon());
            this.Visible = false;
        }

        private void Main_VisibleChanged(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Windows.RemoveWindowStyle(Windows.FindWindow("LeagueOfLegendsWindowClass", "League of Legends (TM) Client"), WindowStyle.Popup);
        }

        private void LaunchMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files\\Riot Games\\League of Legends\\lol.launcher.exe");
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resizeTeamFortress2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.SetWindowPos(Windows.FindWindow("Valve001", "Team Fortress 2"), IntPtr.Zero, 0, 0, 1440, 900, SetWindowPosFlags.NoActivate);
        }
    }
}
