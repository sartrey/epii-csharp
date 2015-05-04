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
            this.browseButton1 = new EPII.UI.WinForms.BrowseButton();
            this.fieldPanel1 = new EPII.UI.WinForms.FieldPanel();
            this.fieldPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseButton1
            // 
            this.browseButton1.BackColor = System.Drawing.Color.LightCyan;
            this.browseButton1.Location = new System.Drawing.Point(75, 0);
            this.browseButton1.Mode = EPII.UI.WinForms.BrowseButton.BrowseMode.OpenFile;
            this.browseButton1.Name = "browseButton1";
            this.browseButton1.Size = new System.Drawing.Size(328, 30);
            this.browseButton1.TabIndex = 1;
            this.browseButton1.Text = "browseButton1";
            this.browseButton1.Tip = "点击这里";
            // 
            // fieldPanel1
            // 
            this.fieldPanel1.BackColor = System.Drawing.Color.Transparent;
            this.fieldPanel1.Content = this.browseButton1;
            this.fieldPanel1.Controls.Add(this.browseButton1);
            this.fieldPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fieldPanel1.HeaderSpan = 72;
            this.fieldPanel1.HeaderText = "fieldPanel1";
            this.fieldPanel1.Location = new System.Drawing.Point(0, 0);
            this.fieldPanel1.Name = "fieldPanel1";
            this.fieldPanel1.NoteSpan = 28;
            this.fieldPanel1.NoteText = "Note";
            this.fieldPanel1.Size = new System.Drawing.Size(434, 30);
            this.fieldPanel1.SpanLocked = false;
            this.fieldPanel1.TabIndex = 0;
            this.fieldPanel1.Text = "fieldPanel1";
            // 
            // FrmControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.fieldPanel1);
            this.Name = "FrmControls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controls";
            this.fieldPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.WinForms.FieldPanel fieldPanel1;
        private UI.WinForms.BrowseButton browseButton1;

    }
}