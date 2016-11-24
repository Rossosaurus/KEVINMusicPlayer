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
    class Functions
    {
        //Variables
        MusicPlayer mpPlayer = new MusicPlayer();
        public MySqlConnection connect = new MySqlConnection("server=localhost; port=3306; userid=KEVIN; password=; database=kevin;");
        public MySqlConnection connect2 = new MySqlConnection("server=localhost; port=3306; userid=KEVIN; password=; database=kevin;");
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
        string yetAnotherTemp;

        //MySQL Commands not used in functions

        public void connectToDB()
        {
            connect.Open();
            connect2.Open();
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
            MySqlCommand checkAndCreateMusic = new MySqlCommand("CREATE TABLE IF NOT EXISTS Music (SongID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, TrackNo VARCHAR(1000), SongName VARCHAR(100), SongLength VARCHAR(100), SongLocation VARCHAR(1000), AlbumID INT(255))", connect);
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
                MySqlCommand appendMusicInfo = new MySqlCommand("INSERT INTO Music (TrackNo, SongName, SongLength, SongLocation, AlbumID)  VALUES(\"" + trackNo + "\", \"" + songName + "\", \"" + songLength + "\", \"" + songLocation1 + "\", \"" + albumID + "\")", connect);
                appendMusicInfo.ExecuteNonQuery();
            }
        }

        public void refreshConnectionToDB()
        {
            connect.Close();
            connect.Open();
        }

        public void countRecords()
        {
            MySqlCommand noOfRows = new MySqlCommand("SELECT COUNT(TrackNo) FROM Music");
        }

        public void openAlbumForm(string locationForLookup)
        {
            frmKEVINAlbum selectedAlbum = new frmKEVINAlbum()
            {
                Tag = locationForLookup,
            };
            selectedAlbum.Show();
        }

        public Button AttachMethodToButton(Button b, Action buttonMethod)
        {
            b.Click += (s, e) => buttonMethod();
            return b;
        }

        public void createAlbumButtons(int x, FlowLayoutPanel field)
        {
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
                        field.Controls.Add(AttachMethodToButton(new Button
                        {
                            Name = "Album" + readAlbumsTable.GetString(0),
                            ForeColor = Color.WhiteSmoke,
                            Text = readAlbumsTable.GetString(1) + "\n" + readAlbumsTable.GetString(2),
                            TextAlign = ContentAlignment.BottomCenter,
                            Size = new Size(135, 135),
                            BackgroundImage = albumCoverImage,
                            BackgroundImageLayout = ImageLayout.Zoom,
                            FlatStyle = FlatStyle.Flat,
                            FlatAppearance =
                            {
                                BorderSize = 1,
                                BorderColor = ColorTranslator.FromHtml("#444444"),
                            },
                        }, () => openAlbumForm(stringX)));
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

        public Button attachSongToButton(Button button, Action method)
        {
            button.Click += (s, e) => method();
            return button;
        }

        public void playSongofButton(string songIDForFile)
        {
            refreshConnectionToDB();
            MySqlCommand selectSongLocation = new MySqlCommand("SELECT SongLocation FROM Music WHERE SongID = \"" + songIDForFile + "\"", connect);
            MySqlDataReader readSongLocation = selectSongLocation.ExecuteReader();
            while (readSongLocation.Read())
            {
                yetAnotherTemp = readSongLocation.GetString(0).Replace("'", "\\");
            }
            mpPlayer.Pause();
            mpPlayer.Stop();
            mpPlayer.Open(yetAnotherTemp);
            mpPlayer.Play();
        }

        public void createSongButtons(string locationForAlbumID, FlowLayoutPanel song1)
        {
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
            double x = 0;
            while (readSongsFromAlbumID.Read())
            {
                x++;
            }
            x = x / 2;
            double halfSongCount = Math.Round(x, 0, MidpointRounding.AwayFromZero);
            refreshConnectionToDB();
            x = 0;
            readSongsFromAlbumID = selectSongsFromAlbumID.ExecuteReader();
            while (readSongsFromAlbumID.Read())
            {
                songLocationmpPlayer = readSongsFromAlbumID.GetString(3).Replace("'","\\");
                string time = readSongsFromAlbumID.GetString(1).Remove(0, 3);
                time = time.Remove(5, 8);
                string anotherTempVar = readSongsFromAlbumID.GetString(4);
                song1.Controls.Add(attachSongToButton(new Button()
                {
                    Name = readSongsFromAlbumID.GetString(2) + " " + readSongsFromAlbumID.GetString(0) + " | " + time,
                    ForeColor = ColorTranslator.FromHtml("#646464"),
                    Text = readSongsFromAlbumID.GetInt16(2) + " " + readSongsFromAlbumID.GetString(0) + " | " + time,
                    Font = new Font("Trebuchet MS", 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = false,
                    Size = new Size(455, 25),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance =
                    {
                        BorderSize = 0,
                    },
                }, () => playSongofButton(anotherTempVar)));
            }
        }
    }
}
