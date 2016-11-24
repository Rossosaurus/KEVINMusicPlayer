namespace KEVIN
{
    partial class frmKEVINAlbum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKEVINAlbum));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAlbumName = new System.Windows.Forms.Label();
            this.flpEverything = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblArtistAndGenre = new System.Windows.Forms.Label();
            this.pbAlbumArt = new System.Windows.Forms.PictureBox();
            this.flpSongsWrapper = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.flpEverything.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblAlbumName);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(753, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblAlbumName
            // 
            this.lblAlbumName.AutoSize = true;
            this.lblAlbumName.Font = new System.Drawing.Font("Trebuchet MS", 27F);
            this.lblAlbumName.Location = new System.Drawing.Point(12, 9);
            this.lblAlbumName.Name = "lblAlbumName";
            this.lblAlbumName.Size = new System.Drawing.Size(53, 44);
            this.lblAlbumName.TabIndex = 0;
            this.lblAlbumName.Text = "   ";
            // 
            // flpEverything
            // 
            this.flpEverything.Controls.Add(this.pnlHeader);
            this.flpEverything.Controls.Add(this.pnlMain);
            this.flpEverything.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpEverything.Location = new System.Drawing.Point(0, 0);
            this.flpEverything.Name = "flpEverything";
            this.flpEverything.Size = new System.Drawing.Size(746, 416);
            this.flpEverything.TabIndex = 2;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.flpSongsWrapper);
            this.pnlMain.Controls.Add(this.lblArtistAndGenre);
            this.pnlMain.Controls.Add(this.pbAlbumArt);
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(746, 356);
            this.pnlMain.TabIndex = 2;
            // 
            // lblArtistAndGenre
            // 
            this.lblArtistAndGenre.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtistAndGenre.Location = new System.Drawing.Point(16, 268);
            this.lblArtistAndGenre.Name = "lblArtistAndGenre";
            this.lblArtistAndGenre.Size = new System.Drawing.Size(236, 79);
            this.lblArtistAndGenre.TabIndex = 1;
            this.lblArtistAndGenre.Text = "Artist and Genre";
            this.lblArtistAndGenre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbAlbumArt
            // 
            this.pbAlbumArt.BackgroundImage = global::KEVIN.Properties.Resources.MainIcon_fw;
            this.pbAlbumArt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbAlbumArt.Location = new System.Drawing.Point(12, 18);
            this.pbAlbumArt.Name = "pbAlbumArt";
            this.pbAlbumArt.Size = new System.Drawing.Size(240, 240);
            this.pbAlbumArt.TabIndex = 0;
            this.pbAlbumArt.TabStop = false;
            // 
            // flpSongsWrapper
            // 
            this.flpSongsWrapper.AutoScroll = true;
            this.flpSongsWrapper.Location = new System.Drawing.Point(259, 18);
            this.flpSongsWrapper.Name = "flpSongsWrapper";
            this.flpSongsWrapper.Size = new System.Drawing.Size(475, 326);
            this.flpSongsWrapper.TabIndex = 2;
            // 
            // frmKEVINAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 416);
            this.Controls.Add(this.flpEverything);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmKEVINAlbum";
            this.Load += new System.EventHandler(this.frmKEVINAddMusic_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flpEverything.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumArt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.FlowLayoutPanel flpEverything;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pbAlbumArt;
        private System.Windows.Forms.Label lblAlbumName;
        private System.Windows.Forms.Label lblArtistAndGenre;
        private System.Windows.Forms.FlowLayoutPanel flpSongsWrapper;
    }
}