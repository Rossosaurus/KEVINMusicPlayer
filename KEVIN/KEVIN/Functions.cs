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
        public int currentQueueID = 0;
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
            connect.Open();
            connect2.Open();
            connect3.Open();
        }

        public void createTables()
        {
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
            refreshConnectionToDB();
            MySqlCommand selectAlbumAndArtist = new MySqlCommand("SELECT Album, Artist FROM Albums", connect);
            MySqlDataReader readAlbumAndArtist = selectAlbumAndArtist.ExecuteReader();
            while (readAlbumAndArtist.Read())
            {
                album = readAlbumAndArtist.GetString(0);
                artist = readAlbumAndArtist.GetString(1);
                if (album1 == album && artist1 == artist)
                {
                    albumExists = true;
                    return;
                }
            }
        }
        
        public void checkIfSongExists(string song, string trackNoOfSong)
        {
            refreshConnectionToDB();
            MySqlCommand selectTrackNoAndSongName = new MySqlCommand("SELECT TrackNo, SongName FROM Music", connect);
            MySqlDataReader readTrackNoAndSongName = selectTrackNoAndSongName.ExecuteReader();
            while (readTrackNoAndSongName.Read())
            {
                TrackNo = readTrackNoAndSongName.GetString(0);
                songNameofSong = readTrackNoAndSongName.GetString(1);
            }
            
            if (song == songNameofSong && trackNoOfSong == TrackNo)
            {
                songExists = true;
                return;
            }
        }

        public void CreateAndAppendAlbumInfoToTables(string AlbumToAppend, string Artist, string Genre)
        {
            MySqlCommand checkandCreateAlbum = new MySqlCommand("CREATE TABLE IF NOT EXISTS Albums (AlbumID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, Album VARCHAR(1000), Artist VARCHAR(100), Genre VARCHAR(100))", connect);
            checkandCreateAlbum.ExecuteNonQuery();
            checkIfAlbumExists(AlbumToAppend, Artist);
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
            MySqlCommand checkAndCreateMusic = new MySqlCommand("CREATE TABLE IF NOT EXISTS Music (SongID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, TrackNo INT(255), SongName VARCHAR(100), SongLength VARCHAR(100), SongLocation VARCHAR(1000), AlbumID INT(255))", connect);
            checkAndCreateMusic.ExecuteNonQuery();
            MySqlCommand selectAlbumID = new MySqlCommand("SELECT AlbumID FROM Albums WHERE Album=\"" + Album + "\" AND Artist=\"" + Artist + "\"", connect);
            MySqlDataReader readAlbumID = selectAlbumID.ExecuteReader();
            while (readAlbumID.Read())
            {
                albumID = readAlbumID.GetString(0);
            }
            checkIfSongExists(songName, trackNo);
            if (songExists == false)
            {
                refreshConnectionToDB();
                MySqlCommand appendMusicInfo = new MySqlCommand("INSERT INTO Music (TrackNo, SongName, SongLength, SongLocation, AlbumID)  VALUES ( " + trackNo + ", \"" + songName + "\", \"" + songLength + "\", \"" + songLocation1 + "\", \"" + albumID + "\")", connect);
                appendMusicInfo.ExecuteNonQuery();
            }
        }

        public void refreshConnectionToDB()
        {
            connect.Close();
            connect.Open();
            connect2.Close();
            connect2.Open();
            connect3.Close();
            connect3.Open();
        }

        public void openAlbumForm(string locationForLookup)
        {
            frmKEVINAlbum selectedAlbum = new frmKEVINAlbum()
            {
                Tag = locationForLookup,
            };
            selectedAlbum.Show();
        }

        public void createAlbumButtons(int x, FlowLayoutPanel field, ContextMenuStrip cms)
        {
            field.Controls.Clear();
            try
            {
                refreshConnectionToDB();
                MySqlCommand selectAlbumsTable = new MySqlCommand("SELECT * FROM Albums ORDER BY Artist ASC, Album ASC", connect);
                MySqlDataReader readAlbumsTable = selectAlbumsTable.ExecuteReader();
                while (readAlbumsTable.Read())
                {
                    albumIDUsedForSearching = readAlbumsTable.GetString(0);
                    connect2.Close();
                    connect2.Open();
                    MySqlCommand selectAlbumIDFromFirstSong = new MySqlCommand("SELECT SongLocation FROM Music WHERE AlbumID= \"" + readAlbumsTable.GetString(0) + "\" LIMIT 1", connect2);
                    MySqlDataReader readAlbumIDFromFirstSong = selectAlbumIDFromFirstSong.ExecuteReader();
                    while (readAlbumIDFromFirstSong.Read())
                    {
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
            refreshConnectionToDB();
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
            button.Click += (s, e) => method();
            button.MouseEnter += (s, e) => mouseHoverCMSTag(cms, button);
            return button;
        }

        public void playSongofButton(string songIDForFile, ContextMenuStrip cms)
        {
            refreshConnectionToDB();
            MySqlCommand deleteAllQueue = new MySqlCommand("DELETE FROM Queue WHERE true", connect);
            deleteAllQueue.ExecuteNonQuery();
            refreshConnectionToDB();
            currentQueueID = 1;
            queueSize = 1;
            stop = true;
            appendQueue(cms);
            refreshConnectionToDB();
            MySqlCommand selectSongLocation = new MySqlCommand("SELECT SongLocation FROM Music WHERE SongID = \"" + songIDForFile + "\"", connect);
            MySqlDataReader readSongLocation = selectSongLocation.ExecuteReader();
            while (readSongLocation.Read())
            {
                yetAnotherTemp = readSongLocation.GetString(0).Replace("'", "\\");
            }
            Timer = 0;
            TagLib.File songLengthFromLocation = TagLib.File.Create(yetAnotherTemp);
            SongLength = songLengthFromLocation.Properties.Duration.TotalSeconds;
            frmKEVINMain.mpPlayer.Stop();
            frmKEVINMain.mpPlayer.Open(yetAnotherTemp);
            playing = true;
            frmKEVINMain.mpPlayer.Play();                      
        }

        public void createSongButtons(string locationForAlbumID, FlowLayoutPanel song1, ContextMenuStrip cms)
        {
            song1.Controls.Clear();
            refreshConnectionToDB();
            MySqlCommand selectAlbumID = new MySqlCommand("SELECT AlbumID FROM Music WHERE SongLocation = \"" + locationForAlbumID + "\" LIMIT 1", connect);
            MySqlDataReader readAlbumID = selectAlbumID.ExecuteReader();
            while (readAlbumID.Read())
            {
                albumIDFromLocation = readAlbumID.GetString(0);
            }
            refreshConnectionToDB();
            MySqlCommand selectSongsFromAlbumID = new MySqlCommand("SELECT SongName, SongLength, TrackNo, SongLocation, SongID FROM Music WHERE AlbumID= \"" + albumIDFromLocation + "\" ORDER BY TrackNo ASC", connect);
            MySqlDataReader readSongsFromAlbumID = selectSongsFromAlbumID.ExecuteReader();
            while (readSongsFromAlbumID.Read())
            {
                songLocationmpPlayer = readSongsFromAlbumID.GetString(3).Replace("'","\\");
                string time = readSongsFromAlbumID.GetString(1).Remove(0, 3);
                time = time.Remove(5, 8);
                string anotherTempVar = readSongsFromAlbumID.GetString(4);
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
            refreshConnectionToDB();
            MySqlCommand selectQueue = new MySqlCommand("SELECT QueueID FROM Queue ORDER BY QueueID DESC LIMIT 1", connect);
            MySqlDataReader readQueue = selectQueue.ExecuteReader();
            while (readQueue.Read())
            {
                tempQueueID = readQueue.GetInt16(0);
                tempQueueID++;
            }
            refreshConnectionToDB();
            if (tempQueueID == 0)
            {
                tempQueueID = 1;
            }
            MySqlCommand appendQueue = new MySqlCommand("INSERT INTO Queue(QueueID, MusicID) VALUES (" + tempQueueID + ", " + cms.Tag.ToString() + ")", connect);
            queueSize++;
            appendQueue.ExecuteNonQuery();
        }

        public void mouseHoverCMSTag(ContextMenuStrip cms, Button b)
        {
            cms.Tag = b.Tag;
           
        }

        public void createQueueButtons(FlowLayoutPanel queue, ContextMenuStrip cms)
        {
            queue.Controls.Clear();
            refreshConnectionToDB();
            MySqlCommand selectQueue = new MySqlCommand("SELECT * FROM Queue", connect);
            MySqlDataReader readQueue = selectQueue.ExecuteReader();
            while (readQueue.Read())
            {
                connect2.Close();
                connect2.Open();
                MySqlCommand selectSongInfo = new MySqlCommand("SELECT SongLocation FROM Music WHERE SongID = " + readQueue.GetString(1), connect2);
                MySqlDataReader readSongInfo = selectSongInfo.ExecuteReader();
                while (readSongInfo.Read())
                {
                    string stripSongLocation = readSongInfo.GetString(0).Replace("'", "\\");
                    TagLib.File songInfoFromSongLocation = TagLib.File.Create(stripSongLocation);
                    TimeSpan songLength = songInfoFromSongLocation.Properties.Duration;
                    string strSongLength = songLength.ToString().Remove(0, 3);
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
            currentQueueID = 1;
            int musicID = 0;
            string songLocation = "";
            refreshConnectionToDB();
            MySqlCommand selectMaxQueueID = new MySqlCommand("SELECT COUNT(*) FROM Queue", connect);
            MySqlDataReader readMaxQueueID = selectMaxQueueID.ExecuteReader();
            while (readMaxQueueID.Read())
            {
                queueSize = readMaxQueueID.GetInt16(0);
            }
            refreshConnectionToDB();
            MySqlCommand selectFirstItemInQueue = new MySqlCommand("SELECT MusicID FROM Queue WHERE QueueID = " + currentQueueID, connect);
            MySqlDataReader readFirstItemInQueue = selectFirstItemInQueue.ExecuteReader();
            while (readFirstItemInQueue.Read())
            {
                musicID = readFirstItemInQueue.GetInt16(0);
            }
            refreshConnectionToDB();
            MySqlCommand selectSongLocation = new MySqlCommand("SELECT SongLocation FROM Music WHERE SongID = " + musicID, connect);
            MySqlDataReader readSongLocation = selectSongLocation.ExecuteReader();
            while (readSongLocation.Read())
            {
                songLocation = readSongLocation.GetString(0).Replace("'", "\\");
            }
            TagLib.File songDetails = null;
            try
            {
                songDetails = TagLib.File.Create(songLocation);
            }
            catch { }
            try
            {                
                SongLength = songDetails.Properties.Duration.TotalSeconds;
                songName.Text = songDetails.Tag.Title.ToString();
            }
            catch { }            
            MemoryStream ms;
            try
            {
                ms = new MemoryStream(songDetails.Tag.Pictures[0].Data.Data);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                albumArt.BackgroundImage = image;
            }
            catch
            {
                albumArt.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt;
            }
            frmKEVINMain.mpPlayer.Open(songLocation);
            currentlyPlaying = songLocation;
        }

        public void addToPlaylist(string playlistName, int SongID)
        {
            refreshConnectionToDB();
            int count = 0;
            MySqlCommand recordCount = new MySqlCommand("SELECT COUNT(*) FROM " + playlistName, connect);
            MySqlDataReader readRecordCount = recordCount.ExecuteReader();
            while (readRecordCount.Read())
            {
                count = readRecordCount.GetInt16(0) + 1;
            }
            refreshConnectionToDB();
            MySqlCommand addToPlaylist = new MySqlCommand("INSERT INTO " + playlistName + " (PlaylistID, SongID) VALUES (" + count + ", " + SongID + ")", connect);
            addToPlaylist.ExecuteNonQuery();
        }

        public void playPlaylist(ContextMenuStrip cms)
        {
            
        }

        public void generatePlaylistButtons(FlowLayoutPanel flp,ContextMenuStrip cms)
        {
            string playlistName = "";
            int count = 0;
            string[] songCount;
            flp.Controls.Clear();
            refreshConnectionToDB();
            MySqlCommand selectPlaylistInfo = new MySqlCommand("SELECT * FROM playlistinfo", connect);
            MySqlDataReader readPlaylistInfo = selectPlaylistInfo.ExecuteReader();
            while (readPlaylistInfo.Read())
            {
                playlistName = readPlaylistInfo.GetString(0);
                MySqlCommand recordCount = new MySqlCommand("SELECT COUNT(*) FROM " + playlistName, connect2);
                MySqlDataReader readRecordCount = recordCount.ExecuteReader();
                while (readRecordCount.Read())
                {
                    count = readRecordCount.GetInt16(0);
                }
                songCount = new string[count];
                count = 0;
                connect2.Close();
                connect2.Open();
                MySqlCommand selectPlaylist = new MySqlCommand("SELECt * FROM " + playlistName, connect2);
                MySqlDataReader readPlaylist = selectPlaylist.ExecuteReader();
                while (readPlaylist.Read())
                {
                    connect3.Close();
                    connect3.Open();                    
                    MySqlCommand selectSong = new MySqlCommand("SELECT SongName,SongLength FROM music WHERE SongID = " + readPlaylist.GetString(1), connect3);
                    MySqlDataReader readSong = selectSong.ExecuteReader();
                    while (readSong.Read())
                    {
                        songCount[count] = readSong.GetString(0) + " | " + readSong.GetString(1).Remove(0,3).Remove(5,8);
                        count++;
                    }
                }
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
            refreshConnectionToDB();
            MySqlCommand deleteSong = new MySqlCommand("DELETE FROM " + playlist + " WHERE SongID = " + songID, connect);
            deleteSong.ExecuteNonQuery();
            flp.Controls.Clear();
            generatePlaylistButtons(flp, cms);
        }
    }
}
