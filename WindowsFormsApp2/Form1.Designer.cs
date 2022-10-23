
namespace WindowsFormsApp2
{
  partial class Form1
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

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.iGrid1 = new TenTec.Windows.iGridLib.iGrid();
      this.iGColHdrStyleDesign1 = new TenTec.Windows.iGridLib.iGColHdrStyleDesign();
      this.iGCellStyleDesign1 = new TenTec.Windows.iGridLib.iGCellStyleDesign();
      ((System.ComponentModel.ISupportInitialize)(this.iGrid1)).BeginInit();
      this.SuspendLayout();
      // 
      // iGrid1
      // 
      this.iGrid1.DefaultAutoGroupRow.Height = 20;
      this.iGrid1.DefaultRow.Height = 20;
      this.iGrid1.DefaultRow.NormalCellHeight = 20;
      this.iGrid1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.iGrid1.Header.Height = 22;
      this.iGrid1.Location = new System.Drawing.Point(0, 0);
      this.iGrid1.Name = "iGrid1";
      this.iGrid1.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.iGrid1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private TenTec.Windows.iGridLib.iGrid iGrid1;
    private TenTec.Windows.iGridLib.iGColHdrStyleDesign iGColHdrStyleDesign1;
    private TenTec.Windows.iGridLib.iGCellStyleDesign iGCellStyleDesign1;
  
    private TenTec.Windows.iGridLib.iGCellStyle iGrid1DefaultCellStyle;
    private TenTec.Windows.iGridLib.iGColHdrStyle iGrid1DefaultColHdrStyle;
    private TenTec.Windows.iGridLib.iGCellStyle iGrid1RowTextColCellStyle;
  }
}

