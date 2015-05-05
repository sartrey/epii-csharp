namespace EPII.Test.WinForms
{
    partial class FrmControls
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
            if (disposing && (components != null)) {
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
            this.Field2 = new EPII.UI.WinForms.FieldPanel();
            this.TextBoxB = new EPII.UI.WinForms.TextBox();
            this.Field1 = new EPII.UI.WinForms.FieldPanel();
            this.BtnBrowseA = new EPII.UI.WinForms.BrowseButton();
            this.Field2.SuspendLayout();
            this.Field1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Field2
            // 
            this.Field2.BackColor = System.Drawing.Color.Transparent;
            this.Field2.Content = this.TextBoxB;
            this.Field2.Controls.Add(this.TextBoxB);
            this.Field2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Field2.HeaderSpan = 34;
            this.Field2.HeaderText = "文本B";
            this.Field2.Location = new System.Drawing.Point(0, 30);
            this.Field2.Name = "Field2";
            this.Field2.NoteSpan = 10;
            this.Field2.NoteText = "*";
            this.Field2.Size = new System.Drawing.Size(434, 30);
            this.Field2.SpanLocked = false;
            this.Field2.TabIndex = 1;
            this.Field2.Text = "文本B";
            // 
            // TextBoxB
            // 
            this.TextBoxB.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TextBoxB.Location = new System.Drawing.Point(37, 0);
            this.TextBoxB.Name = "TextBoxB";
            this.TextBoxB.OldText = null;
            this.TextBoxB.Size = new System.Drawing.Size(384, 30);
            this.TextBoxB.TabIndex = 2;
            // 
            // Field1
            // 
            this.Field1.BackColor = System.Drawing.Color.Transparent;
            this.Field1.Content = this.BtnBrowseA;
            this.Field1.Controls.Add(this.BtnBrowseA);
            this.Field1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Field1.HeaderSpan = 34;
            this.Field1.HeaderText = "文件A";
            this.Field1.Location = new System.Drawing.Point(0, 0);
            this.Field1.Name = "Field1";
            this.Field1.NoteSpan = 10;
            this.Field1.NoteText = "*";
            this.Field1.Size = new System.Drawing.Size(434, 30);
            this.Field1.SpanLocked = false;
            this.Field1.TabIndex = 0;
            this.Field1.Text = "文件A";
            // 
            // BtnBrowseA
            // 
            this.BtnBrowseA.BackColor = System.Drawing.Color.LightCyan;
            this.BtnBrowseA.Location = new System.Drawing.Point(37, 0);
            this.BtnBrowseA.Mode = EPII.UI.WinForms.BrowseButton.BrowseMode.OpenFile;
            this.BtnBrowseA.Name = "BtnBrowseA";
            this.BtnBrowseA.Size = new System.Drawing.Size(384, 30);
            this.BtnBrowseA.TabIndex = 1;
            this.BtnBrowseA.Text = "点击这里浏览文件";
            this.BtnBrowseA.Tip = "点击这里浏览文件";
            // 
            // FrmControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.Field2);
            this.Controls.Add(this.Field1);
            this.Name = "FrmControls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controls";
            this.Field2.ResumeLayout(false);
            this.Field1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.WinForms.FieldPanel Field1;
        private UI.WinForms.BrowseButton BtnBrowseA;
        private UI.WinForms.FieldPanel Field2;
        private UI.WinForms.TextBox TextBoxB;

    }
}