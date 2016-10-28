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
                flpTrackNo.Controls.Add(new Button()
                {
                    Name = "btnTrackNo" + x,
                    Text = trackNoReader[0] as string,
                    BackColor = Color.Transparent,
                    FlatStyle = FlatStyle.Flat,
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    Width = flpArtist.Width,
                    ForeColor = ColorTranslator.FromHtml("#444444"),
                    Font = new Font("Trebuchet MS", 9),
                    Enabled = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    FlatAppearance =
                    {
                        BorderSize = 0
                    }
                });
                x++;
            }
            x = 1;
            selectTrackNo.Connection.Close();
            DB.KEVINDBOnLoad();
            selectSongName.Connection = DB.connect;
            MySqlDataReader songNameReader = selectSongName.ExecuteReader();
            while (songNameReader.Read())
            {
                flpSong.Controls.Add(new Button
                {
                    Name = "btnSong" + x,
                    Text = songNameReader[0] as string,
                    BackColor = Color.Transparent,
                    FlatStyle = FlatStyle.Flat,
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    Width = flpArtist.Width,
                    ForeColor = ColorTranslator.FromHtml("#444444"),
                    Font = new Font("Trebuchet MS", 9),
                    Enabled = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    FlatAppearance =
                    {
                        BorderSize = 0
                    }
                });
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
                y = y.Remove(0, 3);
                y = y.Remove(5, 8);
                flpSongLength.Controls.Add(new Button
                {
                    Name = "btnSongLength" + x,
                    Text = y,
                    BackColor = Color.Transparent,
                    FlatStyle = FlatStyle.Flat,
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    Width = flpArtist.Width,
                    ForeColor = ColorTranslator.FromHtml("#444444"),
                    Font = new Font("Trebuchet MS", 9),
                    Enabled = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    FlatAppearance =
                    {
                        BorderSize = 0
                    }
                });
            }
            x = 1;
            selectSongLength.Connection.Close();
            DB.KEVINDBOnLoad();
            selectAlbum.Connection = DB.connect;
            MySqlDataReader albumReader = selectAlbum.ExecuteReader();
            while (albumReader.Read())
            {
                flpAlbum.Controls.Add(new Button
                {
                    Name = "lblAlbum" + x,
                    Text = albumReader[0] as string,
                    BackColor = Color.Transparent,
                    FlatStyle = FlatStyle.Flat,
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    Width = flpArtist.Width,
                    ForeColor = ColorTranslator.FromHtml("#444444"),
                    Font = new Font("Trebuchet MS", 9),
                    Enabled = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    FlatAppearance =
                    {
                        BorderSize = 0
                    }
                });
            }
            x = 1;
            selectAlbum.Connection.Close();
            DB.KEVINDBOnLoad();
            selectArtist.Connection = DB.connect;
            MySqlDataReader artistReader = selectArtist.ExecuteReader();
            while (artistReader.Read())
            {
                flpArtist.Controls.Add(new Button
                {
                    Name = "btnArtist" + x,
                    Text = artistReader[0] as string,
                    BackColor = Color.Transparent,
                    FlatStyle = FlatStyle.Flat,
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    Width = flpArtist.Width,
                    ForeColor = ColorTranslator.FromHtml("#444444"),
                    Font = new Font("Trebuchet MS", 9),
                    Enabled = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    FlatAppearance =
                    {
                        BorderSize = 0
                    }
                });
            }
            x = 1;
            selectArtist.Connection.Close();
            DB.KEVINDBOnLoad();
            selectGenre.Connection = DB.connect;
            MySqlDataReader genreReader = selectGenre.ExecuteReader();
            while (genreReader.Read())
            {
                flpGenre.Controls.Add(new Button
                {
                    Name = "btnGenre" + x,
                    Text = genreReader[0] as string,
                    FlatStyle = FlatStyle.Flat,
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    Width = flpArtist.Width,
                    ForeColor = ColorTranslator.FromHtml("#444444"),
                    Font = new Font("Trebuchet MS", 9),
                    Enabled = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    FlatAppearance =
                    {
                        BorderSize = 0
                    }
                });
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
            string Artist = string.Join(",", file.Tag.AlbumArtists);
            string Album = file.Tag.Album;
            string Genre = file.Tag.FirstGenre;
            string Location = ofdOpenMusic.FileName;
            string sqlLocation = Location.Replace("\\", "\\\"");

            //Add song
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
            Application.Restart();
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

        private void btnStop_Click(object sender, EventArgs e)
        {
            mpPlayer.Stop();
            this.Text = "KEVIN MP";
            btnPlay.BackgroundImage = KEVIN.Properties.Resources.Pause_fw;
            playpause = false;
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
