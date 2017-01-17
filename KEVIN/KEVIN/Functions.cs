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
using TagLib;
using System.IO;

namespace KEVIN
{
    public class Functions
    {
        //Variables
        public MySqlConnection connect = new MySqlConnection("server=localhost; port=3306; userid=KEVIN; password=; database=kevin;");
        public MySqlConnection connect2 = new MySqlConnection("server=localhost; port=3306; userid=KEVIN; password=; database=kevin;");
        public MySqlConnection connect3 = new MySqlConnection("server=localhost; port=3306; userid=KEVIN; password=; database=kevin;");
        string albumID;
        public bool albumExists = false;
        string album;
        string artist;
        bool songExists;
        string TrackNo;
        string songNameofSong;
        System.Drawing.Image albumCoverImage;
        string albumIDFromLocation;
        string albumIDUsedForSearching;
        public string buttonAlbum;
        public string buttonArtist;
        public string buttonGenre;
        string songLocationmpPlayer;
        string yetAnotherTemp = "";
        public int currentQueueID = 1;
        public int queueSize;
        public int tempQueueID = 0;
        public int Timer = 0;
        public double SongLength;
        public bool playing = false;
        public bool stop = false;
        public bool shuffle = false;
        public bool repeat = false;
        public string currentlyPlaying = "";
        public string previousSong = "";
        public string songToAddToPlaylist = "";
        
        public void blankVoid()
        {
            //Placeholder for things
        }

        public void connectToDB()
        {
            //open all database connections
            connect.Open();
            connect2.Open();
            connect3.Open();
        }

        public void createTables()
        {
            //Create all tables required for the database to function
            refreshConnectionToDB();
            MySqlCommand createQueueTable = new MySqlCommand("CREATE TABLE IF NOT EXISTS Queue (QueueID INT(255), MusicID INT(255))", connect);
            createQueueTable.ExecuteNonQuery();
            refreshConnectionToDB();
            MySqlCommand createControlsTable = new MySqlCommand("CREATE TABLE IF NOT EXISTS PlaylistInfo (PlaylistName VARCHAR(1000))", connect);
            createControlsTable.ExecuteNonQuery();
            refreshConnectionToDB();
            MySqlCommand createAlbumsTable = new MySqlCommand("CREATE TABLE IF NOT EXISTS Albums (AlbumID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, Album VARCHAR(1000), Artist VARCHAR(100), Genre VARCHAR(100))", connect);
            createAlbumsTable.ExecuteNonQuery();
            refreshConnectionToDB();
            MySqlCommand createMusicTable = new MySqlCommand("CREATE TABLE IF NOT EXISTS Music (SongID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, TrackNo INT(255), SongName VARCHAR(100), SongLength VARCHAR(100), SongLocation VARCHAR(1000), AlbumID INT(255))", connect);
            createMusicTable.ExecuteNonQuery();
            refreshConnectionToDB();
        }

        public void checkIfAlbumExists(string album1, string artist1)
        {
            //Selects all albums and artists from the Albums tables
            refreshConnectionToDB();
            MySqlCommand selectAlbumAndArtist = new MySqlCommand("SELECT Album, Artist FROM Albums", connect);
            MySqlDataReader readAlbumAndArtist = selectAlbumAndArtist.ExecuteReader();
            while (readAlbumAndArtist.Read())
            {
                //Compares album name and artist entered with every record of the albums table
                album = readAlbumAndArtist.GetString(0);
                artist = readAlbumAndArtist.GetString(1);
                //if record already exists albumExists is set to true
                if (album1 == album && artist1 == artist)
                {
                    albumExists = true;
                    return;
                }
            }
        }
        
        public void checkIfSongExists(string song, string trackNoOfSong)
        {
            //Selects all TrackNo and SongName fields from the Music table
            refreshConnectionToDB();
            MySqlCommand selectTrackNoAndSongName = new MySqlCommand("SELECT TrackNo, SongName FROM Music", connect);
            MySqlDataReader readTrackNoAndSongName = selectTrackNoAndSongName.ExecuteReader();
            while (readTrackNoAndSongName.Read())
            {
                TrackNo = readTrackNoAndSongName.GetString(0);
                songNameofSong = readTrackNoAndSongName.GetString(1);
            }
            //checks if there is a record with the song name and track number of this song
            if (song == songNameofSong && trackNoOfSong == TrackNo)
            {
                //sets songExists to true if song exists in database already
                songExists = true;
                return;
            }
        }

