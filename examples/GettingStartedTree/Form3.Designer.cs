
namespace GettingStartedTree
{
  partial class Form3
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
      this.meterTreeView1 = new GettingStartedTree.MeterTreeView();
      this.SuspendLayout();
      // 
      // meterTreeView1
      // 
      this.meterTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.meterTreeView1.Location = new System.Drawing.Point(0, 0);
      this.meterTreeView1.Name = "meterTreeView1";
      this.meterTreeView1.Size = new System.Drawing.Size(1531, 678);
      this.meterTreeView1.TabIndex = 6;
      // 
      // Form3
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1531, 678);
      this.Controls.Add(this.meterTreeView1);
      this.Name = "Form3";
      this.Text = "Form3";
      this.ResumeLayout(false);

    }

    #endregion

    private MeterTreeView meterTreeView1;
  }
}