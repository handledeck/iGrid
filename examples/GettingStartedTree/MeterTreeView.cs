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

    public event MeterUpdate MeterUpdateEvent;
    public MeterTreeView()
    {
      InitializeComponent();
      this.treeListView1.FormatRow += TreeListView1_FormatRow;
      this.Load += MeterTreeView_Load;
      
    }

    List<TreeListNode> __treeListNode;

    public void SetTreeListViewValue(string NameOfObject,List<TreeListNode> treeListNode) {
      //this.treeListView1.Clear();
      this.lblNameView.Text = NameOfObject;
      this.__treeListNode = treeListNode;
      //this.treeListView1.SetObjects(treeListNode);
      //this.treeListView1.Refresh();
      //this.treeListView1.Update();
    }

    private void TreeListView1_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
    {
      if (e.ListView.Items.Count > 0)
      {
        this.btnView.Enabled = true;
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
      }
      else {
        this.btnView.Enabled = false;
      }
    }

    private void MeterTreeView_Load(object sender, EventArgs e)
    {
      this.treeListView1.SetObjects(__treeListNode);
      this.treeListView1.CanExpandGetter = delegate (Object x)
      {
        TreeListNode vv = (TreeListNode)x;
        if (vv.MyProperty == null)
          return false;
        return true;
      };
      this.treeListView1.ChildrenGetter = delegate (Object x)
      {
        TreeListNode vv = (TreeListNode)x;
        return vv.MyProperty;
      };

      this.olvName.ImageGetter = delegate (Object x)
      {
        TreeListNode vv = (TreeListNode)x;
        if (vv.MyProperty != null)
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
        ;
      };
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
      if (this.MeterUpdateEvent != null)
        this.MeterUpdateEvent(this);
    }

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}
