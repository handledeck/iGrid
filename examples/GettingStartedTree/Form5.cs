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
  public partial class Form5 : Form
  {
    string __connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
     "localhost", "postgres", "root", 5432);
  
    public Form5()
    {
      InitializeComponent();
      this.ulcTreeView1.SetValue(__connection);
    }
  }
}
