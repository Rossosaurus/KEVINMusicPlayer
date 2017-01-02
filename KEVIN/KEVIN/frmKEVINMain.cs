//KEVIN MP Music Player Source Code
//Telling the program to use the libraries and references required
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using TagLib;
using System.IO;

namespace KEVIN
{
    public partial class frmKEVINMain : Form
    {
        public static readonly KEVIN.MusicPlayer mpPlayer = new MusicPlayer();
        public static Functions Functions = new Functions();
        public static Random shuffle = new Random();
        System.Drawing.Image albumCover = KEVIN.Properties.Resources.NoAlbumArt;
        int x = 1;

        public frmKEVINMain()
        {
            InitializeComponent();
            frmTesting debug = new frmTesting(); debug.Show();
            btnAlbum.MouseEnter += new EventHandler(btnAlbum_MouseEnter);
            btnAlbum.MouseLeave += new EventHandler(btnAlbum_MouseLeave);
            btnPlayer.MouseEnter += new EventHandler(btnPlayer_MouseEnter);
            btnPlayer.MouseLeave += new EventHandler(btnPlayer_MouseLeave);
            btnPlaylists.MouseEnter += new EventHandler(btnPlaylists_MouseEnter);
            btnPlaylists.MouseLeave += new EventHandler(btnPlaylists_MouseLeave);
            btnAddMusic.MouseEnter += new EventHandler(btnAddMusic_MouseEnter);
            btnAddMusic.MouseLeave += new EventHandler(btnAddMusic_MouseLeave);
            btnSettings.MouseEnter += new EventHandler(btnSettings_MouseEnter);
            btnSettings.MouseLeave += new EventHandler(btnSettings_MouseLeave);
            btnSkipBackward.MouseEnter += new EventHandler(btnSkipBackward_MouseEnter);
            btnSkipBackward.MouseLeave += new EventHandler(btnSkipBackward_MouseLeave);
            btnSkipForward.MouseEnter += new EventHandler(btnSkipForward_MouseEnter);
            btnSkipForward.MouseLeave += new EventHandler(btnSkipForward_MouseLeave);            
            this.Resize += new EventHandler(frmKEVINMain_Resize);
        }

