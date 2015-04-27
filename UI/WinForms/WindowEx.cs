using EPII.FEA;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public abstract class WindowEx : IWindow
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
        }
    }
}
