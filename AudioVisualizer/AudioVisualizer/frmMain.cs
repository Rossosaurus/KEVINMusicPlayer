using System;
using System.Drawing;
using System.Windows.Forms;

namespace AudioVisualizer
{
    public partial class frmMain : Form
    {
        private int WAVEDATA_SIZE = 256;

        private FMOD.System system = null;
        private FMOD.Sound sound = null;
        private FMOD.Channel channel = null;

        private float[] wavedata;
        private Timer updateTimer;
 
        private SolidBrush brushBlack, brushWhite, brushGreen;

        public frmMain()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "MP3 Files (*.mp3)|*.mp3|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FMOD.RESULT res = system.createStream(ofd.FileName, FMOD.MODE.HARDWARE | FMOD.MODE._2D, ref sound);
                res = system.playSound(FMOD.CHANNELINDEX.FREE, sound, false, ref channel);

                CheckError(res);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            updateTimer = new Timer();
            updateTimer.Interval = 1000 / 1000; //60 frames per 1000 milliseconds (1 second)
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();

            FMOD.RESULT res = FMOD.Factory.System_Create(ref system);
            CheckError(res);

            res = system.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)null);
            CheckError(res);

            WAVEDATA_SIZE = this.Width;
            wavedata = new float[WAVEDATA_SIZE];

            brushBlack = new SolidBrush(Color.Black);
            brushGreen = new SolidBrush(Color.Green);
            brushWhite = new SolidBrush(Color.White);
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();

            if (system != null)
                system.update();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(brushBlack, 0, 0, this.Width, Height);

            if (system != null)
            {
                DrawWaveData(e.Graphics);
            } else
                base.OnPaint(e);
        }

        public void DrawWaveData(Graphics g)
        {
            int numchannels = 0;
            int dummy = 0;
            FMOD.SOUND_FORMAT dummyformat = FMOD.SOUND_FORMAT.NONE;
            FMOD.DSP_RESAMPLER dummyresampler = FMOD.DSP_RESAMPLER.LINEAR;

            system.getSoftwareFormat(ref dummy, ref dummyformat, ref numchannels, ref dummy, ref dummyresampler, ref dummy);

            for (int channel = 0; channel < numchannels; channel++)
            {
                system.getWaveData(wavedata, WAVEDATA_SIZE, channel);

                for (int x = 0; x < WAVEDATA_SIZE; x++)
                {
                    float y = (wavedata[x] + 1) / 2.0f * Height;
                    g.FillRectangle(brushWhite, x + this.Width - WAVEDATA_SIZE - 10.0f, y, 1.0f, 1.0f);
                }
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            WAVEDATA_SIZE = this.Width;
            wavedata = new float[WAVEDATA_SIZE];
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void CheckError(FMOD.RESULT result)
        {
            if (result != FMOD.RESULT.OK)
            {
                updateTimer.Stop();
                MessageBox.Show("Something went wrong! " + FMOD.Error.String(result));
                Environment.Exit(-1);
            }
        }
    }
}
