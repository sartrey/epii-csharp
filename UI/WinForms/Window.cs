namespace EPII.UI.WinForms
{
    using EPII.Front;
    using System;
    using System.Windows.Forms;

    public partial class Window : ObjectEx, IWindow, IStyleTarget<WindowStyle>
    {
        private Form _WindowCore = null;
        private WindowStyle _Style = null;

        protected Form WindowCore
        {
            get
            {
                if (_WindowCore == null)
                    InnerCreateWindowCore();
                return _WindowCore;
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
                if (HasView)
                    throw new Exception();
                var view = value as UserControl;
                if (view != null)
                    InnerHostView(view);
            }
        }

        public Window()
        {
        }

        protected virtual void OnViewChanged()
        {
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
            if (InnerCanClose()) {
                InnerDumpView();
                WindowCore.Close();
            }
        }

        public void Apply(WindowStyle style)
        {
            _Style = style;
            InnerApplyStyle();
        }

        protected override void DisposeManaged()
        {
            this.Close();
            //do sth else
        }

        protected override void DisposeNative()
        {
        }
    }
}