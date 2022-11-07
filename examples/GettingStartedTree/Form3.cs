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

    public void SetData(List<TreeListNodeModel> treeListNode) {

     
    }

    private void MeterTreeView1_MeterUpdateEvent(MeterTreeView meterTreeView)
    {
      MessageBox.Show("zzzzzzzzzzzzzz");
    }

    private void btnFillTree_Click(object sender, EventArgs e)
    {
      string __connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
     "localhost", "postgres", "root", 5432);
      this.meterTreeView1.SetTreeListViewValue(__connection,11,"Сельский РЭС");
    }

    private void meterTreeView1_Load(object sender, EventArgs e)
    {

    }
  }

  public class ValueDateTime
  {
    public int id { get; set; }
    public string dt { get; set; }
    public double value { get; set; }
    public bool is_true { get; set; }
  }

}
