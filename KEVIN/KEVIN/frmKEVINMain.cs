using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEVIN
{
    public partial class frmKEVINMain : Form
    {
        bool playpause = false;
        bool playing = false;
        MusicPlayer mpPlayer = new MusicPlayer();
        public frmKEVINMain()
        {
            InitializeComponent();
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            mpPlayer.Stop();
            playpause = true;
            ofdOpenMusic.ShowDialog();
        }

        private void ofdOpenMusic_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = System.IO.Path.GetFileNameWithoutExtension(ofdOpenMusic.FileName);
            this.Text = fileName + " - KEVIN";
            mpPlayer.Open(ofdOpenMusic.FileName);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mpPlayer.Stop();
            this.Text = "KEVIN MP";
            btnPlay.BackgroundImage = KEVIN.Properties.Resources.Pause_fw;
            playpause = false;
        }

        private void tlpKEVINMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tlpPlayerBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbAlbumCover_Click(object sender, EventArgs e)
        {
            pbAlbumCover.BackColor = ColorTranslator.FromHtml("#444444");
        }

        private void btnSkipForward_Click(object sender, EventArgs e)
        {

        }

        private void lblCurrentlyPlaying_Click(object sender, EventArgs e)
        {

        }
    }
}
