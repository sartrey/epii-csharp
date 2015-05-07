using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public partial class DataCard : ScrollableControl
    {
        protected DataTable _Data = null;

        [Browsable(false)]
        public DataTable Data
        {
            get { return _Data; }
            set
            {
                if (_Data == value)
                    return;
                if (_Data != null)
                    _Data.Dispose();
                _Data = value;
                UpdateData();
            }
        }

        [Browsable(false)]
        public bool HasData 
        {
            get 
            {
                if (_Data == null)
                    return false;
                return _Data.Rows.Count > 0; 
            }
        }

        [Browsable(false)]
        public bool HasChanged 
        {
            get 
            {
                foreach (var control in Controls)
                {
                    var panel = control as FieldPanel;
                    var input = panel.Content as TextBox;
                    if (input.HasChanged)
                        return true;
                }
                return false; 
            }
        }

        public DataCard()
        {
        }

        private void UpdateData()
        {
            if (_Data == null)
                return;
            var controls = new List<Control>();
            var row = HasData ? _Data.Rows[0] : null;
            for (int i = 0; i < _Data.Columns.Count; i++)
            {
                var column = _Data.Columns[i];
                var input = new TextBox();
                if (row != null)
                    input.OldText = input.Text = row[i].ToString();
                var panel = new FieldPanel();
                panel.Height = 28;
                panel.HeaderText = column.ColumnName;
                panel.NoteText = "";
                panel.Padding = new Padding(2);
                panel.Content = input;
                panel.Dock = DockStyle.Top;
                panel.MouseMove += Input_MouseMove;
                controls.Add(panel);
            }
            controls.Reverse();
            Controls.Clear();
            foreach (var control in controls)
                this.Controls.Add(control);
            OnSizeChanged(null);
        }

        public void SetField(string name, string value) 
        {
            foreach (var control in Controls)
            {
                var field = control as FieldPanel;
                if (field.Text == name)
                {
                    var input = field.Content as TextBox;
                    input.Text = value;
                    break;
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            foreach (var control in Controls) {
                var field = control as FieldPanel;
                field.HeaderSpan = (int)(Width * 0.36);
            }
            base.OnSizeChanged(e);
        }

        private void Input_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var control in Controls) {
                var field = control as FieldPanel;
                if (field == sender) {
                    field.BackColor = Color.Orange;
                    field.Focus();
                } else {
                    var input = field.Content as TextBox;
                    if (input.HasChanged)
                        field.BackColor = Color.Red;
                    else
                        field.BackColor = Color.Transparent;
                }
            }
        }
    }
}
