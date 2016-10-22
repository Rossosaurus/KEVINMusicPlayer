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
        MySqlConnection connect = new MySqlConnection();
        MySqlCommand CheckAndCeateMusic = new MySqlCommand("CREATE TABLE IF NOT EXISTS Music (SongID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, TrackNo INT(255), SongName VARCHAR(100), Artist VARCHAR(100), Album VARCHAR(100), SongLocation VARCHAR(1000))");
        public void KEVINDBOnLoad()
        {
            connect.ConnectionString = "server=localhost; port=3306; userid=KEVIN; password=; database=kevin;";
            connect.Open();
            CheckAndCeateMusic.Connection = connect;
            CheckAndCeateMusic.ExecuteNonQuery();
        }
        
        public void appendSongInformation(string TrackID, string Song_Name, string Album, string Artist, string SongLocation)
        {
            MySqlCommand append = new MySqlCommand("INSERT INTO music (TrackNo, SongName, Album, Artist, SongLocation)  VALUES (\"" + TrackID + "\", \"" + Song_Name + "\", \"" + Album + "\", \"" + Artist + "\", \"" + SongLocation + "\")");
            append.Connection = connect;
            append.ExecuteNonQuery();
        }
    }
}
