namespace EPII.Test.WinForms
{
    partial class FrmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.field = new EPII.UI.WinForms.FieldControl();
            this.SuspendLayout();
            // 
            // field
            // 
            this.field.BackColor = System.Drawing.Color.Transparent;
            this.field.Dock = System.Windows.Forms.DockStyle.Top;
            this.field.Header = "Field";
            this.field.HeaderSpan = 34;
            this.field.Input = null;
            this.field.IsSpanLocked = true;
            this.field.Location = new System.Drawing.Point(0, 0);
            this.field.Name = "field";
            this.field.Note = "Note";
            this.field.NoteSpan = 28;
            this.field.Padding = new System.Windows.Forms.Padding(5);
            this.field.Size = new System.Drawing.Size(284, 33);
            this.field.TabIndex = 0;
            this.field.Text = "Field";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Controls.Add(this.field);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Form";
            this.ResumeLayout(false);

        }

        #endregion

        private UI.WinForms.FieldControl field;
    }
}

