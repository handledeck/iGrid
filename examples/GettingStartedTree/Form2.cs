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

    public void MeterValueDB(List<MeterValue> lst)
    {
      string __connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
      "localhost", "postgres", "root", 5432);
      Dictionary<int, AllResMeter> dic = new Dictionary<int, AllResMeter>();
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          //for (int i = 0; i < lst.Count; i++)
          //{
            db.Insert<MeterValue>(lst.ToArray());
          //}
        }
      }
      catch
      {
        int x = 0;
      }
    }

    void CreateMetersInfo(Dictionary<int, AllResMeter> dd)
    {
      string __connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
      "localhost", "postgres", "root", 5432);
      List<MeterInfo> lst = new List<MeterInfo>();
      Random random = new Random();
      foreach (var item in dd)
      {
        if (item.Value.ListMeterType != null)
        {
          for (int i = 0; i < item.Value.ListMeterType.Count; i++)
          {
            MeterInfo meterValue = new MeterInfo()
            {
              ctrl_id = item.Value.id,
              parent_id = item.Value.parent_id,
              meter_factory = item.Value.ListMeterType[i].meter_factory,
              meter_type = item.Value.ListMeterType[i].meter_type,
              ip=item.Value.ip_address
            };
            lst.Add(meterValue);
          }
        }
      }
        try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          MeterInfo.CheckTableDb(db);
            db.Insert<MeterInfo>(lst.ToArray());
        }
      }
      catch {
      
      }
    }

    void InserRangeData() { 
    
    }

    //List<MeterValue> __lst = null;
    List<TreeListNode> __v;
    public Form2()
    {
      InitializeComponent();
      this.Load += Form2_Load;
      __v = new List<TreeListNode>();
      Dictionary<int, AllResMeter> dd = DbMeterAll();
      // CreateMetersInfo(dd);
      List<MeterValue> lst = new List<MeterValue>();
      Random random = new Random();
      
      foreach (var item in dd)
      {
        if (item.Value.ListMeterType != null)
        {
          for (int i = 0; i < item.Value.ListMeterType.Count; i++)
          {
            MeterValue meterValue = new MeterValue()
            {
              ctrl_id = item.Value.id,
              parent_id=item.Value.parent_id,
              date_time = DateTime.Now,
              ip = item.Value.ip_address,
              meter_factory = item.Value.ListMeterType[i].meter_factory,
              meter_type = item.Value.ListMeterType[i].meter_type,
              //value =string.IsNullOrEmpty(item.Value.ListMeterType[i].meter_factory) ? 0: (float)random.NextDouble(),
              //is_true= string.IsNullOrEmpty(item.Value.ListMeterType[i].meter_factory)? false:true
            };
            if (string.IsNullOrEmpty(item.Value.ListMeterType[i].meter_factory)) {
              meterValue.value = 0;
              meterValue.is_true = false;
              continue;
            }
            int bl = random.Next(2);
            if (bl == 0)
            {
              meterValue.value = 0;
              meterValue.is_true = false;
            }
            else {
              meterValue.value = (float)random.NextDouble();
              meterValue.is_true = true;
            }
            lst.Add(meterValue);
          }
        }
      }

      //MeterValueDB(lst);
      Dictionary<int, MettersRes> dic = DbMeter(11);
      foreach (var item in dic)
      {
        TreeListNode nest = new TreeListNode() {
           name=item.Value.Name,
            ip= item.Value.IP,
            is_true=item.Value.is_true
        };
        for (int i = 0; i < item.Value.ListMeterType.Count; i++)
        {
          TreeListNode vi = new TreeListNode()
          {
            name = item.Value.ListMeterType[i].meter_type,
            meter_factory = item.Value.ListMeterType[i].meter_factory,
            date_time = item.Value.ListMeterType[i].date_time,
            value = item.Value.ListMeterType[i].value,
            is_true= item.Value.ListMeterType[i].is_true
          };
          if (nest.MyProperty == null)
            nest.MyProperty = new List<TreeListNode>();
          nest.MyProperty.Add(vi);
        }
        __v.Add(nest);
      
      }

      this.treeListView1.SetObjects(__v);// Song.GetArtists());
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      
      this.treeListView1.CanExpandGetter = delegate (Object x)
     {
       TreeListNode vv = (TreeListNode)x;
       if (vv.MyProperty == null)
         return false;
       return true;//(x is ArtistExample) || (x is AlbumExample);
      };

      // What objects should belong underneath the given model object?
      this.treeListView1.ChildrenGetter = delegate (Object x)
      {
        TreeListNode vv = (TreeListNode)x;
        //List<MeterValue> l = (List<MeterValue>)x;
        return vv.MyProperty;
        //throw new ArgumentException("Should be Artist or Album");
      };

      this.olvName.ImageGetter = delegate (Object x)
      {
        TreeListNode vv = (TreeListNode)x;
        if (vv.MyProperty != null) {
          if (!vv.is_true)
            return "error";
          else
          return "ok";
        }
         
        else {
          if (!vv.is_true)
            return "err";
          else
          return "nav_down";
        }
          
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

    public Dictionary<int,AllResMeter> DbMeterAll() {
      string __connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
      "localhost", "postgres", "root", 5432);
      Dictionary<int, AllResMeter> dic = new Dictionary<int, AllResMeter>();
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          MeterValue.CheckTableDb(db);
          //MeterValue.CheckTableDb(db);
          string sql = "select mn.parent_id, mn.id, mn.\"name\",mc.ip_address,mc.meters from main_nodes mn left join main_ctrlinfo mc on mc.id = mn.id where mn.node_kind_id > 2";

          IDbCommand cmd = db.CreateCommand();
          cmd.CommandText = sql;
          var reader = cmd.ExecuteReader();
          
          while (reader.Read())
          {
            int parent_id= (int)reader[0];
            int id = (int)reader[1];
            string name = (string)reader[2];
            string ip = (string)reader[3];
            string meters = string.Empty;
            if (reader[4].GetType() != typeof(DBNull)){
              meters = (string)reader[4];
            }
            
            if (!dic.ContainsKey(id))
            {
              var mtr = new AllResMeter()
              {
                id = id,
                parent_id=parent_id,
                name = name,
               ip_address = ip,
               meters=meters
              };
              mtr.ListMeterType = AllResMeter.ResolveMeters(meters);
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

    private Dictionary<int, MettersRes> DbMeter(int parent_id)
    {
      string __connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
       "localhost", "postgres", "root", 5432);
      Dictionary<int, MettersRes> dic = new Dictionary<int, MettersRes>();
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          //MeterInfo.CheckTableDb(db);
          //MeterValue.CheckTableDb(db);
          //string sql = "select mn.id, mn.name,mc.ip_address,mc.meters from main_nodes mn, main_ctrlinfo mc where mn.parent_id = 11 and mn.id = mc.id";
          string sql = string.Format("select mc.id, mn.\"name\" ,mc.ip_address ,mv.date_time,mv.meter_type ,mv.meter_factory ,mv.value, mv.is_true "+
                       "FROM main_ctrlinfo mc "+
                       "left join main_nodes mn on mc.id = mn.id "+
                       "left join meter_value mv on mv.ctrl_id = mc.id and mv.date_time > '{0}' "+
                       "where mv.value notnull and mv.parent_id = {1} order by mc.id",DateTime.Now.ToString("yyyy-MM-dd"),parent_id);
          IDbCommand cmd = db.CreateCommand();
          cmd.CommandText = sql;
          var reader = cmd.ExecuteReader();

          while (reader.Read())
          {
            int id = (int)reader[0];
            string name = (string)reader[1];
            string ip = (string)reader[2];
            DateTime dt = (DateTime)reader[3];
            string meter_type = (string)reader[4];
            string meter_factory = (string)reader[5];
            double value = (double)reader[6];
            bool is_true = (bool)reader[7];
            var mtr = new MettersRes()
            {
              Id = id,
              Name = name,
              IP = ip,
              is_true = is_true
            };
            MeterType meterType = new MeterType()
            {
              meter_type = meter_type,
              meter_factory = meter_factory,
              date_time = dt,
              value = Convert.ToSingle(value),
              is_true = is_true
            };
            
            if (!dic.ContainsKey(id))
            {
              mtr.ListMeterType = new List<MeterType>();
              mtr.ListMeterType.Add(meterType);

              dic.Add(id, mtr);
            }
            else {
              // meterType.is_true = is_true;
              if (!is_true)
                dic[id].is_true = false;
              dic[id].ListMeterType.Add(meterType);
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
      //if (!exp)
      //{
      //  this.treeListView1.ExpandAll();
      //  exp = true;
      //}
      //else {
      //  this.treeListView1.CollapseAll();
      //  exp = false;
      //}
      using (var s=new Form3())
      {
        s.SetData(__v);
        s.ShowDialog();
      }
    }
    
    private void treeListView1_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
    {

      TreeListNode vv = (TreeListNode)e.Model;
      if (vv.MyProperty != null)
      {
        e.ListView.FullRowSelect = false;
        //if (!vv.is_true)
        //  e.Item.ForeColor = Color.Red;
        //e.Item.Font = new Font("Courier New", e.Item.Font.Size);

      }
      else
      {
        if (!vv.is_true)
          e.Item.ForeColor = Color.Gray;
        e.ListView.FullRowSelect = true;
        //if (!vv.is_true)
        //  e.Item.ForeColor = Color.Red;
        //e.Item.Font = new Font("Tahoma", e.Item.Font.Size);
      }

      int z = 0;
    }
  }

  public class TreeListNode {

    public string name { get; set; }
    public DateTime? date_time { get; set; }
    public string ip { get; set; }
    public string meter_type { get; set; }
    public string meter_factory { get; set; }
    public double? value { get; set; }
    public bool is_true { get; set; }
    public List<TreeListNode> MyProperty { get; set; }
  }
}
