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
    public partial class frmTesting : Form
    {
        public frmTesting()
        {
            InitializeComponent();
            bwDebug.RunWorkerAsync();
        }

        private void frmTesting_Load(object sender, EventArgs e)
        {
            
        }

        private void bwDebug_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblMQV.Text = frmKEVINMain.Functions.queueSize.ToString();
                        lblPV.Text = frmKEVINMain.Functions.playing.ToString();
                        lblQNV.Text = frmKEVINMain.Functions.currentQueueID.ToString();
                        lblSLV.Text = frmKEVINMain.Functions.SongLength.ToString();
                        lblTV.Text = frmKEVINMain.Functions.Timer.ToString();
                        lblTQIDV.Text = frmKEVINMain.Functions.tempQueueID.ToString();
                    });
                }
                catch { this.Invoke((MethodInvoker)delegate { this.Close(); }); }
            }
        }
    }
}