        public void CreateAndAppendAlbumInfoToTables(string AlbumToAppend, string Artist, string Genre)
        {
            //Creates table if not exists
            MySqlCommand checkandCreateAlbum = new MySqlCommand("CREATE TABLE IF NOT EXISTS Albums (AlbumID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, Album VARCHAR(1000), Artist VARCHAR(100), Genre VARCHAR(100))", connect);
            checkandCreateAlbum.ExecuteNonQuery();
            checkIfAlbumExists(AlbumToAppend, Artist);
            //if album doesnt already exist in the Albums table create album record in database
            if (albumExists == false)
            {
                refreshConnectionToDB();
                MySqlCommand appendAlbumInfo = new MySqlCommand("INSERT INTO Albums (Album, Artist, Genre) VALUES (\"" + AlbumToAppend + "\", \"" + Artist + "\", \"" + Genre + "\")", connect);
                appendAlbumInfo.ExecuteNonQuery();
            }
            refreshConnectionToDB();
        }

        public void createAndAppendMusicInfoToTables(string Album, string Artist, string trackNo, string songName, string songLength, string songLocation1)
        {
            //Creates table if not exists
            MySqlCommand checkAndCreateMusic = new MySqlCommand("CREATE TABLE IF NOT EXISTS Music (SongID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, TrackNo INT(255), SongName VARCHAR(100), SongLength VARCHAR(100), SongLocation VARCHAR(1000), AlbumID INT(255))", connect);
            checkAndCreateMusic.ExecuteNonQuery();
            //Gets albumID of album the song is from
            MySqlCommand selectAlbumID = new MySqlCommand("SELECT AlbumID FROM Albums WHERE Album=\"" + Album + "\" AND Artist=\"" + Artist + "\"", connect);
            MySqlDataReader readAlbumID = selectAlbumID.ExecuteReader();
            while (readAlbumID.Read())
            {
                albumID = readAlbumID.GetString(0);
            }
            checkIfSongExists(songName, trackNo);
            //If songExists is false create record in music table of database for song
            if (songExists == false)
            {
                refreshConnectionToDB();
                MySqlCommand appendMusicInfo = new MySqlCommand("INSERT INTO Music (TrackNo, SongName, SongLength, SongLocation, AlbumID)  VALUES ( " + trackNo + ", \"" + songName + "\", \"" + songLength + "\", \"" + songLocation1 + "\", \"" + albumID + "\")", connect);
                appendMusicInfo.ExecuteNonQuery();
            }
        }

        public void refreshConnectionToDB()
        {
            //Closes and opens all database connections
            connect.Close();
            connect.Open();
            connect2.Close();
            connect2.Open();
            connect3.Close();
            connect3.Open();
        }

        public void openAlbumForm(string locationForLookup)
        {
            //Create new instance of frmKEVINAlbum
            frmKEVINAlbum selectedAlbum = new frmKEVINAlbum()
            {
                Tag = locationForLookup,
            };
            //Display album
            selectedAlbum.Show();
        }

