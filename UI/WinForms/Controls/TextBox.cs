namespace EPII.UI.WinForms
{
    using System.ComponentModel;

    public class TextBox : System.Windows.Forms.TextBox
    {
        private string _OldText = null;

        [Category("Extend")]
        public string OldText
        {
            get { return _OldText; }
            set { _OldText = value; }
        }

        [Browsable(false)]
        public bool HasChanged
        {
            get
            {
                if (string.IsNullOrEmpty(Text) &&
                    string.IsNullOrEmpty(OldText))
                    return false;
                return Text != OldText;
            }
        }

        public TextBox()
        {
            this.AutoSize = false;
        }
    }
}
