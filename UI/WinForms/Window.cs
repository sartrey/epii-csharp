namespace EPII.UI.WinForms
{
    using EPII.Front;
    using System.Windows.Forms;

    public class Window : ObjectEx, IWindow
    {
        private Form _WindowCore = null;

        public bool CanClose
        {
            get 
            {
                var view = View as IWindowView;
                if (view != null) {
                    return view.CanClose();
                }
                return true;
            }
        }

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
            _WindowCore.FormClosing += WindowCore_FormClosing;
        }

        private void WindowCore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall) {
                if (CanClose) {
                    Close();
                }
                e.Cancel = true;
            }
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

        protected override void DisposeManaged()
        {
            _WindowCore.FormClosing -= WindowCore_FormClosing;
            _WindowCore.Controls.Clear();
            _WindowCore.Dispose();
        }

        protected override void DisposeNative()
        {
        }
    }
}