        public void createAlbumButtons(int x, FlowLayoutPanel field, ContextMenuStrip cms)
        {
            //Clear on controls from flp inputted into field
            field.Controls.Clear();
            //Everything in try statement to avoid crashes
            try
            {
                refreshConnectionToDB();
                //Select all albums records ascending alphabetically by Artist then Album
                MySqlCommand selectAlbumsTable = new MySqlCommand("SELECT * FROM Albums ORDER BY Artist ASC, Album ASC", connect);
                MySqlDataReader readAlbumsTable = selectAlbumsTable.ExecuteReader();
                while (readAlbumsTable.Read())
                {
                    albumIDUsedForSearching = readAlbumsTable.GetString(0);
                    //Refresh connection
                    connect2.Close();
                    connect2.Open();
                    //Select the songLocation of every record in the Music table where the AlbumID is equal to the
                    //albumID of of the record the the reader is currently storing
                    MySqlCommand selectAlbumIDFromFirstSong = new MySqlCommand("SELECT SongLocation FROM Music WHERE AlbumID= \"" + readAlbumsTable.GetString(0) + "\" LIMIT 1", connect2);
                    MySqlDataReader readAlbumIDFromFirstSong = selectAlbumIDFromFirstSong.ExecuteReader();
                    while (readAlbumIDFromFirstSong.Read())
                    {
                        //strips tags from song at song location
                        string temp = readAlbumIDFromFirstSong.GetString(0).Replace("'", "\\");
                        TagLib.File findAlbumArt = TagLib.File.Create(temp);
                        MemoryStream memstrm;
                        try
                        {
                            memstrm = new MemoryStream(findAlbumArt.Tag.Pictures[0].Data.Data);
                            albumCoverImage = System.Drawing.Image.FromStream(memstrm);
                        }
                        catch
                        {
                            albumCoverImage = KEVIN.Properties.Resources.NoAlbumArt;

                        }
                        string stringX = readAlbumIDFromFirstSong.GetString(0);
                        //Add a button to the flp stored in field with the properties below
                        field.Controls.Add(attachToButton(new Button
                        {
                            Name = "Album" + readAlbumsTable.GetString(0),
                            ForeColor = Color.WhiteSmoke,
                            Text = readAlbumsTable.GetString(1) + "\n" + readAlbumsTable.GetString(2),
                            Tag = readAlbumIDFromFirstSong.GetString(0),
                            TextAlign = ContentAlignment.BottomCenter,
                            Size = new Size(135, 135),
                            BackgroundImage = albumCoverImage,
                            BackgroundImageLayout = ImageLayout.Zoom,
                            FlatStyle = FlatStyle.Flat,
                            FlatAppearance =
                            {
                                BorderSize = 1,
                                BorderColor = ColorTranslator.FromHtml("#444444"),
                                MouseOverBackColor = Color.Transparent,
                            },
                            ContextMenuStrip = cms,
                        }, () => openAlbumForm(stringX), cms));
                        x++;
                    }
                }
            }
            catch
            {

            }
        }

        public void getAlbumInfoFromLocation(string locationForAlbumID)
        {
            //Selects AlbumID from song location entered in parameter of function
            refreshConnectionToDB();
            //replace \ with ' for sql queries
            locationForAlbumID = locationForAlbumID.Replace("\\", "'");
            MySqlCommand selectAlbumID = new MySqlCommand("SELECT AlbumID FROM Music WHERE SongLocation = \"" + locationForAlbumID + "\" LIMIT 1", connect);
            MySqlDataReader readAlbumID = selectAlbumID.ExecuteReader();
            while (readAlbumID.Read())
            {
                albumIDFromLocation = readAlbumID.GetString(0);
            }
            refreshConnectionToDB();
            MySqlCommand selectAlbumFromAlbumID = new MySqlCommand("SELECT * FROM Albums Where AlbumID= " + albumIDFromLocation, connect);
            MySqlDataReader readAlbumFromAlbumID = selectAlbumFromAlbumID.ExecuteReader();
            while (readAlbumFromAlbumID.Read())
            {
                buttonAlbum = readAlbumFromAlbumID.GetString(1);
                buttonArtist = readAlbumFromAlbumID.GetString(2);
                buttonGenre = readAlbumFromAlbumID.GetString(3);
            }
        }

        public Button attachToButton(Button button, Action method, ContextMenuStrip cms)
        {
            //Attaches a function to the event handler for when the button is clicked and when the mouse
            //is over the button. 
            button.Click += (s, e) => method();
            button.MouseEnter += (s, e) => mouseHoverCMSTag(cms, button);
            return button;
        }

