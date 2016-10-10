using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEVINFormAesthetics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#444444");
            button1.ForeColor = ColorTranslator.FromHtml("#3c3c3c");
            button2.ForeColor = ColorTranslator.FromHtml("#3c3c3c");
            button3.ForeColor = ColorTranslator.FromHtml("#3c3c3c");
            button4.ForeColor = ColorTranslator.FromHtml("#3c3c3c");
            button5.ForeColor = ColorTranslator.FromHtml("#3c3c3c");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            tableLayoutPanel1.BackColor = ColorTranslator.FromHtml("#3c3c3c");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button1_MouseOver(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(@"C:\Users\Ross\Google Drive\School\A Level\Computing\Coursework\Resources\Icons\");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
    }
}
