/*selectTrackNo.Connection = DB.connect;
MySqlDataReader trackNoReader = selectTrackNo.ExecuteReader();
            while (trackNoReader.Read())
            {
                createButton(flpTrackNo, TrackNo, x, trackNoReader, () => mpPlay(x));
                x++;
            }
            x = 1;
            selectTrackNo.Connection.Close();
            DB.KEVINDBOnLoad();
            selectSongName.Connection = DB.connect;
            MySqlDataReader songNameReader = selectSongName.ExecuteReader();
            while (songNameReader.Read())
            {
                createButton(flpSong, SongName, x, songNameReader, () => mpPlay(x));
                x++;
            }
            x = 1;
            selectSongName.Connection.Close();
            DB.KEVINDBOnLoad();
            selectSongLength.Connection = DB.connect;
            MySqlDataReader songLengthReader = selectSongLength.ExecuteReader();
            while (songLengthReader.Read())
            {
                string y = songLengthReader[0] as string;


                createButton(flpSongLength, y, x, songLengthReader, () => mpPlay(x));
                x++;
            }
            x = 1;
            selectSongLength.Connection.Close();
            DB.KEVINDBOnLoad();
            selectAlbum.Connection = DB.connect;
            MySqlDataReader albumReader = selectAlbum.ExecuteReader();
            while (albumReader.Read())
            {
                createButton(flpAlbum, Album, x, albumReader, () => mpPlay(x));
                x++;
            }
            x = 1;
            selectAlbum.Connection.Close();
            DB.KEVINDBOnLoad();
            selectArtist.Connection = DB.connect;
            MySqlDataReader artistReader = selectArtist.ExecuteReader();
            while (artistReader.Read())
            {
                createButton(flpArtist, Artist, x, artistReader, () => mpPlay(x));
                x++;
            }
            x = 1;
            selectArtist.Connection.Close();
            DB.KEVINDBOnLoad();
            selectGenre.Connection = DB.connect;
            MySqlDataReader genreReader = selectGenre.ExecuteReader();
            while (genreReader.Read())
            {
                createButton(flpGenre, Genre, x, genreReader, () => mpPlay(x));

            }
            selectArtist.Connection.Close();*/

    /*public void queuePlayFirstSong(Label songName, PictureBox albumArt)
    {
        refreshConnectionToDB();
        MySqlCommand selectFirstQueueItem = new MySqlCommand("SELECT MusicID FROM Queue Where QueueID = 0", connect);
        MySqlDataReader readFirstQueueItem = selectFirstQueueItem.ExecuteReader();
        string firstSong = "";
        while (readFirstQueueItem.Read())
        {
            firstSong = readFirstQueueItem.GetString(0);
        }
        refreshConnectionToDB();
        MySqlCommand selectSongInfo = new MySqlCommand("SELECT SongLocation From Music WHERE SongID = " + firstSong, connect);
        MySqlDataReader readSongInfo = selectSongInfo.ExecuteReader();
        string songLocationSlash = "";
        while (readSongInfo.Read())
        {
            songLocationSlash = readSongInfo.GetString(0);
        }
        songLocationSlash = songLocationSlash.Replace("'", "\\");
        frmKEVINMain.mpPlayer.Open(songLocationSlash);
        frmKEVINMain.mpPlayer.Play();
        TagLib.File songInfo = TagLib.File.Create(songLocationSlash);
        songName.Text = songInfo.Tag.Title;
        //main.Text = songInfo.Tag.Title + " - KEVIN MP";
        MemoryStream ms;
        try
        {
            ms = new MemoryStream(songInfo.Tag.Pictures[0].Data.Data);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            albumArt.BackgroundImage = image;
        }
        catch
        {
            albumArt.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt;
        }

    }

    public void playQueueSongs(bool playing, Button b, Label songName, PictureBox albumArt)
    {
        refreshConnectionToDB();
        int maxQueueID = 0;
        MySqlCommand getMaxQueueID = new MySqlCommand("SELECT COUNT(*) FROM Queue", connect);
        MySqlDataReader readMaxQueueID = getMaxQueueID.ExecuteReader();
        while (readMaxQueueID.Read())
        {
            maxQueueID = readMaxQueueID.GetInt16(0);
        }
        string[] queueArray = new string[maxQueueID];
        if (playing == true)
        {
            playing = false;
            b.BackgroundImage = KEVIN.Properties.Resources.Play_fw;
            frmKEVINMain.mpPlayer.Pause();
        }
        else if (playing == false)
        {
            playing = true;
            b.BackgroundImage = KEVIN.Properties.Resources.Pause_fw;
            queuePlayFirstSong(songName, albumArt);
            while (true && playing == true)
            {

            }
        }
    }
    public void waitSongLength(int songLength)
    {
        if (songLength == songLengthComparator)
        {
            refreshConnectionToDB();
            MySqlCommand selectNextQueueItem = new MySqlCommand("SELECT MusicID FROM Queue Where QueueID = 0", connect);
            MySqlDataReader readNextQueueItem = selectNextQueueItem.ExecuteReader();
            string firstSong = "";
            while (readNextQueueItem.Read())
            {
                firstSong = readNextQueueItem.GetString(0);
            }
            refreshConnectionToDB();
            MySqlCommand selectSongInfo = new MySqlCommand("SELECT SongLocation From Music WHERE SongID = " + firstSong, connect);
            MySqlDataReader readSongInfo = selectSongInfo.ExecuteReader();
            string songLocationSlash = "";
            while (readSongInfo.Read())
            {
                songLocationSlash = readSongInfo.GetString(0);
            }
            if (true)
            {

            }
        }
    }*/