        public void playSongofButton(string songIDForFile, ContextMenuStrip cms)
        {
            //delete every record from queue
            refreshConnectionToDB();
            MySqlCommand deleteAllQueue = new MySqlCommand("DELETE FROM Queue WHERE true", connect);
            deleteAllQueue.ExecuteNonQuery();
            refreshConnectionToDB();
            //reset queue properties 
            currentQueueID = 1;
            queueSize = 1;
            stop = true;
            //Append songs in queue table to flpQueue
            appendQueue(cms);
            refreshConnectionToDB();
            //Get song location of song
            MySqlCommand selectSongLocation = new MySqlCommand("SELECT SongLocation FROM Music WHERE SongID = \"" + songIDForFile + "\"", connect);
            MySqlDataReader readSongLocation = selectSongLocation.ExecuteReader();
            while (readSongLocation.Read())
            {
                yetAnotherTemp = readSongLocation.GetString(0).Replace("'", "\\");
            }
            //Reset more queue properties
            Timer = 0;
            TagLib.File songLengthFromLocation = TagLib.File.Create(yetAnotherTemp);
            SongLength = songLengthFromLocation.Properties.Duration.TotalSeconds;
            //Play song
            frmKEVINMain.mpPlayer.Stop();
            frmKEVINMain.mpPlayer.Open(yetAnotherTemp);
            playing = true;
            frmKEVINMain.mpPlayer.Play();                      
        }

