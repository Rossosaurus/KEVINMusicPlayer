using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEVIN
{

    public partial class frmKEVINAddMusic : Form
    {
        public frmKEVINAddMusic()
        {
            InitializeComponent();
        }

        private void frmKEVINAddMusic_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#444444");
            lblAddMusic.ForeColor = ColorTranslator.FromHtml("#646464");
            pnlHeader.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            pnlFooter.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            btnSubmit.ForeColor = ColorTranslator.FromHtml("#646464");

        }
    }
}
