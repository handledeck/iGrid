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
  public delegate void MeterUpdate(MeterTreeView meterTreeView);

  public partial class MeterTreeView : UserControl
  {
    List<TreeListNodeModel> __treeListNode;
    string __connection = string.Empty;
    int __id_parent =-1;
    public event MeterUpdate MeterUpdateEvent;
    public MeterTreeView()
    {
      InitializeComponent();
     
      //TextOverlay textOverlay = this.objectListView1.EmptyListMsgOverlay as TextOverlay;
      //textOverlay.TextColor = Color.Gray;
      //textOverlay.BackColor = Color.Transparent;
      //textOverlay.BorderColor = Color.Transparent;
      //textOverlay.BorderWidth = 0.0f;
      //textOverlay.Font = new Font("Chiller", 40);
      //textOverlay.Rotation = 0;
      this.treeListView1.FormatRow += TreeListView1_FormatRow;
    }

    

    public void SetTreeListViewValue(string connection, int id_parent, string NameRes) {
      this.__connection = connection;
      __id_parent = id_parent;
      this.lblNameView.Text = NameRes;
      FillTreeList();
    }

    private void FillTreeList()
    {
      string __connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
     "localhost", "postgres", "root", 5432);
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
                                     "left join meter_value mv on mi.id = mv.ctrl_id and mv.date_time > '{0}' where mi.parent_id ={1}", DateTime.Now.ToString("yyyy-MM-dd"),this.__id_parent);
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
        if (__treeListNode != null)
          __treeListNode.Clear();
        else
          __treeListNode = new List<TreeListNodeModel>();
        foreach (var item in dic)
        {
          __treeListNode.Add(item.Value);
        }
        this.treeListView1.SetObjects(__treeListNode);
        ResetDelegate();
      }

      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
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


    private void TreeListView1_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
    {
      if (e.ListView.Items.Count > 0)
      {
        this.btnView.Enabled = true;
        TreeListNodeModel vv = (TreeListNodeModel)e.Model;
        if (vv.Nodes != null)
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
      }
      else {
        this.btnView.Enabled = false;
      }
    }

    private void MeterTreeView_Load(object sender, EventArgs e)
    {
     
    }


    bool __expaned = false;
    private void btnView_Click(object sender, EventArgs e)
    {
      if (!__expaned)
      {
        
        this.btnView.Image = imageList2.Images[0];
        __expaned = true;
        this.treeListView1.ExpandAll();
      }
      else {
        
        this.btnView.Image = imageList2.Images[1];
        __expaned = false;
        this.treeListView1.CollapseAll();
      }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      FillTreeList();
    }

   
  }
}
