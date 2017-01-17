//KEVIN MP Music Player Source Code
//Telling the program to use the libraries and references required
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //SQL library
using TagLib; //Tag Library
using System.IO;

namespace KEVIN
{
    public partial class frmKEVINMain : Form
    {
        public static readonly KEVIN.MusicPlayer mpPlayer = new MusicPlayer(); //Create instance of music player class
        public static Functions Functions = new Functions(); //Create instance of functions class
        public static Random shuffle = new Random(); //Create random number variable
        System.Drawing.Image albumCover = KEVIN.Properties.Resources.NoAlbumArt; //Creates a variable that can store an image
        int x = 1;

        public frmKEVINMain()
        {
            //Initialize form
            InitializeComponent();
            //Create instance of form for debugging (Remove in release version
            frmTesting debug = new frmTesting(); debug.Show();
            //Create eventhandlers that arent dynamically generated for controls
            btnAlbum.MouseEnter += new EventHandler(btnAlbum_MouseEnter);
            btnAlbum.MouseLeave += new EventHandler(btnAlbum_MouseLeave);
            btnPlayer.MouseEnter += new EventHandler(btnPlayer_MouseEnter);
            btnPlayer.MouseLeave += new EventHandler(btnPlayer_MouseLeave);
            btnPlaylists.MouseEnter += new EventHandler(btnPlaylists_MouseEnter);
            btnPlaylists.MouseLeave += new EventHandler(btnPlaylists_MouseLeave);
            btnAddMusic.MouseEnter += new EventHandler(btnAddMusic_MouseEnter);
            btnAddMusic.MouseLeave += new EventHandler(btnAddMusic_MouseLeave);
            btnSkipBackward.MouseEnter += new EventHandler(btnSkipBackward_MouseEnter);
            btnSkipBackward.MouseLeave += new EventHandler(btnSkipBackward_MouseLeave);
            btnSkipForward.MouseEnter += new EventHandler(btnSkipForward_MouseEnter);
            btnSkipForward.MouseLeave += new EventHandler(btnSkipForward_MouseLeave);            
            this.Resize += new EventHandler(frmKEVINMain_Resize);
        }

