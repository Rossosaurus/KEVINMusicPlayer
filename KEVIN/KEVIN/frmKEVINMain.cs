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
            this.BackColor = ColorTranslator.FromHtml("#444444");
            btnPlay.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            btnPlay.ForeColor = ColorTranslator.FromHtml("#3c3c3c");
            btnPlay.UseVisualStyleBackColor = false;
            btnOpen.BackColor = Color.Transparent;
            btnSkipBackward.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            btnSkipForward.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            lblCurrentlyPlaying.ForeColor = ColorTranslator.FromHtml("#646464");
            DB.KEVINDBOnLoad();
            this.Text = "KEVIN MP - DB Connected";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            mpPlayer.Stop();
            playpause = true;
            ofdOpenMusic.ShowDialog();
        }

        private void ofdOpenMusic_FileOk(object sender, CancelEventArgs e)
        {
            /*string fileName = System.IO.Path.GetFileNameWithoutExtension(ofdOpenMusic.FileName);
            this.Text = fileName + " - KEVIN";
            lblCurrentlyPlaying.Text = fileName;
            mpPlayer.Open(ofdOpenMusic.FileName);*/
            string a, b, c, d, f;
            a = "1"; b = "Never Gonna Give You Up"; c = "[Singles]"; d = "Rick Astley"; f = "A Location";
            DB.appendSongInformation(a, b, c, d, f);
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


    }
}
