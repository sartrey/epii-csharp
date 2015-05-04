using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public class TextField : FieldPanel
    {
        private string _OldText = null;
        private bool _AutoSelect = true;

        public string InputText 
        {
            get { return (Content as TextBox).Text; }
            set { (Content as TextBox).Text = value; }
        }

        public char PasswordText
        {
            get { return (Content as TextBox).PasswordChar; }
            set { (Content as TextBox).PasswordChar = value; }
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

        [Browsable(false)]
        public bool HasChanged 
        {
            get { return (Content as TextBox).Text != _OldText; }
        }

        public TextField()
        {
            var textbox = new TextBox();
            textbox.Multiline = true;
            Content = textbox;
        }

        private void TbxInput_MouseHover(object sender, EventArgs e)
        {
            if (_AutoSelect) 
            {
                var textbox = Content as TextBox;
                textbox.Focus();
                textbox.SelectAll();
            }
        }

        private void TbxInput_DoubleClick(object sender, EventArgs e)
        {
            (Content as TextBox).Text = _OldText;
        }
    }
}
