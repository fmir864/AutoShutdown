namespace ShutdownApp
{
    partial class frmShutdown
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
            this.bgwShutdownTimer = new System.ComponentModel.BackgroundWorker();
            this.pbWait = new System.Windows.Forms.ProgressBar();
            this.lblNote = new System.Windows.Forms.Label();
            this.countdown = new System.Windows.Forms.Timer(this.components);
            this.lblFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bgwShutdownTimer
            // 
            this.bgwShutdownTimer.WorkerReportsProgress = true;
            this.bgwShutdownTimer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwShutdownTimer_DoWork);
            this.bgwShutdownTimer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwShutdownTimer_ProgressChanged);
            this.bgwShutdownTimer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwShutdownTimer_RunWorkerCompleted);
            // 
            // pbWait
            // 
            this.pbWait.Location = new System.Drawing.Point(12, 177);
            this.pbWait.Name = "pbWait";
            this.pbWait.Size = new System.Drawing.Size(260, 23);
            this.pbWait.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbWait.TabIndex = 0;
            // 
            // lblNote
            // 
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(13, 13);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(259, 105);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "Your PC is been infected with virus and will be shutdown in {0} seconds";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // countdown
            // 
            this.countdown.Enabled = true;
            this.countdown.Interval = 1000;
            this.countdown.Tick += new System.EventHandler(this.countdown_Tick);
            // 
            // lblFile
            // 
            this.lblFile.Location = new System.Drawing.Point(12, 154);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(260, 20);
            this.lblFile.TabIndex = 2;
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmShutdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 212);
            this.ControlBox = false;
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.pbWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmShutdown";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virus Alert!!!";
            this.Load += new System.EventHandler(this.frmShutdown_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwShutdownTimer;
        private System.Windows.Forms.ProgressBar pbWait;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Timer countdown;
        private System.Windows.Forms.Label lblFile;
    }
}

