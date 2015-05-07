namespace EPII.UI.WinForms
{
    using EPII.Front;
    using System.Windows.Forms;

    public class WindowStyle : IStyle
    {
        private FormBorderStyle _BorderStyle 
            = FormBorderStyle.Sizable;
        private FormWindowState _WindowState
            = FormWindowState.Normal;
        private FormStartPosition _StartPosition
            = FormStartPosition.CenterScreen;
        private bool _IsModal = false;
        private bool _SizeLocked = false;
        private string _Title = null;

        public FormBorderStyle BorderStyle 
        {
            get { return _BorderStyle; }
            set { _BorderStyle = value; }
        }

        public FormWindowState WindowState 
        {
            get { return _WindowState; }
            set { _WindowState = value; }
        }

        public FormStartPosition StartPosition 
        {
            get { return _StartPosition; }
            set { _StartPosition = value; }
        }

        public string Title 
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public bool SizeLocked 
        {
            get { return _SizeLocked; }
            set { _SizeLocked = value; }
        }

        public bool IsModal 
        {
            get { return _IsModal; }
            set { _IsModal = value; }
        }
    }
}
