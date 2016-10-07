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
            mpPlayer.Play();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ofdOpenMusic.ShowDialog();
        }

        private void ofdOpenMusic_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = System.IO.Path.GetFileName(ofdOpenMusic.FileName);
            lblCurrentlyPlaying.Text = fileName;
            mpPlayer.Open(ofdOpenMusic.FileName);
        }
    }
}
