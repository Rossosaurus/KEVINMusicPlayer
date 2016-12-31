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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKEVINAlbum));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAlbumName = new System.Windows.Forms.Label();
            this.flpEverything = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.flpSongsWrapper = new System.Windows.Forms.FlowLayoutPanel();
            this.lblArtistAndGenre = new System.Windows.Forms.Label();
            this.pbAlbumArt = new System.Windows.Forms.PictureBox();
            this.cmsRightClickSongs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader.SuspendLayout();
            this.flpEverything.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumArt)).BeginInit();
            this.cmsRightClickSongs.SuspendLayout();
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
            // flpSongsWrapper
            // 
            this.flpSongsWrapper.AutoScroll = true;
            this.flpSongsWrapper.Location = new System.Drawing.Point(259, 18);
            this.flpSongsWrapper.Name = "flpSongsWrapper";
            this.flpSongsWrapper.Size = new System.Drawing.Size(475, 326);
            this.flpSongsWrapper.TabIndex = 2;
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
            // cmsRightClickSongs
            // 
            this.cmsRightClickSongs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.addToQueueToolStripMenuItem,
            this.addToPlaylistToolStripMenuItem});
            this.cmsRightClickSongs.Name = "cmsRightClickAlbums";
            this.cmsRightClickSongs.Size = new System.Drawing.Size(153, 92);
            this.cmsRightClickSongs.Opening += new System.ComponentModel.CancelEventHandler(this.cmsRightClickSongs_Opening);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // addToQueueToolStripMenuItem
            // 
            this.addToQueueToolStripMenuItem.Name = "addToQueueToolStripMenuItem";
            this.addToQueueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToQueueToolStripMenuItem.Text = "Add to Queue";
            this.addToQueueToolStripMenuItem.Click += new System.EventHandler(this.addToQueueToolStripMenuItem_Click);
            // 
            // addToPlaylistToolStripMenuItem
            // 
            this.addToPlaylistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlaylistToolStripMenuItem});
            this.addToPlaylistToolStripMenuItem.Name = "addToPlaylistToolStripMenuItem";
            this.addToPlaylistToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToPlaylistToolStripMenuItem.Text = "Add to Playlist";
            // 
            // newPlaylistToolStripMenuItem
            // 
            this.newPlaylistToolStripMenuItem.Name = "newPlaylistToolStripMenuItem";
            this.newPlaylistToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newPlaylistToolStripMenuItem.Text = "New Playlist";
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
            this.cmsRightClickSongs.ResumeLayout(false);
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
        public System.Windows.Forms.ContextMenuStrip cmsRightClickSongs;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPlaylistToolStripMenuItem;
    }
}