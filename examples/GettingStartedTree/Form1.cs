using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GettingStarted1;
using ServiceStack.OrmLite;

namespace GettingStartedTree
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // Can the given object be expanded?
      this.treeListView1.CanExpandGetter = delegate (Object x)
      {
        return (x is ArtistExample) || (x is AlbumExample);
      };

      // What objects should belong underneath the given model object?
      this.treeListView1.ChildrenGetter = delegate (Object x)
      {
        if (x is ArtistExample)
          return ((ArtistExample)x).Albums;
        if (x is AlbumExample)
          return ((AlbumExample)x).Songs;

        throw new ArgumentException("Should be Artist or Album");
      };

      // Which image should be used for which model
      this.olvColumn1.ImageGetter = delegate (Object x)
      {
        if (x is ArtistExample)
          return "user";
        else if (x is AlbumExample)
          return "folder";
        else
          return "song";
      };

      // Format the size so it looks like "1.1GB"
      this.olvColumn2.AspectToStringConverter = delegate (object x)
      {
        long size = (long)x;
        int[] limits = new int[] { 1024 * 1024 * 1024, 1024 * 1024, 1024 };
        string[] units = new string[] { "GB", "MB", "KB" };

        for (int i = 0; i < limits.Length; i++)
        {
          if (size >= limits[i])
            return String.Format("{0:#,##0.##} " + units[i], ((double)size / limits[i]));
        }

        return String.Format("{0} bytes", size);
        ;
      };

      // Draw stars depending on the value of the rating
      this.olvColumn4.Renderer = new BrightIdeasSoftware.MultiImageRenderer("star", 5, 0, 100);

      this.treeListView1.SetObjects(Song.GetArtists());
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string __connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
       "localhost", "postgres", "root", 5432);
      Dictionary<int, MettersRes> dic = new Dictionary<int, MettersRes>();
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          //MeterValue.CheckTableDb(db);
          string sql = "select mn.id, mn.name,mc.ip_address,mc.meters from main_nodes mn, main_ctrlinfo mc where mn.parent_id = 11 and mn.id = mc.id";

          IDbCommand cmd = db.CreateCommand();
          cmd.CommandText = sql;
          var reader= cmd.ExecuteReader();
         
          while (reader.Read())
          {
            int id = (int)reader[0];
            string name=(string)reader[1];
            string ip = (string)reader[2];
            string meters = (string)reader[3];
            if (!dic.ContainsKey(id)) {
              var mtr = new MettersRes()
              {
                Id = id,
                Name = name,
                IP = ip,
              };
              mtr.ListMeterType = MettersRes.ResolveMeters(meters);
              dic.Add(id, mtr);
            }
          }
        }
      }
      catch (Exception ex)
      {
        int x = 0;
      }
    }
  }
}