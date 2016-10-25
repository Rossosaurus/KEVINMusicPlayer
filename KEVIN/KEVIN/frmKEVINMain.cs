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
        }

        private void frmKEVINMain_Load(object sender, EventArgs e)
        {
            //Variables declared on launch
            int x = 1;
            MySqlCommand selectTrackNo = new MySqlCommand("SELECT TrackNo FROM Music");
            MySqlCommand selectSongName = new MySqlCommand("SELECT SongName FROM Music WHERE TrackNo=" + x);
            MySqlCommand selectAlbum = new MySqlCommand("SELECT Album FROM Music WHERE TrackNo=" + x);
            MySqlCommand selectArtist = new MySqlCommand("SELECT Artist FROM Music WHERE TrackNo=" + x);


            //Set colours via hex codes
            this.BackColor = ColorTranslator.FromHtml("#444444");
            btnPlay.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            btnPlay.ForeColor = ColorTranslator.FromHtml("#3c3c3c");
            btnPlay.UseVisualStyleBackColor = false;
            btnOpen.BackColor = Color.Transparent;
            btnSkipBackward.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            btnSkipForward.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            lblCurrentlyPlaying.ForeColor = ColorTranslator.FromHtml("#646464");
            tlpPlayerBottom.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            pbAlbumCover.BackColor = ColorTranslator.FromHtml("#444444");

            //Connect to DB
            DB.KEVINDBOnLoad();

            //Add Song Information to table
            selectTrackNo.Connection = DB.connect;
            MySqlDataReader trackNoReader = selectTrackNo.ExecuteReader();
            while (trackNoReader.Read())
            {
                flpTrackNo.Controls.Add(new Label
                {
                    Name = "TrackNo" + x,
                    Text = trackNoReader[0] as string
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
                flpSong.Controls.Add(new Label
                {
                    Name = "Song" + x,
                    Text = songNameReader[0] as string
                });
                x++;
            }
            x = 1;
            selectSongName.Connection.Close();
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
            MemoryStream ms = new MemoryStream(file.Tag.Pictures[0].Data.Data);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            pbAlbumCover.BackgroundImage = image;
            
            //Addpend to DB
            DB.appendSongInformation(TrackIDstr, SongName, strSongLength, Album, Artist, Genre, sqlLocation);
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
            btnAlbum.BackgroundImage = KEVIN.Properties.Resources.Reverse_Album_fw___Copy;
        }

        private void btnAlbum_MouseLeave(object sender, EventArgs e)
        {
            btnAlbum.BackgroundImage = KEVIN.Properties.Resources.Album_Iocn;
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
    }
}
