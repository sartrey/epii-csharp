namespace EPII.UI.WinForms
{
    using EPII.Front;
    using System;
    using System.Windows.Forms;

    public class Window : ObjectEx, IWindow, IStyleTarget<WindowStyle>
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
            get 
            {
                if(HasView)
                    return _WindowCore.Controls[0] as IView;
                return null;
            }
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
            _WindowCore.Load += WindowCore_Load;
            _WindowCore.FormClosing += WindowCore_FormClosing;
        }

        private void WindowCore_Load(object sender, EventArgs e) 
        {
            var view = View as IWindowView;
            if (view != null)
                view.OnWindowOpened();
        }

        private void WindowCore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall) {
                e.Cancel = true; //WindowPool need to hide self instead of close
                var view = View as IWindowView;
                if (view != null && !view.CanClose())
                    return;
                Close();
            }
        }

        private void AdaptView()
        {
            var content = View as UserControl;
            _WindowCore.ClientSize = content.Size;
            _WindowCore.StartPosition = FormStartPosition.CenterScreen;
            _WindowCore.SizeGripStyle = SizeGripStyle.Hide;
            content.Dock = DockStyle.Fill;
        }

        public void Open()
        {
            _WindowCore.Show();
        }

        public void Close()
        {
            var view = View as IWindowView;
            if (view != null)
                view.OnWindowClosed();
            _WindowCore.Hide();
            _WindowCore.Controls.Clear();
        }

        public void Apply(WindowStyle style)
        {
            _WindowCore.FormBorderStyle = style.BorderStyle;
            _WindowCore.WindowState = style.WindowState;
            _WindowCore.Text = style.Title;
        }

        protected override void DisposeManaged()
        {
            _WindowCore.FormClosing -= WindowCore_FormClosing;
            _WindowCore.Load -= WindowCore_Load;
            this.Close();
            _WindowCore.Dispose();
        }

        protected override void DisposeNative()
        {
        }
    }
}