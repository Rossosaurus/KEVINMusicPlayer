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
        MySqlCommand CheckAndCeateMusic = new MySqlCommand("CREATE TABLE IF NOT EXISTS Music (SongID INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, SongName VARCHAR(100), Artists VARCHAR(100), Album VARCHAR(100), SongLocation VARCHAR(1000))");
        public void KEVINDBOnLoad()
        {
            connect.ConnectionString = "server=localhost; port=3306; userid=KEVIN; password=; database=kevin;";
            connect.Open();
            CheckAndCeateMusic.Connection = connect;
            CheckAndCeateMusic.ExecuteNonQuery();
        }
        
        public void appendSongInformation(string SongID,string SongName, string Album, string Artist, string SongLocation)
        {
            MySqlCommand append = new MySqlCommand("INSERT INTO music (SongName, Album, Artist, SongLocation)  VALUES (" + SongName + "," + Album + "," + Artist + "," + SongLocation + ")");
            append.Connection = connect;
            append.ExecuteNonQuery();
        }
    }
}
