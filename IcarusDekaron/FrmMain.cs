using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

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
            initCustomFont();
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

        private void initCustomFont()
        {
            //Create your private font collection object.
            PrivateFontCollection pfc = new PrivateFontCollection();
            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = global::IcarusDekaron.Properties.Resources.Hidden_Archives.Length;
            // create a buffer to read in to
            byte[] fontdata = global::IcarusDekaron.Properties.Resources.Hidden_Archives;
            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);
            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);
            // free up the unsafe memory
            Marshal.FreeCoTaskMem(data);
            chkSound.Font = new Font(pfc.Families[0], chkSound.Font.Size, FontStyle.Regular);
            lblPing.Font = new Font(pfc.Families[0], lblPing.Font.Size);
            lnkStart.Font = new Font(pfc.Families[0], lnkStart.Font.Size);
        }

        private void lnkStart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "bin", "dekaron.exe");
            if (System.IO.File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
                player.Stop();
                playing = false;
            }
        }

        private void lnkStart_MouseEnter(object sender, EventArgs e)
        {
            lnkStart.LinkColor = Color.Aquamarine;
        }

        private void lnkStart_MouseLeave(object sender, EventArgs e)
        {
            lnkStart.LinkColor = Color.Transparent;
        }
    }
}
