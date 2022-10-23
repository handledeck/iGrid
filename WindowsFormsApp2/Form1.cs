using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TenTec.Windows.iGridLib;

namespace WindowsFormsApp2
{
  public partial class Form1 : Form
  {
    private iGGroupRowCountManager GRCM = new iGGroupRowCountManager();
    public Form1()
    {
      this.iGrid1 = new TenTec.Windows.iGridLib.iGrid();
      //this.iGrid1DefaultCellStyle = new TenTec.Windows.iGridLib.iGCellStyle(true);
      //this.iGrid1DefaultColHdrStyle = new TenTec.Windows.iGridLib.iGColHdrStyle(true);
      //this.iGrid1RowTextColCellStyle = new TenTec.Windows.iGridLib.iGCellStyle(true);
      
      //((System.ComponentModel.ISupportInitialize)(this.iGrid1)).BeginInit();
      InitializeComponent();
      
     
      // 
      // iGrid1
      // 
      //this.iGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
     // | System.Windows.Forms.AnchorStyles.Left)
      //| System.Windows.Forms.AnchorStyles.Right)));
      //this.iGrid1.DefaultAutoGroupRow.Height = 21;
      //this.iGrid1.DefaultCol.CellStyle = this.iGrid1DefaultCellStyle;
      //this.iGrid1.DefaultCol.ColHdrStyle = this.iGrid1DefaultColHdrStyle;
      //this.iGrid1.DefaultRow.Height = 21;
      //this.iGrid1.DefaultRow.NormalCellHeight = 21;
      //this.iGrid1.Location = new System.Drawing.Point(12, 12);
      this.iGrid1.Name = "iGrid1";
      //this.iGrid1.Size = new System.Drawing.Size(333, 275);
      this.iGrid1.TabIndex = 0;
      iGrid1.Dock = DockStyle.Fill;
      this.Controls.Add(iGrid1);
      this.Load += Form1_Load;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Random myRand = new Random();

      // GRCM.Attach(iGrid1);
      List<MetterGrid> ss = new List<MetterGrid>();
      for (int i = 0; i < 100; i++)
      {
        for (int z = 0; z < 100; z++)
        {
          ss.Add(new MetterGrid()
          {
            Name = Guid.NewGuid().ToString(),
            Num = Guid.NewGuid().ToString(),
            Value = myRand.Next(10000),
            IsTrue = true
          });
        }
         
      }
      iGrid1.BeginUpdate();

      iGrid1.GroupBox.Visible = true;

      iGrid1.Cols.Add("Name", "Name");
      
      iGrid1.Cols.Add("int1", "int1");
      iGrid1.Cols.Add("int2", "int2");
      iGrid1.Cols.Add("int3", "int3");
      iGrid1.Cols.Add("dbl", "dbl");
      
      
      
      iGrid1.Rows.Clear();
      int ii = 0;
      iGrid1.Rows.Count = 7;
      foreach (iGCell cell in iGrid1.Cols["int1"].Cells)
        cell.Value = ss[ii++].Name;//myRand.Next(1, 4);
      ii = 0;
      foreach (iGCell cell in iGrid1.Cols["int2"].Cells)
        cell.Value = ss[ii++].Num;
      ii = 0;
      foreach (iGCell cell in iGrid1.Cols["int3"].Cells)
        cell.Value = ss[ii++].Value;
      ii = 0;
      foreach (iGCell cell in iGrid1.Cols["dbl"].Cells)
        cell.Value = ss[ii++].IsTrue;
      iGrid1.Cols["dbl"].Cells[2].Value = "aaaaa";
      var rr = iGrid1.Rows.Add();
      rr.Cells[2].Value = "qqqqqqqqq";
      //foreach (iGCell cell in iGrid1.Cols["int1"].Cells)
      //  cell.Value = Guid.NewGuid();//myRand.Next(1, 4);
      //foreach (var item in ss)
      //{
      //  iGrid1.Cols["Name"].Cells[0].Value = item.Name;
      //  //iGrid1.Cols["Name"].Cells[ii++].Value = item.Key.ToString();

      //  }

      //cell.Value = Guid.NewGuid();//myRand.Next(1, 4);

      //foreach (iGCell cell in iGrid1.Cols["int1"].Cells)
      //  cell.Value = Guid.NewGuid();//myRand.Next(1, 4);

      //foreach (iGCell cell in iGrid1.Cols["int2"].Cells)
      //  cell.Value = Guid.NewGuid();//myRand.Next(1, 4);

      //foreach (iGCell cell in iGrid1.Cols["int3"].Cells)
      //  cell.Value = Guid.NewGuid();//myRand.Next(1, 4);

      //foreach (iGCell cell in iGrid1.Cols["dbl"].Cells)
      //  cell.Value = Guid.NewGuid();//myRand.Next(1, 4);

      iGrid1.GroupObject.Add("Name");
      iGrid1.GroupObject.Add("int1");

      //iGrid1.GroupObject.Add("int2");
      iGrid1.Group();

      iGrid1.EndUpdate();
    }
  }

  public class MetterGrid {

    public string  Name { get; set; }
    public string Num { get; set; }
    public float Value { get; set; }
    public bool IsTrue { get; set; }
  }
}
