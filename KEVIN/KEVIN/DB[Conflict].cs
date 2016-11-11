using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KEVIN
{
    class DB
    {
        //Variables
        public MySqlConnection connect = new MySqlConnection("server=localhost; port=3306; userid=KEVIN; password=; database=kevin;");
        string albumID;
        //MySQL Commands not used in functions

        public void connectToDB()
        {
            connect.Open();
        }
        
        public void createAndAppendMusicInfoToTables(string Album, string Artist, string Genre, string trackNo, string songName, string songLength, string songLocation)
        {
            MySqlCommand checkandCreateAlbum = new MySqlCommand("CREATE TABLE IF NOT EXISTS Albums (Album ID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, Album VARCHAR(1000), Artist VARCHAR(100), Genre VARCHAR(100)", connect);
            MySqlCommand checkAndCreateMusic = new MySqlCommand("CREATE TABLE IF NOT EXISTS Music (SongID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, TrackNo VARCHAR(1000), SongName VARCHAR(100), SongLength VARCHAR(100), SongLocation VARCHAR(1000), AlbumID VARCHAR(9999), FOREIGN KEY(AlbumID) REFERENCES Albums(AlbumID))", connect);
            checkAndCreateMusic.ExecuteNonQuery();
            checkandCreateAlbum.ExecuteNonQuery();
            MySqlCommand appendAlbumInfo = new MySqlCommand("INSERT INTO Albums (Album, Artist, Genre) VALUES (\"" + Album + "\", \"" + Artist + "\", \"" + Genre + "\")", connect);
            appendAlbumInfo.ExecuteNonQuery();
            MySqlCommand selectAlbumID = new MySqlCommand("SELECT AlbumID FROM Albums Where (Album=\"" + Album + "\" AND Artist=\"" + Artist + "\" AND Genre\"" + Genre + "\")", connect);
            MySqlDataReader readAlbumID = selectAlbumID.ExecuteReader();
            while (readAlbumID.Read())
            {
                albumID = readAlbumID[0] as string;
            }
            MySqlCommand appendMusicInfo = new MySqlCommand("INSERT INTO music (TrackNo, SongName, SongLength, SongLocation, AlbumID)  VALUES (\"" + trackNo + "\", \"" + songName + "\", \"" + songLength + "\", \"" + songLocation + "\", \"" + albumID + "\")", connect);
            appendMusicInfo.ExecuteNonQuery();
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

        public void createOrAppendToAlbum(string Album)
        {
            MySqlCommand checkAlbumTableExists = new MySqlCommand("CREATE TABLE IF NOT EXISTS" + Album + "(Album ID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, Album VARCHAR(1000), Artist VARCHAR(100), Genre VARCHAR(100)");
            checkAlbumTableExists.ExecuteNonQuery();
        }
    }
}
