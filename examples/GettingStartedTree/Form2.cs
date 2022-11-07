using BrightIdeasSoftware;
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
    string __connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
     "localhost", "postgres", "root", 5432);
    //public void MeterValueDB(List<MeterValue> lst)
    //{
      
    //  Dictionary<int, Meters> dic = new Dictionary<int, Meters>();
    //  try
    //  {
    //    var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
    //    using (var db = dbFactory.Open())
    //    {
    //      //for (int i = 0; i < lst.Count; i++)
    //      //{
    //      db.Insert<MeterValue>(lst.ToArray());
    //      //}
    //    }
    //  }
    //  catch
    //  {
    //    int x = 0;
    //  }
    //}

    //void CreateMetersInfo(Dictionary<int, Meters> dd)
    //{
    //  string __connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
    //  "localhost", "postgres", "root", 5432);
    //  List<MeterInfo> lst = new List<MeterInfo>();
    //  Random random = new Random();
    //  foreach (var item in dd)
    //  {
    //    if (item.Value.ListMeterType != null)
    //    {
    //      for (int i = 0; i < item.Value.ListMeterType.Count; i++)
    //      {
    //        MeterInfo meterValue = new MeterInfo()
    //        {
    //          ctrl_id = item.Value.id,
    //          parent_id = item.Value.parent_id,
    //          meter_factory = item.Value.ListMeterType[i].meter_factory,
    //          meter_type = item.Value.ListMeterType[i].meter_type,
    //          ip = item.Value.ip_address
    //        };
    //        lst.Add(meterValue);
    //      }
    //    }
    //  }
    //  try
    //  {
    //    var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
    //    using (var db = dbFactory.Open())
    //    {
    //      MeterInfo.CheckTableDb(db,lst);
    //      db.Insert<MeterInfo>(lst.ToArray());
    //    }
    //  }
    //  catch {

    //  }
    //}

    void InserRangeData() {

    }

    //List<MeterValue> __lst = null;
    List<TreeListNodeModel> __v=new List<TreeListNodeModel>();
    List<ValueDateTime> __valueDateTimes = new List<ValueDateTime>();
    public Form2()
    {
      InitializeComponent();
      TextOverlay textOverlay = this.objectListView1.EmptyListMsgOverlay as TextOverlay;
      textOverlay.TextColor = Color.Gray;
      textOverlay.BackColor = Color.Transparent;
      textOverlay.BorderColor = Color.Transparent;
      textOverlay.BorderWidth = 0.0f;
      textOverlay.Font = new Font("Chiller", 36);
      textOverlay.Rotation = 0;
      TextOverlay textOverlay1 = this.treeListView1.EmptyListMsgOverlay as TextOverlay;
      
      textOverlay1.TextColor = Color.Gray;
      textOverlay1.BackColor = Color.Transparent;
      textOverlay1.BorderColor = Color.Transparent;
      textOverlay1.BorderWidth = 0.0f;
      textOverlay1.Font = new Font("Chiller", 36);
      textOverlay1.Rotation = 0;
      this.treeListView1.SetObjects(__v);
      this.objectListView1.SetObjects(__valueDateTimes);
      this.objectListView1.EmptyListMsg = "This database has no rows";
      this.objectListView1.EmptyListMsgFont = new Font("Tahoma", 10);
      this.treeListView1.EmptyListMsg = "This database has no rows";
      this.treeListView1.EmptyListMsgFont = new Font("Tahoma", 10);
    }

    private Dictionary<int,MettersRes> DbMeter(int parent_id)
    {
      
      Dictionary<int, MettersRes> dic = new Dictionary<int, MettersRes>();
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          //MeterInfo.CheckTableDb(db);
          //MeterValue.CheckTableDb(db);
          //string sql = "select mn.id, mn.name,mc.ip_address,mc.meters from main_nodes mn, main_ctrlinfo mc where mn.parent_id = 11 and mn.id = mc.id";
          string sql = string.Format("select mc.id, mn.\"name\" ,mc.ip_address ,mv.date_time,mv.meter_type ,mv.meter_factory ,mv.value, mv.is_true " +
                       "FROM main_ctrlinfo mc " +
                       "left join main_nodes mn on mc.id = mn.id " +
                       "left join meter_value mv on mv.ctrl_id = mc.id and mv.date_time > '{0}' " +
                       "where mv.value notnull and mv.parent_id = {1} order by mc.id", DateTime.Now.ToString("yyyy-MM-dd"), parent_id);
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
      using (var s = new Form3())
      {
        s.SetData(__v);

        s.ShowDialog();
      }
    }

    private void treeListView1_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
    {

      TreeListNodeModel vv = (TreeListNodeModel)e.Model;
      if (vv.Nodes != null)
      {
        e.ListView.FullRowSelect = false;
        if (!vv.is_true)
          e.Item.ForeColor = Color.Gray;
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

    private void BtnSimulate(object sender, EventArgs e)
    {
      List<MeterValue> mv = new List<MeterValue>();
      try
      {

        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          //db.DropTable<MeterValue>();
          MeterValue.CheckTableDb(__connection);
          DateTime? dt=null;
          DateTime? dtback=null; 


          for (int i = 0; i < 30; i++)
          {
            mv.Clear();
            if (!dt.HasValue)
            {
              dt = DateTime.Now.AddDays(1);
              dtback = dt.Value.AddDays(-1);
            }
            else {
              dt = dt.Value.AddDays(-1);
              dtback = dt.Value.AddDays(-1);
            }
            //dt = dt.AddDays(i * -1);
            //dtback = dtback.AddDays(-1);
            string sql = string.Format("SELECT * "+
                          "FROM meter_info "+
                          "WHERE NOT EXISTS "+
                          "(SELECT ctrl_id FROM meter_value mv where mv.date_time between '{0}' and '{1}' " +
                          "and ctrl_id = meter_info.id);",dtback.Value.ToString("yyyy-MM-dd"), dt.Value.ToString("yyyy-MM-dd"));
            IDbCommand cmd = db.CreateCommand();
            cmd.CommandText = sql;
            var reader = cmd.ExecuteReader();
            Random random = new Random();
            while (reader.Read())
            {
              int id = (int)reader[0];
              int ctrl_id = (int)reader[1];
              int parent_id = (int)reader[2];
              string ip = (string)reader[3];
              //DateTime dt = (DateTime)reader[3];
              if (reader[4].GetType() == typeof(DBNull) || reader[5].GetType() == typeof(DBNull))
                continue;
              string meter_type = (string)reader[4];
              string meter_factory = (string)reader[5];
              //double value = (double)reader[6];
              //bool is_true = (bool)reader[7];
              MeterValue meterValue = new MeterValue()
              {
                ctrl_id = id,
                parent_id = parent_id,
                date_time = dtback.Value,
                ip = ip,
                meter_factory = meter_factory,
                meter_type = meter_type,
                //is_true = true,
                //value = random.NextDouble()
              };

              meterValue.is_true = Convert.ToBoolean(random.Next(2));
              if(meterValue.is_true)
              {

                meterValue.value = random.NextDouble();
                mv.Add(meterValue);
              }
              else
              {
                // meterValue.value = -1;
              }


            }
            reader.Close();
            if (mv.Count > 0)
            {
              db.Insert<MeterValue>(mv.ToArray());
            }
          }
        }
      }

      catch(Exception ex)
      {
        int x = 0;
      }
    }


    private void btnFill(object sender, EventArgs e)
    {
      Dictionary<int, TreeListNodeModel> dic = new Dictionary<int, TreeListNodeModel>();
      MeterValue.CheckTableDb(__connection);
      List<MeterValue> mv = new List<MeterValue>();
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          string sql = string.Format("select mn.id as idmain, mn.\"name\", mi.id, mi.ctrl_id, mi.parent_id,mi.ip ,mi.meter_type, mi.meter_factory, mv.value, mv.is_true,mv.date_time FROM meter_info mi " +
                                     "left join main_nodes mn on mn.id = mi.ctrl_id "+
                                     "left join meter_value mv on mi.id = mv.ctrl_id and mv.date_time > '{0}'", DateTime.Now.ToString("yyyy-MM-dd"));
          IDbCommand cmd = db.CreateCommand();
          cmd.CommandText = sql;
          var reader = cmd.ExecuteReader();
          Random random = new Random();
          while (reader.Read())
          {
            int idmain = (int)reader[0];
            string name = (string)reader[1];
            int id = (int)reader[2];
            int ctrl_id = (int)reader[3];
            int parent_id = (int)reader[4];
            string ip = (string)reader[5];
            //DateTime dt = (DateTime)reader[3];
            if (reader[6].GetType() == typeof(DBNull) || reader[7].GetType() == typeof(DBNull))
              continue;
            string meter_type = (string)reader[5];
            string meter_factory = (string)reader[6];
            double value = reader[8].GetType()==typeof(DBNull) ? 0 : (double)reader[8];
            bool is_true = reader[9].GetType() == typeof(DBNull) ? false : (bool)reader[9];
            DateTime dt = reader[10].GetType() == typeof(DBNull) ? DateTime.MinValue : (DateTime)reader[10];
            TreeListNodeModel mt = new TreeListNodeModel
            {
              name = name,
              is_true=true
            };
            TreeListNodeModel treeListNodeModel = new TreeListNodeModel()
            {
              id=id,
              name= meter_factory,
              date_time = DateTime.Now,
              ip = ip,
              is_true = is_true,
              value = value,
              meter_factory = meter_factory,
              meter_type = meter_type
            };
            if (!dic.ContainsKey(idmain))
            {
              mt.Nodes = new List<TreeListNodeModel>();
              mt.Nodes.Add(treeListNodeModel);
              if (!treeListNodeModel.is_true)
              {
                mt.is_true = false;
              }
              dic.Add(idmain, mt);
              
            }
            else {
              dic[idmain].Nodes.Add(treeListNodeModel);
              if (!treeListNodeModel.is_true) {
                dic[idmain].is_true = false;
              }
            }
          }
          reader.Close();
        }
        if(__v!=null)
        __v.Clear();
        foreach (var item in dic)
        {
          if (__v == null)
          {
            __v = new List<TreeListNodeModel>();
          }
          __v.Add(item.Value);
        }
        this.treeListView1.SetObjects(__v);
        ResetDelegate();
      }
      catch (Exception ex)
      {
        int xx = 0;
      }
    }

    void ResetDelegate() {
      this.treeListView1.CanExpandGetter = delegate (Object x)
      {
        TreeListNodeModel vv = (TreeListNodeModel)x;
        if (vv.Nodes == null)
          return false;
        return true;//(x is ArtistExample) || (x is AlbumExample);
      };

      // What objects should belong underneath the given model object?
      this.treeListView1.ChildrenGetter = delegate (Object x)
      {
        TreeListNodeModel vv = (TreeListNodeModel)x;
        //List<MeterValue> l = (List<MeterValue>)x;
        return vv.Nodes;
        //throw new ArgumentException("Should be Artist or Album");
      };

      this.olvName.ImageGetter = delegate (Object x)
      {
        TreeListNodeModel vv = (TreeListNodeModel)x;
        if (vv.Nodes != null)
        {
          if (!vv.is_true)
            return "error";
          else
            return "ok";
        }

        else
        {
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

    private void treeListView1_SelectionChanged(object sender, EventArgs e)
    {
      TreeListView treeListView = (TreeListView)sender;
      TreeListNodeModel treeListNodeModel = (TreeListNodeModel)treeListView.SelectedObject;
      if (treeListNodeModel.Nodes == null)
      {
        DateTime dtend = DateTime.Now.AddDays(1);
        DateTime dtstart = new DateTime(dtend.Year, dtend.Month, 1);
        Dictionary<string, ValueDateTime> lstVdt = new Dictionary<string, ValueDateTime>();
        int res = dtend.Day - dtstart.Day;
        DateTime lstDt = dtstart;
        for (int i = 1; i < dtend.Day; i++)
        {
          lstVdt.Add(lstDt.ToString("yyyy-MM-dd"), new ValueDateTime()
          {
            dt = lstDt.ToString("yyyy-MM-dd"),
            is_true = false
          }); ;
          lstDt = lstDt.AddDays(1);
        }
        int id = treeListNodeModel.id;
        string sql = string.Format("select date_time,value,is_true from meter_value mv " +
                      "where mv.ctrl_id ={0} " +
                      "and mv.date_time between '{1}' and '{2}'", id,
                      dtstart.ToString("yyyy-MM-dd"), dtend.ToString("yyyy-MM-dd"));
        try
        {
          var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
          using (var db = dbFactory.Open())
          {
            IDbCommand cmd = db.CreateCommand();
            cmd.CommandText = sql;
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
              DateTime dt = (DateTime)reader[0];
              string dt_str = dt.ToString("yyyy-MM-dd");
              double value = (double)reader[1];
              bool is_true = (bool)reader[2];
              if (lstVdt.ContainsKey(dt_str))
              {
                lstVdt[dt_str] = new ValueDateTime()
                {
                  dt = dt_str,
                  id = id,
                  value = value,
                  is_true=true
                };
              }
            }
            reader.Close();
          }
          //this.objectListView1.Clear();
          __valueDateTimes = lstVdt.Values.ToList<ValueDateTime>();
          this.objectListView1.SetObjects(__valueDateTimes);
        }
        catch (Exception exp)
        {

          throw;
        }
      }
      else {
        this.objectListView1.SetObjects(null);
       
      }
    }
    
    private void button3_Click(object sender, EventArgs e)
    {
      MeterInfo.CheckTableDb(__connection);
    }

    private void objectListView1_FormatRow(object sender, FormatRowEventArgs e)
    {
      ValueDateTime vv = (ValueDateTime)e.Model;
      if (!vv.is_true)
      {
        //e.ListView.FullRowSelect = false;
        //if (!vv.is_true)
          e.Item.ForeColor = Color.Gray;
        //e.Item.Font = new Font("Courier New", e.Item.Font.Size);

      }
      else
      {

        e.Item.ForeColor = Color.Black;
        //e.ListView.FullRowSelect = true;
        //if (!vv.is_true)
        //  e.Item.ForeColor = Color.Red;
        //e.Item.Font = new Font("Tahoma", e.Item.Font.Size);
      }

      int z = 0;
    }
  }


 
  
}
