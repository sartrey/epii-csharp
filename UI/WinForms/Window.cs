namespace EPII.UI.WinForms
{
    using EPII.Front;
    using System;
    using System.Windows.Forms;

    public partial class Window : ObjectEx, IWindow, IStyleTarget<WindowStyle>
    {
        private Form _WindowCore = null;
        private WindowStyle _Style = null;

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
                if (HasView)
                    return _WindowCore.Controls[0] as IView;
                return null;
            }
            set
            {
                if (!HasView) {
                    var view = value as UserControl;
                    if (view != null) {
                        _WindowCore.Controls.Add(view);
                        OnViewChanged();
                    }
                }
            }
        }

        public Window()
        {
            _WindowCore = new Form();
            ProcessHandler(true);
        }

        protected virtual void OnViewChanged()
        {
            var content = View as UserControl;
            _WindowCore.ClientSize = content.Size;
            _WindowCore.SizeGripStyle = SizeGripStyle.Hide;
            content.Dock = DockStyle.Fill;
        }

        public void Open()
        {
            if (_Style.IsModal) {
                _WindowCore.ShowDialog();
            } else {
                _WindowCore.Show();
            }
        }

        public void Close()
        {
            var view = View as IWindowView;
            if (view != null) {
                view.OnWindowClosed();
            }
            _WindowCore.Hide();
            _WindowCore.Controls.Clear();
        }

        public void Apply(WindowStyle style)
        {
            _Style = style;
            InnerApplyStyle();
        }

        protected virtual void InnerApplyStyle() 
        {
            _WindowCore.FormBorderStyle = _Style.BorderStyle;
            _WindowCore.WindowState = _Style.WindowState;
            _WindowCore.StartPosition = _Style.StartPosition;
            //todo: try to reset start position cache
            _WindowCore.Text = _Style.Title;
        }

        protected override void DisposeManaged()
        {
            ProcessHandler(false);
            this.Close();
            _WindowCore.Dispose();
        }

        protected override void DisposeNative()
        {
        }
    }
}