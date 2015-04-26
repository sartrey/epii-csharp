using EPII.FEA;
using System;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public abstract class WindowEx : IWindow
    {
        private Form _WindowCore = null;
        private ViewEx _View = null;

        public bool HasView
        {
            get { return _View != null; }
        }

        public IView View
        {
            get { return _View; }
            set
            {
                if (_View != null)
                    return;
                var view = value as ViewEx;
                if (view == null)
                    return;
                _WindowCore.Controls.Add(view.ViewCore);
                _View = view;
            }
        }

        public void Open()
        {
            _WindowCore.Show();
        }

        public void Close()
        {
            _WindowCore.Hide();
            _WindowCore.Controls.Clear();
            _View = null;
        }
    }
}
