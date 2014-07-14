using System;
using System.Drawing;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace IcarusDekaron
{
    public partial class frmMain : Form
    {
        SoundPlayer player = null;
        bool playing = false;
        Task task;
        Timer timer;

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
            this.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            PingReply reply = ping.Send(IcarusDekaron.Server.Address);
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
            if (checkForUpdates())
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadDataCompleted += client_DownloadDataCompleted;
                client.DownloadDataAsync(new Uri("http://html5pwns.altervista.org/update.zip"));
            }
            else
                lblBar.Text = "Client up to date.";
        }

        void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Cancelled)
                lblBar.Text = "Download failed " + ((e.Error != null) ? e.Error.Message : " ");
            else
            {
                lblBar.Text = "Download succeded. Extracting....";
                MemoryStream stream = new MemoryStream(e.Result);
                Action<object> actionDecompress = (object ret) =>
                        {
                            ZipArchive archive = new ZipArchive((MemoryStream)ret, ZipArchiveMode.Read);
                            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IcarusDekaron");
                            if (Directory.Exists(path))
                                Directory.Delete(path, true);
                            archive.ExtractToDirectory(path);
                        };
                task = new Task((Action<object>)actionDecompress, stream);
                task.Start();
                timer = new Timer();
                timer.Interval = 1000;
                timer.Tick += timer_Tick;
                timer.Start();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (task.IsCompleted)
            {
                lblBar.Text = "Stuff extracted. Installing";
                prgBar.Value = 75;
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IcarusDekaron");
                string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    string newfile = file.Replace(path, Directory.GetCurrentDirectory());
                    if (File.Exists(newfile))
                    {
                        File.Replace(file, newfile, newfile + ".bak");
                        File.SetAttributes(newfile + ".bak", FileAttributes.Hidden);
                    }
                    else
                        File.Move(file, newfile);
                    prgBar.Step = 100 / files.Length;
                    prgBar.PerformStep();
                }
                lblBar.Text = "Game updated";
            }
            else if (task.IsCanceled || task.IsFaulted)
            {
                lblBar.Text = "There has been an error when extracting: " + ((task.Exception != null) ? task.Exception.Message : " ");
            }
            timer.Stop();
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            prgBar.Value = e.ProgressPercentage / 2;
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

        private void frmMain_Shown(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
        }

        private bool checkForUpdates()
        {
            WebClient webclient = new WebClient();
            long clientVer = Convert.ToInt64(global::IcarusDekaron.Properties.Resources.Version);
            long serverVer = Convert.ToInt64(webclient.DownloadString(IcarusDekaron.Server.Version));
            return (clientVer < serverVer);
        }
    }
}
