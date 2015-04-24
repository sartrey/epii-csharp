using System;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public abstract class WindowEx : IWindow
    {
        private Form _WindowCore = null;
        private ViewEx _View = null;

        public abstract string Id { get; set; }

        public IView View
        {
            get { return _View; }
            set
            {
                if (_View == value)
                    return;
                var view = value as ViewEx;
                if (view == null)
                    return;
                _WindowCore.Controls.Clear();
                if (_View != null)
                    _View.Dispose();
                _WindowCore.Controls.Add(view.ViewCore);
                _View = view;
            }
        }

        public IWindowStyle Style
        {
            get { throw new NotImplementedException(); }
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Hide()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