        private void frmKEVINMain_Resize(object sender, System.EventArgs e)
        {
            //If form is resized clear all controls from flpQueue and creat a new instance of them
            flpQueue.Controls.Clear();
            if (Functions.shuffle == false)
            {
            Functions.createQueueButtons(flpQueue, cmsQueueRightClick);
            }
            else
            {
                flpQueue.Controls.Add(new Label
                {
                    Name = "shuffle",
                    ForeColor = Color.WhiteSmoke,
                    Text = "SHUFFLE" + Environment.NewLine + "MODE" + Environment.NewLine + "ACTIVE",
                    Font = new Font("Trebuchet MS", 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                });
            }

        }

        private void frmKEVINMain_Load(object sender, EventArgs e)
        {
            //Variables declared on launch            
            MySqlCommand selectTrackNo = new MySqlCommand("SELECT TrackNo FROM Music");
            MySqlCommand selectSongName = new MySqlCommand("SELECT SongName FROM Music");
            MySqlCommand selectSongLength = new MySqlCommand("SELECT SongLength FROM Music");
            MySqlCommand selectAlbum = new MySqlCommand("SELECT Album FROM Music");
            MySqlCommand selectArtist = new MySqlCommand("SELECT Artist FROM Music");
            MySqlCommand selectGenre = new MySqlCommand("SELECT Genre FROM Music");
            Functions.SongLength = 1;

            //Set colours via hex codes
            this.BackColor = ColorTranslator.FromHtml("#444444");
            btnPlay.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            btnPlay.ForeColor = ColorTranslator.FromHtml("#3c3c3c");
            btnPlay.UseVisualStyleBackColor = false;
            btnSkipBackward.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            btnSkipForward.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            this.lblCurrentlyPlaying.ForeColor = ColorTranslator.FromHtml("#646464");
            tlpPlayerBottom.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            pbAlbumCover.BackColor = ColorTranslator.FromHtml("#444444");

            //Set pnlPlaying and pnlPlaylists to hidden
            flpAlbums.Hide();
            pnlPlaylists.Hide();

            //Format of all subforms            
            flpAlbums.Location = new Point(16, 3);
            flpAlbums.Size = new Size(729, 423);
            flpAlbums.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            pnlPlaying.Location = new Point(16, 3);
            pnlPlaying.Size = new Size(729, 423);
            pnlPlaying.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            pnlPlaylists.Location = new Point(16, 3);
            pnlPlaylists.Size = new Size(729, 423);
            pnlPlaylists.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            flpQueue.HorizontalScroll.Maximum = 0;
            flpQueue.AutoScroll = false;
            flpQueue.HorizontalScroll.Visible = false;
            flpQueue.AutoScroll = true;


            //Connect to DB
            Functions.connectToDB();
            Functions.createTables();
            Functions.refreshConnectionToDB();
            Functions.createQueueButtons(flpQueue, cmsQueueRightClick);

            //Functions onLoad
            Functions.openFirstQueueSong(lblCurrentlyPlaying, pbAlbumCover);
            bwTimer.RunWorkerAsync();
            bwPlayer.RunWorkerAsync();
        }

        private void ofdOpenMusic_FileOk(object sender, CancelEventArgs e)
        {
            //For each item selected in the open file dialogue get all the variable information from it and then add the song to the database
            foreach (String songInfo in ofdOpenMusic.FileNames)
            {
                string pathExtension = Path.GetExtension(songInfo);
                if (pathExtension == ".mp3" || pathExtension == ".flac" || pathExtension == ".aac" || pathExtension == ".m4a" || pathExtension == ".wav")
                {
                    //Create a variable that allows you to strip the tags from a song
                    TagLib.File file = TagLib.File.Create(songInfo);
                    //Strip tags from song
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(songInfo);
                    uint TrackID = file.Tag.Track;
                    string TrackIDstr = TrackID.ToString();
                    string SongName;
                    if (file.Tag.Title == null || file.Tag.Title == "")
                    {
                        SongName = ofdOpenMusic.FileName;
                    }
                    else
                    {
                        SongName = file.Tag.Title;
                    }

                    TimeSpan SongLength = file.Properties.Duration;
                    string strSongLength = SongLength.ToString();
                    string Artist = string.Join(",", file.Tag.FirstArtist);
                    string Album = file.Tag.Album;
                    string Genre = file.Tag.FirstGenre;
                    string Location = songInfo;
                    string sqlLocation = Location.Replace("\\", "'");
                    
                    //Refresh database connection                  
                    Functions.refreshConnectionToDB();
                    
                    //Show the playing sub form
                    flpAlbums.Hide();
                    pnlPlaying.Show();
                    pnlPlaylists.Hide();

                    //Append to DB
                    Functions.CreateAndAppendAlbumInfoToTables(Album, Artist, Genre);
                    Functions.albumExists = false;
                    Functions.createAndAppendMusicInfoToTables(Album, Artist, TrackIDstr, SongName, strSongLength, sqlLocation);
                    Functions.connect.Close();
                    //Application.Restart();
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //If btnPlay is clicked check what state Functions.plating has and change it to the opposite state, Then
            //play the song that is currently loaded into mpPlayer
            if (Functions.playing == false)
            {
                btnPlay.BackgroundImage = KEVIN.Properties.Resources.Pause_fw;
                mpPlayer.Play();
                Functions.playing = true;
            }
            else
            {
                btnPlay.BackgroundImage = KEVIN.Properties.Resources.Play_fw;
                mpPlayer.Pause();
                Functions.playing = false;
            }            
        }

        private void btnSkipForward_Click(object sender, EventArgs e)
        {
            //If btnSkipForward is clicked
            string songLocation = "";
            //Set a varible to an equivilant of null tjem check whether music is being shuffled of set to
            //repeat the song currently being played
            if (Functions.shuffle == true)
            {
                //If functions == true
                Functions.refreshConnectionToDB();
                //Select a random song from the records in the database
                MySqlCommand selectRandomRecord = new MySqlCommand("SELECT SongLocation FROM Music ORDER BY RAND() LIMIT 1", Functions.connect);
                MySqlDataReader readRandomRecord = selectRandomRecord.ExecuteReader();
                while (readRandomRecord.Read())
                {
                    //Get the song location of that song
                    songLocation = readRandomRecord.GetString(0).Replace("'", "\\");
                }
                //Get tags from song
                TagLib.File Tags = TagLib.File.Create(songLocation);
                //Reset song length
                Functions.SongLength = Tags.Properties.Duration.TotalSeconds;
                //Stop song
                frmKEVINMain.mpPlayer.Stop();
                //Open new song
                frmKEVINMain.mpPlayer.Open(songLocation);
                //Make sure playing = true
                Functions.playing = true;
                //Set btnPlay to play icon
                btnPlay.BackgroundImage = Properties.Resources.Pause_fw;
                //Reset timer
                Functions.Timer = 0;
                //Play song that has just been loading into mpPlayer
                frmKEVINMain.mpPlayer.Play();
                //Error handling to ensure the program doesnt crash if the tags of the song were empty
                try
                {
                    //Set the pbAlbumCover and lblCurrentlyPlaying to the corresponding information ripped from the songs tags above
                    Functions.SongLength = Tags.Properties.Duration.TotalSeconds;
                    this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = Tags.Tag.Title.ToString(); });
                    MemoryStream ms;
                    //Nesting commands in try statement to avoid unnescessary crashes
                    try
                    {
                        ms = new MemoryStream(Tags.Tag.Pictures[0].Data.Data);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                        //Using this.Invoke to change properties on another thread
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                    }
                    catch
                    {
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                    }

                }
                catch { }
            }
            //If Functions.repeat == true
            else if (Functions.repeat == true)
            {
                //Reset timer stop the currenntly playing song, open the song that was just playing and play the song again
                Functions.Timer = 0;
                mpPlayer.Stop();
                mpPlayer.Open(Functions.currentlyPlaying);                
                mpPlayer.Play();
                Functions.playing = true;
            }
            //Else play the next song in the queue
            else if (Functions.shuffle == false && Functions.repeat == false)
            {
                //If player is on last song of queue go back to the begginning of the queue
                if (Functions.currentQueueID == Functions.queueSize)
                {
                    Functions.Timer = 0;
                    mpPlayer.Stop();
                    Functions.openFirstQueueSong(lblCurrentlyPlaying, pbAlbumCover);
                    mpPlayer.Play();
                    goto endOfCheck;
                }
                Functions.refreshConnectionToDB();
                //Else get the number of records in the queue
                MySqlCommand selectMaxQueueID = new MySqlCommand("SELECT COUNT(*) FROM Queue", Functions.connect);
                MySqlDataReader readMaxQueueID = selectMaxQueueID.ExecuteReader();
                while (readMaxQueueID.Read())
                {
                    Functions.queueSize = readMaxQueueID.GetInt16(0);
                }
                //Reset timer
                Functions.Timer = 0;
                Functions.refreshConnectionToDB();
                //Get music ID of next song
                MySqlCommand selectNextID = new MySqlCommand("SELECT MusicID FROM queue WHERE queueID = " + Functions.currentQueueID++, Functions.connect);
                MySqlDataReader readNextID = selectNextID.ExecuteReader();
                int nextMusicID = 0;
                while (readNextID.Read())
                {
                    nextMusicID = readNextID.GetInt16(0);
                }
                //Get song location of next song
                Functions.refreshConnectionToDB();
                MySqlCommand selectNextSong = new MySqlCommand("SELECT SongLocation FROM music WHERE SongID = " + nextMusicID, Functions.connect);
                MySqlDataReader readNextSong = selectNextSong.ExecuteReader();
                while (readNextSong.Read())
                {
                    songLocation = readNextSong.GetString(0).Replace("'", "\\");
                }
                //Get tags from song file
                TagLib.File songDetails;
                //Set properties in Try statement to avoid unwanted crashes
                try
                {
                    songDetails = TagLib.File.Create(songLocation);
                    Functions.SongLength = songDetails.Properties.Duration.TotalSeconds;
                    this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = songDetails.Tag.Title.ToString(); });
                    MemoryStream ms;
                    try
                    {
                        ms = new MemoryStream(songDetails.Tag.Pictures[0].Data.Data);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                    }
                    catch
                    {
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                    }                
                }
                catch { }
                //Play song
                mpPlayer.Stop();
                mpPlayer.Open(songLocation);
                mpPlayer.Play();
            }
            endOfCheck:;
        }

