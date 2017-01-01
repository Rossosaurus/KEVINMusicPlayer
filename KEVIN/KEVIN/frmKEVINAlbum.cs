using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using TagLib;
using System.IO;

namespace KEVIN
{

    public partial class frmKEVINAlbum : Form
    {
        Functions AlbumFunctions = new Functions();
        string locationWithApostrophe;
        public frmKEVINAlbum()
        {
            InitializeComponent();
        }

        public void frmKEVINAddMusic_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#444444");
            lblAlbumName.ForeColor = Color.WhiteSmoke;
            pnlHeader.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            lblArtistAndGenre.ForeColor = Color.WhiteSmoke;
            locationWithApostrophe = this.Tag.ToString();
            string replaceLocation = locationWithApostrophe.Replace("'", "\\");
            TagLib.File albumTags = TagLib.File.Create(replaceLocation);
            this.Text = albumTags.Tag.Album + " - " + albumTags.Tag.FirstArtist;
            lblAlbumName.Text = albumTags.Tag.Album;
            lblArtistAndGenre.Text = albumTags.Tag.FirstArtist + "\n" + albumTags.Tag.FirstGenre;
            MemoryStream msAlbumArt;
            try
            {
                msAlbumArt = new MemoryStream(albumTags.Tag.Pictures[0].Data.Data);
                System.Drawing.Image image = System.Drawing.Image.FromStream(msAlbumArt);
                pbAlbumArt.BackgroundImage = image;
            }
            catch
            {
                pbAlbumArt.BackgroundImage = KEVIN.Properties.Resources.NoAlbumArt;
            }
            frmKEVINMain.Functions.getAlbumInfoFromLocation(locationWithApostrophe);
            frmKEVINMain.Functions.createSongButtons(locationWithApostrophe, flpSongsWrapper, cmsRightClickSongs);  
        }

        private void cmsRightClickSongs_Opening(object sender, CancelEventArgs e)
        {
            addToPlaylistToolStripMenuItem.DropDownItems.Clear();
            int playlistCount = 0;
            int counter = 0;
            ToolStripMenuItem[] playlistNames;
            frmKEVINMain.Functions.refreshConnectionToDB();
            MySqlCommand selectPlaylistCount = new MySqlCommand("SELECT COUNT(*) FROM playlistinfo", frmKEVINMain.Functions.connect);
            MySqlDataReader readPlaylistCount = selectPlaylistCount.ExecuteReader();
            while (readPlaylistCount.Read())
            {
                playlistCount = readPlaylistCount.GetInt16(0) + 1;
            }
            playlistNames = new ToolStripMenuItem[playlistCount];
            frmKEVINMain.Functions.refreshConnectionToDB();
            MySqlCommand selectPlaylists = new MySqlCommand("SELECT * FROM playlistinfo", frmKEVINMain.Functions.connect);
            MySqlDataReader readPlaylists = selectPlaylists.ExecuteReader();
            playlistNames[counter] = new ToolStripMenuItem();
            playlistNames[counter].Name = "NewPlaylist";
            playlistNames[counter].Text = "New Playlist";
            playlistNames[counter].Click += (s, eventarg) => newPlaylistClick();
            playlistNames[counter].Image = Properties.Resources.AddMusic_2_fw;
            counter++;
            while (readPlaylists.Read())
            {
                playlistNames[counter] = new ToolStripMenuItem();
                playlistNames[counter].Name = readPlaylists.GetString(0);
                playlistNames[counter].Text = readPlaylists.GetString(0);
                playlistNames[counter].Click += (s, eventarg) => frmKEVINMain.Functions.addToPlaylist(readPlaylists.GetString(0), Convert.ToInt16(cmsRightClickSongs.Tag.ToString()));
                playlistNames[counter].Image = Properties.Resources.AddMusic_2_fw;
                counter++;
            }            
            addToPlaylistToolStripMenuItem.DropDownItems.AddRange(playlistNames);
        }

        private void addToQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlbumFunctions.appendQueue(cmsRightClickSongs);       
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKEVINMain.Functions.playSongofButton(cmsRightClickSongs.Tag.ToString(), cmsRightClickSongs);
        }

        public void newPlaylistClick()
        {
            frmKEVINCreatePlaylist createPlaylist = new frmKEVINCreatePlaylist();
            createPlaylist.Tag = cmsRightClickSongs.Tag;
            createPlaylist.Show();
        }
    }
}
