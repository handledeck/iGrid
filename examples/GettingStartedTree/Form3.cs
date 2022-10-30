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
  public partial class Form3 : Form
  {
    public Form3()
    {
      InitializeComponent();
      
    }

    

    public void SetData(List<TreeListNode> treeListNode) {

      this.meterTreeView1.MeterUpdateEvent += MeterTreeView1_MeterUpdateEvent;
      this.meterTreeView1.SetTreeListViewValue("Test of object",treeListNode);
    }

    private void MeterTreeView1_MeterUpdateEvent(MeterTreeView meterTreeView)
    {
      MessageBox.Show("zzzzzzzzzzzzzz");
    }
  }
}
