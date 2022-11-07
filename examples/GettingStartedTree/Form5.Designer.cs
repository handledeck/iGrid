
namespace GettingStartedTree
{
  partial class Form5
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
      this.ulcTreeView1 = new GettingStartedTree.UlcTreeView();
      this.SuspendLayout();
      // 
      // ulcTreeView1
      // 
      this.ulcTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ulcTreeView1.Location = new System.Drawing.Point(0, 0);
      this.ulcTreeView1.Name = "ulcTreeView1";
      this.ulcTreeView1.Size = new System.Drawing.Size(1154, 635);
      this.ulcTreeView1.TabIndex = 0;
      // 
      // Form5
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1154, 635);
      this.Controls.Add(this.ulcTreeView1);
      this.Name = "Form5";
      this.Text = "Form5";
      this.ResumeLayout(false);

    }

    #endregion

    private UlcTreeView ulcTreeView1;
  }
}