        private void btnSkipForward_MouseEnter(object sender, EventArgs e)
        {
            //If the mouse is over this button change the background image
            btnSkipForward.BackgroundImage = Properties.Resources.SkipFwrdHover;
        }

        private void btnSkipForward_MouseLeave(object sender, EventArgs e)
        {
            //If the mouse leaves this button change the background
            btnSkipForward.BackgroundImage = Properties.Resources.SkipFwrd_fw;
        }

        private void btnSkipBackward_Click(object sender, EventArgs e)
        {
            //If this button is clicked, stop the song currently playing, open the song stored in Functions.previousSong
            mpPlayer.Stop();
            mpPlayer.Open(Functions.previousSong);
            TagLib.File songDetails;
            //Error handling to prevent crashes
            try
            {
                //Set lblCurrentlyPlaying and pbAlbumCover to the contents ripped from the tags of the song that is about
                //to be played
                songDetails = TagLib.File.Create(Functions.previousSong);
                Functions.SongLength = songDetails.Properties.Duration.TotalSeconds;
                this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = songDetails.Tag.Title.ToString(); });
                MemoryStream ms;
                try
                {
                    ms = new MemoryStream(songDetails.Tag.Pictures[0].Data.Data);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                }
                catch
                {
                    this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                }

            }
            catch { }
            //Play song
            mpPlayer.Play();
        }

        private void btnSkipBackward_MouseEnter(object sender, EventArgs e)
        {
            //If the mouse is over this button change the background image
            btnSkipBackward.BackgroundImage = Properties.Resources.SkipBkrwdHover;
        }

        private void btnSkipBackward_MouseLeave(object sender, EventArgs e)
        {
            //If the mouse leaves this button change the background image
            btnSkipBackward.BackgroundImage = Properties.Resources.SkipBkrwd_fw;
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            //checks if Functions.shuffle == true and if so changes it to false
            if (Functions.shuffle == true)
            {
                Functions.shuffle = false;
                //Change this buttons background image
                btnShuffle.BackgroundImage = Properties.Resources.shuffle_fw;
                //Clear flpQueue of controls
                flpQueue.Controls.Clear();
                //Executes the createQueueButtons function
                Functions.createQueueButtons(flpQueue, cmsQueueRightClick);            
            }
            //Else checks if Functions.shuffle == false and if so sets it to true then plays a random song
            else if (Functions.shuffle == false)
            {
                Functions.shuffle = true;
                //Change background image of button
                btnShuffle.BackgroundImage = Properties.Resources.shuffleSelected;
                //Clear controls from flpQueue
                flpQueue.Controls.Clear();
                //Creates a control with the attributes in the curly braces
                flpQueue.Controls.Add(new Label
                {
                    Name = "shuffle",
                    ForeColor = Color.WhiteSmoke,
                    Text = "SHUFFLE" + Environment.NewLine + "MODE" + Environment.NewLine + "ACTIVE",
                    Font = new Font("Trebuchet MS", 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                });
                //Sets songLocation to a null equivilant for use later
                string songLocation = "";
                //Refreshes connection to avoid errors then selects the SongLocation of a random record in the database
                Functions.refreshConnectionToDB();
                MySqlCommand selectRandomRecord = new MySqlCommand("SELECT SongLocation FROM Music ORDER BY RAND() LIMIT 1", Functions.connect);
                MySqlDataReader readRandomRecord = selectRandomRecord.ExecuteReader();
                while (readRandomRecord.Read())
                {
                    songLocation = readRandomRecord.GetString(0).Replace("'", "\\");
                }
                //Gets tags of song and assigns them to assorted variables
                TagLib.File Tags = TagLib.File.Create(songLocation);
                Functions.SongLength = Tags.Properties.Duration.TotalSeconds;
                //Stops song currently playing
                frmKEVINMain.mpPlayer.Stop();
                //Opens random song from earlier
                frmKEVINMain.mpPlayer.Open(songLocation);
                //Sets currently playing song to currentlyPlaying
                Functions.currentlyPlaying = songLocation;
                //Sets playing to true
                Functions.playing = true;
                //Sets btnPlay's background image to its playing image
                btnPlay.BackgroundImage = Properties.Resources.Pause_fw;
                //Resets the timer
                Functions.Timer = 0;
                //Plays song
                frmKEVINMain.mpPlayer.Play();
                //Set properties from tags in Try statement to avoid crashing the program
                try
                {
                    Functions.SongLength = Tags.Properties.Duration.TotalSeconds;
                    this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = Tags.Tag.Title.ToString(); });
                    MemoryStream ms;
                    try
                    {
                        ms = new MemoryStream(Tags.Tag.Pictures[0].Data.Data);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                    }
                    catch
                    {
                        this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                    }

                }
                catch { }
            }            
        }        

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            //Reverse the state of Functions.repeat on button click and change the background image
            if  (Functions.repeat == false)
            {
                Functions.repeat = true;
                btnRepeat.BackgroundImage = Properties.Resources.repeatSelected;
            }
            else if (Functions.repeat == true)
            {
                Functions.repeat = false;
                btnRepeat.BackgroundImage = Properties.Resources.repeat_fw;
            }
        }

        private void btnAlbum_Click(object sender, EventArgs e)
        {
            //Create all the album buttons, hide both main panels and show flpAlbums
            Functions.createAlbumButtons(x, flpAlbums, cmsRightClickAlbums);
            pnlPlaying.Hide();
            pnlPlaylists.Hide();
            flpAlbums.Show();
        }

        private void btnAlbum_MouseEnter(object sender, EventArgs e)
        {
            //If the mouse is over this button change the background image
            btnAlbum.BackgroundImage = KEVIN.Properties.Resources.Album2_fw;
        }

        private void btnAlbum_MouseLeave(object sender, EventArgs e)
        {
            //If the mouse leaves this button change the background image
            btnAlbum.BackgroundImage = KEVIN.Properties.Resources.Album_Icon;
        }

        private void btnPlayer_Click(object sender, EventArgs e)
        {
            //hide pnlPlaylists and flpAlbums, show pnlPlayling and create all the queue buttons
            pnlPlaying.Show();
            pnlPlaylists.Hide();
            flpAlbums.Hide();
            Functions.createQueueButtons(flpQueue, cmsQueueRightClick);
        }

        private void btnPlayer_MouseEnter(object sender, EventArgs e)
        {
            //If the mouse is over this button change the background image
            btnPlayer.BackgroundImage = KEVIN.Properties.Resources.Player2_fw;
        }

        private void btnPlayer_MouseLeave(object sender, EventArgs e)
        {
            //If the mouse leaves this button change the background image
            btnPlayer.BackgroundImage = KEVIN.Properties.Resources.Music_Player_Logo_fw;
        }

        private void btnPlaylists_Click(object sender, EventArgs e)
        {
            //Hide pnlPlaying and flpAlbums, show pnlPlaylists and generate the playlist buttons
            pnlPlaying.Hide();
            pnlPlaylists.Show();
            flpAlbums.Hide();
            Functions.generatePlaylistButtons(flpPlaylists, cmsPlaylistsRightClick);
        }

        private void btnPlaylists_MouseEnter(object sender, EventArgs e)
        {
            //If the mouse is over this button change the background image
            btnPlaylists.BackgroundImage = KEVIN.Properties.Resources.Playlist2_fw;
        }

        private void btnPlaylists_MouseLeave(object sender, EventArgs e)
        {
            //If the mouse leaves this button change the background image
            btnPlaylists.BackgroundImage = KEVIN.Properties.Resources.Playlist_Logo_Colour_fw;
        }

        private void btnAddMusic_Click(object sender, EventArgs e)
        {
            //Opens the open file dialogue to select the music you want to add to the player
            ofdOpenMusic.ShowDialog();
        }

        private void btnAddMusic_MouseEnter(object sender, EventArgs e)
        {
            //If the mouse is over this button change the background image
            btnAddMusic.BackgroundImage = KEVIN.Properties.Resources.AddMusic_2_fw;
        }

        private void btnAddMusic_MouseLeave(object sender, EventArgs e)
        {
            //If the mouse leaves this button change the background image
            btnAddMusic.BackgroundImage = KEVIN.Properties.Resources.Add_Music_Logo_fw;
        }

        private void bwTimer_DoWork(object sender, DoWorkEventArgs e)
        {
            //Sets timer to 0 on initialisation
            Functions.Timer = 0;
            //Set thread to forever increment timer by one if Functions.playing is true
            while (true)
            {
                while (Functions.playing == true)
                {
                    Functions.Timer++;
                    System.Threading.Thread.Sleep(1000);
                }
            }

        }

        //Set code to be executed on seperate thread in brackground worker
        private void bwPlayer_DoWork(object sender, DoWorkEventArgs e)
        {
            //Set songLocation to an instance of null
            string songLocation = "";
            //Permanantly check if the next song needs to be playing and:
            while (true)
            {
                Functions.previousSong = Functions.currentlyPlaying;
                //if shuffle and repeat are not true:    
                if (Functions.Timer > Functions.SongLength && Functions.shuffle == false && Functions.repeat == false)
                {
                    //Get next songs information
                    Functions.refreshConnectionToDB();
                    if (Functions.currentQueueID == Functions.queueSize)
                    {                        
                        Functions.Timer = 0;
                        mpPlayer.Stop();
                        Functions.openFirstQueueSong(lblCurrentlyPlaying, pbAlbumCover);
                        mpPlayer.Play();
                        goto endOfCheck;
                    }
                    MySqlCommand selectMaxQueueID = new MySqlCommand("SELECT COUNT(*) FROM Queue", Functions.connect);
                    MySqlDataReader readMaxQueueID = selectMaxQueueID.ExecuteReader();
                    while (readMaxQueueID.Read())
                    {
                        Functions.queueSize = readMaxQueueID.GetInt16(0);
                    }
                    Functions.Timer = 0;
                    Functions.refreshConnectionToDB();
                    MySqlCommand selectNextID = new MySqlCommand("SELECT MusicID FROM queue WHERE queueID = " + Functions.currentQueueID++, Functions.connect);
                    MySqlDataReader readNextID = selectNextID.ExecuteReader();
                    int nextMusicID = 0;
                    while (readNextID.Read())
                    {
                        nextMusicID = readNextID.GetInt16(0);
                    }

                    Functions.refreshConnectionToDB();
                    MySqlCommand selectNextSong = new MySqlCommand("SELECT SongLocation FROM music WHERE SongID = " + nextMusicID, Functions.connect);
                    MySqlDataReader readNextSong = selectNextSong.ExecuteReader();
                    while (readNextSong.Read())
                    {
                        songLocation = readNextSong.GetString(0).Replace("'", "\\");
                    }

                    TagLib.File songDetails;
                    //Set properties from tags in Try statement to prevent crashes
                    try
                    {
                        songDetails = TagLib.File.Create(songLocation);
                        Functions.SongLength = songDetails.Properties.Duration.TotalSeconds;
                        this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = songDetails.Tag.Title.ToString(); });
                        MemoryStream ms;
                        try
                        {
                            ms = new MemoryStream(songDetails.Tag.Pictures[0].Data.Data);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                            this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                        }
                        catch
                        {
                            this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                        }
                    }
                    catch { }
                    //Play song
                    mpPlayer.Stop();
                    mpPlayer.Open(songLocation);
                    Functions.currentlyPlaying = songLocation;
                    mpPlayer.Play();
                    endOfCheck:;
                }
                //If repeat is true
                else if (Functions.Timer > Functions.SongLength && Functions.repeat == true)
                {
                    //Reset timer and play the same song again
                    Functions.Timer = 0;
                    mpPlayer.Stop();
                    Functions.currentlyPlaying = songLocation;
                    mpPlayer.Open(songLocation);
                    Functions.playing = true;
                    mpPlayer.Play();
                }
                //if shuffle is true
                else if (Functions.Timer > Functions.SongLength && Functions.shuffle == true)
                {
                    //Pick a random record from the music table
                    Functions.refreshConnectionToDB();
                    MySqlCommand selectRandomRecord = new MySqlCommand("SELECT SongLocation FROM Music ORDER BY RAND() LIMIT 1", Functions.connect);
                    MySqlDataReader readRandomRecord = selectRandomRecord.ExecuteReader();
                    while (readRandomRecord.Read())
                    {
                        songLocation = readRandomRecord.GetString(0).Replace("'", "\\");
                    }
                    //get tags
                    TagLib.File Tags = TagLib.File.Create(songLocation);
                    Functions.SongLength = Tags.Properties.Duration.TotalSeconds;                    
                    frmKEVINMain.mpPlayer.Stop();
                    frmKEVINMain.mpPlayer.Open(songLocation);
                    Functions.currentlyPlaying = songLocation;
                    Functions.playing = true;
                    btnPlay.BackgroundImage = Properties.Resources.Pause_fw;
                    Functions.Timer = 0;
                    //Play song
                    frmKEVINMain.mpPlayer.Play();
                    //Set properties from tags in Try statement to prevent crashes
                    try
                    {
                        Functions.SongLength = Tags.Properties.Duration.TotalSeconds;
                        this.Invoke((MethodInvoker)delegate { lblCurrentlyPlaying.Text = Tags.Tag.Title.ToString(); });
                        MemoryStream ms;
                        try
                        {
                            ms = new MemoryStream(Tags.Tag.Pictures[0].Data.Data);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                            this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = image; });
                        }
                        catch
                        {
                            this.Invoke((MethodInvoker)delegate { pbAlbumCover.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt; });
                        }

                    }
                    catch { }
                }
                //if stop is true halt music playback
                if (Functions.stop == true)
                {
                    mpPlayer.Stop();
                    Functions.stop = false;
                }
                //if playing is true play song loaded in mpPlayer and set background image of btnPlay
                if (Functions.playing == true)
                {
                    mpPlayer.Play();
                    btnPlay.BackgroundImage = Properties.Resources.Pause_fw;
                }
                //if playing is false pause song loaded in mpPlayer and set background image of btnPlay
                if (Functions.playing == false)
                {
                    mpPlayer.Pause();
                    btnPlay.BackgroundImage = Properties.Resources.Play_fw;
                }
                //sleep thread for 0.1 second
                System.Threading.Thread.Sleep(100);

            }
        }

        private void tlsDelete_Click(object sender, EventArgs e)
        {
            //get all records of queue table
            Functions.refreshConnectionToDB();
            MessageBox.Show(cmsQueueRightClick.Tag.ToString());
            string rowToDeleteSTR = cmsQueueRightClick.Tag.ToString();
            int rowToDelete= Convert.ToInt16(rowToDeleteSTR);
            int numberOfRows = 1;
            MySqlCommand selectNOR = new MySqlCommand("SELECT COUNT(*) FROM Queue", Functions.connect);
            MySqlDataReader readNOR = selectNOR.ExecuteReader();
            while (readNOR.Read())
            {
                numberOfRows = readNOR.GetInt16(0);
            }
            string[,] queue = new string[numberOfRows, 2];
            MySqlCommand selectQueue = new MySqlCommand("SELECT * FROM Queue", Functions.connect2);
            MySqlDataReader readQueue = selectQueue.ExecuteReader();
            int x = 0;
            //append to queue[,] array
            while (readQueue.Read())
            {
                queue[x, 0] = readQueue.GetString(0);
                queue[x, 1] = readQueue.GetString(1);
                x++;
            }
            x = 0;
            //if record that needs to be deleted is the last record
            if (rowToDelete == numberOfRows)
            {
                //delete last record
                Functions.refreshConnectionToDB();
                MySqlCommand deleteLastQueue = new MySqlCommand("DELETE FROM Queue Where QueueID=" + rowToDelete, Functions.connect);
                deleteLastQueue.ExecuteNonQuery();
                flpQueue.Controls.Clear();
                Functions.createQueueButtons(flpQueue, cmsQueueRightClick);
            }
            else
            {
                //find record that needs to be deleted
                //remove record from array
                while (rowToDelete <= numberOfRows - 1)
                {
                    queue[rowToDelete - 1, 1] = queue[rowToDelete, 1];
                    rowToDelete++;
                }
                Functions.refreshConnectionToDB();
                //empty queue table                
                MySqlCommand deleteQueue = new MySqlCommand("DELETE FROM Queue", Functions.connect);
                deleteQueue.ExecuteNonQuery();
                //Reappend queue from array with record removed
                while (x <= numberOfRows - 2)
                {
                    Functions.refreshConnectionToDB();
                    MySqlCommand appendQueue = new MySqlCommand("INSERT INTO Queue(QueueID, MusicID)  Values (" + queue[x, 0] + ", " + queue[x, 1] + ")", Functions.connect);
                    appendQueue.ExecuteNonQuery();
                    x++;
                }
                //clear all controls from flpQueue
                flpQueue.Controls.Clear();
                //Regenerate queue buttons
                Functions.createQueueButtons(flpQueue, cmsQueueRightClick);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Execute openAlbumForm function
            Functions.openAlbumForm(cmsRightClickAlbums.Tag.ToString());
        }

        private void cmsPlaylistsRightClick_Opening(object sender, CancelEventArgs e)
        {
            //create arrays of toolstrip menu items
            ToolStripMenuItem[] deletePlaylist = new ToolStripMenuItem[1];
            ToolStripMenuItem[] playlists;
            //initialize variables
            int count = 0;
            string songName = "";
            //Set propertied of first record of deletePlaylist toolstripmenuitem
            deletePlaylist[0] = new ToolStripMenuItem();
            deletePlaylist[0].Text = "Delete Playlist";
            deletePlaylist[0].Image = Properties.Resources.Close;
            deletePlaylist[0].Click += (s, eventarg) => dropPlaylist(cmsPlaylistsRightClick.Tag.ToString());
            deleteToolStripMenuItem.DropDownItems.Clear();
            //add deletePlaylist to to deleteToolStripMenuItem
            deleteToolStripMenuItem.DropDownItems.AddRange(deletePlaylist);
            Functions.refreshConnectionToDB();
            //get number of songs in playlist right clicked on
            MySqlCommand countPlaylists = new MySqlCommand("SELECT COUNT(*) FROM " + cmsPlaylistsRightClick.Tag.ToString(), Functions.connect);
            MySqlDataReader readCountPlaylists = countPlaylists.ExecuteReader();
            while (readCountPlaylists.Read())
            {
                count = readCountPlaylists.GetInt16(0);
            }
            //initialize other tool strip menu item array
            playlists = new ToolStripMenuItem[count];
            Functions.refreshConnectionToDB();
            //generate a record in said array for every song in playlist that has been righht clicked on
            MySqlCommand selectPlaylistSongs = new MySqlCommand("SELECT SongID FROM " + cmsPlaylistsRightClick.Tag.ToString(), Functions.connect);
            MySqlDataReader readPlaylistSongs = selectPlaylistSongs.ExecuteReader();
            count = 0;
            while (readPlaylistSongs.Read())
            {
                Functions.connect2.Close();
                Functions.connect2.Open();
                MySqlCommand selectSong = new MySqlCommand("SELECT SongName FROM music WHERE SongID=" + readPlaylistSongs.GetString(0), Functions.connect2);
                MySqlDataReader readSong = selectSong.ExecuteReader();
                while (readSong.Read())
                {
                    songName = readSong.GetString(0);
                }
                playlists[count] = new ToolStripMenuItem();
                playlists[count].Name = readPlaylistSongs.GetString(0).Replace("_", " ");
                playlists[count].Text = songName;
                playlists[count].Image = Properties.Resources.Close;
                playlists[count].Click += (s, eventarg) => Functions.deleteSongFromPlaylist(((ToolStripMenuItem)s).Tag.ToString(), cmsPlaylistsRightClick.Tag.ToString(), flpPlaylists, cmsPlaylistsRightClick);
                playlists[count].Tag = readPlaylistSongs.GetString(0);                
                count++;
            }
            //Add tool strip menu items to deleteToolStripMenuItem
            deleteToolStripMenuItem.DropDownItems.AddRange(playlists);
        }

        public void dropPlaylist(string name)
        {
            //Delete table with the name stored in variable name and delete the playlist record from playlistinfo table
            Functions.refreshConnectionToDB();
            MySqlCommand dropPlaylist = new MySqlCommand("DROP TABLE " + name, Functions.connect);
            dropPlaylist.ExecuteNonQuery();
            MySqlCommand deletePlaylist = new MySqlCommand("DELETE FROM playlistinfo WHERE PlaylistName = \"" + name + "\"", Functions.connect2);
            deletePlaylist.ExecuteNonQuery();
            Functions.refreshConnectionToDB();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Execute playPlaylist function
            Functions.playPlaylist(cmsPlaylistsRightClick);
        }

        private void btnVDown_Click(object sender, EventArgs e)
        {
            //Decrease system volume
            mpPlayer.DecVol(this);
        }

        private void btnVUp_Click(object sender, EventArgs e)
        {
            //Increase system volume
            mpPlayer.IncVol(this);
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            //Mute system volume
            mpPlayer.Mute(this);
        }
    }
}

