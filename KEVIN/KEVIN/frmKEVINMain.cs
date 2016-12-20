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
            this.Resize += new EventHandler(frmKEVINMain_Resize);
        }

        private void frmKEVINMain_Resize(object sender, System.EventArgs e)
        {
            flpQueue.Controls.Clear();
            Functions.createQueueButtons(flpQueue, cmsQueueRightClick);
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

                    //Addpend to DB
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

        private void lblCurrentlyPlaying_Click(object sender, EventArgs e)
        {

        }

        private void tlpKEVINMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tlpPlayerBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTrackNo_Click(object sender, EventArgs e)
        {

        }

        private void flpSong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlPlaylists_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flpQueue_Paint(object sender, PaintEventArgs e)
        {

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
            while (true)
            {
                if (Functions.Timer > Functions.SongLength)
                {
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
                    string nextSongLocation = "";
                    while (readNextSong.Read())
                    {
                        nextSongLocation = readNextSong.GetString(0).Replace("'", "\\");
                    }

                    TagLib.File songDetails = TagLib.File.Create(nextSongLocation);
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
                    mpPlayer.Stop();
                    mpPlayer.Open(nextSongLocation);
                    mpPlayer.Play();
                endOfCheck:;
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

        private void tlpNoPlayingLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addToQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tlsDelete_Click(object sender, EventArgs e)
        {
            Functions.refreshConnectionToDB();
            MessageBox.Show(cmsQueueRightClick.Tag.ToString());
            string rowToDeleteSTR = cmsQueueRightClick.Tag.ToString();
            int rowToDelete= Convert.ToInt16(rowToDeleteSTR);
            int temp;
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
    }
}

