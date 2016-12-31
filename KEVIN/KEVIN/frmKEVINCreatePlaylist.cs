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

namespace KEVIN
{
    public partial class frmKEVINCreatePlaylist : Form
    {
        public frmKEVINCreatePlaylist()
        {
            InitializeComponent();
        }

        private void frmKEVINCreatePlaylist_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            txtbxPlaylist.BackColor = ColorTranslator.FromHtml("#3c3c3c");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Tag.ToString());
            int temp = 0;
            bool playlistExists = false;
            frmKEVINMain.Functions.refreshConnectionToDB();
            MySqlCommand createPlaylistIfNotExist = new MySqlCommand("CREATE TABLE IF NOT EXISTS " + txtbxPlaylist.Text.Replace(" ", "_") + " (PlaylistID INT(255), SongID INT(255))", frmKEVINMain.Functions.connect);
            MySqlCommand selectPlaylistInfo = new MySqlCommand("SELECT * FROM playlistinfo", frmKEVINMain.Functions.connect2);
            MySqlDataReader readPlaylistInfo = selectPlaylistInfo.ExecuteReader();
            while (readPlaylistInfo.Read())
            {
                if (string.Equals(readPlaylistInfo.GetString(0), txtbxPlaylist.Text.Replace(" ", "_"), StringComparison.CurrentCultureIgnoreCase))
                {
                    playlistExists = true;
                }
            }
            if (playlistExists == false)
            {
                frmKEVINMain.Functions.refreshConnectionToDB();
                MySqlCommand appendPlaylistExistance = new MySqlCommand("INSERT INTO playlistinfo(PlaylistName) VALUES (\"" + txtbxPlaylist.Text.Replace(" ", "_") + "\")", frmKEVINMain.Functions.connect);
                appendPlaylistExistance.ExecuteNonQuery();
            }
            frmKEVINMain.Functions.refreshConnectionToDB();
            MySqlCommand selectTableSize = new MySqlCommand("SELECT COUNT(*) FROM " + txtbxPlaylist.Text.Replace(" ", "_"), frmKEVINMain.Functions.connect);
            MySqlDataReader readTableSize = selectTableSize.ExecuteReader();
            while (readTableSize.Read())
            {
                temp = readTableSize.GetInt16(0);
            }
            frmKEVINMain.Functions.refreshConnectionToDB();
            temp = temp + 1;
            MessageBox.Show(temp.ToString());
            MySqlCommand appendSongToPlaylist = new MySqlCommand("INSERT INTO " + txtbxPlaylist.Text.Replace(" ", "_") + "(PlaylistID, SongID) VALUES (" + temp + ", " + this.Tag.ToString() + ")", frmKEVINMain.Functions.connect);
            appendSongToPlaylist.ExecuteNonQuery();
            frmKEVINMain.Functions.refreshConnectionToDB();
            this.Close();
        }
        private void txtbxPlaylist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
