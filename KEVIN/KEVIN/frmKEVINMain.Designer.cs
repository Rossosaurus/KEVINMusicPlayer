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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKEVINMain));
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSkipBackward = new System.Windows.Forms.Button();
            this.btnSkipForward = new System.Windows.Forms.Button();
            this.ofdOpenMusic = new System.Windows.Forms.OpenFileDialog();
            this.tlpKEVINMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPlayerTopMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnAlbum = new System.Windows.Forms.Button();
            this.btnPlaylists = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnPlayer = new System.Windows.Forms.Button();
            this.btnAddMusic = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSongTable = new System.Windows.Forms.Panel();
            this.tlpSong = new System.Windows.Forms.TableLayoutPanel();
            this.flpGenre = new System.Windows.Forms.FlowLayoutPanel();
            this.flpArtist = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAlbum = new System.Windows.Forms.FlowLayoutPanel();
            this.flpSongLength = new System.Windows.Forms.FlowLayoutPanel();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblSongLength = new System.Windows.Forms.Label();
            this.lblTrackNo = new System.Windows.Forms.Label();
            this.flpTrackNo = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSong = new System.Windows.Forms.Label();
            this.flpSong = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.tlpPlayerBottom = new System.Windows.Forms.TableLayoutPanel();
            this.pbAlbumCover = new System.Windows.Forms.PictureBox();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.lblCurrentlyPlaying = new System.Windows.Forms.Label();
            this.tlpKEVINMain.SuspendLayout();
            this.tlpPlayerTopMenu.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pnlSongTable.SuspendLayout();
            this.tlpSong.SuspendLayout();
            this.tlpPlayerBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumCover)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlay.BackgroundImage")));
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(616, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(39, 40);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(115, 6);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(50, 22);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
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
            this.btnSkipBackward.Location = new System.Drawing.Point(593, 2);
            this.btnSkipBackward.Margin = new System.Windows.Forms.Padding(2);
            this.btnSkipBackward.Name = "btnSkipBackward";
            this.btnSkipBackward.Size = new System.Drawing.Size(18, 42);
            this.btnSkipBackward.TabIndex = 5;
            this.btnSkipBackward.UseVisualStyleBackColor = false;
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
            this.btnSkipForward.Location = new System.Drawing.Point(660, 2);
            this.btnSkipForward.Margin = new System.Windows.Forms.Padding(2);
            this.btnSkipForward.Name = "btnSkipForward";
            this.btnSkipForward.Size = new System.Drawing.Size(18, 42);
            this.btnSkipForward.TabIndex = 6;
            this.btnSkipForward.UseVisualStyleBackColor = false;
            this.btnSkipForward.Click += new System.EventHandler(this.btnSkipForward_Click);
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
            this.tlpKEVINMain.Controls.Add(this.tlpMain, 0, 1);
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
            this.tlpPlayerTopMenu.ColumnCount = 8;
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740475F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740475F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740475F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.29764F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740475F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740475F));
            this.tlpPlayerTopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpPlayerTopMenu.Controls.Add(this.btnOpen, 4, 0);
            this.tlpPlayerTopMenu.Controls.Add(this.btnAlbum, 1, 0);
            this.tlpPlayerTopMenu.Controls.Add(this.btnPlaylists, 3, 0);
            this.tlpPlayerTopMenu.Controls.Add(this.btnSettings, 6, 0);
            this.tlpPlayerTopMenu.Controls.Add(this.btnPlayer, 2, 0);
            this.tlpPlayerTopMenu.Controls.Add(this.btnAddMusic, 5, 0);
            this.tlpPlayerTopMenu.Location = new System.Drawing.Point(3, 3);
            this.tlpPlayerTopMenu.Name = "tlpPlayerTopMenu";
            this.tlpPlayerTopMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tlpPlayerTopMenu.RowCount = 1;
            this.tlpPlayerTopMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlayerTopMenu.Size = new System.Drawing.Size(738, 35);
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
            this.btnAlbum.Size = new System.Drawing.Size(33, 29);
            this.btnAlbum.TabIndex = 0;
            this.btnAlbum.UseVisualStyleBackColor = false;
            this.btnAlbum.Click += new System.EventHandler(this.btnAlbum_Click);
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
            this.btnPlaylists.Location = new System.Drawing.Point(79, 3);
            this.btnPlaylists.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlaylists.Name = "btnPlaylists";
            this.btnPlaylists.Size = new System.Drawing.Size(33, 29);
            this.btnPlaylists.TabIndex = 2;
            this.btnPlaylists.UseVisualStyleBackColor = false;
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
            this.btnSettings.Location = new System.Drawing.Point(688, 3);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(33, 29);
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
            this.btnPlayer.Location = new System.Drawing.Point(46, 3);
            this.btnPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlayer.Name = "btnPlayer";
            this.btnPlayer.Size = new System.Drawing.Size(33, 29);
            this.btnPlayer.TabIndex = 3;
            this.btnPlayer.UseVisualStyleBackColor = false;
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
            this.btnAddMusic.Location = new System.Drawing.Point(655, 3);
            this.btnAddMusic.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddMusic.Name = "btnAddMusic";
            this.btnAddMusic.Size = new System.Drawing.Size(33, 29);
            this.btnAddMusic.TabIndex = 1;
            this.btnAddMusic.UseVisualStyleBackColor = false;
            this.btnAddMusic.Click += new System.EventHandler(this.btnAddMusic_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.AutoScroll = true;
            this.tlpMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlpMain.BackgroundImage")));
            this.tlpMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlSongTable, 0, 0);
            this.tlpMain.Location = new System.Drawing.Point(14, 44);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(14, 3, 14, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(716, 423);
            this.tlpMain.TabIndex = 1;
            // 
            // pnlSongTable
            // 
            this.pnlSongTable.BackColor = System.Drawing.Color.Transparent;
            this.pnlSongTable.Controls.Add(this.tlpSong);
            this.pnlSongTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSongTable.Location = new System.Drawing.Point(3, 3);
            this.pnlSongTable.Name = "pnlSongTable";
            this.pnlSongTable.Size = new System.Drawing.Size(710, 417);
            this.pnlSongTable.TabIndex = 6;
            // 
            // tlpSong
            // 
            this.tlpSong.AutoScrollMinSize = new System.Drawing.Size(396, 417);
            this.tlpSong.ColumnCount = 6;
            this.tlpSong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.18841F));
            this.tlpSong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.49275F));
            this.tlpSong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.57971F));
            this.tlpSong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.78261F));
            this.tlpSong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.3913F));
            this.tlpSong.Controls.Add(this.flpGenre, 5, 1);
            this.tlpSong.Controls.Add(this.flpArtist, 4, 1);
            this.tlpSong.Controls.Add(this.flpAlbum, 3, 1);
            this.tlpSong.Controls.Add(this.flpSongLength, 2, 1);
            this.tlpSong.Controls.Add(this.lblGenre, 5, 0);
            this.tlpSong.Controls.Add(this.lblSongLength, 2, 0);
            this.tlpSong.Controls.Add(this.lblTrackNo, 0, 0);
            this.tlpSong.Controls.Add(this.flpTrackNo, 0, 1);
            this.tlpSong.Controls.Add(this.lblSong, 1, 0);
            this.tlpSong.Controls.Add(this.flpSong, 1, 1);
            this.tlpSong.Controls.Add(this.lblAlbum, 3, 0);
            this.tlpSong.Controls.Add(this.lblArtist, 4, 0);
            this.tlpSong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSong.Enabled = false;
            this.tlpSong.Location = new System.Drawing.Point(0, 0);
            this.tlpSong.Name = "tlpSong";
            this.tlpSong.RowCount = 2;
            this.tlpSong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.21F));
            this.tlpSong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.79F));
            this.tlpSong.Size = new System.Drawing.Size(710, 417);
            this.tlpSong.TabIndex = 0;
            // 
            // flpGenre
            // 
            this.flpGenre.AutoSize = true;
            this.flpGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpGenre.Location = new System.Drawing.Point(594, 21);
            this.flpGenre.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flpGenre.Name = "flpGenre";
            this.flpGenre.Size = new System.Drawing.Size(116, 396);
            this.flpGenre.TabIndex = 6;
            // 
            // flpArtist
            // 
            this.flpArtist.AutoSize = true;
            this.flpArtist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpArtist.Location = new System.Drawing.Point(424, 21);
            this.flpArtist.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flpArtist.Name = "flpArtist";
            this.flpArtist.Size = new System.Drawing.Size(165, 396);
            this.flpArtist.TabIndex = 5;
            // 
            // flpAlbum
            // 
            this.flpAlbum.AutoSize = true;
            this.flpAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAlbum.Location = new System.Drawing.Point(283, 21);
            this.flpAlbum.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flpAlbum.Name = "flpAlbum";
            this.flpAlbum.Size = new System.Drawing.Size(136, 396);
            this.flpAlbum.TabIndex = 4;
            // 
            // flpSongLength
            // 
            this.flpSongLength.AutoSize = true;
            this.flpSongLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSongLength.Location = new System.Drawing.Point(184, 21);
            this.flpSongLength.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flpSongLength.Name = "flpSongLength";
            this.flpSongLength.Size = new System.Drawing.Size(94, 396);
            this.flpSongLength.TabIndex = 3;
            // 
            // lblGenre
            // 
            this.lblGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGenre.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.lblGenre.Location = new System.Drawing.Point(592, 0);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(115, 21);
            this.lblGenre.TabIndex = 7;
            this.lblGenre.Text = "Genre";
            this.lblGenre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSongLength
            // 
            this.lblSongLength.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSongLength.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.lblSongLength.Location = new System.Drawing.Point(182, 0);
            this.lblSongLength.Name = "lblSongLength";
            this.lblSongLength.Size = new System.Drawing.Size(93, 21);
            this.lblSongLength.TabIndex = 4;
            this.lblSongLength.Text = "Song Length";
            this.lblSongLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrackNo
            // 
            this.lblTrackNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrackNo.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.lblTrackNo.Location = new System.Drawing.Point(3, 0);
            this.lblTrackNo.Name = "lblTrackNo";
            this.lblTrackNo.Size = new System.Drawing.Size(14, 21);
            this.lblTrackNo.TabIndex = 0;
            this.lblTrackNo.Text = "#";
            this.lblTrackNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTrackNo.Click += new System.EventHandler(this.lblTrackNo_Click);
            // 
            // flpTrackNo
            // 
            this.flpTrackNo.AutoSize = true;
            this.flpTrackNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTrackNo.Location = new System.Drawing.Point(0, 21);
            this.flpTrackNo.Margin = new System.Windows.Forms.Padding(0);
            this.flpTrackNo.Name = "flpTrackNo";
            this.flpTrackNo.Size = new System.Drawing.Size(20, 396);
            this.flpTrackNo.TabIndex = 1;
            // 
            // lblSong
            // 
            this.lblSong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSong.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.lblSong.Location = new System.Drawing.Point(23, 0);
            this.lblSong.Name = "lblSong";
            this.lblSong.Size = new System.Drawing.Size(153, 21);
            this.lblSong.TabIndex = 3;
            this.lblSong.Text = "Song";
            this.lblSong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpSong
            // 
            this.flpSong.AutoSize = true;
            this.flpSong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSong.Location = new System.Drawing.Point(25, 21);
            this.flpSong.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flpSong.Name = "flpSong";
            this.flpSong.Size = new System.Drawing.Size(154, 396);
            this.flpSong.TabIndex = 2;
            this.flpSong.Paint += new System.Windows.Forms.PaintEventHandler(this.flpSong_Paint);
            // 
            // lblAlbum
            // 
            this.lblAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlbum.BackColor = System.Drawing.Color.Transparent;
            this.lblAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlbum.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.lblAlbum.Location = new System.Drawing.Point(281, 0);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(135, 21);
            this.lblAlbum.TabIndex = 6;
            this.lblAlbum.Text = "Album";
            this.lblAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArtist
            // 
            this.lblArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArtist.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.lblArtist.Location = new System.Drawing.Point(422, 0);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(164, 21);
            this.lblArtist.TabIndex = 5;
            this.lblArtist.Text = "Artist";
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tlpPlayerBottom.Location = new System.Drawing.Point(3, 467);
            this.tlpPlayerBottom.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tlpPlayerBottom.Name = "tlpPlayerBottom";
            this.tlpPlayerBottom.RowCount = 1;
            this.tlpPlayerBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlayerBottom.Size = new System.Drawing.Size(738, 46);
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
            this.pbAlbumCover.Size = new System.Drawing.Size(45, 46);
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
            this.btnRepeat.Location = new System.Drawing.Point(548, 2);
            this.btnRepeat.Margin = new System.Windows.Forms.Padding(2);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(41, 42);
            this.btnRepeat.TabIndex = 8;
            this.btnRepeat.UseVisualStyleBackColor = false;
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
            this.btnShuffle.Location = new System.Drawing.Point(683, 3);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(39, 40);
            this.btnShuffle.TabIndex = 9;
            this.btnShuffle.UseVisualStyleBackColor = false;
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
            this.lblCurrentlyPlaying.Location = new System.Drawing.Point(48, 0);
            this.lblCurrentlyPlaying.Name = "lblCurrentlyPlaying";
            this.lblCurrentlyPlaying.Size = new System.Drawing.Size(495, 46);
            this.lblCurrentlyPlaying.TabIndex = 10;
            this.lblCurrentlyPlaying.Click += new System.EventHandler(this.lblCurrentlyPlaying_Click);
            // 
            // frmKEVINMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(740, 514);
            this.Controls.Add(this.tlpKEVINMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(718, 553);
            this.Name = "frmKEVINMain";
            this.Text = "KEVIN MP";
            this.Load += new System.EventHandler(this.frmKEVINMain_Load);
            this.tlpKEVINMain.ResumeLayout(false);
            this.tlpPlayerTopMenu.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.pnlSongTable.ResumeLayout(false);
            this.tlpSong.ResumeLayout(false);
            this.tlpSong.PerformLayout();
            this.tlpPlayerBottom.ResumeLayout(false);
            this.tlpPlayerBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSkipBackward;
        private System.Windows.Forms.Button btnSkipForward;
        private System.Windows.Forms.OpenFileDialog ofdOpenMusic;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TableLayoutPanel tlpKEVINMain;
        private System.Windows.Forms.TableLayoutPanel tlpPlayerTopMenu;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
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
        private System.Windows.Forms.Panel pnlSongTable;
        private System.Windows.Forms.TableLayoutPanel tlpSong;
        public System.Windows.Forms.Label lblTrackNo;
        private System.Windows.Forms.FlowLayoutPanel flpTrackNo;
        private System.Windows.Forms.FlowLayoutPanel flpSong;
        public System.Windows.Forms.Label lblSong;
        public System.Windows.Forms.Label lblGenre;
        public System.Windows.Forms.Label lblAlbum;
        public System.Windows.Forms.Label lblArtist;
        public System.Windows.Forms.Label lblSongLength;
        private System.Windows.Forms.FlowLayoutPanel flpSongLength;
        private System.Windows.Forms.FlowLayoutPanel flpGenre;
        private System.Windows.Forms.FlowLayoutPanel flpArtist;
        private System.Windows.Forms.FlowLayoutPanel flpAlbum;
    }
}

