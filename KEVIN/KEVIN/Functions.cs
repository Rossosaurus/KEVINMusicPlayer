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
        bool albumExists = false;
        string album;
        string artist;
        bool songExists;
        string TrackNo;
        string songNameofSong;
        System.Drawing.Image albumCoverImage;
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

        public void createAndAppendMusicInfoToTables(string Album, string Artist, string Genre, string trackNo, string songName, string songLength, string songLocation1)
        {
            MySqlCommand checkandCreateAlbum = new MySqlCommand("CREATE TABLE IF NOT EXISTS Albums (AlbumID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, Album VARCHAR(1000), Artist VARCHAR(100), Genre VARCHAR(100))", connect);
            MySqlCommand checkAndCreateMusic = new MySqlCommand("CREATE TABLE IF NOT EXISTS Music (SongID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, TrackNo VARCHAR(1000), SongName VARCHAR(100), SongLength VARCHAR(100), SongLocation VARCHAR(1000), AlbumID INT(255))", connect);
            checkandCreateAlbum.ExecuteNonQuery();
            checkAndCreateMusic.ExecuteNonQuery();
            checkIfAlbumExists(Album, Artist);
            if (albumExists == false)
            {
                refreshConnectionToDB();
                MySqlCommand appendAlbumInfo = new MySqlCommand("INSERT INTO Albums (Album, Artist, Genre) VALUES (\"" + Album + "\", \"" + Artist + "\", \"" + Genre + "\")", connect);
                appendAlbumInfo.ExecuteNonQuery();
            }
            refreshConnectionToDB();
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

        public void openAlbumForm()
        {
            
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
                MySqlCommand selectAlbumsTable = new MySqlCommand("SELECT * FROM Albums ORDER BY Artist ASC, Album DESC", connect);
                MySqlDataReader readAlbumsTable = selectAlbumsTable.ExecuteReader();
                while (readAlbumsTable.Read())
                {
                    connect2.Close();
                    connect2.Open();
                    MySqlCommand selectAlbumIDFromFirstSong = new MySqlCommand("SELECT SongLocation FROM Music Where AlbumID= \"" + readAlbumsTable.GetString(0) + "\" LIMIT 1", connect2);
                    MySqlDataReader readAlbumIDFromFirstSong = selectAlbumIDFromFirstSong.ExecuteReader();
                    while (readAlbumIDFromFirstSong.Read())
                    {
                        string temp = readAlbumIDFromFirstSong.GetString(0).Replace("\"", "\\");
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
                        field.Controls.Add(AttachMethodToButton(new Button
                        {
                            Name = "Album" + readAlbumsTable.GetString(0),
                            ForeColor = Color.WhiteSmoke,
                            Text = readAlbumsTable.GetString(1) + "\n" + readAlbumsTable.GetString(2),
                            TextAlign = ContentAlignment.BottomCenter,
                            Size = new Size(130, 130),
                            BackgroundImage = albumCoverImage,
                            BackgroundImageLayout = ImageLayout.Zoom,
                            FlatStyle = FlatStyle.Flat,
                            FlatAppearance =
                            {
                                BorderSize = 1,
                                BorderColor = ColorTranslator.FromHtml("#444444"),
                            },
                        }, () => openAlbumForm()));
                        x++;
                    }
                }
            }
            catch
            {

            }
        }
    }
}
