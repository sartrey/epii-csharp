using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public class TextField : FieldControl
    {
        private string _OldText = null;
        private bool _AutoSelect = true;

        public string InputText 
        {
            get { return (GetContent() as TextBox).Text; }
            set { (GetContent() as TextBox).Text = value; }
        }

        public char PasswordText
        {
            get { return (GetContent() as TextBox).PasswordChar; }
            set { (GetContent() as TextBox).PasswordChar = value; }
        }

        public string OldText 
        {
            get { return _OldText; }
            set { _OldText = value; }
        }

        public bool AutoSelect 
        {
            get { return _AutoSelect; }
            set { _AutoSelect = value; }
        }

        public bool AcceptsReturn 
        {
            get { return (GetContent() as TextBox).AcceptsReturn; }
            set { (GetContent() as TextBox).AcceptsReturn = value; }
        }

        public bool WordWrap 
        {
            get { return (GetContent() as TextBox).WordWrap; }
            set { (GetContent() as TextBox).WordWrap = value; }
        }

        [Browsable(false)]
        public bool HasChanged 
        {
            get { return (GetContent() as TextBox).Text != _OldText; }
        }

        public TextField()
        {
            var textbox = new TextBox();
            textbox.Multiline = true;
            SetContent(textbox);
        }

        private void TbxInput_MouseHover(object sender, EventArgs e)
        {
            if (_AutoSelect) 
            {
                var textbox = GetContent() as TextBox;
                textbox.Focus();
                textbox.SelectAll();
            }
        }

        private void TbxInput_DoubleClick(object sender, EventArgs e)
        {
            (GetContent() as TextBox).Text = _OldText;
        }
    }
}
