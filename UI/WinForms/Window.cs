namespace EPII.UI.WinForms
{
    using EPII.FEA;
    using System.Windows.Forms;

    public class Window : IWindow
    {
        private Form _WindowCore = null;

        public bool HasView
        {
            get { return _WindowCore.Controls.Count > 0; }
        }

        public IView View
        {
            get { return _WindowCore.Controls[0] as IView; }
            set
            {
                if (HasView)
                    return;
                var view = value as UserControl;
                if (view == null)
                    return;
                _WindowCore.Controls.Add(view);
                AdaptView();
            }
        }

        public Window() 
        {
            _WindowCore = new Form();
        }

        private void AdaptView()
        {
            var content = View as UserControl;
            _WindowCore.ClientSize = content.Size;
            _WindowCore.StartPosition = FormStartPosition.CenterScreen;
            _WindowCore.SizeGripStyle = SizeGripStyle.Hide;
        }

        public void Open()
        {
            _WindowCore.Show();
        }

        public void Close()
        {
            _WindowCore.Hide();
            _WindowCore.Controls.Clear();
        }
    }
}
