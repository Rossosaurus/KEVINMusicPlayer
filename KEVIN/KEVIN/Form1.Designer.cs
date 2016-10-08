namespace KEVIN
{
    partial class frmKEVINMain
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
            this.lblSong = new System.Windows.Forms.Label();
            this.lblCurrentlyPlaying = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSkipBackward = new System.Windows.Forms.Button();
            this.btnSkipForward = new System.Windows.Forms.Button();
            this.ofdOpenMusic = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lblSong
            // 
            this.lblSong.AutoSize = true;
            this.lblSong.Location = new System.Drawing.Point(12, 9);
            this.lblSong.Name = "lblSong";
            this.lblSong.Size = new System.Drawing.Size(35, 13);
            this.lblSong.TabIndex = 0;
            this.lblSong.Text = "Song:";
            // 
            // lblCurrentlyPlaying
            // 
            this.lblCurrentlyPlaying.AutoSize = true;
            this.lblCurrentlyPlaying.Location = new System.Drawing.Point(53, 9);
            this.lblCurrentlyPlaying.Name = "lblCurrentlyPlaying";
            this.lblCurrentlyPlaying.Size = new System.Drawing.Size(148, 13);
            this.lblCurrentlyPlaying.TabIndex = 1;
            this.lblCurrentlyPlaying.Text = "-----------------------------------------------";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(12, 37);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(126, 37);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(68, 66);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSkipBackward
            // 
            this.btnSkipBackward.Location = new System.Drawing.Point(12, 95);
            this.btnSkipBackward.Name = "btnSkipBackward";
            this.btnSkipBackward.Size = new System.Drawing.Size(75, 23);
            this.btnSkipBackward.TabIndex = 5;
            this.btnSkipBackward.Text = "<<";
            this.btnSkipBackward.UseVisualStyleBackColor = true;
            // 
            // btnSkipForward
            // 
            this.btnSkipForward.Location = new System.Drawing.Point(126, 95);
            this.btnSkipForward.Name = "btnSkipForward";
            this.btnSkipForward.Size = new System.Drawing.Size(75, 23);
            this.btnSkipForward.TabIndex = 6;
            this.btnSkipForward.Text = ">>";
            this.btnSkipForward.UseVisualStyleBackColor = true;
            // 
            // ofdOpenMusic
            // 
            this.ofdOpenMusic.DefaultExt = "mp3";
            this.ofdOpenMusic.FileName = "ofdOpenMusic";
            this.ofdOpenMusic.InitialDirectory = "C:\\Users\\Ross\\Music";
            this.ofdOpenMusic.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdOpenMusic_FileOk);
            // 
            // frmKEVINMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 125);
            this.Controls.Add(this.btnSkipForward);
            this.Controls.Add(this.btnSkipBackward);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblCurrentlyPlaying);
            this.Controls.Add(this.lblSong);
            this.Name = "frmKEVINMain";
            this.Text = "KEVIN";
            this.Load += new System.EventHandler(this.frmKEVINMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSong;
        private System.Windows.Forms.Label lblCurrentlyPlaying;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSkipBackward;
        private System.Windows.Forms.Button btnSkipForward;
        private System.Windows.Forms.OpenFileDialog ofdOpenMusic;
    }
}

