namespace GettingStartedTree
{
  partial class Form2
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
      this.treeListView1 = new BrightIdeasSoftware.TreeListView();
      this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvDateTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvMeterFactory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.button1 = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // treeListView1
      // 
      this.treeListView1.AllColumns.Add(this.olvName);
      this.treeListView1.AllColumns.Add(this.olvDateTime);
      this.treeListView1.AllColumns.Add(this.olvMeterFactory);
      this.treeListView1.AllColumns.Add(this.olvValue);
      this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvName,
            this.olvDateTime,
            this.olvMeterFactory,
            this.olvValue});
      this.treeListView1.Cursor = System.Windows.Forms.Cursors.Default;
      this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeListView1.FullRowSelect = true;
      this.treeListView1.HideSelection = false;
      this.treeListView1.IncludeColumnHeadersInCopy = true;
      this.treeListView1.IncludeHiddenColumnsInDataTransfer = true;
      this.treeListView1.Location = new System.Drawing.Point(4, 4);
      this.treeListView1.Margin = new System.Windows.Forms.Padding(4);
      this.treeListView1.Name = "treeListView1";
      this.treeListView1.OwnerDraw = true;
      this.treeListView1.ShowGroups = false;
      this.treeListView1.ShowSortIndicators = false;
      this.treeListView1.Size = new System.Drawing.Size(845, 668);
      this.treeListView1.SmallImageList = this.imageList1;
      this.treeListView1.TabIndex = 0;
      this.treeListView1.UseCompatibleStateImageBehavior = false;
      this.treeListView1.UseFilterIndicator = false;
      this.treeListView1.UseHotItem = true;
      this.treeListView1.View = System.Windows.Forms.View.Details;
      this.treeListView1.VirtualMode = true;
      this.treeListView1.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.treeListView1_FormatRow);
      // 
      // olvName
      // 
      this.olvName.AspectName = "name";
      this.olvName.Width = 316;
      // 
      // olvDateTime
      // 
      this.olvDateTime.AspectName = "date_time";
      this.olvDateTime.Width = 142;
      // 
      // olvMeterFactory
      // 
      this.olvMeterFactory.AspectName = "meter_factory";
      this.olvMeterFactory.Width = 138;
      // 
      // olvValue
      // 
      this.olvValue.AspectName = "value";
      this.olvValue.Width = 146;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "ok");
      this.imageList1.Images.SetKeyName(1, "err");
      this.imageList1.Images.SetKeyName(2, "nav_down");
      this.imageList1.Images.SetKeyName(3, "error");
      this.imageList1.Images.SetKeyName(4, "delete2.ico");
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(4, 680);
      this.button1.Margin = new System.Windows.Forms.Padding(4);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(100, 28);
      this.button1.TabIndex = 1;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.treeListView1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.0171F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.982906F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(853, 720);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(853, 720);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Form2";
      this.Text = "Form2";
      ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView1;
        private BrightIdeasSoftware.OLVColumn olvDateTime;
        private BrightIdeasSoftware.OLVColumn olvName;
        private BrightIdeasSoftware.OLVColumn olvMeterFactory;
        private BrightIdeasSoftware.OLVColumn olvValue;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
  }
}