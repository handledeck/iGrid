
namespace GettingStartedTree
{
  partial class MeterTreeView
  {
    /// <summary> 
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором компонентов

    /// <summary> 
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterTreeView));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.treeListView1 = new BrightIdeasSoftware.TreeListView();
      this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvDateTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvMeterFactory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblNameView = new System.Windows.Forms.Label();
      this.btnView = new System.Windows.Forms.Button();
      this.imageList2 = new System.Windows.Forms.ImageList(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.treeListView1, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 504);
      this.tableLayoutPanel1.TabIndex = 0;
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
      this.treeListView1.Location = new System.Drawing.Point(4, 52);
      this.treeListView1.Margin = new System.Windows.Forms.Padding(4);
      this.treeListView1.Name = "treeListView1";
      this.treeListView1.OwnerDraw = true;
      this.treeListView1.ShowGroups = false;
      this.treeListView1.ShowSortIndicators = false;
      this.treeListView1.Size = new System.Drawing.Size(992, 448);
      this.treeListView1.SmallImageList = this.imageList1;
      this.treeListView1.TabIndex = 1;
      this.treeListView1.UseCompatibleStateImageBehavior = false;
      this.treeListView1.UseFilterIndicator = false;
      this.treeListView1.UseHotItem = true;
      this.treeListView1.View = System.Windows.Forms.View.Details;
      this.treeListView1.VirtualMode = true;
      // 
      // olvName
      // 
      this.olvName.AspectName = "name";
      this.olvName.Text = "Имя объекта";
      this.olvName.Width = 316;
      // 
      // olvDateTime
      // 
      this.olvDateTime.AspectName = "date_time";
      this.olvDateTime.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvDateTime.Text = "Дата и время";
      this.olvDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvDateTime.Width = 152;
      // 
      // olvMeterFactory
      // 
      this.olvMeterFactory.AspectName = "meter_factory";
      this.olvMeterFactory.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvMeterFactory.Text = "Номер счетчика";
      this.olvMeterFactory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvMeterFactory.Width = 146;
      // 
      // olvValue
      // 
      this.olvValue.AspectName = "value";
      this.olvValue.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvValue.Text = "Данные(на начало суток)";
      this.olvValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvValue.Width = 290;
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
      this.imageList1.Images.SetKeyName(5, "text_code.png");
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnRefresh);
      this.panel1.Controls.Add(this.lblNameView);
      this.panel1.Controls.Add(this.btnView);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(994, 42);
      this.panel1.TabIndex = 2;
      // 
      // lblNameView
      // 
      this.lblNameView.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.lblNameView.AutoSize = true;
      this.lblNameView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblNameView.Location = new System.Drawing.Point(139, 13);
      this.lblNameView.Name = "lblNameView";
      this.lblNameView.Size = new System.Drawing.Size(47, 18);
      this.lblNameView.TabIndex = 2;
      this.lblNameView.Text = "value";
      // 
      // btnView
      // 
      this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnView.ImageIndex = 0;
      this.btnView.ImageList = this.imageList2;
      this.btnView.Location = new System.Drawing.Point(951, 4);
      this.btnView.Name = "btnView";
      this.btnView.Size = new System.Drawing.Size(40, 31);
      this.btnView.TabIndex = 1;
      this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
      this.btnView.UseVisualStyleBackColor = true;
      this.btnView.Click += new System.EventHandler(this.btnView_Click);
      // 
      // imageList2
      // 
      this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
      this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList2.Images.SetKeyName(0, "text_align_left.png");
      this.imageList2.Images.SetKeyName(1, "text_tree.png");
      this.imageList2.Images.SetKeyName(2, "refresh.png");
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(19, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 18);
      this.label1.TabIndex = 0;
      this.label1.Text = "Имя объекта";
      // 
      // btnRefresh
      // 
      this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRefresh.ImageIndex = 2;
      this.btnRefresh.ImageList = this.imageList2;
      this.btnRefresh.Location = new System.Drawing.Point(906, 4);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(39, 31);
      this.btnRefresh.TabIndex = 3;
      this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // MeterTreeView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "MeterTreeView";
      this.Size = new System.Drawing.Size(1000, 504);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private BrightIdeasSoftware.TreeListView treeListView1;
    private BrightIdeasSoftware.OLVColumn olvName;
    private BrightIdeasSoftware.OLVColumn olvDateTime;
    private BrightIdeasSoftware.OLVColumn olvMeterFactory;
    private BrightIdeasSoftware.OLVColumn olvValue;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnView;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.Label lblNameView;
    private System.Windows.Forms.ImageList imageList2;
    private System.Windows.Forms.Button btnRefresh;
  }
}
