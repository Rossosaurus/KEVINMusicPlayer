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
    public partial class frmKEVINSettings : Form
    {
        public frmKEVINSettings()
        {
            InitializeComponent();
        }

        private void frmKEVINSettings_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#444444");
            lblSettings.ForeColor = ColorTranslator.FromHtml("#3c3c3c");
            tlpNavigationBar.BackColor = ColorTranslator.FromHtml("#646464");
            tlpSettingsTitle.BackColor = ColorTranslator.FromHtml("#646464");
        }

        private void tlpNavigationBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tlpSettingsTitle_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
