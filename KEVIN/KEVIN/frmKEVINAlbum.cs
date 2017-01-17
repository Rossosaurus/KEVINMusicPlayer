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
        //Variable declaration
        string locationWithApostrophe;
        public frmKEVINAlbum()
        {
            InitializeComponent();
        }

        public void frmKEVINAddMusic_Load(object sender, EventArgs e)
        {
            //Format form and its controls
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
            //Get information about the album that was clicked on to launch this form
            frmKEVINMain.Functions.getAlbumInfoFromLocation(locationWithApostrophe);
            //Create a button for each song in the album
            frmKEVINMain.Functions.createSongButtons(locationWithApostrophe, flpSongsWrapper, cmsRightClickSongs);  
        }

        private void cmsRightClickSongs_Opening(object sender, CancelEventArgs e)
        {
            //Clear all itewms from addToPlaylistToolStripMenuItem
            addToPlaylistToolStripMenuItem.DropDownItems.Clear();
            //Initialize variables
            int playlistCount = 0;
            int counter = 0;
            ToolStripMenuItem[] playlistNames;
            frmKEVINMain.Functions.refreshConnectionToDB();
            //Get number of playlists that have been created
            MySqlCommand selectPlaylistCount = new MySqlCommand("SELECT COUNT(*) FROM playlistinfo", frmKEVINMain.Functions.connect);
            MySqlDataReader readPlaylistCount = selectPlaylistCount.ExecuteReader();
            while (readPlaylistCount.Read())
            {
                playlistCount = readPlaylistCount.GetInt16(0) + 1;
            }
            //Creat a new instance of playlistNames for every playlist that has been created
            playlistNames = new ToolStripMenuItem[playlistCount];
            frmKEVINMain.Functions.refreshConnectionToDB();
            //Select everything from playlistInfo
            MySqlCommand selectPlaylists = new MySqlCommand("SELECT * FROM playlistinfo", frmKEVINMain.Functions.connect);
            MySqlDataReader readPlaylists = selectPlaylists.ExecuteReader();
            //Create a tool strip menu item for creating a new playlist
            playlistNames[counter] = new ToolStripMenuItem();
            playlistNames[counter].Name = "NewPlaylist";
            playlistNames[counter].Text = "New Playlist";
            playlistNames[counter].Click += (s, eventarg) => newPlaylistClick();
            playlistNames[counter].Image = Properties.Resources.AddMusic_2_fw;
            counter++;
            //Create a tool strip menu item for every playlist in playlistInfo
            while (readPlaylists.Read())
            {
                playlistNames[counter] = new ToolStripMenuItem();
                playlistNames[counter].Name = readPlaylists.GetString(0);
                playlistNames[counter].Text = readPlaylists.GetString(0);
                playlistNames[counter].Click += (s, eventarg) => frmKEVINMain.Functions.addToPlaylist(readPlaylists.GetString(0), Convert.ToInt16(cmsRightClickSongs.Tag.ToString()));
                playlistNames[counter].Image = Properties.Resources.AddMusic_2_fw;
                counter++;
            }
            //Add array of tool strip menu items to parent addToPlaylistToolStripMenuItem        
            addToPlaylistToolStripMenuItem.DropDownItems.AddRange(playlistNames);
        }

        private void addToQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Execute function appendQueue
            frmKEVINMain.Functions.appendQueue(cmsRightClickSongs);       
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Execute function playSongOfButton
            frmKEVINMain.Functions.playSongofButton(cmsRightClickSongs.Tag.ToString(), cmsRightClickSongs);
        }

        public void newPlaylistClick()
        {
            //Create an instance of frmKEVINCreatePlaylist with its tag as cmsRightClickSongs tag
            frmKEVINCreatePlaylist createPlaylist = new frmKEVINCreatePlaylist();
            createPlaylist.Tag = cmsRightClickSongs.Tag;
            //Display instance of frmKEVINCreatePlaylist
            createPlaylist.Show();
        }
    }
}
