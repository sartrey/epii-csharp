namespace EPII.Test.WinForms
{
    partial class PersonView
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
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtBirth = new System.Windows.Forms.TextBox();
            this.BtnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtName
            // 
            this.TxtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtName.Location = new System.Drawing.Point(0, 0);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(300, 21);
            this.TxtName.TabIndex = 0;
            // 
            // TxtBirth
            // 
            this.TxtBirth.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtBirth.Location = new System.Drawing.Point(0, 21);
            this.TxtBirth.Name = "TxtBirth";
            this.TxtBirth.Size = new System.Drawing.Size(300, 21);
            this.TxtBirth.TabIndex = 1;
            // 
            // BtnNext
            // 
            this.BtnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnNext.Location = new System.Drawing.Point(0, 42);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(300, 48);
            this.BtnNext.TabIndex = 2;
            this.BtnNext.Text = "Next Person";
            this.BtnNext.UseVisualStyleBackColor = true;
            // 
            // PersonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.TxtBirth);
            this.Controls.Add(this.TxtName);
            this.Name = "PersonView";
            this.Size = new System.Drawing.Size(300, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtBirth;
        private System.Windows.Forms.Button BtnNext;

    }
}
