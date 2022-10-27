using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GettingStarted1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            this.titleColumn.ImageGetter = delegate (object rowObject) {
                Song s = (Song)rowObject;
                if (s.Rating > 80)
                    return "star";
                else 
                    return "song";
            };

            this.sizeColumn.AspectToStringConverter = delegate(object x) {
                long size = (long)x;
                int[] limits = new int[] { 1024 * 1024 * 1024, 1024 * 1024, 1024 };
                string[] units = new string[] { "GB", "MB", "KB" };

                for (int i = 0; i < limits.Length; i++) {
                    if (size >= limits[i])
                        return String.Format("{0:#,##0.##} " + units[i], ((double)size / limits[i]));
                }

                return String.Format("{0} bytes", size); ;
            };

            this.lastPlayedColumn.GroupKeyGetter = delegate(object rowObject) {
                Song song = (Song)rowObject;
                return new DateTime(song.LastPlayed.Year, song.LastPlayed.Month, 1);
            };
            
            this.lastPlayedColumn.GroupKeyToTitleConverter = delegate(object groupKey) {
                return ((DateTime)groupKey).ToString("MMMM yyyy");
            };

            this.ratingColumn.MakeGroupies(
                new int[] { 20, 39, 79 },
                new string[] { "Why do you even have these songs?", "Passable I suppose", "Buy more like these", "To be played continuously" }
            );

            this.olvSongs.SetObjects(Song.GetSongs());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.olvSongs.ShowGroups = this.checkBox1.Checked;
            this.olvSongs.BuildList(true);
        }
    }
}