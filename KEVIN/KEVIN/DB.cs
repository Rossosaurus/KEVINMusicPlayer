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
        public MySqlConnection connect = new MySqlConnection();

        //MySQL Commands not used in functions
        
        public void KEVINDBOnLoad()
        {
            MySqlCommand CheckAndCeateMusic = new MySqlCommand("CREATE TABLE IF NOT EXISTS Music (SongID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, TrackNo VARCHAR(1000), SongName VARCHAR(100), SongLength VARCHAR(100), Artist VARCHAR(100), Album VARCHAR(100), Genre VARCHAR(100), SongLocation VARCHAR(1000))");
            connect.ConnectionString = "server=localhost; port=3306; userid=KEVIN; password=; database=kevin;";
            connect.Open();
            CheckAndCeateMusic.Connection = connect;
            CheckAndCeateMusic.ExecuteNonQuery();
        }
        
        public void appendSongInformation(string TrackID, string Song_Name, string SongLength, string Album, string Artist, string Genre, string SongLocation)
        {
            MySqlCommand append = new MySqlCommand("INSERT INTO music (TrackNo, SongName, SongLength, Album, Artist, Genre, SongLocation)  VALUES (\"" + TrackID + "\", \"" + Song_Name + "\", \"" + SongLength + "\", \"" + Album + "\", \"" + Artist + "\", \"" + Genre + "\", \"" + SongLocation + "\")");
            append.Connection = connect;
            append.ExecuteNonQuery();
        }
        public void countRecords()
        {
            MySqlCommand noOfRows = new MySqlCommand("SELECT COUNT(TrackNo) FROM Music");
        }

    }
}
