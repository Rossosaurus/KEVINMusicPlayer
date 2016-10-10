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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKEVINMain));
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSkipBackward = new System.Windows.Forms.Button();
            this.btnSkipForward = new System.Windows.Forms.Button();
            this.ofdOpenMusic = new System.Windows.Forms.OpenFileDialog();
            this.tlpKEVINMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPlayerTopMenu = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPlayerBottom = new System.Windows.Forms.TableLayoutPanel();
            this.tlpKEVINMain.SuspendLayout();
            this.tlpPlayerBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPlay.Location = new System.Drawing.Point(208, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(63, 40);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(350, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(50, 40);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(277, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(67, 40);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSkipBackward
            // 
            this.btnSkipBackward.Location = new System.Drawing.Point(406, 3);
            this.btnSkipBackward.Name = "btnSkipBackward";
            this.btnSkipBackward.Size = new System.Drawing.Size(31, 40);
            this.btnSkipBackward.TabIndex = 5;
            this.btnSkipBackward.Text = "<<";
            this.btnSkipBackward.UseVisualStyleBackColor = true;
            // 
            // btnSkipForward
            // 
            this.btnSkipForward.Location = new System.Drawing.Point(468, 3);
            this.btnSkipForward.Name = "btnSkipForward";
            this.btnSkipForward.Size = new System.Drawing.Size(31, 40);
            this.btnSkipForward.TabIndex = 6;
            this.btnSkipForward.Text = ">>";
            this.btnSkipForward.UseVisualStyleBackColor = true;
            // 
            // ofdOpenMusic
            // 
            this.ofdOpenMusic.DefaultExt = "mp3";
            this.ofdOpenMusic.InitialDirectory = "C:\\Users\\Ross\\Music";
            this.ofdOpenMusic.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdOpenMusic_FileOk);
            // 
            // tlpKEVINMain
            // 
            this.tlpKEVINMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpKEVINMain.ColumnCount = 1;
            this.tlpKEVINMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKEVINMain.Controls.Add(this.tlpPlayerTopMenu, 0, 0);
            this.tlpKEVINMain.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tlpKEVINMain.Controls.Add(this.tlpPlayerBottom, 0, 2);
            this.tlpKEVINMain.Location = new System.Drawing.Point(-2, -1);
            this.tlpKEVINMain.Name = "tlpKEVINMain";
            this.tlpKEVINMain.RowCount = 3;
            this.tlpKEVINMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.128545F));
            this.tlpKEVINMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.75194F));
            this.tlpKEVINMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.302325F));
            this.tlpKEVINMain.Size = new System.Drawing.Size(744, 516);
            this.tlpKEVINMain.TabIndex = 7;
            this.tlpKEVINMain.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpKEVINMain_Paint);
            // 
            // tlpPlayerTopMenu
            // 
            this.tlpPlayerTopMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPlayerTopMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpPlayerTopMenu.BackgroundImage")));
            this.tlpPlayerTopMenu.ColumnCount = 2;
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 690F));
            this.tlpPlayerTopMenu.Location = new System.Drawing.Point(3, 3);
            this.tlpPlayerTopMenu.Name = "tlpPlayerTopMenu";
            this.tlpPlayerTopMenu.RowCount = 1;
            this.tlpPlayerTopMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayerTopMenu.Size = new System.Drawing.Size(738, 35);
            this.tlpPlayerTopMenu.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel3.BackgroundImage")));
            this.tableLayoutPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(14, 44);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(14, 3, 14, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(716, 423);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tlpPlayerBottom
            // 
            this.tlpPlayerBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPlayerBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpPlayerBottom.BackgroundImage")));
            this.tlpPlayerBottom.ColumnCount = 7;
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.36585F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.63415F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272F));
            this.tlpPlayerBottom.Controls.Add(this.btnPlay, 2, 0);
            this.tlpPlayerBottom.Controls.Add(this.btnOpen, 3, 0);
            this.tlpPlayerBottom.Controls.Add(this.btnStop, 4, 0);
            this.tlpPlayerBottom.Controls.Add(this.btnSkipBackward, 5, 0);
            this.tlpPlayerBottom.Controls.Add(this.btnSkipForward, 6, 0);
            this.tlpPlayerBottom.Location = new System.Drawing.Point(3, 467);
            this.tlpPlayerBottom.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tlpPlayerBottom.Name = "tlpPlayerBottom";
            this.tlpPlayerBottom.RowCount = 1;
            this.tlpPlayerBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.tlpPlayerBottom.Size = new System.Drawing.Size(738, 46);
            this.tlpPlayerBottom.TabIndex = 2;
            this.tlpPlayerBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // frmKEVINMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(740, 514);
            this.Controls.Add(this.tlpKEVINMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(718, 553);
            this.Name = "frmKEVINMain";
            this.Text = "KEVIN MP";
            this.Load += new System.EventHandler(this.frmKEVINMain_Load);
            this.tlpKEVINMain.ResumeLayout(false);
            this.tlpPlayerBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSkipBackward;
        private System.Windows.Forms.Button btnSkipForward;
        private System.Windows.Forms.OpenFileDialog ofdOpenMusic;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TableLayoutPanel tlpKEVINMain;
        private System.Windows.Forms.TableLayoutPanel tlpPlayerTopMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tlpPlayerBottom;
    }
}

