using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using TagLib;
namespace SmartDJ__
{
    public partial class Form1 : Form
    {
        //List<ReadID3v1Tags.ID3v1Tag> fileTags = new List<ReadID3v1Tags.ID3v1Tag>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            
            if (fbdMusic.ShowDialog() == DialogResult.OK)
            {
                //ReadID3v1Tags i = new ReadID3v1Tags();
                foreach(String fil in Directory.GetFiles(fbdMusic.SelectedPath,"*.mp3",SearchOption.AllDirectories))
                {
                    TagLib.File f = TagLib.File.Create(fil);
                    ListViewItem l = new ListViewItem(f.Tag.Title);
                        l.SubItems.Add(f.Tag.Album);
                        l.SubItems.Add(f.Tag.AlbumArtists[0]);
                        l.SubItems.Add(f.Tag.Genres[0]);
                        l.SubItems.Add(f.Tag.Year.ToString());
                        listView1.Items.Add(l);
                    listView2.Items.Add((ListViewItem)l.Clone());
                    //fileTags.Add(i.Read(fil));
                }
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            lblOutput.Text = CompareStrings(listView1.FocusedItem.Text, listView2.FocusedItem.Text).ToString();
        }
        private Int32 CompareStrings(String str1, String str2)
        {
            return 100-Math.Abs(string.Compare(str1, str2, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.CompareOptions.OrdinalIgnoreCase));
        }
    }
}
