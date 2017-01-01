namespace KEVIN
{
    public partial class frmKEVINMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKEVINMain));
            this.btnPlay = new System.Windows.Forms.Button();
            this.cmsRightClickAlbums = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSkipBackward = new System.Windows.Forms.Button();
            this.btnSkipForward = new System.Windows.Forms.Button();
            this.ofdOpenMusic = new System.Windows.Forms.OpenFileDialog();
            this.tlpKEVINMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPlayerTopMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnAlbum = new System.Windows.Forms.Button();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.btnPlaylists = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnPlayer = new System.Windows.Forms.Button();
            this.btnAddMusic = new System.Windows.Forms.Button();
            this.tlpPlayerBottom = new System.Windows.Forms.TableLayoutPanel();
            this.pbAlbumCover = new System.Windows.Forms.PictureBox();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.lblCurrentlyPlaying = new System.Windows.Forms.Label();
            this.pnlMiddleBacking = new System.Windows.Forms.Panel();
            this.pnlPlaylists = new System.Windows.Forms.Panel();
            this.flpPlaylists = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPlaying = new System.Windows.Forms.Panel();
            this.tlpNoPlayingLayout = new System.Windows.Forms.TableLayoutPanel();
            this.flpQueue = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAlbums = new System.Windows.Forms.FlowLayoutPanel();
            this.bwTimer = new System.ComponentModel.BackgroundWorker();
            this.bwPlayer = new System.ComponentModel.BackgroundWorker();
            this.cmsQueueRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlsPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPlaylistsRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shuffleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wholePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRightClickAlbums.SuspendLayout();
            this.tlpKEVINMain.SuspendLayout();
            this.tlpPlayerTopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            this.tlpPlayerBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumCover)).BeginInit();
            this.pnlMiddleBacking.SuspendLayout();
            this.pnlPlaylists.SuspendLayout();
            this.pnlPlaying.SuspendLayout();
            this.tlpNoPlayingLayout.SuspendLayout();
            this.cmsQueueRightClick.SuspendLayout();
            this.cmsPlaylistsRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.BackgroundImage = global::KEVIN.Properties.Resources.Play_fw;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.ContextMenuStrip = this.cmsRightClickAlbums;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(636, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(40, 43);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // cmsRightClickAlbums
            // 
            this.cmsRightClickAlbums.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.cmsRightClickAlbums.Name = "cmsRightClickAlbums";
            this.cmsRightClickAlbums.Size = new System.Drawing.Size(104, 26);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // btnSkipBackward
            // 
            this.btnSkipBackward.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkipBackward.BackColor = System.Drawing.Color.Transparent;
            this.btnSkipBackward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSkipBackward.BackgroundImage")));
            this.btnSkipBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSkipBackward.FlatAppearance.BorderSize = 0;
            this.btnSkipBackward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSkipBackward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSkipBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkipBackward.Location = new System.Drawing.Point(612, 2);
            this.btnSkipBackward.Margin = new System.Windows.Forms.Padding(2);
            this.btnSkipBackward.Name = "btnSkipBackward";
            this.btnSkipBackward.Size = new System.Drawing.Size(19, 45);
            this.btnSkipBackward.TabIndex = 5;
            this.btnSkipBackward.UseVisualStyleBackColor = false;
            this.btnSkipBackward.Click += new System.EventHandler(this.btnSkipBackward_Click);
            // 
            // btnSkipForward
            // 
            this.btnSkipForward.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkipForward.BackColor = System.Drawing.Color.Transparent;
            this.btnSkipForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSkipForward.BackgroundImage")));
            this.btnSkipForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSkipForward.FlatAppearance.BorderSize = 0;
            this.btnSkipForward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSkipForward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSkipForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkipForward.Location = new System.Drawing.Point(681, 2);
            this.btnSkipForward.Margin = new System.Windows.Forms.Padding(2);
            this.btnSkipForward.Name = "btnSkipForward";
            this.btnSkipForward.Size = new System.Drawing.Size(19, 45);
            this.btnSkipForward.TabIndex = 6;
            this.btnSkipForward.UseVisualStyleBackColor = false;
            this.btnSkipForward.Click += new System.EventHandler(this.btnSkipForward_Click);
            // 
            // ofdOpenMusic
            // 
            this.ofdOpenMusic.DefaultExt = "mp3";
            this.ofdOpenMusic.InitialDirectory = "C:\\Users\\Ross\\Music";
            this.ofdOpenMusic.Multiselect = true;
            this.ofdOpenMusic.Title = "Open Music";
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
            this.tlpKEVINMain.Controls.Add(this.tlpPlayerBottom, 0, 2);
            this.tlpKEVINMain.Controls.Add(this.pnlMiddleBacking, 0, 1);
            this.tlpKEVINMain.Location = new System.Drawing.Point(-2, -1);
            this.tlpKEVINMain.Name = "tlpKEVINMain";
            this.tlpKEVINMain.RowCount = 3;
            this.tlpKEVINMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.128545F));
            this.tlpKEVINMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.75194F));
            this.tlpKEVINMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.302325F));
            this.tlpKEVINMain.Size = new System.Drawing.Size(764, 516);
            this.tlpKEVINMain.TabIndex = 7;
            this.tlpKEVINMain.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpKEVINMain_Paint);
            // 
            // tlpPlayerTopMenu
            // 
            this.tlpPlayerTopMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPlayerTopMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpPlayerTopMenu.BackgroundImage")));
            this.tlpPlayerTopMenu.ColumnCount = 8;
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740475F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740475F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740475F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.29764F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740475F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740475F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpPlayerTopMenu.Controls.Add(this.btnAlbum, 1, 0);
            this.tlpPlayerTopMenu.Controls.Add(this.tbVolume, 4, 0);
            this.tlpPlayerTopMenu.Controls.Add(this.btnPlaylists, 3, 0);
            this.tlpPlayerTopMenu.Controls.Add(this.btnSettings, 6, 0);
            this.tlpPlayerTopMenu.Controls.Add(this.btnPlayer, 2, 0);
            this.tlpPlayerTopMenu.Controls.Add(this.btnAddMusic, 5, 0);
            this.tlpPlayerTopMenu.Location = new System.Drawing.Point(3, 3);
            this.tlpPlayerTopMenu.Name = "tlpPlayerTopMenu";
            this.tlpPlayerTopMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tlpPlayerTopMenu.RowCount = 1;
            this.tlpPlayerTopMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlayerTopMenu.Size = new System.Drawing.Size(758, 35);
            this.tlpPlayerTopMenu.TabIndex = 0;
            // 
            // btnAlbum
            // 
            this.btnAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlbum.BackColor = System.Drawing.Color.Transparent;
            this.btnAlbum.BackgroundImage = global::KEVIN.Properties.Resources.Album_Icon;
            this.btnAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAlbum.FlatAppearance.BorderSize = 0;
            this.btnAlbum.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAlbum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlbum.Location = new System.Drawing.Point(13, 3);
            this.btnAlbum.Margin = new System.Windows.Forms.Padding(0);
            this.btnAlbum.Name = "btnAlbum";
            this.btnAlbum.Size = new System.Drawing.Size(34, 29);
            this.btnAlbum.TabIndex = 0;
            this.btnAlbum.UseVisualStyleBackColor = false;
            this.btnAlbum.Click += new System.EventHandler(this.btnAlbum_Click);
            // 
            // tbVolume
            // 
            this.tbVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVolume.Location = new System.Drawing.Point(118, 6);
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(552, 23);
            this.tbVolume.TabIndex = 1;
            this.tbVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // btnPlaylists
            // 
            this.btnPlaylists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlaylists.BackColor = System.Drawing.Color.Transparent;
            this.btnPlaylists.BackgroundImage = global::KEVIN.Properties.Resources.Playlist_Logo_Colour_fw;
            this.btnPlaylists.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlaylists.FlatAppearance.BorderSize = 0;
            this.btnPlaylists.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlaylists.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlaylists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaylists.Location = new System.Drawing.Point(81, 3);
            this.btnPlaylists.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlaylists.Name = "btnPlaylists";
            this.btnPlaylists.Size = new System.Drawing.Size(34, 29);
            this.btnPlaylists.TabIndex = 2;
            this.btnPlaylists.UseVisualStyleBackColor = false;
            this.btnPlaylists.Click += new System.EventHandler(this.btnPlaylists_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BackgroundImage = global::KEVIN.Properties.Resources.Settings_Logo_Coloured_fw;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(707, 3);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(34, 29);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPlayer
            // 
            this.btnPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayer.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer.BackgroundImage = global::KEVIN.Properties.Resources.Music_Player_Logo_fw;
            this.btnPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlayer.FlatAppearance.BorderSize = 0;
            this.btnPlayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer.Location = new System.Drawing.Point(47, 3);
            this.btnPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlayer.Name = "btnPlayer";
            this.btnPlayer.Size = new System.Drawing.Size(34, 29);
            this.btnPlayer.TabIndex = 3;
            this.btnPlayer.UseVisualStyleBackColor = false;
            this.btnPlayer.Click += new System.EventHandler(this.btnPlayer_Click);
            // 
            // btnAddMusic
            // 
            this.btnAddMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMusic.BackColor = System.Drawing.Color.Transparent;
            this.btnAddMusic.BackgroundImage = global::KEVIN.Properties.Resources.Add_Music_Logo_fw;
            this.btnAddMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddMusic.FlatAppearance.BorderSize = 0;
            this.btnAddMusic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddMusic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMusic.Location = new System.Drawing.Point(673, 3);
            this.btnAddMusic.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddMusic.Name = "btnAddMusic";
            this.btnAddMusic.Size = new System.Drawing.Size(34, 29);
            this.btnAddMusic.TabIndex = 1;
            this.btnAddMusic.UseVisualStyleBackColor = false;
            this.btnAddMusic.Click += new System.EventHandler(this.btnAddMusic_Click);
            // 
            // tlpPlayerBottom
            // 
            this.tlpPlayerBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPlayerBottom.ColumnCount = 8;
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.23F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.81999F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.23F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.13F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.23F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.13F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.23F));
            this.tlpPlayerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpPlayerBottom.Controls.Add(this.pbAlbumCover, 0, 0);
            this.tlpPlayerBottom.Controls.Add(this.btnPlay, 4, 0);
            this.tlpPlayerBottom.Controls.Add(this.btnSkipForward, 5, 0);
            this.tlpPlayerBottom.Controls.Add(this.btnSkipBackward, 3, 0);
            this.tlpPlayerBottom.Controls.Add(this.btnRepeat, 2, 0);
            this.tlpPlayerBottom.Controls.Add(this.btnShuffle, 6, 0);
            this.tlpPlayerBottom.Controls.Add(this.lblCurrentlyPlaying, 1, 0);
            this.tlpPlayerBottom.Location = new System.Drawing.Point(0, 467);
            this.tlpPlayerBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPlayerBottom.Name = "tlpPlayerBottom";
            this.tlpPlayerBottom.RowCount = 1;
            this.tlpPlayerBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlayerBottom.Size = new System.Drawing.Size(764, 49);
            this.tlpPlayerBottom.TabIndex = 2;
            this.tlpPlayerBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpPlayerBottom_Paint);
            // 
            // pbAlbumCover
            // 
            this.pbAlbumCover.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAlbumCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbAlbumCover.Location = new System.Drawing.Point(0, 0);
            this.pbAlbumCover.Margin = new System.Windows.Forms.Padding(0);
            this.pbAlbumCover.Name = "pbAlbumCover";
            this.pbAlbumCover.Size = new System.Drawing.Size(46, 49);
            this.pbAlbumCover.TabIndex = 7;
            this.pbAlbumCover.TabStop = false;
            this.pbAlbumCover.Click += new System.EventHandler(this.pbAlbumCover_Click);
            // 
            // btnRepeat
            // 
            this.btnRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRepeat.BackColor = System.Drawing.Color.Transparent;
            this.btnRepeat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRepeat.BackgroundImage")));
            this.btnRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRepeat.FlatAppearance.BorderSize = 0;
            this.btnRepeat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRepeat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepeat.Location = new System.Drawing.Point(566, 2);
            this.btnRepeat.Margin = new System.Windows.Forms.Padding(2);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(42, 45);
            this.btnRepeat.TabIndex = 8;
            this.btnRepeat.UseVisualStyleBackColor = false;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // btnShuffle
            // 
            this.btnShuffle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShuffle.BackColor = System.Drawing.Color.Transparent;
            this.btnShuffle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShuffle.BackgroundImage")));
            this.btnShuffle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShuffle.FlatAppearance.BorderSize = 0;
            this.btnShuffle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnShuffle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShuffle.Location = new System.Drawing.Point(705, 3);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(40, 43);
            this.btnShuffle.TabIndex = 9;
            this.btnShuffle.UseVisualStyleBackColor = false;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // lblCurrentlyPlaying
            // 
            this.lblCurrentlyPlaying.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentlyPlaying.AutoSize = true;
            this.lblCurrentlyPlaying.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentlyPlaying.Font = new System.Drawing.Font("Trebuchet MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentlyPlaying.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCurrentlyPlaying.Location = new System.Drawing.Point(49, 0);
            this.lblCurrentlyPlaying.Name = "lblCurrentlyPlaying";
            this.lblCurrentlyPlaying.Size = new System.Drawing.Size(512, 49);
            this.lblCurrentlyPlaying.TabIndex = 10;
            this.lblCurrentlyPlaying.Click += new System.EventHandler(this.lblCurrentlyPlaying_Click);
            // 
            // pnlMiddleBacking
            // 
            this.pnlMiddleBacking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMiddleBacking.Controls.Add(this.pnlPlaylists);
            this.pnlMiddleBacking.Controls.Add(this.pnlPlaying);
            this.pnlMiddleBacking.Controls.Add(this.flpAlbums);
            this.pnlMiddleBacking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddleBacking.Location = new System.Drawing.Point(0, 41);
            this.pnlMiddleBacking.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiddleBacking.Name = "pnlMiddleBacking";
            this.pnlMiddleBacking.Size = new System.Drawing.Size(764, 426);
            this.pnlMiddleBacking.TabIndex = 3;
            // 
            // pnlPlaylists
            // 
            this.pnlPlaylists.BackgroundImage = global::KEVIN.Properties.Resources.Backing;
            this.pnlPlaylists.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPlaylists.Controls.Add(this.flpPlaylists);
            this.pnlPlaylists.Location = new System.Drawing.Point(16, 3);
            this.pnlPlaylists.Name = "pnlPlaylists";
            this.pnlPlaylists.Size = new System.Drawing.Size(728, 423);
            this.pnlPlaylists.TabIndex = 2;
            this.pnlPlaylists.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPlaylists_Paint);
            // 
            // flpPlaylists
            // 
            this.flpPlaylists.BackColor = System.Drawing.Color.Transparent;
            this.flpPlaylists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPlaylists.Location = new System.Drawing.Point(0, 0);
            this.flpPlaylists.Name = "flpPlaylists";
            this.flpPlaylists.Size = new System.Drawing.Size(728, 423);
            this.flpPlaylists.TabIndex = 0;
            // 
            // pnlPlaying
            // 
            this.pnlPlaying.BackgroundImage = global::KEVIN.Properties.Resources.Backing;
            this.pnlPlaying.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPlaying.Controls.Add(this.tlpNoPlayingLayout);
            this.pnlPlaying.Location = new System.Drawing.Point(261, 3);
            this.pnlPlaying.Name = "pnlPlaying";
            this.pnlPlaying.Size = new System.Drawing.Size(247, 197);
            this.pnlPlaying.TabIndex = 1;
            // 
            // tlpNoPlayingLayout
            // 
            this.tlpNoPlayingLayout.BackColor = System.Drawing.Color.Transparent;
            this.tlpNoPlayingLayout.ColumnCount = 2;
            this.tlpNoPlayingLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.38264F));
            this.tlpNoPlayingLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.61735F));
            this.tlpNoPlayingLayout.Controls.Add(this.flpQueue, 1, 0);
            this.tlpNoPlayingLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNoPlayingLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpNoPlayingLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpNoPlayingLayout.Name = "tlpNoPlayingLayout";
            this.tlpNoPlayingLayout.RowCount = 1;
            this.tlpNoPlayingLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpNoPlayingLayout.Size = new System.Drawing.Size(247, 197);
            this.tlpNoPlayingLayout.TabIndex = 0;
            // 
            // flpQueue
            // 
            this.flpQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpQueue.AutoScroll = true;
            this.flpQueue.AutoSize = true;
            this.flpQueue.BackgroundImage = global::KEVIN.Properties.Resources.queue_fw;
            this.flpQueue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpQueue.Location = new System.Drawing.Point(191, 0);
            this.flpQueue.Margin = new System.Windows.Forms.Padding(0);
            this.flpQueue.Name = "flpQueue";
            this.flpQueue.Size = new System.Drawing.Size(56, 197);
            this.flpQueue.TabIndex = 0;
            this.flpQueue.Paint += new System.Windows.Forms.PaintEventHandler(this.flpQueue_Paint);
            // 
            // flpAlbums
            // 
            this.flpAlbums.AutoScroll = true;
            this.flpAlbums.BackgroundImage = global::KEVIN.Properties.Resources.Backing;
            this.flpAlbums.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpAlbums.Location = new System.Drawing.Point(16, 3);
            this.flpAlbums.Margin = new System.Windows.Forms.Padding(25, 3, 25, 0);
            this.flpAlbums.Name = "flpAlbums";
            this.flpAlbums.Size = new System.Drawing.Size(241, 197);
            this.flpAlbums.TabIndex = 0;
            // 
            // bwTimer
            // 
            this.bwTimer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwTimer_DoWork);
            // 
            // bwPlayer
            // 
            this.bwPlayer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwPlayer_DoWork);
            // 
            // cmsQueueRightClick
            // 
            this.cmsQueueRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsPlay,
            this.tlsDelete});
            this.cmsQueueRightClick.Name = "cmsQueueRightClick";
            this.cmsQueueRightClick.Size = new System.Drawing.Size(108, 48);
            // 
            // tlsPlay
            // 
            this.tlsPlay.Name = "tlsPlay";
            this.tlsPlay.Size = new System.Drawing.Size(107, 22);
            this.tlsPlay.Text = "Play";
            // 
            // tlsDelete
            // 
            this.tlsDelete.Name = "tlsDelete";
            this.tlsDelete.Size = new System.Drawing.Size(107, 22);
            this.tlsDelete.Text = "Delete";
            this.tlsDelete.Click += new System.EventHandler(this.tlsDelete_Click);
            // 
            // cmsPlaylistsRightClick
            // 
            this.cmsPlaylistsRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.shuffleToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsPlaylistsRightClick.Name = "cmsAlbumsRightClick";
            this.cmsPlaylistsRightClick.Size = new System.Drawing.Size(153, 92);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playToolStripMenuItem.Text = "Play";
            // 
            // shuffleToolStripMenuItem
            // 
            this.shuffleToolStripMenuItem.Name = "shuffleToolStripMenuItem";
            this.shuffleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.shuffleToolStripMenuItem.Text = "Shuffle";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wholePlaylistToolStripMenuItem});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // wholePlaylistToolStripMenuItem
            // 
            this.wholePlaylistToolStripMenuItem.Name = "wholePlaylistToolStripMenuItem";
            this.wholePlaylistToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.wholePlaylistToolStripMenuItem.Text = "Whole Playlist";
            // 
            // frmKEVINMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(760, 514);
            this.Controls.Add(this.tlpKEVINMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(718, 553);
            this.Name = "frmKEVINMain";
            this.Text = "KEVIN MP";
            this.Load += new System.EventHandler(this.frmKEVINMain_Load);
            this.cmsRightClickAlbums.ResumeLayout(false);
            this.tlpKEVINMain.ResumeLayout(false);
            this.tlpPlayerTopMenu.ResumeLayout(false);
            this.tlpPlayerTopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            this.tlpPlayerBottom.ResumeLayout(false);
            this.tlpPlayerBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumCover)).EndInit();
            this.pnlMiddleBacking.ResumeLayout(false);
            this.pnlPlaylists.ResumeLayout(false);
            this.pnlPlaying.ResumeLayout(false);
            this.tlpNoPlayingLayout.ResumeLayout(false);
            this.tlpNoPlayingLayout.PerformLayout();
            this.cmsQueueRightClick.ResumeLayout(false);
            this.cmsPlaylistsRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSkipBackward;
        private System.Windows.Forms.Button btnSkipForward;
        private System.Windows.Forms.OpenFileDialog ofdOpenMusic;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TableLayoutPanel tlpKEVINMain;
        private System.Windows.Forms.TableLayoutPanel tlpPlayerTopMenu;
        private System.Windows.Forms.TableLayoutPanel tlpPlayerBottom;
        private System.Windows.Forms.PictureBox pbAlbumCover;
        private System.Windows.Forms.Button btnRepeat;
        private System.Windows.Forms.Button btnShuffle;
        private System.Windows.Forms.Label lblCurrentlyPlaying;
        private System.Windows.Forms.Button btnAlbum;
        private System.Windows.Forms.Button btnAddMusic;
        private System.Windows.Forms.Button btnPlaylists;
        private System.Windows.Forms.Button btnPlayer;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlMiddleBacking;
        private System.Windows.Forms.Panel pnlPlaylists;
        private System.Windows.Forms.Panel pnlPlaying;
        private System.Windows.Forms.FlowLayoutPanel flpAlbums;
        public System.Windows.Forms.ContextMenuStrip cmsRightClickAlbums;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpNoPlayingLayout;
        private System.Windows.Forms.FlowLayoutPanel flpQueue;
        private System.ComponentModel.BackgroundWorker bwTimer;
        private System.ComponentModel.BackgroundWorker bwPlayer;
        private System.Windows.Forms.ContextMenuStrip cmsQueueRightClick;
        private System.Windows.Forms.ToolStripMenuItem tlsPlay;
        private System.Windows.Forms.ToolStripMenuItem tlsDelete;
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.ContextMenuStrip cmsPlaylistsRightClick;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shuffleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wholePlaylistToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flpPlaylists;
    }
}

