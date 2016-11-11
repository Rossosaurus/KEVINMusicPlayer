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
