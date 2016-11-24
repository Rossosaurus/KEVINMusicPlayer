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
        public frmKEVINAlbum()
        {
            InitializeComponent();
        }

        private void frmKEVINAddMusic_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#444444");
            lblAlbumName.ForeColor = ColorTranslator.FromHtml("#646464");
            pnlHeader.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            lblArtistAndGenre.ForeColor = ColorTranslator.FromHtml("#646464");
            string locationWithApostrophe = this.Tag.ToString();
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
            AlbumFunctions.getAlbumInfoFromLocation(locationWithApostrophe);
            AlbumFunctions.createSongButtons(locationWithApostrophe, flpSongsWrapper);  
        }
    }
}
