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
        DB DB = new DB();
        string path;
        string TrackNo = "lblTrackNo";
        string SongName = "lblSongName";
        string Album = "lblAlbum";
        string Artist = "lblArtist";
        string Genre = "lblGenre";

        public void mpPlay(int x)
        {
            playpause = true;
            DB.connect.Close();
            DB.KEVINDBOnLoad();
            MySqlCommand selectSongID = new MySqlCommand("SELECT SongID FROM Music WHERE SongName = ");
            MySqlCommand selectPath = new MySqlCommand("SELECT SongLocation FROM Music WHERE SongID= " + x);
            selectPath.Connection = DB.connect;
            MySqlDataReader readerPath = selectPath.ExecuteReader();
            while (readerPath.Read())
            {
                path = readerPath[0] as string;
                path = path.Replace("\"", "\\");
            }
            mpPlayer.Stop();
            mpPlayer.Open(path);
            mpPlayer.Play();
            DB.connect.Close();
            DB.KEVINDBOnLoad();
        }

        public Button AttachMethodToButton(Button b, Action buttonMethod)
        {
            b.Click += (s, e) => buttonMethod();
            return b;
        }

        public void createButton(FlowLayoutPanel field, string buttonName, int x, MySqlDataReader reader, Action buttonAction)
        {
            field.Controls.Add(AttachMethodToButton(new Button()
            {
                Name = buttonName + x,
                Text = reader[0] as string,
                FlatStyle = FlatStyle.Flat,
                AutoSize = false,
                Dock = DockStyle.Top,
                Width = flpArtist.Width,
                ForeColor = ColorTranslator.FromHtml("#444444"),
                Font = new Font("Trebuchet MS", 9),
                Enabled = true,
                TextAlign = ContentAlignment.MiddleLeft,

            }, () => mpPlay(x)));
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
            btnOpen.BackColor = Color.Transparent;
            btnSkipBackward.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            btnSkipForward.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            this.lblCurrentlyPlaying.ForeColor = ColorTranslator.FromHtml("#444444");
            this.lblAlbum.ForeColor= ColorTranslator.FromHtml("#444444");
            this.lblArtist.ForeColor = ColorTranslator.FromHtml("#444444");
            this.lblGenre.ForeColor = ColorTranslator.FromHtml("#444444");
            this.lblSong.ForeColor = ColorTranslator.FromHtml("#444444");
            this.lblSongLength.ForeColor = ColorTranslator.FromHtml("#444444");
            this.lblTrackNo.ForeColor = ColorTranslator.FromHtml("#444444");
            tlpPlayerBottom.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            pbAlbumCover.BackColor = ColorTranslator.FromHtml("#444444");

            //Connect to DB
            DB.KEVINDBOnLoad();
        
            //Add Song Information to table
            selectTrackNo.Connection = DB.connect;
            MySqlDataReader trackNoReader = selectTrackNo.ExecuteReader();
            while (trackNoReader.Read())
            {
                createButton(flpTrackNo, TrackNo, x, trackNoReader, () => mpPlay(x));
                x++;
            }
            x = 1;
            selectTrackNo.Connection.Close();
            DB.KEVINDBOnLoad();
            selectSongName.Connection = DB.connect;
            MySqlDataReader songNameReader = selectSongName.ExecuteReader();
            while (songNameReader.Read())
            {
                createButton(flpSong, SongName, x, songNameReader, () => mpPlay(x));
                x++;
            }
            x = 1;
            selectSongName.Connection.Close();
            DB.KEVINDBOnLoad();
            selectSongLength.Connection = DB.connect;
            MySqlDataReader songLengthReader = selectSongLength.ExecuteReader();
            while (songLengthReader.Read())
            {
                string y = songLengthReader[0] as string;
                
                createButton(flpSongLength, y, x, songLengthReader, () => mpPlay(x));
                x++;
            }
            x = 1;
            selectSongLength.Connection.Close();
            DB.KEVINDBOnLoad();
            selectAlbum.Connection = DB.connect;
            MySqlDataReader albumReader = selectAlbum.ExecuteReader();
            while (albumReader.Read())
            {
                createButton(flpAlbum, Album, x, albumReader, () => mpPlay(x));
                x++;
            }
            x = 1;
            selectAlbum.Connection.Close();
            DB.KEVINDBOnLoad();
            selectArtist.Connection = DB.connect;
            MySqlDataReader artistReader = selectArtist.ExecuteReader();
            while (artistReader.Read())
            {
                createButton(flpArtist, Artist, x, artistReader, () => mpPlay(x));
                x++;
            }
            x = 1;
            selectArtist.Connection.Close();
            DB.KEVINDBOnLoad();
            selectGenre.Connection = DB.connect;
            MySqlDataReader genreReader = selectGenre.ExecuteReader();
            while (genreReader.Read())
            {
                createButton(flpGenre, Genre, x, genreReader, () => mpPlay(x));

            }
            selectArtist.Connection.Close();
            DB.KEVINDBOnLoad();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            mpPlayer.Stop();
            playpause = true;
            ofdOpenMusic.ShowDialog();
        }

        private void ofdOpenMusic_FileOk(object sender, CancelEventArgs e)
        {
            //Variable decleration
            TagLib.File file = TagLib.File.Create(@ofdOpenMusic.FileName);
            string fileName = System.IO.Path.GetFileNameWithoutExtension(ofdOpenMusic.FileName);
            uint TrackID = file.Tag.Track;
            string TrackIDstr = TrackID.ToString();
            string SongName = file.Tag.Title;
            TimeSpan SongLength = file.Properties.Duration;
            string strSongLength = SongLength.ToString();
            strSongLength = strSongLength.Remove(0, 3);
            strSongLength = strSongLength.Remove(5, 8);

            string Artist = string.Join(",", file.Tag.AlbumArtists);
            string Album = file.Tag.Album;
            string Genre = file.Tag.FirstGenre;
            string Location = ofdOpenMusic.FileName;
            string sqlLocation = Location.Replace("\\", "\\\"");

            //Add song
            DB.connect.Close();
            DB.KEVINDBOnLoad();
            this.Text = SongName + " - KEVIN";
            lblCurrentlyPlaying.Text = fileName;
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
                
            }
                        
            //Addpend to DB
            DB.appendSongInformation(TrackIDstr, SongName, strSongLength, Album, Artist, Genre, sqlLocation);
            DB.connect.Close();
            //Application.Restart();
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

        private void btnAddMusic_Click(object sender, EventArgs e)
        {
            frmKEVINAddMusic addMusic = new frmKEVINAddMusic();
            addMusic.Show();
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

        
    }
}
