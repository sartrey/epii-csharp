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
            this.fieldControl1 = new EPII.UI.WinForms.FieldControl();
            this.browseField1 = new EPII.UI.WinForms.BrowseField();
            this.dateField1 = new EPII.UI.WinForms.DateField();
            this.selectField1 = new EPII.UI.WinForms.SelectField();
            this.textField1 = new EPII.UI.WinForms.TextField();
            this.SuspendLayout();
            // 
            // fieldControl1
            // 
            this.fieldControl1.BackColor = System.Drawing.Color.Transparent;
            this.fieldControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fieldControl1.Header = "fieldControl1";
            this.fieldControl1.HeaderSpan = 84;
            this.fieldControl1.IsSpanLocked = false;
            this.fieldControl1.Location = new System.Drawing.Point(0, 0);
            this.fieldControl1.Name = "fieldControl1";
            this.fieldControl1.Note = "Note";
            this.fieldControl1.NoteSpan = 28;
            this.fieldControl1.Size = new System.Drawing.Size(284, 24);
            this.fieldControl1.TabIndex = 0;
            this.fieldControl1.Text = "fieldControl1";
            // 
            // browseField1
            // 
            this.browseField1.BackColor = System.Drawing.Color.Transparent;
            this.browseField1.Dock = System.Windows.Forms.DockStyle.Top;
            this.browseField1.Header = "browseField1";
            this.browseField1.HeaderSpan = 78;
            this.browseField1.IsSpanLocked = false;
            this.browseField1.Location = new System.Drawing.Point(0, 24);
            this.browseField1.Mode = EPII.UI.WinForms.BrowseField.BrowseMode.OpenFile;
            this.browseField1.Name = "browseField1";
            this.browseField1.Note = "Note";
            this.browseField1.NoteSpan = 28;
            this.browseField1.Size = new System.Drawing.Size(284, 24);
            this.browseField1.TabIndex = 1;
            this.browseField1.Text = "browseField1";
            this.browseField1.Tip = null;
            // 
            // dateField1
            // 
            this.dateField1.BackColor = System.Drawing.Color.Transparent;
            this.dateField1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateField1.Header = "dateField1";
            this.dateField1.HeaderSpan = 65;
            this.dateField1.IsSpanLocked = false;
            this.dateField1.Location = new System.Drawing.Point(0, 48);
            this.dateField1.Name = "dateField1";
            this.dateField1.Note = "Note";
            this.dateField1.NoteSpan = 28;
            this.dateField1.SelectedDate = new System.DateTime(2015, 3, 13, 11, 26, 57, 56);
            this.dateField1.Size = new System.Drawing.Size(284, 24);
            this.dateField1.TabIndex = 2;
            this.dateField1.Text = "dateField1";
            // 
            // selectField1
            // 
            this.selectField1.BackColor = System.Drawing.Color.Transparent;
            this.selectField1.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectField1.Header = "selectField1";
            this.selectField1.HeaderSpan = 78;
            this.selectField1.IsSpanLocked = false;
            this.selectField1.Location = new System.Drawing.Point(0, 72);
            this.selectField1.Name = "selectField1";
            this.selectField1.Note = "Note";
            this.selectField1.NoteSpan = 28;
            this.selectField1.Size = new System.Drawing.Size(284, 24);
            this.selectField1.TabIndex = 3;
            this.selectField1.Text = "selectField1";
            // 
            // textField1
            // 
            this.textField1.AcceptsReturn = false;
            this.textField1.AutoSelect = true;
            this.textField1.BackColor = System.Drawing.Color.Transparent;
            this.textField1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textField1.Header = "textField1";
            this.textField1.HeaderSpan = 65;
            this.textField1.InputText = "";
            this.textField1.IsSpanLocked = false;
            this.textField1.Location = new System.Drawing.Point(0, 96);
            this.textField1.Name = "textField1";
            this.textField1.Note = "Note";
            this.textField1.NoteSpan = 28;
            this.textField1.OldText = null;
            this.textField1.PasswordText = '\0';
            this.textField1.Size = new System.Drawing.Size(284, 24);
            this.textField1.TabIndex = 4;
            this.textField1.Text = "textField1";
            this.textField1.WordWrap = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 159);
            this.Controls.Add(this.textField1);
            this.Controls.Add(this.selectField1);
            this.Controls.Add(this.dateField1);
            this.Controls.Add(this.browseField1);
            this.Controls.Add(this.fieldControl1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Form";
            this.ResumeLayout(false);

        }

        #endregion

        private UI.WinForms.FieldControl fieldControl1;
        private UI.WinForms.BrowseField browseField1;
        private UI.WinForms.DateField dateField1;
        private UI.WinForms.SelectField selectField1;
        private UI.WinForms.TextField textField1;


    }
}

