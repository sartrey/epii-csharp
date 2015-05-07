namespace EPII.UI.WinForms
{
    using EPII.Front;
    using System;
    using System.Windows.Forms;

    public partial class Window
    {
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
                e.Cancel = true; //WindowPool need to hide self instead of close
                var view = View as IWindowView;
                if (view != null && !view.CanClose())
                    return;
                Close();
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
