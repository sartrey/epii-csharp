namespace EPII.UI.WinForms
{
    using EPII.Front;
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

        protected Form WindowCore 
        {
            get 
            {
                if (_WindowCore == null) {
                    _WindowCore = new Form();
                    ProcessHandler();
                }
                return _WindowCore; 
            }
        }

        public Window()
        {
        }

        protected virtual void OnViewChanged()
        {
            var content = View as UserControl;
            WindowCore.ClientSize = content.Size;
            WindowCore.SizeGripStyle = SizeGripStyle.Hide;
            content.Dock = DockStyle.Fill;
        }

        public void Open()
        {
            if (_Style.IsModal) {
                WindowCore.ShowDialog();
            } else {
                WindowCore.Show();
            }
        }

        public void Close()
        {
            var view = View as IWindowView;
            if (view != null) {
                view.OnWindowClosed();
            }
            ProcessHandler(false);
            WindowCore.Controls.Clear();
            WindowCore.Close();
        }

        public void Apply(WindowStyle style)
        {
            _Style = style;
            InnerApplyStyle();
        }

        protected virtual void InnerApplyStyle() 
        {
            WindowCore.FormBorderStyle = _Style.BorderStyle;
            WindowCore.WindowState = _Style.WindowState;
            WindowCore.StartPosition = _Style.StartPosition;
            WindowCore.Text = _Style.Title;
        }

        protected override void DisposeManaged()
        {
            Close();
            //do something other
        }

        protected override void DisposeNative()
        {
        }
    }
}