        private void frmKEVINMain_Resize(object sender, System.EventArgs e)
        {
            flpQueue.Controls.Clear();
            if (Functions.shuffle == false)
            {
            Functions.createQueueButtons(flpQueue, cmsQueueRightClick);
            }
            else
            {
                flpQueue.Controls.Add(new Label
                {
                    Name = "shuffle",
                    ForeColor = Color.WhiteSmoke,
                    Text = "SHUFFLE" + Environment.NewLine + "MODE" + Environment.NewLine + "ACTIVE",
                    Font = new Font("Trebuchet MS", 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                });
            }

        }

        private void frmKEVINMain_Load(object sender, EventArgs e)
        {
            //Variables declared on launch            
            MySqlCommand selectTrackNo = new MySqlCommand("SELECT TrackNo FROM Music");
            MySqlCommand selectSongName = new MySqlCommand("SELECT SongName FROM Music");
            MySqlCommand selectSongLength = new MySqlCommand("SELECT SongLength FROM Music");
            MySqlCommand selectAlbum = new MySqlCommand("SELECT Album FROM Music");
            MySqlCommand selectArtist = new MySqlCommand("SELECT Artist FROM Music");
            MySqlCommand selectGenre = new MySqlCommand("SELECT Genre FROM Music");
            Functions.SongLength = 1;

            //Set colours via hex codes
            this.BackColor = ColorTranslator.FromHtml("#444444");
            btnPlay.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            btnPlay.ForeColor = ColorTranslator.FromHtml("#3c3c3c");
            btnPlay.UseVisualStyleBackColor = false;
            btnSkipBackward.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            btnSkipForward.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            this.lblCurrentlyPlaying.ForeColor = ColorTranslator.FromHtml("#646464");
            tlpPlayerBottom.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            pbAlbumCover.BackColor = ColorTranslator.FromHtml("#444444");

            //Set pnlPlaying and pnlPlaylists to hidden
            flpAlbums.Hide();
            pnlPlaylists.Hide();

            //Format of all subforms            
            flpAlbums.Location = new Point(16, 3);
            flpAlbums.Size = new Size(729, 423);
            flpAlbums.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            pnlPlaying.Location = new Point(16, 3);
            pnlPlaying.Size = new Size(729, 423);
            pnlPlaying.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            pnlPlaylists.Location = new Point(16, 3);
            pnlPlaylists.Size = new Size(729, 423);
            pnlPlaylists.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            flpQueue.HorizontalScroll.Maximum = 0;
            flpQueue.AutoScroll = false;
            flpQueue.HorizontalScroll.Visible = false;
            flpQueue.AutoScroll = true;


            //Connect to DB
            Functions.connectToDB();
            Functions.createTables();
            Functions.refreshConnectionToDB();
            Functions.createQueueButtons(flpQueue, cmsQueueRightClick);

            //Functions onLoad
            Functions.openFirstQueueSong(lblCurrentlyPlaying, pbAlbumCover);
            bwTimer.RunWorkerAsync();
            bwPlayer.RunWorkerAsync();
        }

        private void ofdOpenMusic_FileOk(object sender, CancelEventArgs e)
        {
            //Variable decleration
            foreach (String songInfo in ofdOpenMusic.FileNames)
            {
                string pathExtension = Path.GetExtension(songInfo);
                if (pathExtension == ".mp3" || pathExtension == ".flac" || pathExtension == ".aac" || pathExtension == ".m4a" || pathExtension == ".wav")
                {
                    TagLib.File file = TagLib.File.Create(songInfo);
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(songInfo);
                    uint TrackID = file.Tag.Track;
                    string TrackIDstr = TrackID.ToString();
                    string SongName;
                    if (file.Tag.Title == null || file.Tag.Title == "")
                    {
                        SongName = ofdOpenMusic.FileName;
                    }
                    else
                    {
                        SongName = file.Tag.Title;
                    }

                    TimeSpan SongLength = file.Properties.Duration;
                    string strSongLength = SongLength.ToString();
                    string Artist = string.Join(",", file.Tag.FirstArtist);
                    string Album = file.Tag.Album;
                    string Genre = file.Tag.FirstGenre;
                    string Location = songInfo;
                    string sqlLocation = Location.Replace("\\", "'");

                    //Add song
                    Functions.refreshConnectionToDB();
                    lblCurrentlyPlaying.Text = SongName;
                    MemoryStream ms;
                    try
                    {
                        ms = new MemoryStream(file.Tag.Pictures[0].Data.Data);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                        pbAlbumCover.BackgroundImage = image;
                    }
                    catch
                    {
                        pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt;
                    }

                    flpAlbums.Hide();
                    pnlPlaying.Show();
                    pnlPlaylists.Hide();

                    //Append to DB
                    Functions.CreateAndAppendAlbumInfoToTables(Album, Artist, Genre);
                    Functions.albumExists = false;
                    Functions.createAndAppendMusicInfoToTables(Album, Artist, TrackIDstr, SongName, strSongLength, sqlLocation);
                    Functions.connect.Close();
                    //Application.Restart();
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (Functions.playing == false)
            {
                btnPlay.BackgroundImage = KEVIN.Properties.Resources.Pause_fw;
                mpPlayer.Play();
                Functions.playing = true;
            }
            else
            {
                btnPlay.BackgroundImage = KEVIN.Properties.Resources.Play_fw;
                mpPlayer.Pause();
                Functions.playing = false;
            }            
        }

        private void btnSkipForward_Click(object sender, EventArgs e)
        {
            string songLocation = "";
            if (Functions.shuffle == true)
            {
                MessageBox.Show("SKIP");
                Functions.refreshConnectionToDB();
                MySqlCommand selectRandomRecord = new MySqlCommand("SELECT SongLocation FROM Music ORDER BY RAND() LIMIT 1", Functions.connect);
                MySqlDataReader readRandomRecord = selectRandomRecord.ExecuteReader();
                while (readRandomRecord.Read())
                {
                    songLocation = readRandomRecord.GetString(0).Replace("'", "\\");
                }
                TagLib.File Tags = TagLib.File.Create(songLocation);
                Functions.SongLength = Tags.Properties.Duration.TotalSeconds;
                frmKEVINMain.mpPlayer.Stop();
                frmKEVINMain.mpPlayer.Open(songLocation);
                Functions.playing = true;
                btnPlay.BackgroundImage = Properties.Resources.Pause_fw;
                Functions.Timer = 0;
                frmKEVINMain.mpPlayer.Play();
                try
                {
                    Functions.SongLength = Tags.Properties.Duration.TotalSeconds;
                    this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = Tags.Tag.Title.ToString(); });
                    MemoryStream ms;
                    try
                    {
                        ms = new MemoryStream(Tags.Tag.Pictures[0].Data.Data);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                    }
                    catch
                    {
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                    }

                }
                catch { }
            }
            else if (Functions.repeat == true)
            {
                MessageBox.Show("SKIP");
                Functions.Timer = 0;
                mpPlayer.Stop();
                mpPlayer.Open(Functions.currentlyPlaying);                
                mpPlayer.Play();
                Functions.playing = true;
            }
            else if (Functions.shuffle == false && Functions.repeat == false)
            {
                MessageBox.Show("SKIP");
                if (Functions.currentQueueID == Functions.queueSize)
                {
                    Functions.Timer = 0;
                    mpPlayer.Stop();
                    Functions.openFirstQueueSong(lblCurrentlyPlaying, pbAlbumCover);
                    mpPlayer.Play();
                    goto endOfCheck;
                }
                Functions.refreshConnectionToDB();
                MySqlCommand selectMaxQueueID = new MySqlCommand("SELECT COUNT(*) FROM Queue", Functions.connect);
                MySqlDataReader readMaxQueueID = selectMaxQueueID.ExecuteReader();
                while (readMaxQueueID.Read())
                {
                    Functions.queueSize = readMaxQueueID.GetInt16(0);
                }
                Functions.Timer = 0;
                Functions.refreshConnectionToDB();
                MySqlCommand selectNextID = new MySqlCommand("SELECT MusicID FROM queue WHERE queueID = " + Functions.currentQueueID++, Functions.connect);
                MySqlDataReader readNextID = selectNextID.ExecuteReader();
                int nextMusicID = 0;
                while (readNextID.Read())
                {
                    nextMusicID = readNextID.GetInt16(0);
                }

                Functions.refreshConnectionToDB();
                MySqlCommand selectNextSong = new MySqlCommand("SELECT SongLocation FROM music WHERE SongID = " + nextMusicID, Functions.connect);
                MySqlDataReader readNextSong = selectNextSong.ExecuteReader();
                while (readNextSong.Read())
                {
                    songLocation = readNextSong.GetString(0).Replace("'", "\\");
                }

                TagLib.File songDetails;
                try
                {
                    songDetails = TagLib.File.Create(songLocation);
                    Functions.SongLength = songDetails.Properties.Duration.TotalSeconds;
                    this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = songDetails.Tag.Title.ToString(); });
                    MemoryStream ms;
                    try
                    {
                        ms = new MemoryStream(songDetails.Tag.Pictures[0].Data.Data);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                    }
                    catch
                    {
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                    }

                }
                catch { }
                mpPlayer.Stop();
                mpPlayer.Open(songLocation);
                mpPlayer.Play();
            }
            endOfCheck:;
        }

