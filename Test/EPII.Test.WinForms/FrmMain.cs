using System.Windows.Forms;

namespace EPII.Test.WinForms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            var textbox = new TextBox();
            textbox.Multiline = true;
            field.Input = textbox;
        }
    }
}
