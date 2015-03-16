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
            get { return _Data.Rows.Count > 0; }
        }

        [Browsable(false)]
        public bool HasChanged 
        {
            get 
            {
                foreach (var control in Controls)
                {
                    var input = control as TextField;
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
                var input = new TextField();
                input.Text = column.ColumnName;
                input.Note = "";
                input.Padding = new Padding(2);
                if (row != null)
                {
                    input.InputText = row[i].ToString();
                    input.OldText = row[i].ToString();
                }
                input.Dock = DockStyle.Top;
                input.MouseMove += Input_MouseMove;
                controls.Add(input);
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
                var field = control as TextField;
                if (field.Text == name)
                {
                    field.InputText = value;
                    break;
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            foreach (var control in Controls) {
                var field = control as TextField;
                field.HeaderSpan = (int)(Width * 0.36);
            }
            base.OnSizeChanged(e);
        }

        private void Input_MouseMove(object sender, MouseEventArgs e)
        {
            foreach(Control control in Controls)
            {
                if (control == sender)
                {
                    control.BackColor = Color.Orange;
                    control.Focus();
                }
                else
                {
                    var input = control as TextField;
                    if(input.HasChanged)
                        control.BackColor = Color.Red;
                    else 
                        control.BackColor = Color.Transparent;
                }
            }
        }
    }
}