        private void btnSkipForward_MouseEnter(object sender, EventArgs e)
        {
            btnSkipForward.BackgroundImage = Properties.Resources.SkipFwrdHover;
        }

        private void btnSkipForward_MouseLeave(object sender, EventArgs e)
        {
            btnSkipForward.BackgroundImage = Properties.Resources.SkipFwrd_fw;
        }

        private void btnSkipBackward_Click(object sender, EventArgs e)
        {
            mpPlayer.Stop();
            mpPlayer.Open(Functions.previousSong);
            TagLib.File songDetails;
            try
            {
                songDetails = TagLib.File.Create(Functions.previousSong);
                Functions.SongLength = songDetails.Properties.Duration.TotalSeconds;
                this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = songDetails.Tag.Title.ToString(); });
                MemoryStream ms;
                try
                {
                    ms = new MemoryStream(songDetails.Tag.Pictures[0].Data.Data);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                }
                catch
                {
                    this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                }

            }
            catch { }
            mpPlayer.Play();
        }

        private void btnSkipBackward_MouseEnter(object sender, EventArgs e)
        {
            btnSkipBackward.BackgroundImage = Properties.Resources.SkipBkrwdHover;
        }

        private void btnSkipBackward_MouseLeave(object sender, EventArgs e)
        {
            btnSkipBackward.BackgroundImage = Properties.Resources.SkipBkrwd_fw;
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            if (Functions.shuffle == true)
            {
                Functions.shuffle = false;
                btnShuffle.BackgroundImage = Properties.Resources.shuffle_fw;
                flpQueue.Controls.Clear();
                Functions.createQueueButtons(flpQueue, cmsQueueRightClick);            
            }
            else if (Functions.shuffle == false)
            {
                Functions.shuffle = true;
                btnShuffle.BackgroundImage = Properties.Resources.shuffleSelected;
                flpQueue.Controls.Clear();
                flpQueue.Controls.Add(new Label
                {
                    Name = "shuffle",
                    ForeColor = Color.WhiteSmoke,
                    Text = "SHUFFLE" + Environment.NewLine + "MODE" + Environment.NewLine + "ACTIVE",
                    Font = new Font("Trebuchet MS", 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                });
                string songLocation = "";
                Functions.refreshConnectionToDB();
                MySqlCommand selectRandomRecord = new MySqlCommand("SELECT SongLocation FROM Music ORDER BY RAND() LIMIT 1", Functions.connect);
                MySqlDataReader readRandomRecord = selectRandomRecord.ExecuteReader();
                while (readRandomRecord.Read())
                {
                    songLocation = readRandomRecord.GetString(0).Replace("'", "\\");
                }
                TagLib.File Tags = TagLib.File.Create(songLocation);
                Functions.SongLength = Tags.Properties.Duration.TotalSeconds;
                frmKEVINMain.mpPlayer.Stop();
                frmKEVINMain.mpPlayer.Open(songLocation);
                Functions.currentlyPlaying = songLocation;
                Functions.playing = true;
                btnPlay.BackgroundImage = Properties.Resources.Pause_fw;
                Functions.Timer = 0;
                frmKEVINMain.mpPlayer.Play();
                try
                {
                    Functions.SongLength = Tags.Properties.Duration.TotalSeconds;
                    this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = Tags.Tag.Title.ToString(); });
                    MemoryStream ms;
                    try
                    {
                        ms = new MemoryStream(Tags.Tag.Pictures[0].Data.Data);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                    }
                    catch
                    {
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                    }

                }
                catch { }
            }
            
        }        

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            if  (Functions.repeat == false)
            {
                Functions.repeat = true;
                btnRepeat.BackgroundImage = Properties.Resources.repeatSelected;
            }
            else if (Functions.repeat == true)
            {
                Functions.repeat = false;
                btnRepeat.BackgroundImage = Properties.Resources.repeat_fw;
            }
        }

        private void btnAlbum_Click(object sender, EventArgs e)
        {
            Functions.createAlbumButtons(x, flpAlbums, cmsRightClickAlbums);
            pnlPlaying.Hide();
            pnlPlaylists.Hide();
            flpAlbums.Show();
        }

        private void btnAlbum_MouseEnter(object sender, EventArgs e)
        {
            btnAlbum.BackgroundImage = KEVIN.Properties.Resources.Album2_fw;
        }

        private void btnAlbum_MouseLeave(object sender, EventArgs e)
        {
            btnAlbum.BackgroundImage = KEVIN.Properties.Resources.Album_Icon;
        }

        private void btnPlayer_Click(object sender, EventArgs e)
        {
            pnlPlaying.Show();
            pnlPlaylists.Hide();
            flpAlbums.Hide();
            Functions.createQueueButtons(flpQueue, cmsQueueRightClick);
        }

        private void btnPlayer_MouseEnter(object sender, EventArgs e)
        {
            btnPlayer.BackgroundImage = KEVIN.Properties.Resources.Player2_fw;
        }

        private void btnPlayer_MouseLeave(object sender, EventArgs e)
        {
            btnPlayer.BackgroundImage = KEVIN.Properties.Resources.Music_Player_Logo_fw;
        }

        private void btnPlaylists_Click(object sender, EventArgs e)
        {
            pnlPlaying.Hide();
            pnlPlaylists.Show();
            flpAlbums.Hide();
            Functions.generatePlaylistButtons(flpPlaylists, cmsPlaylistsRightClick);
        }

        private void btnPlaylists_MouseEnter(object sender, EventArgs e)
        {
            btnPlaylists.BackgroundImage = KEVIN.Properties.Resources.Playlist2_fw;
        }

        private void btnPlaylists_MouseLeave(object sender, EventArgs e)
        {
            btnPlaylists.BackgroundImage = KEVIN.Properties.Resources.Playlist_Logo_Colour_fw;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmKEVINSettings Settings = new frmKEVINSettings();
            Settings.Show();
        }

        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            btnSettings.BackgroundImage = KEVIN.Properties.Resources.Settings_Logo_Coloured2_fw;
        }

        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            btnSettings.BackgroundImage = KEVIN.Properties.Resources.Settings_Logo_Coloured_fw;
        }

        private void btnAddMusic_Click(object sender, EventArgs e)
        {
            ofdOpenMusic.ShowDialog();
        }

        private void btnAddMusic_MouseEnter(object sender, EventArgs e)
        {
            btnAddMusic.BackgroundImage = KEVIN.Properties.Resources.AddMusic_2_fw;
        }

        private void btnAddMusic_MouseLeave(object sender, EventArgs e)
        {
            btnAddMusic.BackgroundImage = KEVIN.Properties.Resources.Add_Music_Logo_fw;
        }

        private void pbAlbumCover_Click(object sender, EventArgs e)
        {
            pbAlbumCover.BackColor = ColorTranslator.FromHtml("#444444");
        }

        private void bwTimer_DoWork(object sender, DoWorkEventArgs e)
        {
            Functions.Timer = 0;
            while (true)
            {
                while (Functions.playing == true)
                {
                    Functions.Timer++;
                    System.Threading.Thread.Sleep(1000);
                }
            }

        }

        private void bwPlayer_DoWork(object sender, DoWorkEventArgs e)
        {
            string songLocation = "";
            while (true)
            {
                Functions.previousSong = Functions.currentlyPlaying;   
                if (Functions.Timer > Functions.SongLength && Functions.shuffle == false && Functions.repeat == false)
                {
                    MessageBox.Show("NORMAL");
                    Functions.refreshConnectionToDB();
                    if (Functions.currentQueueID == Functions.queueSize)
                    {                        
                        Functions.Timer = 0;
                        mpPlayer.Stop();
                        Functions.openFirstQueueSong(lblCurrentlyPlaying, pbAlbumCover);
                        mpPlayer.Play();
                        goto endOfCheck;
                    }
                    MySqlCommand selectMaxQueueID = new MySqlCommand("SELECT COUNT(*) FROM Queue", Functions.connect);
                    MySqlDataReader readMaxQueueID = selectMaxQueueID.ExecuteReader();
                    while (readMaxQueueID.Read())
                    {
                        Functions.queueSize = readMaxQueueID.GetInt16(0);
                    }
                    Functions.Timer = 0;
                    Functions.refreshConnectionToDB();
                    MySqlCommand selectNextID = new MySqlCommand("SELECT MusicID FROM queue WHERE queueID = " + Functions.currentQueueID++, Functions.connect);
                    MySqlDataReader readNextID = selectNextID.ExecuteReader();
                    int nextMusicID = 0;
                    while (readNextID.Read())
                    {
                        nextMusicID = readNextID.GetInt16(0);
                    }

                    Functions.refreshConnectionToDB();
                    MySqlCommand selectNextSong = new MySqlCommand("SELECT SongLocation FROM music WHERE SongID = " + nextMusicID, Functions.connect);
                    MySqlDataReader readNextSong = selectNextSong.ExecuteReader();
                    while (readNextSong.Read())
                    {
                        songLocation = readNextSong.GetString(0).Replace("'", "\\");
                    }

                    TagLib.File songDetails;
                    try
                    {
                        songDetails = TagLib.File.Create(songLocation);
                        Functions.SongLength = songDetails.Properties.Duration.TotalSeconds;
                        this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = songDetails.Tag.Title.ToString(); });
                        MemoryStream ms;
                        try
                        {
                            ms = new MemoryStream(songDetails.Tag.Pictures[0].Data.Data);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                            this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                        }
                        catch
                        {
                            this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                        }

                    }
                    catch { }
                    mpPlayer.Stop();
                    mpPlayer.Open(songLocation);
                    Functions.currentlyPlaying = songLocation;
                    mpPlayer.Play();
                    endOfCheck:;
                }
                else if (Functions.Timer > Functions.SongLength && Functions.repeat == true)
                {
                    Functions.Timer = 0;
                    MessageBox.Show("REPEAT");
                    mpPlayer.Stop();
                    Functions.currentlyPlaying = songLocation;
                    mpPlayer.Open(songLocation);
                    Functions.playing = true;
                    mpPlayer.Play();
                }
                else if (Functions.Timer > Functions.SongLength && Functions.shuffle == true)
                {
                    MessageBox.Show("SHUFFLE");                   
                    Functions.refreshConnectionToDB();
                    MySqlCommand selectRandomRecord = new MySqlCommand("SELECT SongLocation FROM Music ORDER BY RAND() LIMIT 1", Functions.connect);
                    MySqlDataReader readRandomRecord = selectRandomRecord.ExecuteReader();
                    while (readRandomRecord.Read())
                    {
                        songLocation = readRandomRecord.GetString(0).Replace("'", "\\");
                    }
                    TagLib.File Tags = TagLib.File.Create(songLocation);
                    Functions.SongLength = Tags.Properties.Duration.TotalSeconds;                    
                    frmKEVINMain.mpPlayer.Stop();
                    frmKEVINMain.mpPlayer.Open(songLocation);
                    Functions.currentlyPlaying = songLocation;
                    Functions.playing = true;
                    btnPlay.BackgroundImage = Properties.Resources.Pause_fw;
                    Functions.Timer = 0;
                    frmKEVINMain.mpPlayer.Play();
                    try
                    {
                        Functions.SongLength = Tags.Properties.Duration.TotalSeconds;
                        this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = Tags.Tag.Title.ToString(); });
                        MemoryStream ms;
                        try
                        {
                            ms = new MemoryStream(Tags.Tag.Pictures[0].Data.Data);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                            this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                        }
                        catch
                        {
                            this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                        }

                    }
                    catch { }
                }
                if (Functions.stop == true)
                {
                    mpPlayer.Stop();
                    Functions.stop = false;
                }
                if (Functions.playing == true)
                {
                    mpPlayer.Play();
                    btnPlay.BackgroundImage = Properties.Resources.Pause_fw;
                }
                if (Functions.playing == false)
                {
                    mpPlayer.Pause();
                    btnPlay.BackgroundImage = Properties.Resources.Play_fw;
                }
                System.Threading.Thread.Sleep(100);

            }
        }

        private void tlsDelete_Click(object sender, EventArgs e)
        {
            Functions.refreshConnectionToDB();
            MessageBox.Show(cmsQueueRightClick.Tag.ToString());
            string rowToDeleteSTR = cmsQueueRightClick.Tag.ToString();
            int rowToDelete= Convert.ToInt16(rowToDeleteSTR);
            int numberOfRows = 1;
            MySqlCommand selectNOR = new MySqlCommand("SELECT COUNT(*) FROM Queue", Functions.connect);
            MySqlDataReader readNOR = selectNOR.ExecuteReader();
            while (readNOR.Read())
            {
                numberOfRows = readNOR.GetInt16(0);
            }
            string[,] queue = new string[numberOfRows, 2];
            MySqlCommand selectQueue = new MySqlCommand("SELECT * FROM Queue", Functions.connect2);
            MySqlDataReader readQueue = selectQueue.ExecuteReader();
            int x = 0;
            while (readQueue.Read())
            {
                queue[x, 0] = readQueue.GetString(0);
                queue[x, 1] = readQueue.GetString(1);
                x++;
            }
            x = 0;
            if (rowToDelete == numberOfRows)
            {
                Functions.refreshConnectionToDB();
                MySqlCommand deleteLastQueue = new MySqlCommand("DELETE FROM Queue Where QueueID=" + rowToDelete, Functions.connect);
                deleteLastQueue.ExecuteNonQuery();
                flpQueue.Controls.Clear();
                Functions.createQueueButtons(flpQueue, cmsQueueRightClick);
            }
            else
            {
                
                while (rowToDelete <= numberOfRows - 1)
                {
                    queue[rowToDelete - 1, 1] = queue[rowToDelete, 1];
                    rowToDelete++;
                }
                Functions.refreshConnectionToDB();
                MySqlCommand deleteQueue = new MySqlCommand("DELETE FROM Queue", Functions.connect);
                deleteQueue.ExecuteNonQuery();
                while (x <= numberOfRows - 2)
                {
                    Functions.refreshConnectionToDB();
                    MySqlCommand appendQueue = new MySqlCommand("INSERT INTO Queue(QueueID, MusicID)  Values (" + queue[x, 0] + ", " + queue[x, 1] + ")", Functions.connect);
                    appendQueue.ExecuteNonQuery();
                    x++;
                }
                flpQueue.Controls.Clear();
                Functions.createQueueButtons(flpQueue, cmsQueueRightClick);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions.openAlbumForm(cmsRightClickAlbums.Tag.ToString());
        }

        private void cmsPlaylistsRightClick_Opening(object sender, CancelEventArgs e)
        {
            ToolStripMenuItem[] deletePlaylist = new ToolStripMenuItem[1];
            ToolStripMenuItem[] playlists;
            int count = 0;
            string songName = "";
            deletePlaylist[0] = new ToolStripMenuItem();
            deletePlaylist[0].Text = "Delete Playlist";
            deletePlaylist[0].Image = Properties.Resources.Close;
            deletePlaylist[0].Click += (s, eventarg) => dropPlaylist(cmsPlaylistsRightClick.Tag.ToString());
            deleteToolStripMenuItem.DropDownItems.Clear();
            deleteToolStripMenuItem.DropDownItems.AddRange(deletePlaylist);
            Functions.refreshConnectionToDB();
            MySqlCommand countPlaylists = new MySqlCommand("SELECT COUNT(*) FROM " + cmsPlaylistsRightClick.Tag.ToString(), Functions.connect);
            MySqlDataReader readCountPlaylists = countPlaylists.ExecuteReader();
            while (readCountPlaylists.Read())
            {
                count = readCountPlaylists.GetInt16(0);
            }
            playlists = new ToolStripMenuItem[count];
            Functions.refreshConnectionToDB();
            MySqlCommand selectPlaylistSongs = new MySqlCommand("SELECT SongID FROM " + cmsPlaylistsRightClick.Tag.ToString(), Functions.connect);
            MySqlDataReader readPlaylistSongs = selectPlaylistSongs.ExecuteReader();
            count = 0;
            while (readPlaylistSongs.Read())
            {
                Functions.connect2.Close();
                Functions.connect2.Open();
                MySqlCommand selectSong = new MySqlCommand("SELECT SongName FROM music WHERE SongID=" + readPlaylistSongs.GetString(0), Functions.connect2);
                MySqlDataReader readSong = selectSong.ExecuteReader();
                while (readSong.Read())
                {
                    songName = readSong.GetString(0);
                }
                playlists[count] = new ToolStripMenuItem();
                playlists[count].Name = readPlaylistSongs.GetString(0).Replace("_", " ");
                playlists[count].Text = songName;
                playlists[count].Image = Properties.Resources.Close;
                playlists[count].Click += (s, eventarg) => Functions.deleteSongFromPlaylist(((ToolStripMenuItem)s).Tag.ToString(), cmsPlaylistsRightClick.Tag.ToString(), flpPlaylists, cmsPlaylistsRightClick);
                playlists[count].Tag = readPlaylistSongs.GetString(0);                
                count++;
            }
            deleteToolStripMenuItem.DropDownItems.AddRange(playlists);
        }

        public void dropPlaylist(string name)
        {
            Functions.refreshConnectionToDB();
            MySqlCommand dropPlaylist = new MySqlCommand("DROP TABLE " + name, Functions.connect);
            dropPlaylist.ExecuteNonQuery();
            MySqlCommand deletePlaylist = new MySqlCommand("DELETE FROM playlistinfo WHERE PlaylistName = \"" + name + "\"", Functions.connect2);
            deletePlaylist.ExecuteNonQuery();
            Functions.refreshConnectionToDB();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions.playPlaylist(cmsPlaylistsRightClick);
        }

        private void btnVDown_Click(object sender, EventArgs e)
        {
            mpPlayer.DecVol(this);
        }

        private void btnVUp_Click(object sender, EventArgs e)
        {
            mpPlayer.IncVol(this);
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            mpPlayer.Mute(this);
        }
    }
}

