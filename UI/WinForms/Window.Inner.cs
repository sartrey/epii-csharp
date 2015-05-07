namespace EPII.UI.WinForms
{
    using EPII.Front;
    using System;
    using System.Windows.Forms;

    public partial class Window
    {
        protected bool InnerCanClose()
        {
            var view = View as IWindowView;
            if (view != null)
                return view.CanClose();
            return true;
        }

        protected void InnerCreateWindowCore() 
        {
            _WindowCore = new Form();
            ProcessHandler(true);
        }

        protected void InnerHostView(Control view) 
        {
            WindowCore.ClientSize = view.Size;
            WindowCore.SizeGripStyle = SizeGripStyle.Hide;
            WindowCore.Controls.Add(view);
            view.Dock = DockStyle.Fill;
        }

        protected void InnerDumpView()
        {
            var view = View as IWindowView;
            if (view != null)
                view.OnWindowClosed();
            ProcessHandler(false);
            WindowCore.Controls.Clear();
        }

        protected virtual void InnerApplyStyle()
        {
            WindowCore.FormBorderStyle = _Style.BorderStyle;
            WindowCore.WindowState = _Style.WindowState;
            WindowCore.StartPosition = _Style.StartPosition;
            WindowCore.Text = _Style.Title;
        }


        protected virtual void ProcessHandler(bool bind = true) 
        {
            if (bind) {
                _WindowCore.Load += OnWindowCoreLoad;
                _WindowCore.FormClosing += OnWindowCoreClosing;
                _WindowCore.ResizeBegin += OnWindowCoreResizeBegin;
                _WindowCore.ResizeEnd += OnWindowCoreResizeEnd;
            } else {
                _WindowCore.Load -= OnWindowCoreLoad;
                _WindowCore.FormClosing -= OnWindowCoreClosing;
                _WindowCore.ResizeBegin -= OnWindowCoreResizeBegin;
                _WindowCore.ResizeEnd -= OnWindowCoreResizeEnd;
            }
        }

        private void OnWindowCoreLoad(object sender, EventArgs e)
        {
            var view = View as IWindowView;
            if (view != null)
                view.OnWindowOpened();
        }

        private void OnWindowCoreClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall) {
                if (InnerCanClose()) {
                    InnerDumpView();
                } else {
                    e.Cancel = true;
                }
            }
        }

        private void OnWindowCoreResizeBegin(object sender, EventArgs e)
        {
            if (_Style.SizeLocked) {
                //todo: realize size lock
            }
        }

        private void OnWindowCoreResizeEnd(object sender, EventArgs e) {
            if (_Style.SizeLocked) {
            }
        }
    }
}
