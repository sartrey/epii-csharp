namespace EPII.Test.WinForms
{
    partial class TestView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Tbx1 = new System.Windows.Forms.TextBox();
            this.Dtp1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // Tbx1
            // 
            this.Tbx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Tbx1.Location = new System.Drawing.Point(0, 0);
            this.Tbx1.Name = "Tbx1";
            this.Tbx1.Size = new System.Drawing.Size(320, 21);
            this.Tbx1.TabIndex = 0;
            // 
            // Dtp1
            // 
            this.Dtp1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Dtp1.Location = new System.Drawing.Point(0, 21);
            this.Dtp1.Name = "Dtp1";
            this.Dtp1.Size = new System.Drawing.Size(320, 21);
            this.Dtp1.TabIndex = 1;
            // 
            // TestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Dtp1);
            this.Controls.Add(this.Tbx1);
            this.Name = "TestView";
            this.Size = new System.Drawing.Size(320, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tbx1;
        private System.Windows.Forms.DateTimePicker Dtp1;

    }
}
