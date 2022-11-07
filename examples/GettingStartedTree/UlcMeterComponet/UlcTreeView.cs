using BrightIdeasSoftware;
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
  public partial class UlcTreeView : UserControl
  {
    string __connection = string.Empty;
    List<TreeListNodeModel> __treeNodes = new List<TreeListNodeModel>();
    List<ValueDateTime> __valueDateTimes = new List<ValueDateTime>();
    public UlcTreeView()
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
      this.treeListView1.SetObjects(__treeNodes);
      this.objectListView1.SetObjects(__valueDateTimes);
      this.objectListView1.EmptyListMsg = "This database has no rows";
      this.objectListView1.EmptyListMsgFont = new Font("Tahoma", 10);
      this.treeListView1.EmptyListMsg = "This database has no rows";
      this.treeListView1.EmptyListMsgFont = new Font("Tahoma", 10);
     
      this.treeListView1.SelectionChanged += TreeListView1_SelectionChanged;
    }

    
    public void SetValue(string connection)
    {
      this.__connection = connection;
      
      FillTreeList();
      ResetDelegate();
      this.treeListView1.FormatRow += TreeListView1_FormatRow;
    }

   

    private void FillTreeList()
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
                                     "left join main_nodes mn on mn.id = mi.ctrl_id " +
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
            double value = reader[8].GetType() == typeof(DBNull) ? 0 : (double)reader[8];
            bool is_true = reader[9].GetType() == typeof(DBNull) ? false : (bool)reader[9];
            DateTime dt = reader[10].GetType() == typeof(DBNull) ? DateTime.MinValue : (DateTime)reader[10];
            TreeListNodeModel mt = new TreeListNodeModel
            {
              name = name,
              is_true = true
            };
            TreeListNodeModel treeListNodeModel = new TreeListNodeModel()
            {
              id = id,
              name = meter_factory,
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
            else
            {
              dic[idmain].Nodes.Add(treeListNodeModel);
              if (!treeListNodeModel.is_true)
              {
                dic[idmain].is_true = false;
              }
            }
          }
          reader.Close();
        }
        if (__treeNodes != null)
          __treeNodes.Clear();
        foreach (var item in dic)
        {
          if (__treeNodes == null)
          {
            __treeNodes = new List<TreeListNodeModel>();
          }
          __treeNodes.Add(item.Value);
        }
        this.treeListView1.SetObjects(__treeNodes);
        ResetDelegate();
      }
      catch (Exception ex)
      {
        int xx = 0;
      }
    }

    private void TreeListView1_FormatRow(object sender, FormatRowEventArgs e)
    {

      //TreeListNodeModel vv = (TreeListNodeModel)e.Model;
      //if (vv.Nodes == null)
      //{
      //  e.ListView.FullRowSelect = true;
      //  //if (!vv.is_true)
      //  //  e.Item.ForeColor = Color.Gray;
      //  //e.Item.Font = new Font("Courier New", e.Item.Font.Size);

      //}
      //else
      //{
      //  e.ListView.FullRowSelect = false;

      //  //if (!vv.is_true)
      //  //  e.Item.ForeColor = Color.Gray;
      //  //e.ListView.FullRowSelect = true;
      //  //if (!vv.is_true)
      //  //  e.Item.ForeColor = Color.Red;
      //  //e.Item.Font = new Font("Tahoma", e.Item.Font.Size);
      //}
    }



    void ResetDelegate()
    {
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

    private void TreeListView1_SelectionChanged(object sender, EventArgs e)
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
                  is_true = true
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
      else
      {
        this.objectListView1.SetObjects(null);

      }
    }

    private void objectListView1_FormatRow(object sender, FormatRowEventArgs e)
    {

      var ol = (ValueDateTime)e.Item.RowObject;
      if (!ol.is_true)
      {
        e.Item.ForeColor = Color.Gray;
      }
      else {
        e.Item.ForeColor = Color.Black;
      }

      int x = 0;
    }
  }
}
