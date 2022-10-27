using GettingStarted1;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GettingStartedTree
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
      this.Load += Form2_Load;
      List<VV> v = new List<VV>();
      Dictionary<int, MettersRes> dic = DbMeter();
      foreach (var item in dic)
      {
        VV nest = new VV() {
           name=item.Value.Name,
            ip= item.Value.IP,

        };
        for (int i = 0; i < item.Value.ListMeterType.Count; i++)
        {
          VV vi = new VV()
          {
            name = item.Value.ListMeterType[i].meter_type,
            meter_factory = item.Value.ListMeterType[i].meter_factory,
            date_time = DateTime.Now,
            value = 0.1
          };
          if (nest.MyProperty == null)
            nest.MyProperty = new List<VV>();
          nest.MyProperty.Add(vi);
        }
        v.Add(nest);
        //for (int i = 0; i < item.Value.ListMeterType; i++)
        //{

        //}
      }

      
      //v.Add(new VV()
      //{
      //  name = "One"
      //});


      //v[0].MyProperty = new List<VV>();
      //for (int i = 0; i < 10; i++)
      //{
      //  v[0].MyProperty.Add(new VV()
      //  {
      //    name = Guid.NewGuid().ToString(),
      //    date_time = DateTime.Now,
      //    ip = "12345",
      //    meter_factory = "1234",
      //    meter_type = "aaa",
      //    value = 0.1
      //  }); ;
      //}
      this.treeListView1.SetObjects(v);// Song.GetArtists());
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      
      this.treeListView1.CanExpandGetter = delegate (Object x)
     {
       VV vv = (VV)x;
       if (vv.MyProperty == null)
         return false;
       return true;//(x is ArtistExample) || (x is AlbumExample);
      };

      // What objects should belong underneath the given model object?
      this.treeListView1.ChildrenGetter = delegate (Object x)
      {
        VV vv = (VV)x;
        //List<MeterValue> l = (List<MeterValue>)x;
        return vv.MyProperty;
        //throw new ArgumentException("Should be Artist or Album");
      };

      this.olvName.ImageGetter = delegate (Object x)
      {
        VV vv = (VV)x;
        if (vv.MyProperty != null)
          return "nav";
        else
          return "nav_down";
      };


      this.olvDateTime.AspectToStringConverter = delegate (object x)
      {
        if (x != null)
        {
          DateTime? dt = (DateTime)x;
          if (dt.HasValue)
          {
            return dt.Value.ToString("dd.MM.yy HH:mm:ss");
          }
          else return "";
        }
        return "";
        //return String.Format("{0} bytes", size);
        ;
      };
    }

    private Dictionary<int, MettersRes> DbMeter()
    {
      string __connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
       "localhost", "postgres", "root", 5432);
      Dictionary<int, MettersRes> dic = new Dictionary<int, MettersRes>();
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          MeterValue.CheckTableDb(db);
          string sql = "select mn.id, mn.name,mc.ip_address,mc.meters from main_nodes mn, main_ctrlinfo mc where mn.parent_id = 11 and mn.id = mc.id";

          IDbCommand cmd = db.CreateCommand();
          cmd.CommandText = sql;
          var reader = cmd.ExecuteReader();

          while (reader.Read())
          {
            int id = (int)reader[0];
            string name = (string)reader[1];
            string ip = (string)reader[2];
            string meters = (string)reader[3];
            if (!dic.ContainsKey(id))
            {
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
        return dic;
      }
      catch (Exception ex)
      {
        return null;
      }
    }


    bool exp = false;
    private void button1_Click(object sender, EventArgs e)
    {
      if (!exp)
      {
        this.treeListView1.ExpandAll();
        exp = true;
      }
      else {
        this.treeListView1.CollapseAll();
        exp = false;
      }
        
    }
  }

  public class VV {

    public string name { get; set; }
    public DateTime? date_time { get; set; }
    public string ip { get; set; }
    public string meter_type { get; set; }
    public string meter_factory { get; set; }
    public double? value { get; set; }
    public List<VV> MyProperty { get; set; }
  }
}
