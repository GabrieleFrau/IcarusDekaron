﻿namespace IcarusDekaron
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPing = new System.Windows.Forms.Label();
            this.chkSound = new System.Windows.Forms.CheckBox();
            this.lnkStart = new System.Windows.Forms.LinkLabel();
            this.lblBar = new System.Windows.Forms.Label();
            this.trayIconMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // prgBar
            // 
            this.prgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgBar.BackColor = System.Drawing.Color.Black;
            this.prgBar.ForeColor = System.Drawing.Color.DarkRed;
            this.prgBar.Location = new System.Drawing.Point(9, 554);
            this.prgBar.Margin = new System.Windows.Forms.Padding(0);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(779, 34);
            this.prgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgBar.TabIndex = 1;
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "IcarusLauncher";
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayIconMenuStrip
            // 
            this.trayIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.trayIconMenuStrip.Name = "trayIconMenuStrip";
            this.trayIconMenuStrip.ShowImageMargin = false;
            this.trayIconMenuStrip.Size = new System.Drawing.Size(72, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.openToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShowShortcutKeys = false;
            this.openToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.closeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShowShortcutKeys = false;
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::IcarusDekaron.Properties.Resources.minimize;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(631, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 64);
            this.btnExit.TabIndex = 4;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::IcarusDekaron.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(713, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 64);
            this.btnClose.TabIndex = 5;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblPing
            // 
            this.lblPing.AutoSize = true;
            this.lblPing.BackColor = System.Drawing.Color.Transparent;
            this.lblPing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPing.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPing.Location = new System.Drawing.Point(6, 9);
            this.lblPing.Name = "lblPing";
            this.lblPing.Size = new System.Drawing.Size(62, 29);
            this.lblPing.TabIndex = 7;
            this.lblPing.Text = "Ping";
            // 
            // chkSound
            // 
            this.chkSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSound.BackColor = System.Drawing.Color.Transparent;
            this.chkSound.Checked = true;
            this.chkSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSound.FlatAppearance.BorderSize = 0;
            this.chkSound.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.chkSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.chkSound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.chkSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSound.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSound.Location = new System.Drawing.Point(545, 13);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(80, 29);
            this.chkSound.TabIndex = 9;
            this.chkSound.Text = "Sound";
            this.chkSound.UseVisualStyleBackColor = false;
            this.chkSound.CheckedChanged += new System.EventHandler(this.chkSound_CheckedChanged);
            // 
            // lnkStart
            // 
            this.lnkStart.AutoSize = true;
            this.lnkStart.BackColor = System.Drawing.Color.Transparent;
            this.lnkStart.DisabledLinkColor = System.Drawing.Color.Black;
            this.lnkStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkStart.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkStart.LinkColor = System.Drawing.Color.Transparent;
            this.lnkStart.Location = new System.Drawing.Point(283, 193);
            this.lnkStart.Name = "lnkStart";
            this.lnkStart.Size = new System.Drawing.Size(234, 37);
            this.lnkStart.TabIndex = 10;
            this.lnkStart.TabStop = true;
            this.lnkStart.Text = "Icarus Dekaron";
            this.lnkStart.VisitedLinkColor = System.Drawing.Color.Transparent;
            this.lnkStart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkStart_LinkClicked);
            this.lnkStart.MouseEnter += new System.EventHandler(this.lnkStart_MouseEnter);
            this.lnkStart.MouseLeave += new System.EventHandler(this.lnkStart_MouseLeave);
            // 
            // lblBar
            // 
            this.lblBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBar.AutoSize = true;
            this.lblBar.BackColor = System.Drawing.Color.Transparent;
            this.lblBar.ForeColor = System.Drawing.Color.Transparent;
            this.lblBar.Location = new System.Drawing.Point(383, 564);
            this.lblBar.Name = "lblBar";
            this.lblBar.Size = new System.Drawing.Size(108, 13);
            this.lblBar.TabIndex = 11;
            this.lblBar.Text = "Checking for updates";
            this.lblBar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IcarusDekaron.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.lblBar);
            this.Controls.Add(this.lnkStart);
            this.Controls.Add(this.chkSound);
            this.Controls.Add(this.lblPing);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.prgBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IcarusDekaron";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.trayIconMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblPing;
        private System.Windows.Forms.CheckBox chkSound;
        private System.Windows.Forms.LinkLabel lnkStart;
        internal System.Windows.Forms.Label lblBar;
    }
}

