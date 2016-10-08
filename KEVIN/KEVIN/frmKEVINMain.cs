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

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (playpause == false)
            {
                return;
            }
            if (playing == true)
            {
                btnPlay.Text = "Play";
                mpPlayer.Pause();
                playing = false;
                return;
            }
            if (playing == false)
            {
                btnPlay.Text = "Pause";
                mpPlayer.Play();
                playing = true;
                return;
            }            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            playpause = true;
            ofdOpenMusic.ShowDialog();
        }

        private void ofdOpenMusic_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = System.IO.Path.GetFileName(ofdOpenMusic.FileName);
            lblCurrentlyPlaying.Text = fileName;
            mpPlayer.Open(ofdOpenMusic.FileName);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mpPlayer.Stop();
            lblCurrentlyPlaying.Text = "-----------------------------------------------";
            btnPlay.Text = "Play";
        }
    }
}