        public void createSongButtons(string locationForAlbumID, FlowLayoutPanel song1, ContextMenuStrip cms)
        {
            //Clear everything from flp stored in song1
            song1.Controls.Clear();
            refreshConnectionToDB();
            //Select the albumID of the album button that was clicked to execute this function
            MySqlCommand selectAlbumID = new MySqlCommand("SELECT AlbumID FROM Music WHERE SongLocation = \"" + locationForAlbumID + "\" LIMIT 1", connect);
            MySqlDataReader readAlbumID = selectAlbumID.ExecuteReader();
            while (readAlbumID.Read())
            {
                albumIDFromLocation = readAlbumID.GetString(0);
            }
            refreshConnectionToDB();
            //Select information from Music table
            MySqlCommand selectSongsFromAlbumID = new MySqlCommand("SELECT SongName, SongLength, TrackNo, SongLocation, SongID FROM Music WHERE AlbumID= \"" + albumIDFromLocation + "\" ORDER BY TrackNo ASC", connect);
            MySqlDataReader readSongsFromAlbumID = selectSongsFromAlbumID.ExecuteReader();
            while (readSongsFromAlbumID.Read())
            {
                //Replace ' with \ so that mpPlayer can play the song when needed
                songLocationmpPlayer = readSongsFromAlbumID.GetString(3).Replace("'","\\");
                //Strip characters from length of song
                string time = readSongsFromAlbumID.GetString(1).Remove(0, 3);
                time = time.Remove(5, 8);
                string anotherTempVar = readSongsFromAlbumID.GetString(4);
                //Create a button for every song in album above with properties below
                song1.Controls.Add(attachToButton(new Button()
                {
                    Name = readSongsFromAlbumID.GetString(2) + " " + readSongsFromAlbumID.GetString(0) + " | " + time,
                    ForeColor = Color.WhiteSmoke,
                    Text = readSongsFromAlbumID.GetInt16(2) + " " + readSongsFromAlbumID.GetString(0) + " | " + time,
                    Tag = readSongsFromAlbumID.GetString(4),
                    Font = new Font("Trebuchet MS", 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = false,
                    Size = new Size(450, 25),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance =
                    {
                        BorderSize = 0,
                    },
                    ContextMenuStrip = cms,
                }, () => playSongofButton(anotherTempVar, cms), cms));
            }
        }

        public void appendQueue(ContextMenuStrip cms)
        {
            //Select QueueID of last item in the queue
            refreshConnectionToDB();
            MySqlCommand selectQueue = new MySqlCommand("SELECT QueueID FROM Queue ORDER BY QueueID DESC LIMIT 1", connect);
            MySqlDataReader readQueue = selectQueue.ExecuteReader();
            while (readQueue.Read())
            {
                //Add one to last QueueID
                tempQueueID = readQueue.GetInt16(0);
                tempQueueID++;
            }
            refreshConnectionToDB();
            //if there are no records in QueueID set tempQueueID to 1
            if (tempQueueID == 0)
            {
                tempQueueID = 1;
            }
            //Add song to queue table
            MySqlCommand appendQueue = new MySqlCommand("INSERT INTO Queue(QueueID, MusicID) VALUES (" + tempQueueID + ", " + cms.Tag.ToString() + ")", connect);
            queueSize++;
            appendQueue.ExecuteNonQuery();
        }

        public void mouseHoverCMSTag(ContextMenuStrip cms, Button b)
        {
            //Sets tag of sontext menu strip listed in function parameters to be equal to the tag of a button listed in the function parameters
            cms.Tag = b.Tag;           
        }

        public void createQueueButtons(FlowLayoutPanel queue, ContextMenuStrip cms)
        {
            //Wipe all controls from flp stored in queue
            queue.Controls.Clear();
            refreshConnectionToDB();
            //Select everything from queue
            MySqlCommand selectQueue = new MySqlCommand("SELECT * FROM Queue", connect);
            MySqlDataReader readQueue = selectQueue.ExecuteReader();
            while (readQueue.Read())
            {
                connect2.Close();
                connect2.Open();
                //Select the song location of the the queue tables record that the readQueue reader is currently storing
                MySqlCommand selectSongInfo = new MySqlCommand("SELECT SongLocation FROM Music WHERE SongID = " + readQueue.GetString(1), connect2);
                MySqlDataReader readSongInfo = selectSongInfo.ExecuteReader();
                while (readSongInfo.Read())
                {
                    //replace every ' with \ in the song location to allow it to be used with mpPlayer
                    string stripSongLocation = readSongInfo.GetString(0).Replace("'", "\\");
                    //Get tags
                    TagLib.File songInfoFromSongLocation = TagLib.File.Create(stripSongLocation);
                    //Get song length and convert it to a string
                    TimeSpan songLength = songInfoFromSongLocation.Properties.Duration;
                    string strSongLength = songLength.ToString().Remove(0, 3);
                    //Create a button for every record in the queue with these properties in the flp stored in queue
                    queue.Controls.Add(attachToButton(new Button()
                    {
                        AutoEllipsis = true,
                        Name = "Queue" + readQueue.GetString(0),
                        ForeColor = Color.WhiteSmoke,
                        Text = songInfoFromSongLocation.Tag.Title + " | " + strSongLength.Remove(5,8),
                        Tag = readQueue.GetString(0),
                        Font = new Font("Trebuchet MS", 10),
                        TextAlign = ContentAlignment.MiddleLeft,
                        Width = queue.Width - 8,
                        Margin = new Padding(4,2,2,4),
                        Anchor = AnchorStyles.Left | AnchorStyles.Right,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance =
                        {
                            BorderSize = 0,
                            MouseOverBackColor = Color.Transparent,
                        },
                        ContextMenuStrip = cms
                    }, () => blankVoid(), cms));
                }   
            }
        }        

        public void openFirstQueueSong(Label songName, PictureBox albumArt)
        {
            //Initialize variables
            currentQueueID = 1;
            int musicID = 0;
            string songLocation = "";
            refreshConnectionToDB();
            //Select number of records from queue
            MySqlCommand selectMaxQueueID = new MySqlCommand("SELECT COUNT(*) FROM Queue", connect);
            MySqlDataReader readMaxQueueID = selectMaxQueueID.ExecuteReader();
            while (readMaxQueueID.Read())
            {
                //Set queue size to number of records in queue table
                queueSize = readMaxQueueID.GetInt16(0);
            }
            refreshConnectionToDB();
            //get first records musicID from queue
            MySqlCommand selectFirstItemInQueue = new MySqlCommand("SELECT MusicID FROM Queue WHERE QueueID = " + currentQueueID, connect);
            MySqlDataReader readFirstItemInQueue = selectFirstItemInQueue.ExecuteReader();
            while (readFirstItemInQueue.Read())
            {
                musicID = readFirstItemInQueue.GetInt16(0);
            }
            refreshConnectionToDB();
            //Select the song location from the first musicID
            MySqlCommand selectSongLocation = new MySqlCommand("SELECT SongLocation FROM Music WHERE SongID = " + musicID, connect);
            MySqlDataReader readSongLocation = selectSongLocation.ExecuteReader();
            while (readSongLocation.Read())
            {
                songLocation = readSongLocation.GetString(0).Replace("'", "\\");
            }
            //Get tags
            TagLib.File songDetails = null;
            try
            {
                songDetails = TagLib.File.Create(songLocation);                        
                SongLength = songDetails.Properties.Duration.TotalSeconds;
                songName.Text = songDetails.Tag.Title.ToString();            
                MemoryStream ms;
                ms = new MemoryStream(songDetails.Tag.Pictures[0].Data.Data);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                albumArt.BackgroundImage = image;
            }
            catch
            {
                albumArt.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt;
            }
            //Open song for playing
            frmKEVINMain.mpPlayer.Open(songLocation);
            //Debugging Variable
            currentlyPlaying = songLocation;
        }

        public void addToPlaylist(string playlistName, int SongID)
        {
            refreshConnectionToDB();
            int count = 0;
            //Get number of record in playlist name stored in playlistName
            MySqlCommand recordCount = new MySqlCommand("SELECT COUNT(*) FROM " + playlistName, connect);
            MySqlDataReader readRecordCount = recordCount.ExecuteReader();
            while (readRecordCount.Read())
            {
                count = readRecordCount.GetInt16(0) + 1;
            }
            refreshConnectionToDB();
            //Insert song ID into playlist name stored in playlistName
            MySqlCommand addToPlaylist = new MySqlCommand("INSERT INTO " + playlistName + " (PlaylistID, SongID) VALUES (" + count + ", " + SongID + ")", connect);
            addToPlaylist.ExecuteNonQuery();
        }

        public void playPlaylist(ContextMenuStrip cms)
        {
            //Initialize variables
            refreshConnectionToDB();
            int[] playlistSongIDs;
            int count = 0;
            int countplus = 0;
            //Get number of songs in playlist
            MySqlCommand countSongs = new MySqlCommand("SELECT COUNT(*) FROM " + cms.Tag.ToString(), connect);
            MySqlDataReader readCountSongs = countSongs.ExecuteReader();
            while (readCountSongs.Read())
            {
                count = readCountSongs.GetInt16(0);
            }
            //Generate an array with count number of fields
            playlistSongIDs = new int[count];
            //Assign each songID in the playlist to a field in the array playlistSongIDs
            MySqlCommand selectPlaylist = new MySqlCommand("SELECT SongID FROM " + cms.Tag.ToString(), connect2);
            MySqlDataReader readPlaylist = selectPlaylist.ExecuteReader();
            count = 0;
            while (readPlaylist.Read())
            {
                playlistSongIDs[count] = readPlaylist.GetInt16(0);
                count++;
            }
            //Delete everything from queue
            MySqlCommand deleteQueue = new MySqlCommand("DELETE FROM queue", connect3);
            deleteQueue.ExecuteNonQuery();
            count = 0;
            //Add each songID stored in playlistSongIDs into queue
            refreshConnectionToDB();
            while (count < playlistSongIDs.Length)
            {
                countplus = count + 1;
                MySqlCommand appendQueue = new MySqlCommand("INSERT INTO queue(QueueID, MusicID) VALUES (" + countplus + ", " + playlistSongIDs[count] + ")", connect);
                appendQueue.ExecuteNonQuery();
                count++;
            }
            //Stop playling music
            frmKEVINMain.mpPlayer.Stop();
            //Reset variables used to control music
            Timer = 0;
            playing = true;
            queueSize = playlistSongIDs.Length;
            currentQueueID = 1;
            string songLocation = "";
            refreshConnectionToDB();
            //Get song location of first item in playlist
            MySqlCommand selectQueue1 = new MySqlCommand("SELECT SongLocation FROM music WHERE SongID = " + playlistSongIDs[0], connect);
            MySqlDataReader readQueue1 = selectQueue1.ExecuteReader();
            while (readQueue1.Read())
            {
                songLocation = readQueue1.GetString(0).Replace("'", "\\");
            }
            TagLib.File songLengthFromLocation = TagLib.File.Create(songLocation);
            SongLength = songLengthFromLocation.Properties.Duration.TotalSeconds;
            frmKEVINMain.mpPlayer.Open(songLocation);
            frmKEVINMain.mpPlayer.Play();
        }

        public void generatePlaylistButtons(FlowLayoutPanel flp,ContextMenuStrip cms)
        {
            //Initialize variables
            string playlistName = "";
            int count = 0;
            string[] songCount;
            //Clear flp stored in flp of controls
            flp.Controls.Clear();
            refreshConnectionToDB();
            //Select everything from playlistinfo table
            MySqlCommand selectPlaylistInfo = new MySqlCommand("SELECT * FROM playlistinfo", connect);
            MySqlDataReader readPlaylistInfo = selectPlaylistInfo.ExecuteReader();
            while (readPlaylistInfo.Read())
            {
                //get name of playlist from record currently being stored by the reader
                playlistName = readPlaylistInfo.GetString(0);
                //Get number of songs in each playlist
                MySqlCommand recordCount = new MySqlCommand("SELECT COUNT(*) FROM " + playlistName, connect2);
                MySqlDataReader readRecordCount = recordCount.ExecuteReader();
                while (readRecordCount.Read())
                {
                    count = readRecordCount.GetInt16(0);
                }
                //create a new array instance in songCount with count number of fields
                songCount = new string[count];
                count = 0;
                connect2.Close();
                connect2.Open();
                //Get everything from playlist name stored in playlistName
                MySqlCommand selectPlaylist = new MySqlCommand("SELECt * FROM " + playlistName, connect2);
                MySqlDataReader readPlaylist = selectPlaylist.ExecuteReader();
                while (readPlaylist.Read())
                {
                    connect3.Close();
                    connect3.Open();   
                    //Select songName and songLength from the music table where SongID is equal to the songID stored in the record of the playlist
                    //readPlaylist is currently storing               
                    MySqlCommand selectSong = new MySqlCommand("SELECT SongName,SongLength FROM music WHERE SongID = " + readPlaylist.GetString(1), connect3);
                    MySqlDataReader readSong = selectSong.ExecuteReader();
                    while (readSong.Read())
                    {
                        //Join some varibles into one and store it into songCount[count] then increment count
                        songCount[count] = readSong.GetString(0) + " | " + readSong.GetString(1).Remove(0,3).Remove(5,8);
                        count++;
                    }
                }
                //Add a control into the flp that is stored in flp with the properties below
                flp.Controls.Add(attachToButton(new Button()
                {
                    Name = playlistName,
                    ForeColor = Color.WhiteSmoke,
                    Text = playlistName.Replace("_", " ") + "\n" + string.Join("\n", songCount),
                    Tag = playlistName,
                    Font = new Font("Trebuchet MS", 8),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(135,135),
                    Anchor= AnchorStyles.Left | AnchorStyles.Top,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance =
                    {
                        BorderColor = ColorTranslator.FromHtml("#3c3c3c"),
                        BorderSize = 1
                    },
                    Margin = new Padding(5,5,5,5),
                    ContextMenuStrip = cms,
                }, () => playPlaylist(cms), cms));
            }
        }

        public void deleteSongFromPlaylist(string songID, string playlist, FlowLayoutPanel flp, ContextMenuStrip cms)
        {
            //Delete song ID stored in songID parameter from the playlist stored in playlist parameter
            refreshConnectionToDB();
            MySqlCommand deleteSong = new MySqlCommand("DELETE FROM " + playlist + " WHERE SongID = " + songID, connect);
            deleteSong.ExecuteNonQuery();
            //Clear all controls that are children of flp stored in flp
            flp.Controls.Clear();
            //Regenerate every playlist button
            generatePlaylistButtons(flp, cms);
        }
    }
}
