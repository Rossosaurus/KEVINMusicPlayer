//KEVIN MP Music Player Source Code
//Telling the program to use the libraries and references required
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using TagLib;
using System.IO;

namespace KEVIN
{
    public partial class frmKEVINMain : Form
    {
        bool playpause = false;
        bool playing = false;
        MusicPlayer mpPlayer = new MusicPlayer();
        Functions Functions = new Functions();
        string path;
        System.Drawing.Image albumCover = KEVIN.Properties.Resources.NoAlbumArt;

        public void mpPlay(int x)
        {
            playpause = true;
            Functions.refreshConnectionToDB();
            MySqlCommand selectSongID = new MySqlCommand("SELECT SongID FROM Music WHERE SongName = ", Functions.connect);
            MySqlCommand selectPath = new MySqlCommand("SELECT SongLocation FROM Music WHERE SongID= " + x, Functions.connect);
            MySqlDataReader readerPath = selectPath.ExecuteReader();
            while (readerPath.Read())
            {
                path = readerPath[0] as string;
                path = path.Replace("'", "\\");
            }
            mpPlayer.Stop();
            mpPlayer.Open(path);
            mpPlayer.Play();
            Functions.refreshConnectionToDB();
        }

        public frmKEVINMain()
        {
            InitializeComponent();
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
        }

        private void frmKEVINMain_Load(object sender, EventArgs e)
        {
            //Variables declared on launch
            int x = 1;
            MySqlCommand selectTrackNo = new MySqlCommand("SELECT TrackNo FROM Music");
            MySqlCommand selectSongName = new MySqlCommand("SELECT SongName FROM Music");
            MySqlCommand selectSongLength = new MySqlCommand("SELECT SongLength FROM Music");
            MySqlCommand selectAlbum = new MySqlCommand("SELECT Album FROM Music");
            MySqlCommand selectArtist = new MySqlCommand("SELECT Artist FROM Music");
            MySqlCommand selectGenre = new MySqlCommand("SELECT Genre FROM Music");

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
            pnlPlaying.Hide();
            pnlPlaylists.Hide();
            //Format of all subforms            
            flpAlbums.Location = new Point(16,3);
            flpAlbums.Size = new Size(729, 423);
            flpAlbums.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            pnlPlaying.Location = new Point(16, 3);
            pnlPlaying.Size = new Size(729, 423);
            pnlPlaying.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            pnlPlaylists.Location = new Point(16, 3);
            pnlPlaylists.Size = new Size(729, 423);
            pnlPlaylists.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

            //Connect to DB
            Functions.connectToDB();
            Functions.createAlbumButtons(x, flpAlbums);
            Functions.refreshConnectionToDB();
            

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            
        }

        private void ofdOpenMusic_FileOk(object sender, CancelEventArgs e)
        {
            //Variable decleration
            foreach (String songInfo in ofdOpenMusic.FileNames)
            {
                string pathExtension = Path.GetExtension(songInfo);
                if (pathExtension == ".mp3" || pathExtension == ".flac" || pathExtension == ".aac" || pathExtension == ".m4a" || pathExtension == ".wav")
                {
                    mpPlayer.Stop();
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
                    //strSongLength = strSongLength.Remove(0, 3);
                    //strSongLength = strSongLength.Remove(5, 8);

                    string Artist = string.Join(",", file.Tag.Artists);
                    string Album = file.Tag.Album;
                    string Genre = file.Tag.FirstGenre;
                    string Location = songInfo;
                    string sqlLocation = Location.Replace("\\", "'");

                    //Add song
                    Functions.refreshConnectionToDB();
                    this.Text = Album + " - KEVIN";
                    lblCurrentlyPlaying.Text = SongName;
                    mpPlayer.Open(ofdOpenMusic.FileName);
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
            if (playpause == false)
            {
                return;
            }
            if (playing == true)
            {
                btnPlay.BackgroundImage = KEVIN.Properties.Resources.Pause_fw;
                mpPlayer.Pause();
                playing = false;
                return;
            }
            if (playing == false)
            {
                btnPlay.BackgroundImage = KEVIN.Properties.Resources.Play_fw;
                mpPlayer.Play();
                playing = true;
                return;
            }            
        }

        private void btnSkipForward_Click(object sender, EventArgs e)
        {

        }

        private void btnAlbum_Click(object sender, EventArgs e)
        {
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
            playpause = true;
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
    }
}
