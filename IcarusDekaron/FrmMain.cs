using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Net.NetworkInformation;

namespace IcarusDekaron
{
    public partial class frmMain : Form
    {
        SoundPlayer player;
        bool playing = false;
        public frmMain()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown 
                && e.CloseReason != CloseReason.TaskManagerClosing)
            {
                if (this.Visible)
                {
                    e.Cancel = true;
                    this.Hide();
                    trayIcon.Visible = true;
                    trayIcon.ShowBalloonTip(1, "Launcher minimized", "Double click to open", ToolTipIcon.Info);
                }
                else
                    trayIcon.Visible = false;
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            trayIcon.Visible = false;
            this.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            this.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            this.Hide();
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer(global::IcarusDekaron.Properties.Resources.karon);
            player.PlayLooping();
            playing = true;
            Ping ping = new Ping();
            PingReply reply = ping.Send(Properties.Settings.Default.Server);
            if (reply.Status == IPStatus.Success)
            {
                lblPing.ForeColor = Color.Green;
                lblPing.Text = "Server is reachable";
            }
            else
            {
                lblPing.ForeColor = Color.Red;
                lblPing.Text = "Server unreachable: " + reply.Status.ToString();
            }
        }

        private void chkSound_CheckedChanged(object sender, EventArgs e)
        {
            if (playing)
            {
                chkSound.Checked = false;
                player.Stop();
                playing = false;
            }
            else
            {
                chkSound.Checked = true;
                player.PlayLooping();
                playing = true;
            }
        }

        private void lblDekaron_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("./bin/Dekaron.exe", "lezzo");
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
